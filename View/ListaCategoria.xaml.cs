using Business;
using Entity;
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

namespace View
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NuevaCategoria nuevaCategoria = new NuevaCategoria(0);
            _ = nuevaCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item)
            {
                return;
            }

            idCategoria = Convert.ToInt32(item.IdCategoria);
            NuevaCategoria nuevaCategoria = new NuevaCategoria(idCategoria);
            _ = nuevaCategoria.ShowDialog();
            Cargar();
        }

        private void Cargar()
        {
            BCategoria bCategoria;
            try
            {
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Erro en la consulta");
                throw ex;
            }
        }
    }
}