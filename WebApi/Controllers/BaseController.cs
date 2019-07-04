using System.Security.Claims;
using System.Web.Http;

namespace WebApi
{
    public class BaseController : ApiController
    {

        /// <summary>
        /// 
        /// </summary>
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(User as ClaimsPrincipal);
            }
        }
    }
}
