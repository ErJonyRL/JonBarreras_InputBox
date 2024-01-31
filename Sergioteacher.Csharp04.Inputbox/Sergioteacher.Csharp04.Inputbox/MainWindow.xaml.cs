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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace JonBarreras.Csharp04.Inputbox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string data;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Application.Current.Shutdown();
        }

        private void VentanaPrincipal_Activated(object sender, EventArgs e)
        {
            Tsalida.Text = data;
        }

        private void BIntro_Click(object sender, RoutedEventArgs e)
        {
            string inputText = MiTexto.Text;

            // Verificar si la caja de texto está vacía
            if (string.IsNullOrEmpty(inputText))
            {
                // Listar ficheros locales al ejecutable
                string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory);
                // Aquí puedes realizar la lógica para mostrar los ficheros en tu aplicación
                // Por ejemplo, podrías asignarlos a un ListBox o cualquier otro control de tu interfaz.
                // En este ejemplo, solo mostraremos un MessageBox con la lista de ficheros.
                Tsalida.Text = "Ficheros locales al ejecutable:\n" + string.Join("\n", files);
            }
            else
            {
                // Verificar si la ruta proporcionada es válida
                if (Directory.Exists(inputText))
                {
                    // Listar ficheros en la carpeta especificada
                    string[] files = Directory.GetFiles(inputText);
                    // Aquí también puedes realizar la lógica para mostrar los ficheros en tu aplicación.
                    Tsalida.Text = "Ficheros en la carpeta especificada:\n" + string.Join("\n", files);
                }
                else
                {
                    // Mostrar un mensaje de error si la ruta no es válida
                    MessageBox.Show("La ruta proporcionada no es válida.");
                }
            }

            data = MiTexto.Text;
        }

        private void VentanaInput_Activated(object sender, EventArgs e)
        {
            MiTexto.Text = "";
            
        }
    }
}
