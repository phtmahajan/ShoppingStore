using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Admin(string ID)
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", ID = ID });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();
            ProductStore.Models.Product model = new Models.Product();
            model.CategoryID = Convert.ToInt32(ID);
            return View(model);
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Category()
        {

            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "ProductCategory", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ViewProduct(string ID)
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", ID = ID });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();
            ProductStore.Models.Product model = new Models.Product();
            model.CategoryID = Convert.ToInt32(ID);
            return View(model);
        }
    }
}
