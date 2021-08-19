using System.Security.Principal;
using System.Web.Mvc;

namespace Appartments_MVC_Course.Controllers
{
    public class AppartmentsController : Controller
    {
        // GET: Appartments
        public ActionResult Index()
        {
            return View();
        }

        // Appartments/stam/id?sortBy=fuck
        [Route("apartments/theroute/best/{id:range(1,5)}/{sortBy}")]
        public ActionResult stam(int? id,string sortBy)
        {

            //return Content("Stam actione");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "none";
            }
            return Content("Stam action" + id + ", sort By:"+ sortBy);
        }
        public ActionResult RealStam()
        {
            return View();
        }
    }
}