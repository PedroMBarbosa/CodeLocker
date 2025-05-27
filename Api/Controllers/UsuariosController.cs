using Api.Models;
using Api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DBCodeLockerContext _context;

        public UsuariosController(DBCodeLockerContext context)
        {
            _context = context;
        }

        [HttpPost("CadastrarUsuario")]
        public IActionResult Register([FromBody] Usuario usuario)
        {
            try
            {
                // Verifica se já existe um cliente com o mesmo email
                if (_context.usuario.Any(u => u.email == usuario.email))
                    return BadRequest(new { message = "Cliente já existe!" });

                // Adiciona o cliente no banco
                _context.usuario.Add(usuario);
                _context.SaveChanges();

                return Ok(new { message = "Cliente registrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Erro ao registrar cliente.",
                    erro = ex.InnerException?.Message ?? ex.Message,
                    stack = ex.StackTrace
                });
            }
        }
    }
}
