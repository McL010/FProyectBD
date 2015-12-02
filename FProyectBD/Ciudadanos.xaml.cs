using FProyectBD.DBClass;
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
using System.Text.RegularExpressions;

namespace FProyectBD
{
    /// <summary>
    /// Lógica de interacción para Ciudadanos.xaml
    /// </summary>
    public partial class Ciudadanos : Window
    {
        public Ciudadanos()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();

            FProyectBD.DBClass.Ciudadanos ciu = new FProyectBD.DBClass.Ciudadanos();
            ciu.IdCV= (IdM.Text);
            ciu.Nombre = Nom.Text;
            ciu.Direccion = Direc1.Text;
            ciu.Ciudad = Ciu.Text;
            ciu.Telefono = Tel.Text;

            db.Ciudadanos.Add(ciu);
            db.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdC.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdC.Text);
                var ciu = db.Ciudadanos
                          .SingleOrDefault(x => x.IdC == id);
                // where x.id == id
                //select x;

                if (ciu != null)
                {
                    db.Ciudadanos.Remove(ciu);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(IdC.Text, @"^\d+$") && Regex.IsMatch(IdM.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Nom.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Direc1.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Ciu.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Tel.Text, @"^[a-zA-Z]+$"))
            //{
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdC.Text);
                var ciu = db.Ciudadanos
                          .SingleOrDefault(x => x.IdC== id);
                // where x.id == id
                //select x;

                if (ciu != null)
                {
                    ciu.IdCV = (IdM.Text);
                    ciu.Nombre = Nom.Text;
                    ciu.Direccion = Direc1.Text;
                    ciu.Ciudad = Ciu.Text;
                    ciu.Telefono = Tel.Text;
                    db.SaveChanges();
                }
            //}
            //else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FProyectBD.DBClass.PrincipalFP db = new FProyectBD.DBClass.PrincipalFP();

            var temp = from s in db.Ciudadanos
                       select s;
            DataCiu.ItemsSource = temp.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();

            int idCi = Convert.ToInt32(IdC.Text);

            var cons = from s in db.Ciudadanos

                       where s.IdC == idCi
                       select s;
            DataCiu.ItemsSource = cons.ToList();

            var cons1 = db.Ciudadanos.SingleOrDefault(s => s.IdC == idCi);
            IdM.Text = cons1.IdCV;
            Nom.Text = cons1.Nombre;
            Direc1.Text = cons1.Direccion;
            Ciu.Text = cons1.Ciudad;
            Tel.Text = cons1.Telefono;


            
        }
    }
}
