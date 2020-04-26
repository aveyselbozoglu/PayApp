using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Payer.Filter
{
    public class AuthAdmin :FilterAttribute, IAuthenticationFilter
    {
        
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Session["login"])))
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}