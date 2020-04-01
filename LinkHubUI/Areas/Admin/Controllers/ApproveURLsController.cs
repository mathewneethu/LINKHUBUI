using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
     [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {

                var urls = objBs.urlbs.GetAll().Where(x => x.IsApproved == "P").ToList();
               
                return View(urls);
            }
            else
            {
                var urls = objBs.urlbs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
           
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.urlbs.GetByID(id);
                myUrl.IsApproved = "A";
                objBs.urlbs.Update(myUrl);
                TempData["msg"] = "Approved Successfully";
                return RedirectToAction("Index");
                
            }
            catch (Exception e1)
            {
                TempData["msg"] = "Approved Failed:" + e1.Message;
                return RedirectToAction("Index");

            }
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.urlbs.GetByID(id);
                myUrl.IsApproved = "R";
                objBs.urlbs.Update(myUrl);
                TempData["msg"] = "Rejected Successfully";
                return RedirectToAction("Index");

            }
            catch (Exception e1)
            {
                TempData["msg"] = "Rejected Failed:" + e1.Message;
                return RedirectToAction("Index");

            }
        }

         [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids, string Status, string CurrentStatus)//parameter sholud be same as the data in ajax
        {
            try
            {
                objBs.ApproveOrReject(Ids, Status);
                TempData["msg"] = "Operation Successfully";
                var urls = objBs.urlbs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs",urls);
            }
            catch(Exception e1)
            {
                TempData["msg"] = "Operation Failed" + e1.Message;
                var urls = objBs.urlbs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApproveURLs", urls);
            }
        
        }

    }
}