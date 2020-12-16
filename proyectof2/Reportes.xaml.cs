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
using System.Windows.Shapes;

namespace proyectof2
{
    /// <summary>
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        string pathName = @"d:\registroVentas.txt";
        public Reportes()
        {
            InitializeComponent();
            CargarDatos();
        }
        internal void EscribirArchivoB(string mensaje)
        {
            StreamWriter tuberiaEscritura4 = File.AppendText(pathName);
            tuberiaEscritura4.WriteLine(mensaje);
            tuberiaEscritura4.Close();
        }

        private void CargarDatos()
        {
            Consumidor consumidor;
            List<Consumidor> listaRegistro = new List<Consumidor>();
            string[] datosRegistro;
            if (File.Exists(pathName))
            {
                StreamReader tuberiaLectura4 = File.OpenText(pathName);
                string linea2 = tuberiaLectura4.ReadLine();
                while (linea2 != null)
                {
                    datosRegistro = linea2.Split('/');
                    consumidor = new Consumidor(int.Parse(datosRegistro[0]), int.Parse(datosRegistro[1]), datosRegistro[2], datosRegistro[3], double.Parse(datosRegistro[4]));
                    listaRegistro.Add(consumidor);
                    linea2 = tuberiaLectura4.ReadLine();
                }
                tuberiaLectura4.Close();
                registrogrid.ItemsSource = listaRegistro;
            }
           
        }


        private void bolber_Click(object sender, RoutedEventArgs e)
        {
            Nuevo nuevo = new Nuevo();
            this.Hide();
            nuevo.Show();
            this.Close();
        }

        private void Baccion_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < registrogrid.Items.Count - 1; i++)
            {
                sum += (double.Parse((registrogrid.Columns[4].GetCellContent(registrogrid.Items[i]) as TextBlock).Text));
            }
            sum = Math.Round(sum, 2);
            supertotal.Content = sum;
        }
    }
}
