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

        public DespesasFixasController(IUnitOfWork uof)
        {
            _uof = uof;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DespesasFixas>>> GetAll()
        {
            var despesasFixas = await _uof.DespesasFixasRepository.GetAllAsync();
            if (despesasFixas is null)
                return NotFound("Não Existem Registros");

            return Ok(despesasFixas);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DespesasFixas>> GetById(int id)
        {
            var DespesaFixa = await _uof.DespesasFixasRepository.GetAsync(c => c.Id == id);
            if (DespesaFixa is null)
                return NotFound("Produto não encontrado");


            return Ok(DespesaFixa);
        }
        [HttpPost]
        public async Task<ActionResult<DespesasFixas>> Post(DespesasFixas despesa)
        {
            if (despesa is null)
                return BadRequest();

            var novoproduto = _uof.DespesasFixasRepository.AddAsync(despesa);
            await _uof.CommitAsync();

            return Ok(despesa);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<DespesasFixas>> Delete(int id)
        {
            var despesa = await _uof.DespesasFixasRepository.GetAsync(c => c.Id == id);
            if (despesa is null)
                return BadRequest();

            var despesaRemovida = _uof.DespesasFixasRepository.DeleteAsync(despesa);
            await _uof.CommitAsync();
            return Ok(despesaRemovida);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<DespesasFixas>> Put(int id, DespesasFixas despesasFixas)
        {
            if(id != despesasFixas.Id)
                return BadRequest();

            var despesaAtualizada = _uof.DespesasFixasRepository.UpdateAsync(despesasFixas);
            await _uof.CommitAsync();
            return Ok(despesasFixas);
        }
    }
}
