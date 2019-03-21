using Microsoft.AspNetCore.Mvc;

namespace ChessAPIs.Controllers
{
    public class ChessUIController : Controller
    {
        // GET: ChessUI
        public ActionResult Index()
        {
            return View();
        }
    }
}