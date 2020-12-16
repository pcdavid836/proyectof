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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {

        string pathName = @"d:\productos.txt";
        string pathNameAuxiliar = @"d:\auxiliar.txt";
        public Productos()
        {
            InitializeComponent();
            CargarProductos();
        }

        internal void EscribirArchivoB(string mensaje)
        {
            StreamWriter tuberiaEscritura = File.AppendText(pathName);
            tuberiaEscritura.WriteLine(mensaje);
            tuberiaEscritura.Close();
        }

        private void CargarProductos()
        {
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
                datagridp.ItemsSource = listaProductos;
            }


        }

        private void bañadir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del producto:");
                string nombreProducto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del producto:");
                string codigoBarra = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el codigo de barra:");
                string precioC = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de compra del producto:");
                string precioV = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de venta del producto:");
                string cantidad = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad del producto:");
                int externo;
                double precioCD = Convert.ToDouble(precioC);
                precioCD = Math.Round(precioCD, 2);
                double precioVD = Convert.ToDouble(precioV);
                precioVD = Math.Round(precioVD, 2);


                if (nombreP(nombreProducto))
                {
                    if (Confirmarp(cantidad))
                    {
                        externo = int.Parse(cantidad);
                        if (ValidarRangop(externo))
                        {
                            Productos productos = new Productos();
                            productos.EscribirArchivoB(id + "/" + nombreProducto + "/" + codigoBarra + "/" + precioCD + "/" + precioVD + "/" + cantidad);
                            MessageBox.Show("Producto agregado con exito");
                            CargarProductos();
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

        private bool nombreP(string nombreProducto)
        {
            bool respuesta = true;
            if (nombreProducto == "")
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool ValidarRangop(int cantidad)
        {
            bool respuesta = true;
            if (cantidad < 1)
            {
                MessageBox.Show("La cantidad del producto debe ser mayor a 0.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool Confirmarp(object cantidad)
        {
            bool respuesta = true;
            if (cantidad == "")
            {
                MessageBox.Show("La cantidad solo puede ser definida por números!", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private void beliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ciEliminar = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del producto que desea eliminar:");
                if (ciEliminar != "")
                {
                    string linea;
                    string[] datosProductos;
                    char separador = '/';
                    bool eliminado = false;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                    linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {
                        datosProductos = linea.Split(separador);
                        if (ciEliminar != datosProductos[0])
                        {
                            tuberiaEscritura.WriteLine(linea);
                        }
                        else
                        {
                            eliminado = true;
                        }
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaEscritura.Close();
                    tuberiaLectura.Close();
                    File.Delete(pathName);
                    File.Move(pathNameAuxiliar, pathName);
                    File.Delete(pathNameAuxiliar);
                    if (eliminado)
                    {
                        MessageBox.Show("El producto se ha eliminado con exito.");
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe.");
                    }
                    ciEliminar = "";
                }
                else
                {
                    MessageBox.Show("No se pemite un espacio vacio.");
                }

            }
            catch (Exception)
            {

            }
        }

        private void bolber_Click(object sender, RoutedEventArgs e)
        {
            Nuevo nuevo = new Nuevo();
            this.Hide();
            nuevo.Show();
            this.Close();
        }

        private void bmodificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idModificar = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del producto que desea modificar:");
                if (idModificar != "")
                {
                    string linea;
                    string[] datosProducto;
                    char separador = '/';
                    bool modificar = false;
                    StreamReader tuberiaLectura = File.OpenText(pathName);
                    StreamWriter tuberiaEscritura = File.AppendText(pathNameAuxiliar);
                    linea = tuberiaLectura.ReadLine();
                    while (linea != null)
                    {
                        datosProducto = linea.Split(separador);
                        if (idModificar != datosProducto[0])
                        {
                            tuberiaEscritura.WriteLine(linea);
                        }
                        else
                        {
                            modificar = true;
                            string productoModificado = txbProd.Text;
                            tuberiaEscritura.WriteLine(idModificar + "/" + productoModificado);
                        }
                        linea = tuberiaLectura.ReadLine();
                    }
                    tuberiaEscritura.Close();
                    tuberiaLectura.Close();


                    File.Delete(pathName);
                    File.Move(pathNameAuxiliar, pathName);
                    File.Delete(pathNameAuxiliar);
                    if (modificar)
                    {
                        MessageBox.Show("El producto se modifico con exito");
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("El producto no existe");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un ID valido");
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
