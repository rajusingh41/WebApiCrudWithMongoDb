using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApi
{
    public class AppUser: ClaimsPrincipal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="principal"></param>
        public AppUser(ClaimsPrincipal principal)
       : base(principal)
        {
        }

        /// <summary>
        /// Get login user id 
        /// this use for createBy and updateBy in query parameter and other reference 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
#pragma warning disable S2325 // Methods and properties that don't access instance data should be static
        public int UserId
#pragma warning restore S2325 // Methods and properties that don't access instance data should be static
        {
            get
            {
                // return Convert.ToInt32(Current.FindFirst("LogOnId").Value, CultureInfo.CurrentCulture);
                return 10;
            }
        }

        /// <summary>
        /// Get login user company code / domain code 
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
#pragma warning disable S2325 // Methods and properties that don't access instance data should be static
        public string DomainCode
#pragma warning restore S2325 // Methods and properties that don't access instance data should be static
        {
            get {
                //  return Current.FindFirst("domainCode").Value.ToLower(CultureInfo.CurrentCulture);
                return "dgn5";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        
        public string UserCode
        {
            get { return "UTL009"; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            get { return "Kadam"; }
        }

    }
}