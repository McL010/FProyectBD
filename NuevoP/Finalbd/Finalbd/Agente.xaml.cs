using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Finalbd.Cbd;
using System.Text.RegularExpressions;

namespace Finalbd
{
    /// <summary>
    /// Lógica de interacción para Agente.xaml
    /// </summary>
    public partial class Agente : Window
    {
        public Agente()
        {
            InitializeComponent();
        }
        private void CleanUp() {
            IdA.Text = String.Empty;
            NombreA.Text = String.Empty;
            Dep.Text = String.Empty;
        
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdA.Text, @"^\d+$") && Regex.IsMatch(NombreA.Text.Trim(), @"^[a-zA-Z\s]+$") && Regex.IsMatch(Dep.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                Mibd db = new Mibd();
                Finalbd.Cbd.Agente agen = new Finalbd.Cbd.Agente();
                agen.Nombre = NombreA.Text;
                agen.Departamento = Dep.Text;



                db.Agens.Add(agen);
                db.SaveChanges();
                MessageBox.Show("Se Dieron de alta Los Datos Correctamente");
                CleanUp();
                
            }
            else { MessageBox.Show("Ingrese Solo Numero, solo Letras"); 
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdA.Text.Trim(), @"^\d+$") && Regex.IsMatch(NombreA.Text.Trim(), @"^[a-zA-Z\s]+$") && Regex.IsMatch(Dep.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
                Mibd db = new Mibd();
                int id = int.Parse(IdA.Text);
                var agen = db.Agens
                          .SingleOrDefault(x => x.IDAgente == id);
                // where x.id == id
                //select x;

                if (agen != null)
                {
                    db.Agens.Remove(agen);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdA.Text.Trim (), @"^\d+$") && Regex.IsMatch(NombreA.Text.Trim(), @"^[a-zA-Z\s]+$") && Regex.IsMatch(Dep.Text.Trim(), @"^[a-zA-Z\s]+$"))
            {
            Mibd db = new Mibd();
            int id = int.Parse(IdA.Text);
            var agen = db.Agens
                      .SingleOrDefault(x => x.IDAgente == id);
            // where x.id == id
            //select x;

            if (agen != null)
            {
                agen.Nombre = NombreA.Text;
                agen.Departamento = Dep.Text;


                db.SaveChanges();
            }
            }
            else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdA.Text.Trim(), @"^\d+$"))
            {
                Mibd db = new Mibd();

                int id = Convert.ToInt32(IdA.Text);


                var cons = from s in db.Agens

                           where s.IDAgente == id
                           select s;
                DataA.ItemsSource = cons.ToList();

                var cons1 = db.Agens.SingleOrDefault(s => s.IDAgente == id);
                NombreA.Text = cons1.Nombre;
                Dep.Text = cons1.Departamento;


            }
            else { MessageBox.Show("Ingrese solo numeros positivos"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Finalbd.Cbd.Mibd db = new Finalbd.Cbd.Mibd();

            var temp = from s in db.Agens
                       select s;
            DataA.ItemsSource = temp.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }
    }
}
