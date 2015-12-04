using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Finalbd;
using Finalbd.Cbd;
using System.Data;

namespace Finalbd
{
    /// <summary>
    /// Lógica de interacción para Sancion.xaml
    /// </summary>
    public partial class Reporte : Window
    {

        private Finalbd.Cbd.Sancion tmpSan = null;
        private List<Finalbd.Cbd.Sancion> carri;
        
        public Reporte()
        {
            InitializeComponent();

            carri = new List<Sancion>();
        }

        private void reportito_Loaded(object sender, RoutedEventArgs e)
        {
            Finalbd.Cbd.Mibd db = new Cbd.Mibd();
            Finalbd.Cbd.Sancion sn = new Cbd.Sancion();
            Finalbd.Cbd.Ciudadano ci = new Cbd.Ciudadano();

            Aut.ItemsSource = db.Auts.ToList();
            Aut.DisplayMemberPath = "Placa";
            Aut.SelectedValuePath = "IDAuto";

            cbCiudadano.ItemsSource = db.Cius.ToList();
            cbCiudadano.DisplayMemberPath = "Nombre";
            cbCiudadano.SelectedValuePath = "IDCiudadano";

            cbAgente.ItemsSource = db.Agens.ToList();
            cbAgente.DisplayMemberPath = "Nombre";
            cbAgente.SelectedValuePath = "IDAgente";

            cbMulta.ItemsSource = db.Mults.ToList();
            cbMulta.DisplayMemberPath = "Descripcion";
            cbMulta.SelectedValuePath = "IDMulta";

            cbreport.ItemsSource = db.Sans.ToList();
            cbreport.DisplayMemberPath = "IdS";
            cbreport.SelectedValuePath = "IdS";


        }


        private void Limpiar() {


            //shopping cart = a new empty list
            carri = new List<Sancion>();
            //Textboxes and labels are set to defaults
            prec.Text = string.Empty;
          
            total.Content = "Total: $0.00";
            //DataGrid items are set to null
            reportito.ItemsSource = null;
            reportito.Items.Refresh();
            //Tmp variable is erased using null
            tmpSan = null;

        
        
        }

                    //we query the array cart and add a new calculated field Subtotal
            
        private void LlenaGrid(){
        
        var datosEn = from s in carri
                            select new{

                                s.IdS,
                                s.IDAuto,
                                s.IDAgente,
                                s.IDCiudadano,
                                s.IDMulta,
                                s.Precio

                              
                            };

            //refresh dataGridview-----------
            reportito.ItemsSource = null;
            reportito.ItemsSource = carri;

            //we add the total with sum(price) and apply a currency formating.
            total.Content = string.Format("Total: {0}", carri.Sum(x => x.Precio).ToString("C"));
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


   
        private void Consultar_Click(object sender, RoutedEventArgs e)
        {


            //Asegurarse de que el carro tenga por lo menos un juego
            if (carri.Count > 0 )
            {
                using (Mibd db = new Mibd())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //Objeto de factura
                          Finalbd.Cbd.Ciudadano fact = new Finalbd.Cbd.Ciudadano();
                            //FProy.BD.Game gm = new FProy.BD.Game();
                            //fact.Fec = DateTime.Now;
                            //fact.idStore = (int)cb2.SelectedValue;
                            //fact.datos = Convert.ToString("Juego: " + cb1.SelectedValue + " Para consola: " + tx1.Text + " Del genero: " + tx2.Text + "Precio: " + tx3.Text);



                            foreach (var reporte in carri)
                            {
                                
                                Finalbd.Cbd.Sancion ci = db.Sans.SingleOrDefault(s => s.IdS == reporte.IdS);
                                fact.Sanciones.Add(ci);
                            }

                            db.Cius.Add(fact);
                            db.SaveChanges();
                            trans.Commit();

                            //MessageBox.Show(string.Format("Transaction #{0}  completada", fact.IDCiudadano), "exitosamente", MessageBoxButton.OK,
                            //    MessageBoxImage.Information);

                        }//try
                        catch
                        {


                            //if an error is produced, we rollback everything
                            trans.Rollback();
                            //We notify the user of the error
                            MessageBox.Show("Error de compra, imposible procesar compra", "Error Fatal", MessageBoxButton.OK,
                                MessageBoxImage.Error);

                        }



                    }//Crear transacción

                }//Crear enlace a bd
            }//Contador de items en carro
        }

        private void meter_Click(object sender, RoutedEventArgs e)
        {



            int Id = Convert.ToInt32(cbreport.SelectedValue);
            Finalbd.Cbd.Mibd db = new Finalbd.Cbd.Mibd();
            Finalbd.Cbd.Sancion sn = db.Sans.SingleOrDefault(x => x.IdS == Id);
            tmpSan = sn;

            carri.RemoveAll(s => s.IdS == tmpSan.IdS);

            if (tmpSan == null)
            {
                //if tmpProduct is empty (Product not found) we exit the procedure
                MessageBox.Show("No hay reportes realizados", "Sin reportes", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                //exit procedure

            }
          

            carri.Add(new Sancion()
            {    IdS = tmpSan.IdS,
                Precio = tmpSan.Precio,
                IDAgente = tmpSan.IDAgente,
                IDAuto = tmpSan.IDAuto,
                IDCiudadano = tmpSan.IDCiudadano,
                IDMulta = tmpSan.IDMulta,
                Fec = tmpSan.Fec
                
            });


            LlenaGrid();
            tmpSan= null;



            
           

            
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Mibd db = new Mibd();
            Sancion sn = new Sancion();

            

            sn.Precio = int.Parse(prec.Text);
            sn.Fec = DateTime.Now;
            sn.IDAuto = Convert.ToInt32(Aut.SelectedValue.ToString());
            sn.IDAgente = Convert.ToInt32(cbAgente.SelectedValue.ToString());
            sn.IDCiudadano = Convert.ToInt32(cbCiudadano.SelectedValue.ToString());
            sn.IDMulta = Convert.ToInt32(cbMulta.SelectedValue.ToString());

            db.Sans.Add(sn);
            db.SaveChanges();
            MessageBox.Show("Se Guardaron Los Cambios Correctamente");

            cbreport.ItemsSource = db.Sans.ToList();
        }

        private void cbat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {




        }

        private void cbAgente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
