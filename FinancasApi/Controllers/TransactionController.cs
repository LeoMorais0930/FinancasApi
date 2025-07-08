using Microsoft.AspNetCore.Mvc;

namespace FinancasApi.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
