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
    /// Lógica de interacción para Ciudadano.xaml
    /// </summary>
    public partial class Ciudadano : Window
    {
        public Ciudadano()
        {
            InitializeComponent();
        }

        private void Alta_Click(object sender, RoutedEventArgs e)
        {

            Mibd db = new Mibd();
            Finalbd.Cbd.Ciudadano ciu = new Finalbd.Cbd.Ciudadano();
            ciu.Nombre = NombreC.Text;
            ciu.sexo = Sexo.Text;



            db.Cius.Add(ciu);
            db.SaveChanges();
        }

        private void Baja_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdC1.Text, @"^\d+$"))
            {
                Mibd db = new Mibd();
                int id = int.Parse(IdC1.Text);
                var ciu = db.Cius
                          .SingleOrDefault(x => x.IDCiudadano == id);
                // where x.id == id
                //select x;

                if (ciu != null)
                {
                    db.Cius.Remove(ciu);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(Itp.Text, @"^\d+$") && Regex.IsMatch(Ts.Text, @"^\d+$") && Regex.IsMatch(Sanc.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Imp.Text, @"^\d+$"))
            //{
                Mibd  db = new Mibd();
                int id = int.Parse(IdC1.Text);
                var tisa = db.Cius
                          .SingleOrDefault(x => x.IDCiudadano == id);
                // where x.id == id
                //select x;

                if (tisa != null)
                {
                    tisa.Nombre = NombreC.Text;
                    tisa.sexo = Sexo.Text;
                    db.SaveChanges();
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mibd db = new Mibd();

            int id = Convert.ToInt32(IdC1.Text);

            var cons = from s in db.Cius

                       where s.IDCiudadano == id
                       select s;
            DataCiu.ItemsSource = cons.ToList();

            var cons1 = db.Cius.SingleOrDefault(s => s.IDCiudadano == id);
            NombreC.Text = cons1.Nombre;
            Sexo.Text = cons1.sexo;
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Finalbd.Cbd.Mibd db = new Finalbd.Cbd.Mibd();

            var temp = from s in db.Cius
                       select s;
            DataCiu.ItemsSource = temp.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }
    }
}
