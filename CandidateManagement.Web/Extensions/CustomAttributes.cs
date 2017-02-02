using CandidateManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateManagement.Web.Extensions
{
    public class CustomAttributes
    {
    }
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var redirect = filterContext.RequestContext.HttpContext.Request.UrlReferrer.AbsolutePath;
            filterContext.Result = new RedirectResult(redirect);
        }
    }
    //public class AuthorizeUserAttribute : AuthorizeAttribute
    //{
    //    IAccessService _service;

    //    // Custom property
    //    public string AccessLevel { get; set; }

    //    protected override bool AuthorizeCore(HttpContextBase httpContext)
    //    {
    //        if (AccessLevel == "")
    //        {
    //            return false;
    //        }
    //        //var isAuthorized = base.AuthorizeCore(httpContext);
    //        //if (!isAuthorized)
    //        //{
    //        //    return false;
    //        //}

    //        //string privilegeLevels = string.Join("", GetUserRights(httpContext.User.Identity.Name.ToString())); // Call another method to get rights of the user from DB

    //        //if (privilegeLevels.Contains(this.AccessLevel))
    //        //{
    //        //    return true;
    //        //}
    //        //else
    //        //{
    //        //    return false;
    //        //}
    //        return true;
    //    }
    //}

    class MyCustomFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["UserID"] == null)
            {
                filterContext.Result = new RedirectResult("/");
            }
        }
    }
}