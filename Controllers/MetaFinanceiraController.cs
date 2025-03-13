using GerenciamentoFinanceiro.Model;
using GerenciamentoFinanceiro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetaFinanceiraController : Controller
    {
        private readonly IUnitOfWork _uof;

        public MetaFinanceiraController(IUnitOfWork uof)
        {
            _uof = uof;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaFinanceira>>> GetAll()
        {
            var despesasFixas = await _uof.MetaFinanceiraRepository.GetAllAsync();
            if (despesasFixas is null)
                return NotFound("Não Existem Registros");

            return Ok(despesasFixas);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MetaFinanceira>> GetById(int id)
        {
            var DespesaFixa = await _uof.MetaFinanceiraRepository.GetAsync(c => c.Id == id);
            if (DespesaFixa is null)
                return NotFound("Produto não encontrado");


            return Ok(DespesaFixa);
        }
        [HttpPost]
        public async Task<ActionResult<MetaFinanceira>> Post(MetaFinanceira Meta)
        {
            if (Meta is null)
                return BadRequest();

            var novoproduto = _uof.MetaFinanceiraRepository.AddAsync(Meta);
            await _uof.CommitAsync();

            return Ok(Meta);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MetaFinanceira>> Delete(int id)
        {
            var Meta = await _uof.MetaFinanceiraRepository.GetAsync(c => c.Id == id);
            if (Meta is null)
                return BadRequest();

            var despesaRemovida = _uof.MetaFinanceiraRepository.DeleteAsync(Meta);
            await _uof.CommitAsync();
            return Ok(despesaRemovida);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<MetaFinanceira>> Put(int id, MetaFinanceira Meta)
        {
            if (id != Meta.Id)
                return BadRequest();

            var MetaAtualizada = _uof.MetaFinanceiraRepository.UpdateAsync(Meta);
            await _uof.CommitAsync();
            return Ok(MetaAtualizada);
        }
    }
}
