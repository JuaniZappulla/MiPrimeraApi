using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;
using MiPrimeraApi.Datos;
using System.Reflection.Metadata.Ecma335;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductosController:ControllerBase
    {
        [HttpGet("GetById/{id}")]
        public async Task <ActionResult<MProductos>> GetById(int id)
        {
            var funcion = new DProductos();
            var producto = await funcion.getProductoById(id);

            return producto;
        }

        [HttpPost]
        [Route("AddProducto")]
        public async Task addProducto([FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            await funcion.addProducto(parametros);
        }

        [HttpPut("EditarPrecioProducto/{id}")]
        //[Route("")]
        public async Task<ActionResult> editarPrecioProducto(int id,[FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            parametros.Id = id;
            await funcion.editarPrecioProducto(parametros);
            return NoContent();
        }

        [HttpPut("EditarDescripcionProducto/{id}")]
        //[Route("")]
        public async Task<ActionResult> editarDescripcionProducto(int id, [FromBody] MProductos parametros)
        {
            var funcion = new DProductos();
            parametros.Id = id;
            await funcion.editarDescripcionProducto(parametros);
            return NoContent();
        }

        [HttpDelete("EliminarProducto/{id}")]
        public async Task<ActionResult> eliminarProducto(int id)
        {
            var funcion = new DProductos();
            await funcion.eliminarProducto(id);
            return NoContent();
        }
    }
}
