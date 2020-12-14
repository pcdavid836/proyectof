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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        string pathName = @"d:\productos.txt";
        string pathNameVenta = @"d:\vender.txt";
        public Ventas()
        {
            InitializeComponent();
            CargarProductos();
            CargarProductos2();

        }

        internal void EscribirArchivoB2(string mensaje)
        {
            StreamWriter tuberiaEscritura2 = File.AppendText(pathName);
            StreamWriter tuberiaEscritura3 = File.AppendText(pathNameVenta);
            tuberiaEscritura2.WriteLine(mensaje);
            tuberiaEscritura3.WriteLine(mensaje);
            tuberiaEscritura2.Close();
            tuberiaEscritura3.Close();
        }
        


        private void CargarProductos()
        {
            string shortDate = DateTime.Now.ToString("yyyy-MM-dd");
            fecha.Content = shortDate;
            Items items;
            List<Items> listaProductos = new List<Items>();
            string[] datosProductos;
            if (File.Exists(pathName))
            {
                StreamReader tuberiaLectura2 = File.OpenText(pathName);
                string linea2 = tuberiaLectura2.ReadLine();
                while (linea2 != null)
                {
                    datosProductos = linea2.Split('/');
                    items = new Items(int.Parse(datosProductos[0]), datosProductos[1], int.Parse(datosProductos[2]), double.Parse(datosProductos[3]), double.Parse(datosProductos[4]), int.Parse(datosProductos[5]));
                    listaProductos.Add(items);
                    linea2 = tuberiaLectura2.ReadLine();
                }
                tuberiaLectura2.Close();
               listgrid.ItemsSource = listaProductos;
            }

        }

        private void CargarProductos2()
        {
            Venderte venderte;
            List<Items> listaVenderte = new List<Items>();
            string[] datosVenderte;
            if (File.Exists(pathNameVenta))
            {
                StreamReader tuberiaLectura3 = File.OpenText(pathName);
                string linea3 = tuberiaLectura3.ReadLine();
                while (linea3 != null)
                {
                    datosVenderte = linea3.Split('/');
                    venderte = new Venderte(int.Parse(datosVenderte[0]), datosVenderte[1],int.Parse(datosVenderte[2]), double.Parse(datosVenderte[3]), int.Parse(datosVenderte[4]), int.Parse(datosVenderte[5]));
                    //listaVenderte.Add(venderte);
                    linea3 = tuberiaLectura3.ReadLine();
                }
                tuberiaLectura3.Close();
                addgrid1.ItemsSource = listaVenderte;
            }
        }

        private void bolber8_Click(object sender, RoutedEventArgs e)
        {
            Nuevo nuevo = new Nuevo();
            this.Hide();
            nuevo.Show();
            this.Close();
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del producto:");
                string nombrev = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del producto:");
                string codigoBarrav = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el codigo de barra:");
                string preciocv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de compra del producto:");
                string preciovv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de venta del producto:");
                string cantidadv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad del producto:");
                int externo2;


                if (nombrePv(nombrev))
                {
                    if (Confirmarp2(cantidadv))
                    {
                        externo2 = int.Parse(cantidadv);
                        if (ValidarRangop2(externo2))
                        {
                            Productos productos = new Productos();
                            productos.EscribirArchivoB(idv + "/" + nombrev + "/" + codigoBarrav + "/" + preciocv + "/" + preciovv + "/" + cantidadv);
                            MessageBox.Show("Producto agregado a la lista.");
                            CargarProductos2();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, La cantidad de un producto y el nombre no pueden estar vacias o no tener ningun valor..\nExcepcion: " + ex.Message);
                Console.WriteLine("Excepcion: " + ex);
            }
        }

        private bool ValidarRangop2(int externo2)
        {
            bool respuesta = true;
            if (externo2 < 1)
            {
                MessageBox.Show("La cantidad del producto debe ser mayor a 0.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool Confirmarp2(string cantidadv)
        {
            bool respuesta = true;
            if (cantidadv == "")
            {
                MessageBox.Show("La cantidad solo puede ser definida por números!", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool nombrePv(string nombrev)
        {
            bool respuesta = true;
            if (nombrev == "")
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
