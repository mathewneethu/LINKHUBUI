﻿using BOL;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
     [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
       
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToActionPermanent("Index", "Home", new { area = "Common" });

                }
                else
                {
                    TempData["msg"] = "Login Failed!";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception e1)
            {
                TempData["msg"] = "Login Failed!" + e1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult ExternalLogin(string provider)
        {
            OAuthWebSecurity.RequestAuthentication(provider, Url.Action("ExternalLoginCallback"));
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
        public ActionResult ExternalLoginCallback(string provider)
        {
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }

        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}