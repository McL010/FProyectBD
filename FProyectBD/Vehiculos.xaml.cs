using System.Text.RegularExpressions;
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

namespace FProyectBD
{
    /// <summary>
    /// Lógica de interacción para Vehiculos.xaml
    /// </summary>
    public partial class Vehiculos : Window
    {
        public Vehiculos()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            FProyectBD.DBClass.Vehiculos veh = new FProyectBD.DBClass.Vehiculos();
            veh.Matricula = Mat.Text;
            veh.IdC = int.Parse(Idc.Text);
            veh.Marca = Marc.Text;
            veh.Modelo = Mod.Text;
            veh.Tipo = Tip.Text;

            db.Vehiculos.Add(veh);
            db.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Idv.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(Idv.Text);
                var veh = db.Vehiculos
                          .SingleOrDefault(x => x.IdV == id);
                // where x.id == id
                //select x;

                if (veh != null)
                {
                    db.Vehiculos.Remove(veh);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(Idv.Text, @"^\d+$") && Regex.IsMatch(Mat.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Idc.Text, @"^\d+$") && Regex.IsMatch(Marc.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Mod.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Tip.Text, @"^[a-zA-Z]+$"))
            //{
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(Idv.Text);
                var veh = db.Vehiculos
                          .SingleOrDefault(x => x.IdV == id);
                // where x.id == id
                //select x;

                if (veh != null)
                {
                    veh.Matricula = Mat.Text;
                    veh.IdC = int.Parse(Idc.Text);
                    veh.Marca = Marc.Text;
                    veh.Modelo = Mod.Text;
                    veh.Tipo = Tip.Text;
                    db.SaveChanges();
                }
            //}
            //else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FProyectBD.DBClass.PrincipalFP db = new FProyectBD.DBClass.PrincipalFP();

            var temp = from s in db.Vehiculos
                       select s;
            DataVeh.ItemsSource = temp.ToList();
        }
    }
}
