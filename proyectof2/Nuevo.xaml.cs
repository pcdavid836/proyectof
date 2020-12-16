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

namespace proyectof2
{
    /// <summary>
    /// Lógica de interacción para Nuevo.xaml
    /// </summary>
    public partial class Nuevo : Window
    {
        public Nuevo()
        {
            InitializeComponent();
        }

        private void bm1_Click(object sender, RoutedEventArgs e)
        {
            Productos productos = new Productos();
            this.Hide();
            productos.Show();
            this.Close();

        }
        private void bm2_Click(object sender, RoutedEventArgs e)
        {
            Ventas ventas = new Ventas();
            this.Hide();
            ventas.Show();
            this.Close();
        }
        private void bm3_Click(object sender, RoutedEventArgs e)
        {
            Reportes reportes = new Reportes();
            this.Hide();
            reportes.Show();
            this.Close();
        }

        private void bmask_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = new Empresa();
            this.Hide();
            empresa.Show();
            this.Close();
        }

        private void bmexit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Cerrar la aplicación?", "Salir?", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
            }
                
        }

        private void busuario_Click(object sender, RoutedEventArgs e)
        {
            info info = new info();
            this.Hide();
            info.Show();
            this.Close();
        }
    }
}
