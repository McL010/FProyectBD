using FProyectBD.DBClass;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para Tipo_de_Sancion.xaml
    /// </summary>
    public partial class Tipo_de_Sancion : Window
    {
        public Tipo_de_Sancion()
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
            FProyectBD.DBClass.TipoSancion tisa = new FProyectBD.DBClass.TipoSancion();
            tisa.TipoS = int.Parse(Ts.Text);
            tisa.Sancion = Sanc.Text;
            tisa.Importe = int.Parse(Imp.Text);
            

            db.TipoSancion.Add(tisa);
            db.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(Itp.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(Itp.Text);
                var tisa = db.TipoSancion
                          .SingleOrDefault(x => x.IdT == id);
                // where x.id == id
                //select x;

                if (tisa != null)
                {
                    db.TipoSancion.Remove(tisa);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(Itp.Text, @"^\d+$") && Regex.IsMatch(Ts.Text, @"^\d+$") && Regex.IsMatch(Sanc.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Imp.Text, @"^\d+$"))
            //{
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(Itp.Text);
                var tisa = db.TipoSancion
                          .SingleOrDefault(x => x.IdT == id);
                // where x.id == id
                //select x;

                if (tisa != null)
                {
                    tisa.TipoS = int.Parse(Ts.Text);
                    tisa.Sancion = Sanc.Text;
                    tisa.Importe = int.Parse(Imp.Text);
                    db.SaveChanges();
                }
            //}
            //else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            FProyectBD.DBClass.PrincipalFP db = new FProyectBD.DBClass.PrincipalFP();

            var temp = from s in db.TipoSancion
                       select s;
            DataTipSan.ItemsSource = temp.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();

            int idTS = Convert.ToInt32(Itp.Text);

            var cons = from s in db.TipoSancion

                       where s.IdT == idTS
                       select s;
            DataTipSan.ItemsSource = cons.ToList();

            var cons1 = db.TipoSancion.SingleOrDefault(s => s.IdT == idTS);
            Ts.Text = Convert.ToString(cons1.TipoS);
            Sanc.Text = cons1.Sancion;
            Imp.Text = Convert.ToString(cons1.Importe);
            
        }
    }
  }