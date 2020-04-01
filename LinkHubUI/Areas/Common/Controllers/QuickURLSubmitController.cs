using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLSubmitController : BaseCommonController
    {
        // GET: Common/QuickURLSubmit
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel MyQuickURL)
        {
            //ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            //return View();

            try
            {
                ModelState.Remove("MyUser.Password");
                ModelState.Remove("MyUser.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");

                if (ModelState.IsValid)
                {
                    objBs.InsertQuickURL(MyQuickURL);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
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