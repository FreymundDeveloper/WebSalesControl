using Microsoft.AspNetCore.Mvc;

namespace WebSalesControl.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
