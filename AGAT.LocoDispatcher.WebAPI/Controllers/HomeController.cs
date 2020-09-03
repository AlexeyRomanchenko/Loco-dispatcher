using AGAT.LocoDispatcher.Business.Managers;
using AGAT.LocoDispatcher.Common.Interfaces.Managers;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace AGAT.LocoDispatcher.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
