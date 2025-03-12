using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    public class TransacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
