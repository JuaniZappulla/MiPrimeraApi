using MiPrimeraApi.Conexion;
using MiPrimeraApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi.Datos
{
    public class DProductos
    {
        ConexionDb cn = new ConexionDb();

        public async Task <MProductos> getProductoById(int id)
        {
            MProductos MProducto = new MProductos();

            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("usp_obtenerProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", id);
                    using (var item = await cmd.ExecuteReaderAsync()) 
                    {
                        while (await item.ReadAsync())
                        {
                            MProducto = new MProductos();
                            MProducto.Id = (int)item["Id"];
                            MProducto.Descripcion = (string)item["Descripcion"];
                            MProducto.Precio = (decimal)item["Precio"];
                        }
                    }
                }
            }
            return MProducto;
        }

        public async Task addProducto(MProductos mProductos)
        {
            using (var sql = new SqlConnection(cn.ConnectionString()))
            {
                using (var cmd = new SqlCommand("usp_nuevoProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", mProductos.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", mProductos.Precio);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
