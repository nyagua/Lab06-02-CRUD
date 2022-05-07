using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace View
{
    /// <summary>
    /// Lógica de interacción para NuevaCategoria.xaml
    /// </summary>
    public partial class NuevaCategoria : Window
    {
        public int ID { get; set; }
        List<Categoria> categorias;
        public NuevaCategoria(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);
                if (categorias.Count > 0)
                {
                    txtId.Text = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
            else
            {
                btnEliminar.IsEnabled = false;
            }
        }

        private void Grabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria;
            bool result;
            try
            {
                bCategoria = new BCategoria();
                if (ID > 0)
                {
                    result = bCategoria.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }
                else
                {
                    result = bCategoria.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }
                if (!result)
                {
                    _ = MessageBox.Show("Error al grabar la categoria");
                }
                Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria;
            bool result;
            try
            {
                bCategoria = new BCategoria();
                result = bCategoria.Eliminar(ID);
                if (!result)
                {
                    _ = MessageBox.Show("Error al eliminar la catogoria");
                }
                Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}