using Microsoft.AspNetCore.Mvc;

namespace FinancasApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
