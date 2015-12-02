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
    /// Lógica de interacción para Multa.xaml
    /// </summary>
    public partial class Multa : Window
    {
        public Multa()
        {
            InitializeComponent();
        }

        private void Alta_Click(object sender, RoutedEventArgs e)
        {
            Mibd  db= new Mibd();
            Finalbd.Cbd.Multa mul = new Finalbd.Cbd.Multa();
            mul.Descripcion = Desc.Text;
            


            db.Mults.Add(mul);
            db.SaveChanges();
        }

        private void Baja_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdM.Text, @"^\d+$"))
            {
                Mibd db = new Mibd();
                int id = int.Parse(IdM.Text);
                var mul = db.Mults
                          .SingleOrDefault(x => x.IDMulta == id);
                // where x.id == id
                //select x;

                if (mul != null)
                {
                    db.Mults.Remove(mul);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
             //if (Regex.IsMatch(Itp.Text, @"^\d+$") && Regex.IsMatch(Ts.Text, @"^\d+$") && Regex.IsMatch(Sanc.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Imp.Text, @"^\d+$"))
            //{
                Mibd  db = new Mibd();
                int id = int.Parse(IdM.Text);
                var tisa = db.Mults
                          .SingleOrDefault(x => x.IDMulta == id);
                // where x.id == id
                //select x;

                if (tisa != null)
                {
                    tisa.Descripcion= Desc.Text;
                   
                    db.SaveChanges();
                }
            //}
            //else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Mibd db = new Mibd();

            int id = Convert.ToInt32(IdM.Text);

            var cons = from s in db.Mults

                       where s.IDMulta == id
                       select s;
            DataM.ItemsSource = cons.ToList();

            var cons1 = db.Mults.SingleOrDefault(s => s.IDMulta == id);
            Desc.Text = cons1.Descripcion;
            
            
        }

        private void Con_Click(object sender, RoutedEventArgs e)
        {
            Finalbd.Cbd.Mibd db = new Finalbd.Cbd.Mibd();

            var temp = from s in db.Mults
                       select s;
            DataM.ItemsSource = temp.ToList();
        }
        
        }
    }

