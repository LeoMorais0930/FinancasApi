using Microsoft.AspNetCore.Mvc;

namespace FinancasApi.Controllers
{
    public class GoalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
