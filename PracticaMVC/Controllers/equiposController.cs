using Microsoft.AspNetCore.Mvc;

namespace PracticaMVC.Controllers
{
    public class equiposController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
