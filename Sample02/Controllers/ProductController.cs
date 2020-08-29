using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample02.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}