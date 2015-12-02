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
using FProyectBD.DBClass;

namespace FProyectBD
{
    /// <summary>
    /// Lógica de interacción para Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        //Temp varible to hold the last found item
        private Sanciones tempSan = null;
        //Array of Cart items 
        private List<Sanciones> Query; 
        public Reporte()
        {
            InitializeComponent();
            Query = new List<Sanciones>();

        }

        private void DataR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataR_Loaded(object sender, RoutedEventArgs e)
        {

            PrincipalFP db = new PrincipalFP();
            Ciudadanos st = new Ciudadanos();
            TipoSancion ab = new TipoSancion();

            Cd1.ItemsSource = db.Ciudadanos.ToList();
            Cd1.DisplayMemberPath = "Nombre";
            Cd1.SelectedValuePath = "IdC";

            San1.ItemsSource = db.TipoSancion.ToList();
            San1.DisplayMemberPath = "Sancion";
            San1.SelectedValuePath = "IdT";

            
        }
        private void Limpiar()
        {
            Query = new List<Sanciones>();
            Matr.Text = string.Empty;

            Cd1.SelectedIndex = 0;
            San1.SelectedIndex = 0;

            DataR.ItemsSource = null;
            DataR.Items.Refresh();
            tempSan = null;

        }



        private void clean_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void bus_Click(object sender, RoutedEventArgs e)
        {
            PrincipalFP db = new PrincipalFP();
            //parse the product code as int from the TextBox
            int id = int.Parse(Matr.Text);
            //We query the database for the product
           FProyectBD.DBClass.Sanciones  m= db.Sanciones.SingleOrDefault(x => x.IdS == id);

            if (m != null) //if product was found
            {
                //store in a temp variable (if user clicks on add we will need this for the Array)
                tempSan= m;
                //We display the product information on a label 
                Total.Content = string.Format("ID: {0}, Name: {1}, Price: {2}, InStock (Qty): {3}", p.Id, p.Name, p.Price, p.Qty);
            }
        }
    }
}
