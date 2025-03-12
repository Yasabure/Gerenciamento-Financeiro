using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiro.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
