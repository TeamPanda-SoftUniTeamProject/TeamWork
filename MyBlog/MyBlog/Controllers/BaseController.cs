using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    string fullName = user.FullName;
                    if (fullName != null)
                    {
                        ViewData.Add("FullName", fullName);
                    }
                    else
                    {
                        ViewData.Add("Fullname",username);
                    }
                    
                }
               
            }
            base.OnActionExecuted(filterContext);
        }
        public BaseController()
        { }
    }
}