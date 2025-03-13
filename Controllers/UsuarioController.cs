using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _uof;

        public UsuarioController(IUnitOfWork uof)
        {
            _uof = uof;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var user = await _uof.UsuarioRepository.GetAllAsync();
            if (user is null)
                return NotFound("Não Existem Registros");

            return Ok(user);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var user = await _uof.UsuarioRepository.GetAsync(c => c.Id == id);
            if (user is null)
                return NotFound("Produto não encontrado");


            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario user)
        {
            if (user is null)
                return BadRequest();

            var novoUsuario = _uof.UsuarioRepository.AddAsync(user);
            await _uof.CommitAsync();

            return Ok(user);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var user = await _uof.UsuarioRepository.GetAsync(c => c.Id == id);
            if (user is null)
                return BadRequest();

            var userRemovido = _uof.UsuarioRepository.DeleteAsync(user);
            await _uof.CommitAsync();
            return Ok(user);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario user)
        {
            if (id != user.Id)
                return BadRequest();

            var despesaAtualizada = _uof.UsuarioRepository.UpdateAsync(user);
            await _uof.CommitAsync();
            return Ok(user);
        }
    }
}
