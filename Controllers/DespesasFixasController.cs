using AutoMapper;
using GerenciamentoFinanceiro.DTOs;
using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DespesasFixasController : Controller
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public DespesasFixasController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesasFixasDTO>>> GetAll()
        {
            var despesasFixas = await _uof.DespesasFixasRepository.GetAllAsync();
            if (despesasFixas is null)
                return NotFound("Não Existem Registros");

            var despesasFixasDTO = _mapper.Map<IEnumerable<DespesasFixasDTO>>(despesasFixas);
            return Ok(despesasFixasDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DespesasFixasDTO>> GetById(int id)
        {
            var DespesaFixa = await _uof.DespesasFixasRepository.GetAsync(c => c.Id == id);
            if (DespesaFixa is null)
                return NotFound("Produto não encontrado");

            var DespesaFixaDTO = _mapper.Map<DespesasFixasDTO>(DespesaFixa);
            return Ok(DespesaFixaDTO);
        }
        [HttpPost]
        public async Task<ActionResult<DespesasFixasDTO>> Post(DespesasFixasDTO despesaDTO)
        {
            if (despesaDTO is null)
                return BadRequest();

            var despesa = _mapper.Map<DespesasFixas>(despesaDTO);
            var novoproduto = _uof.DespesasFixasRepository.AddAsync(despesa);
            await _uof.CommitAsync();
            var novoProdutoDTO = _mapper.Map<DespesasFixasDTO>(despesa);
            return Ok(novoProdutoDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DespesasFixasDTO>> Delete(int id)
        {
            var despesa = await _uof.DespesasFixasRepository.GetAsync(c => c.Id == id);
            if (despesa is null)
                return BadRequest();

            var despesaRemovida = _uof.DespesasFixasRepository.DeleteAsync(despesa);
            await _uof.CommitAsync();
            var despesaRemovidaDTO = _mapper.Map<DespesasFixas>(despesa);
            return Ok(despesaRemovidaDTO);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DespesasFixasDTO>> Put(int id, DespesasFixasDTO despesasFixasDTO)
        {
            if(despesasFixasDTO is null)
                return BadRequest();

            var despesaFixaExiste = await _uof.DespesasFixasRepository.GetAsync(c => c.Id == id);
            if(despesaFixaExiste is null)
                return NotFound();

            _mapper.Map(despesasFixasDTO, despesaFixaExiste);
            var despesaAtualizada = _uof.DespesasFixasRepository.UpdateAsync(despesaFixaExiste);
            await _uof.CommitAsync();
            var despesasAtualizadaDTO = _mapper.Map<DespesasFixasDTO>(despesaFixaExiste);
            return Ok(despesasAtualizadaDTO);
        }
    }
}
