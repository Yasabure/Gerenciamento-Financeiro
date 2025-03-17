using AutoMapper;
using GerenciamentoFinanceiro.DTOs;
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
        private readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExibirUsuarioDTO>>> GetAll()
        {
            var user = await _uof.UsuarioRepository.GetAllAsync();
            if (user is null)
                return NotFound("Não Existem Registros");

            var userDto = _mapper.Map<IEnumerable<ExibirUsuarioDTO>>(user);
            return Ok(userDto);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ExibirUsuarioDTO>> GetById(int id)
        {
            var user = await _uof.UsuarioRepository.GetAsync(c => c.Id == id);
            if (user is null)
                return NotFound("Produto não encontrado");

            var userDto = _mapper.Map<ExibirUsuarioDTO>(user);
            return Ok(userDto);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> Post(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO is null)
                return BadRequest();

            var user = _mapper.Map<Usuario>(usuarioDTO);
            var novoUsuario = await _uof.UsuarioRepository.AddAsync(user);
            await _uof.CommitAsync();
            var novoUsuarioDto = _mapper.Map<UsuarioDTO>(user);

            return Ok(novoUsuarioDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AtualizarUsuarioDTO>> Delete(int id)
        {
            var user = await _uof.UsuarioRepository.GetAsync(c => c.Id == id);
            if (user is null)
                return BadRequest();

            var userRemovido = _uof.UsuarioRepository.DeleteAsync(user);
            await _uof.CommitAsync();
            var userDto = _mapper.Map<AtualizarUsuarioDTO>(user);
            return Ok(user);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<AtualizarUsuarioDTO>> Put(int id, AtualizarUsuarioDTO user)
        {
            if (id != user.Id)
                return BadRequest();

            var usuario = _mapper.Map<Usuario>(user);
            var UsuarioAtualizado = _uof.UsuarioRepository.UpdateAsync(usuario);
            await _uof.CommitAsync();
            var UsuarioAtualizadoDTO = _mapper.Map<AtualizarUsuarioDTO>(usuario);
            return Ok(usuario);
        }
    }
}
