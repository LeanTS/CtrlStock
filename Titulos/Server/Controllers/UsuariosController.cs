using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Titulos.BData.Data;
using Titulos.BData.Data.Entity;

namespace Titulos.Server.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly Context context;

        public UsuariosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            return await context.Usuarios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuarios>> Get(int Id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == Id);
            if (!existe)
            {
                return NotFound($"El Usuario de {Id} no existe");
            }
            return await context.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Usuarios usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
            return usuario.Id;
        }

        [HttpPut("{id:int}")] 
        public async Task<ActionResult> Put(Usuarios entidad, string user)
        {
            if (user != entidad.Usuario)
            {
                return BadRequest("El Usuario no corresponde.");
            }

            var existe = await context.Usuarios.AnyAsync(x => x.Usuario == user);
            if (!existe)
            {
                return NotFound($"El Usuario={user} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El Usuario de id={id} no existe");
            }
            Usuarios users = new Usuarios();
            users.Id = id;

            context.Remove(users);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
