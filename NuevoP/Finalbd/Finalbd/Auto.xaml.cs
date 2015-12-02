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
    /// Lógica de interacción para Auto.xaml
    /// </summary>
    public partial class Auto : Window
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Mibd db = new Mibd();
            Finalbd.Cbd.Auto aut = new Finalbd.Cbd.Auto();
            aut.Marca = Mar.Text;
            aut.Modelo = Mod.Text;
            aut.Placa = Plac.Text;



            db.Auts.Add(aut);
            db.SaveChanges();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdAU.Text, @"^\d+$"))
            {
                Mibd db = new Mibd();
                int id = int.Parse(IdAU.Text);
                var mul = db.Auts
                          .SingleOrDefault(x => x.IDAuto == id);
                // where x.id == id
                //select x;

                if (mul != null)
                {
                    db.Auts.Remove(mul);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(Itp.Text, @"^\d+$") && Regex.IsMatch(Ts.Text, @"^\d+$") && Regex.IsMatch(Sanc.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Imp.Text, @"^\d+$"))
            //{
            Mibd db = new Mibd();
            int id = int.Parse(IdAU.Text);
            var tisa = db.Auts
                      .SingleOrDefault(x => x.IDAuto == id);
            // where x.id == id
            //select x;

            if (tisa != null)
            {
                tisa.Marca = Mar.Text;
                tisa.Modelo = Mod.Text;
                tisa.Placa = Plac.Text;

                db.SaveChanges();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Mibd db = new Mibd();

            int id = Convert.ToInt32(IdAU.Text);

            var cons = from s in db.Auts

                       where s.IDAuto == id
                       select s;

            DataAu.ItemsSource = db.Auts.ToList();

            var cons1 = db.Auts.SingleOrDefault(s => s.IDAuto == id);
            Mar.Text = cons1.Marca;
            Mod.Text = cons1.Modelo;
            Plac.Text = cons1.Placa;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Finalbd.Cbd.Mibd db = new Finalbd.Cbd.Mibd();

            var temp = from s in db.Auts
                       select s;
            DataAu.ItemsSource = temp.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }
    }
}
