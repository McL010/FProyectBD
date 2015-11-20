﻿using FProyectBD.DBClass;
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
    }
}
