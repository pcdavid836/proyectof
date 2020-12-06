using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyectof2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Reinicio : Window
    {
        string pathName = @"d:\personajes.txt";
        public Reinicio()
        {
            InitializeComponent();
            VerificarArchivo();
        }
     
        private void VerificarArchivo()
        {
            try
            {
                if (!File.Exists(pathName))
                {
                    File.Create(pathName).Dispose();
                    EscribirArchivo("1,admin,contraseña,Admin,N/A.");
                }

            }
            catch (Exception ex)
            {

            }
        }

        internal void EscribirArchivo(string mensaje)
        {
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            tuberiaEscritura.WriteLine(mensaje);
            tuberiaEscritura.Close();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string user = textbox1.Text.Trim();
                string password = passwordbox1.Password.Trim();
                if (user != "" && password != "")
                {
                    if (ValidarUsuario(user, password))
                    {
                        Nuevo nuevo = new Nuevo();
                        this.Hide();
                        nuevo.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Datos Incorrectos");
                    }
                }
                else
                {
                    MessageBox.Show( "Ingresa el usuario y la contraseña");
                }

            }
            catch (Exception ex)
            {

            }
        }


        private bool ValidarUsuario(string user, string password)
        {
            bool resultado = false;
            string[] datosUsuario;
            StreamReader tuberiaLectura = File.OpenText(pathName);
            string linea = tuberiaLectura.ReadLine();
            while (linea != null)
            {
                datosUsuario = linea.Split(',');
                if (user == datosUsuario[1] && password == datosUsuario[2])
                {
                    resultado = true;
                    break;
                }
                linea = tuberiaLectura.ReadLine();
            }
            tuberiaLectura.Close();
            return resultado;
        }

       
    }
}
