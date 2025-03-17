using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GerenciamentoFinanceiro.DTOs;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransacaoController : Controller
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public TransacaoController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransacaoDTO>>> GetAll()
        {
            var transacoes = await _uof.TransacaoRepository.GetAllAsync();
            if (transacoes is null)
                return NotFound("Não Existem Registros");
            var transacoesDTO = _mapper.Map<IEnumerable<TransacaoDTO>>(transacoes);
            return Ok(transacoesDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TransacaoDTO>> GetById(int id)
        {
            var transacao = await _uof.TransacaoRepository.GetAsync(c => c.Id == id);
            if (transacao is null)
                return NotFound("Produto não encontrado");

            var transacaoDTO = _mapper.Map<TransacaoDTO>(transacao);
            return Ok(transacaoDTO);
        }
        [HttpPost]
        public async Task<ActionResult<TransacaoDTO>> Post(TransacaoDTO transacao)
        {
            if (transacao is null)
                return BadRequest();

            var transacaoDTO = _mapper.Map<Transacao>(transacao);
            var novaTransacao = _uof.TransacaoRepository.AddAsync(transacaoDTO);
            await _uof.CommitAsync();

            return Ok(transacaoDTO);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TransacaoDTO>> Delete(int id)
        {
            var transacao = await _uof.TransacaoRepository.GetAsync(c => c.Id == id);
            if (transacao is null)
                return BadRequest();
            var TransacaoRemovida = _uof.TransacaoRepository.DeleteAsync(transacao);
            await _uof.CommitAsync();
            var transacaoRemovidaDTO = _mapper.Map<TransacaoDTO>(transacao);
            return Ok(transacao);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<TransacaoDTO>> Put(int id, TransacaoDTO transacao)
        {
            if (transacao is null)
                return BadRequest();

            var TransacaoExiste = await _uof.TransacaoRepository.GetAsync(c => c.Id == id);
            if (TransacaoExiste is null)
                return NotFound();

            _mapper.Map(transacao, TransacaoExiste);
            var despesaAtualizada = await _uof.TransacaoRepository.UpdateAsync(TransacaoExiste);
            await _uof.CommitAsync();
            var transacaoAtualizadaDTO = _mapper.Map<TransacaoDTO>(TransacaoExiste);
            return Ok(transacaoAtualizadaDTO);
        }
    }
}
