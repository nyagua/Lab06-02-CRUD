using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BCategoria
    {
        private DCategoria dCategoria;

        public List<Categoria> Listar(int IdCategoria)
        {
            List<Categoria> categorias;

            try
            {
                dCategoria = new DCategoria();
                categorias = dCategoria.Listar(new Categoria { IdCategoria = IdCategoria });
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return categorias;
        }

        public bool Insertar(Categoria categoria)
        {
            bool result;
            List<Categoria> categorias = Listar(0);
            int max = categorias.Max(c => c.IdCategoria);
            try
            {
                dCategoria = new DCategoria();
                Categoria nuevaCategoria = new Categoria
                {
                    IdCategoria = max + 1,
                    Descripcion = categoria.Descripcion,
                    NombreCategoria = categoria.NombreCategoria
                };
                dCategoria.Insertar(nuevaCategoria);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Actualizar(Categoria categoria)
        {
            bool result;
            try
            {
                dCategoria = new DCategoria();
                dCategoria.Actualizar(categoria);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Eliminar(int IdCategoria)
        {
            bool result;
            try
            {
                dCategoria = new DCategoria();
                dCategoria.Eliminar(IdCategoria);
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }
    }
}