using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMekashron.Filters;
using WebMekashron.Security;
using WebMekashron.Services;

namespace WebMekashron.Controllers
{
    [SessionAuthorization]
    public class UserController : Controller
    {
        private static readonly Service _service = new Service();

        public ActionResult Index()
        {
            var error = "";
            var model = _service.GetByEntity(MembershipHelper.Current.UserName, MembershipHelper.Current.Password, MembershipHelper.Current.Id, ref error);

            if (!string.IsNullOrWhiteSpace(error))
            {
                return View("Error", error);
            }

            return View(model);
        }
    }
}