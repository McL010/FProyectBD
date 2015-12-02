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
    /// Lógica de interacción para Agentes.xaml
    /// </summary>
    public partial class Agentes : Window
    {
        public Agentes()
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
            FProyectBD.DBClass.Agentes agent = new FProyectBD.DBClass.Agentes();
            agent.NAgente = int.Parse(NAgent.Text);
            agent.Nombre = Nombre.Text;
            agent.Apellidos = Ape.Text;
            agent.Cargo = Carg.Text;
            agent.Sueldo = int.Parse(Suel.Text);

            db.Agentes.Add(agent);
            db.SaveChanges();


             
            
            



        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdAgen.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdAgen.Text);
                var agent = db.Agentes
                          .SingleOrDefault(x => x.IdAgente == id);
                // where x.id == id
                //select x;

                if (agent != null)
                {
                    db.Agentes.Remove(agent);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Solo numeros #id"); }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(IdAgen.Text, @"^\d+$") && Regex.IsMatch(NAgent.Text, @"^\d+$") && Regex.IsMatch(Nombre.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Ape.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Carg.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(Suel.Text, @"^\d+$"))
            {
                PrincipalFP db = new PrincipalFP();
                int id = int.Parse(IdAgen.Text);
                var agent = db.Agentes
                          .SingleOrDefault(x => x.IdAgente == id);
                // where x.id == id
                //select x;

                if (agent != null)
                {
                    agent.NAgente = int.Parse(NAgent.Text);
                    agent.Nombre = Nombre.Text;
                    agent.Apellidos = Ape.Text;
                    agent.Cargo = Carg.Text;
                    agent.Sueldo = int.Parse(Suel.Text);
                    db.SaveChanges();
                }
            }
            else { MessageBox.Show("Verifique ingresar los campos correctos"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
           FProyectBD.DBClass.PrincipalFP db = new FProyectBD.DBClass.PrincipalFP();
          
            var temp= from s in db.Agentes
                       select s;
            DataAgente.ItemsSource=temp.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();

            int idAgen = Convert.ToInt32(IdAgen.Text);

            var cons = from s in db.Agentes

                       where s.IdAgente == idAgen
                       select s;
            DataAgente.ItemsSource = cons.ToList();

            var cons1 = db.Agentes.SingleOrDefault(s => s.IdAgente == idAgen);
            NAgent.Text = Convert.ToString(cons1.NAgente);
            Nombre.Text = cons1.Nombre;
            Ape.Text = cons1.Apellidos;
            Carg.Text =cons1.Cargo;
            Suel.Text = Convert.ToString(cons1.Sueldo);
        }
    }
}
