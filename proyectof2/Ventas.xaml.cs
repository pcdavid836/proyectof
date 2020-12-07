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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void bolber8_Click(object sender, RoutedEventArgs e)
        {
            Nuevo nuevo = new Nuevo();
            this.Hide();
            nuevo.Show();
            this.Close();
        }

        private void generate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
