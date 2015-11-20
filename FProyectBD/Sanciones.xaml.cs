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
    /// Lógica de interacción para Sanciones.xaml
    /// </summary>
    public partial class Sanciones : Window
    {
        public Sanciones()
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
            FProyectBD.DBClass.Sanciones sanc = new FProyectBD.DBClass.Sanciones();
            sanc.Fecha = Fec.Text;
            sanc.Lugar = Lug.Text;
            sanc.TipoS = int.Parse(TipS.Text);
            sanc.NAgente= int.Parse(NAgente.Text);
            sanc.Matricula = Mat.Text;

            db.Sanciones.Add(sanc);
            db.SaveChanges();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdS.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdS.Text);
                var sanc = db.Sanciones
                          .SingleOrDefault(x => x.IdS == id);
                // where x.id == id
                //select x;

                if (sanc != null)
                {
                    db.Sanciones.Remove(sanc);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(IdS.Text, @"^\d+$") && Regex.IsMatch(Fec.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Lug.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(TipS.Text, @"^\d+$") && Regex.IsMatch(NAgente.Text, @"^\d+$") && Regex.IsMatch(Mat.Text, @"^[a-zA-Z]+$"))
            //{
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdS.Text);
                var sanc = db.Sanciones
                          .SingleOrDefault(x => x.IdS == id);
                // where x.id == id
                //select x;

                if (sanc != null)
                {
                    sanc.Fecha = Fec.Text;
                    sanc.Lugar = Lug.Text;
                    sanc.TipoS = int.Parse(TipS.Text);
                    sanc.NAgente = int.Parse(NAgente.Text);
                    sanc.Matricula = Mat.Text;
                    db.SaveChanges();
                }
            //}
            //else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }
    }
}
