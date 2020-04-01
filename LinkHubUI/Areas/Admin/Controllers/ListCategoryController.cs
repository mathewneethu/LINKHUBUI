using BLL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{

     [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
       
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var category = objBs.categoryBs.GetAll();
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {

                        case "Asc":
                            category = category.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;


                case "CategoryDesc":
                    switch (SortOrder)
                    {

                        case "Asc":
                            category = category.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    category = category.OrderBy(x => x.CategoryName).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetAll().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            category = category.Skip((page - 1) * 10).Take(10);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objBs.categoryBs.Delete(id);
                TempData["msg"] = "Deletd Successfully";
                return RedirectToAction("Index");
            }
            catch(Exception e1)
            {
                TempData["msg"] = "Delete Failed:" + e1.Message;
                return RedirectToAction("Index");

            }
        }

        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/CategoryListRepor.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "CategoryDataSet";
            reportDataSource.Value = objBs.categoryBs.GetAll();

            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            //string FileNameExtension = (ReportType == "Excel") ? "xlsx" : "pdf";
            string FileNameExtension = (ReportType == "Excel") ? "xlsx" : (ReportType == "Word" ? "doc" : "pdf");
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding,
                out FileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename=Urls." + FileNameExtension);
            return File(renderedBytes, FileNameExtension);

        }
    }
}