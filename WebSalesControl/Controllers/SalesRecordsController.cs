using Microsoft.AspNetCore.Mvc;

namespace WebSalesControl.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
