using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    public class MetaFinanceiraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
