using System.Web.Mvc;

namespace WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return RedirectToAction("", "Swagger", new { area = "" });
            
        }
    }
}
