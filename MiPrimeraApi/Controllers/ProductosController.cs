using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;
using MiPrimeraApi.Datos;
using System.Reflection.Metadata.Ecma335;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductosController
    {
        [HttpGet]
        [Route("GetById")]
        public async Task <ActionResult<MProductos>> GetById([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            var producto = await funcion.getProductoById(parametros.Id);

            return producto;
        }

        [HttpPost]
        [Route("AddProducto")]
        public async Task addProducto([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            await funcion.addProducto(parametros);
        }


    }
}
