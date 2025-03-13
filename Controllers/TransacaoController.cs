using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransacaoController : Controller
    {
        private readonly IUnitOfWork _uof;

        public TransacaoController(IUnitOfWork uof)
        {
            _uof = uof;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetAll()
        {
            var despesasFixas = await _uof.TransacaoRepository.GetAllAsync();
            if (despesasFixas is null)
                return NotFound("Não Existem Registros");

            return Ok(despesasFixas);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transacao>> GetById(int id)
        {
            var transacao = await _uof.TransacaoRepository.GetAsync(c => c.Id == id);
            if (transacao is null)
                return NotFound("Produto não encontrado");


            return Ok(transacao);
        }
        [HttpPost]
        public async Task<ActionResult<Transacao>> Post(Transacao transacao)
        {
            if (transacao is null)
                return BadRequest();

            var novaTransacao = _uof.TransacaoRepository.AddAsync(transacao);
            await _uof.CommitAsync();

            return Ok(transacao);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Transacao>> Delete(int id)
        {
            var transacao = await _uof.TransacaoRepository.GetAsync(c => c.Id == id);
            if (transacao is null)
                return BadRequest();

            var despesaRemovida = _uof.TransacaoRepository.DeleteAsync(transacao);
            await _uof.CommitAsync();
            return Ok(transacao);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Transacao>> Put(int id, Transacao transacao)
        {
            if (id != transacao.Id)
                return BadRequest();

            var despesaAtualizada = _uof.TransacaoRepository.UpdateAsync(transacao);
            await _uof.CommitAsync();
            return Ok(transacao);
        }
    }
}
