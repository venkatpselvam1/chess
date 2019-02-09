using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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