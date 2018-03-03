using System.Web.Mvc;

namespace Web.Controllers
{
    public class TemplatesController : Controller
    {
        public ActionResult Index(string id)
        {
            return View(viewName: id);
        }
    }
}