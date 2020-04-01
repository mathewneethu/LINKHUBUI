using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    objBs.userBs.Insert(user);
                    TempData["msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {

                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["msg"] = "Create Failed:" + e1.Message;
                return RedirectToAction("Index");

            }
        }
    }
}