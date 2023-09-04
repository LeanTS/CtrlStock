using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Titulos.BData.Data;
using Titulos.BData.Data.Entity;
using Titulos.Shared.DTO;

namespace Titulos.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly Context context;

        public ProductosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get()
        {
            var veri = await context.Productos.ToListAsync();
            if (veri == null || veri.Count == 0)
            {
                return BadRequest("No existe el Producto");
            }
            return veri;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<Productos>> Get(long id)
        {
            var existe = await context.Productos.AnyAsync(x => x.ProdId == id);
            if (!existe)
            {
                return NotFound($"El Producto {id} no existe");
            }
            return await context.Productos.FirstOrDefaultAsync(x => x.ProdId == id);
        }

        [HttpPost]
        public async Task<ActionResult<long>> Post(ProductosDTO entidad)
        {
            try
            {
                var existe = await context.Productos.AnyAsync(x => x.NomProd == entidad.NombreProd);
                if (!existe)
                {
                    return NotFound($"El Producto de Nombre={entidad.NombreProd} no existe");
                }

                Productos prods = new Productos();

                prods.NomProd = entidad.NombreProd;
                prods.DescripcionProd = entidad.Descripcion;

                await context.AddAsync(prods);
                await context.SaveChangesAsync();
                return prods.ProdId;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:long}")] 
        public async Task<ActionResult> Put(Productos entidad, long id)
        {
            if (id != entidad.ProdId)
            {
                return BadRequest("El Codigo del Producto no corresponde.");
            }

            var existe = await context.Productos.AnyAsync(x => x.ProdId == id);
            if (!existe)
            {
                return NotFound($"El Producto de Codigo={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            var existe = await context.Productos.AnyAsync(x => x.ProdId == id);
            if (!existe)
            {
                return NotFound($"El Producto de Codigo={id} no existe");
            }
            Productos prods = new Productos();
            prods.ProdId = id;

            context.Remove(prods);

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
