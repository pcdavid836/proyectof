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
        string pathName2 = @"d:\registroVentas.txt";
        public Ventas()
        {
            InitializeComponent();
            CargarProductos();

        }

        internal void EscribirArchivoB2(string mensaje2, string mensaje3)
        {
            
            StreamWriter tuberiaEscritura3 = File.AppendText(pathName);
           
            tuberiaEscritura3.WriteLine(mensaje3);
     
            tuberiaEscritura3.Close();
        
        }
        


        private void CargarProductos()
        {
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "Id", Binding = new Binding("Id") });
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "Nombre", Binding = new Binding("Nombre") });
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "CodigoProducto", Binding = new Binding("CodigoProducto") });
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "PrecioC", Binding = new Binding("PrecioC") });
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "PrecioV", Binding = new Binding("PrecioV") });
            addgrid1.Columns.Add(new DataGridTextColumn { Header = "Cantidad", Binding = new Binding("Cantidad") });
            string shortDate = DateTime.Now.ToString("yyyy-MM-dd");
            fecha.Content = shortDate;
            Items items;
            List<Items> listaProductos = new List<Items>();
            string[] datosProductos;
            if (File.Exists(pathName))
            {
                StreamReader tuberiaLectura3 = File.OpenText(pathName);
                string linea2 = tuberiaLectura3.ReadLine();
                while (linea2 != null)
                {
                    datosProductos = linea2.Split('/');
                    items = new Items(int.Parse(datosProductos[0]), datosProductos[1], int.Parse(datosProductos[2]), double.Parse(datosProductos[3]), double.Parse(datosProductos[4]), int.Parse(datosProductos[5]));
                    listaProductos.Add(items);
                    linea2 = tuberiaLectura3.ReadLine();
                }
                tuberiaLectura3.Close();
               listgrid.ItemsSource = listaProductos;
            }


            Consumidor consumidor;
            List<Consumidor> listaRegistro = new List<Consumidor>();
            string[] datosRegistro;
            if (File.Exists(pathName2))
            {
                StreamReader tuberiaLectura2 = File.OpenText(pathName2);
                string linea2 = tuberiaLectura2.ReadLine();
                while (linea2 != null)
                {
                    datosRegistro = linea2.Split('/');
                    consumidor = new Consumidor(int.Parse(datosRegistro[0]), int.Parse(datosRegistro[1]), datosRegistro[2], datosRegistro[3], double.Parse(datosRegistro[4]));
                    listaRegistro.Add(consumidor);
                    linea2 = tuberiaLectura2.ReadLine();
                }
                tuberiaLectura2.Close();
                ventasgrid.ItemsSource = listaRegistro;
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
                    string codigoBarrav = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el codigo del producto:");
                    string idv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el id del producto:");
                    string nombrev = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del producto:");
                    int codigoSearch = int.Parse(codigoBarrav);
                    string preciocv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de compra del producto:");
                    string preciovv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el precio de venta del producto:");
                    string cantidadv = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad del producto:");
                int externo2;
                    int codigoLimite = listgrid.Items.Count-1;
                if (rangocode(codigoSearch, codigoLimite))
                {
                    if (nombrePv(nombrev))
                    {
                        if (Confirmarp2(cantidadv))
                        {
                            externo2 = int.Parse(cantidadv);
                            if (ValidarRangop2(externo2))
                            {
                                totla.Content = codigoLimite;
                                List<Venderte> cajaLista = new List<Venderte>();

                                addgrid1.Items.Add(new Venderte { Id = int.Parse(idv), Nombre = nombrev, CodigoProducto = int.Parse(codigoBarrav), PrecioC = Double.Parse(preciocv), PrecioV = Double.Parse(preciovv), Cantidad = int.Parse(cantidadv) });

                                MessageBox.Show("Producto agregado a la lista.");
                            }
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

        private bool rangocode(int codigoSearch,int codigoLimite)
        {
            bool respuesta = true;
            if (codigoSearch < 1 || codigoSearch > codigoLimite)
            {
                MessageBox.Show("Ingrese la Id correcta del producto.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
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
            try
            {
                int idf = int.Parse(textbox3.Text);
                int nit = int.Parse(textbox1.Text);
                string nombreOR = textbox2.Text;
                string fechaaux = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                string fecha = fechaaux;
                double total = 200;


                if (surfingVoid(idf))
                {
                    if (surfingVoid2(nit))
                    {
                        if (surfingVoid3(nombreOR))
                        {
                            if (ValidarRate(total))
                            {
                                Consumidor consumidor = new Consumidor();
                                consumidor.EscribirArchivoB3(idf + "/" + nit + "/" + nombreOR + "/" + fecha + "/" + total);
                                MessageBox.Show("Producto agregado con exito");
                                CargarProductos();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Ingrese datos correctos en el Registro.\nExcepcion: " + ex.Message);
                Console.WriteLine("Excepcion: " + ex);
            }
        }

        private bool surfingVoid(int idf)
        {
            bool respuesta = true;
            if (Convert.ToString(idf)  == "")
            {
                MessageBox.Show("Ningun espacio debe estar vacio!", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool surfingVoid2(int nit)
        {
            bool respuesta = true;
            if (Convert.ToString(nit) == "")
            {
                MessageBox.Show("Ningun espacio debe estar vacio!", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool surfingVoid3(string nombreOR)
        {
            bool respuesta = true;
            if (nombreOR == "")
            {
                MessageBox.Show("Ningun espacio debe estar vacio!", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }

        private bool ValidarRate(double total)
        {
            bool respuesta = true;
            if (total < 1)
            {
                MessageBox.Show("El precio de la compra debe ser mayor a 0 Bs.", "Error en el ingreso de datos", MessageBoxButton.OK, MessageBoxImage.Error);
                respuesta = false;
            }
            return respuesta;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addgrid1.Items.Clear();
            totla.Content = "0.00";
        }

    }
}
