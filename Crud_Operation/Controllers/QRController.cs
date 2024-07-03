using Microsoft.AspNetCore.Mvc;

namespace Crud_Operation.Controllers
{
    public class QRController : Controller
    {
        public IActionResult QRScan()
        {
            return View();
        }
    }
}
