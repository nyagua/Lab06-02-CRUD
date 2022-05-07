using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCategoria
    {
        public List<Categoria> Listar(Categoria categoria)
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                string commandText = "USP_GetCategoria02";
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdCategoria", SqlDbType.Int)
                {
                    Value = categoria.IdCategoria
                };

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            IdCategoria = Convert.ToInt32(reader["idcategoria"]),
                            NombreCategoria = Convert.ToString(reader["nombrecategoria"]),
                            Descripcion = Convert.ToString(reader["descripcion"])
                        });
                    }
                }
            } catch (Exception ex)
            {
                throw ex;
            }
            return categorias;
        }

        public void Insertar(Categoria categoria)
        {
            SqlParameter[] parameters;
            string comandText;

            try
            {
                comandText = "USP_InsCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@IdCategoria", SqlDbType.Int)
                {
                    Value = categoria.IdCategoria
                };
                parameters[1] = new SqlParameter("@NombreCategoria", SqlDbType.VarChar)
                {
                    Value = categoria.NombreCategoria
                };
                parameters[2] = new SqlParameter("@Descripcion", SqlDbType.Text)
                {
                    Value = categoria.Descripcion
                };
                _ = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Actualizar(Categoria categoria)
        {
            SqlParameter[] parameters;
            string comandText;

            try
            {
                comandText = "USP_UpdCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@IdCategoria", SqlDbType.Int)
                {
                    Value = categoria.IdCategoria
                };
                parameters[1] = new SqlParameter("@NombreCategoria", SqlDbType.VarChar)
                {
                    Value = categoria.NombreCategoria
                };
                parameters[2] = new SqlParameter("@Descripcion", SqlDbType.Text)
                {
                    Value = categoria.Descripcion
                };

                _ = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int IdCategoria)
        {
            SqlParameter[] parameters;
            string commandText;

            try
            {
                commandText = "USP_DelCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdCategoria", SqlDbType.Int)
                {
                    Value = IdCategoria
                };
                _ = SqlHelper.ExecuteNonQuery(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
