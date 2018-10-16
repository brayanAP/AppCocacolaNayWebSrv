
using Microsoft.AspNetCore.Mvc;

namespace AppCocacolaNayWebSrv.Controllers
{
    public class FicIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}