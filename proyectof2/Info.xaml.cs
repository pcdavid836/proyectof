﻿using System;
using System.Collections.Generic;
using System.IO;
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


namespace proyectof2
{
    /// <summary>
    /// Lógica de interacción para info.xaml
    /// </summary>
    public partial class info : Window
    {
        string pathName = @"d:\personajes.txt";
        public info()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            User user;
            List<User> listaUsuarios = new List<User>();
            string[] datosUsuario;
            if (File.Exists(pathName))
            {
                StreamReader tuberiaLectura = File.OpenText(pathName);
                string linea = tuberiaLectura.ReadLine();
                while (linea != null)
                {
                    datosUsuario = linea.Split(',');
                    user = new User(datosUsuario[0], datosUsuario[3], datosUsuario[4], datosUsuario[1], datosUsuario[2]);
                    listaUsuarios.Add(user);
                    linea = tuberiaLectura.ReadLine();
                }
                tuberiaLectura.Close();
                datagrid1.ItemsSource = listaUsuarios;
            }

        }
        private void B1_Click(object sender, RoutedEventArgs e)
        {
            string nombreP = textbox12.Text;
            string clase = Convert.ToString(DateTime.Today.ToString("dd-MM-yyyy"));
            string usuario = textbox10.Text;
            string password = textbox11.Text;
            string id = textbox13.Text;
            Reinicio reinicio = new Reinicio();
            reinicio.EscribirArchivo(id+","+usuario+","+password+","+nombreP+","+clase);
            MessageBox.Show("Usuario creado con exito");
            CargarUsuarios();

        }

        private void bolber2_Click(object sender, RoutedEventArgs e)
        {
            Nuevo nuevo = new Nuevo();
            this.Hide();
            nuevo.Show();
            this.Close();
        }
    }
  }

