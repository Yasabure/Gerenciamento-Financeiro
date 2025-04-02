using AutoMapper;
using GerenciamentoFinanceiro.DTOs;
using GerenciamentoFinanceiro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
        }

        /// <summary>
        /// Obtém todos os usuários (Apenas Admins)
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExibirUsuarioDTO>>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var usersDto = _mapper.Map<IEnumerable<ExibirUsuarioDTO>>(users);
            return Ok(usersDto);
        }

        /// <summary>
        /// Obtém um usuário pelo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ExibirUsuarioDTO>> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado");

            var userDto = _mapper.Map<ExibirUsuarioDTO>(user);
            return Ok(userDto);
        }

        /// <summary>
        /// Registra um novo usuário
        /// </summary>
        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDTO>> Register(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest();

            var user = _mapper.Map<Usuario>(usuarioDTO);
            user.UserName = usuarioDTO.Email;
            user.Email = usuarioDTO.Email;
            user.DataCadastro = DateTime.UtcNow;

            var result = await _userManager.CreateAsync(user, usuarioDTO.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Usuário registrado com sucesso!");
        }

        /// <summary>
        /// Autenticação do usuário (Login)
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return Unauthorized("Usuário ou senha inválidos!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                return Unauthorized("Usuário ou senha inválidos!");

            var token = GerarToken(user);
            return Ok(new { Token = token });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado!");

            await _userManager.DeleteAsync(user);
            return Ok("Usuário removido!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AtualizarUsuarioDTO>> Put(Guid id, AtualizarUsuarioDTO userDto)
        {
            if (id != userDto.Id)
                return BadRequest();

            var usuario = await _userManager.FindByIdAsync(id.ToString());
            if (usuario == null)
                return NotFound("Usuário não encontrado!");

            _mapper.Map(userDto, usuario);
            var result = await _userManager.UpdateAsync(usuario);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(userDto);
        }

        private string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
