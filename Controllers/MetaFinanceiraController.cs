using AutoMapper;
using GerenciamentoFinanceiro.DTOs;
using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MetaFinanceiraController : Controller
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public MetaFinanceiraController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaFinanceiraDTO>>> GetAll()
        {
            var despesasFixas = await _uof.MetaFinanceiraRepository.GetAllAsync();
            if (despesasFixas is null)
                return NotFound("Não Existem Registros");

            var despesasFixasDTO = _mapper.Map<IEnumerable<MetaFinanceiraDTO>>(despesasFixas);
            return Ok(despesasFixasDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MetaFinanceiraDTO>> GetById(int id)
        {
            var DespesaFixa = await _uof.MetaFinanceiraRepository.GetAsync(c => c.Id == id);
            if (DespesaFixa is null)
                return NotFound("Produto não encontrado");
            var DespesaFixaDTO = _mapper.Map<MetaFinanceiraDTO>(DespesaFixa);

            return Ok(DespesaFixa);
        }
        [HttpPost]
        public async Task<ActionResult<MetaFinanceiraDTO>> Post(MetaFinanceiraDTO metaFinanceiraDTO)
        {
            if (metaFinanceiraDTO is null)
                return BadRequest();

            var metaFinanceira = _mapper.Map<MetaFinanceira>(metaFinanceiraDTO);
            var NovaMetaFinanceira = _uof.MetaFinanceiraRepository.AddAsync(metaFinanceira);
            await _uof.CommitAsync();
            var Meta = _mapper.Map<MetaFinanceiraDTO>(metaFinanceira);

            return Ok(Meta);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MetaFinanceiraDTO>> Delete(int id)
        {
            var Meta = await _uof.MetaFinanceiraRepository.GetAsync(c => c.Id == id);
            if (Meta is null)
                return BadRequest();

            var despesaRemovida = _uof.MetaFinanceiraRepository.DeleteAsync(Meta);
            await _uof.CommitAsync();
            var despesaRemovidaDTO = _mapper.Map<MetaFinanceiraDTO>(Meta);
            return Ok(despesaRemovida);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MetaFinanceira>> Put(int id, MetaFinanceiraDTO metaFinanceiraDTO)
        {
            if(metaFinanceiraDTO is null)
                return BadRequest();

            var meta  = await _uof.MetaFinanceiraRepository.GetAsync(c => c.Id == id);
            if (meta is null)
                return NotFound();

            _mapper.Map(metaFinanceiraDTO, meta);
            var MetaAtualizada = await _uof.MetaFinanceiraRepository.UpdateAsync(meta);
            await _uof.CommitAsync();
            var transacaoAtualizadaDTO = _mapper.Map<MetaFinanceiraDTO>(meta);
            return Ok(transacaoAtualizadaDTO);
        }
    }
}
