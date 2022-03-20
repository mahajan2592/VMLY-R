using RevenueForecastingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevenueForecastingTool.Controllers
{
    public class ReportingController : Controller
    {
        private DB_Entities _db = new DB_Entities();
        // GET: Reporting
        public ActionResult Index()
        {
            List<decimal> RevenueArray = new List<decimal>();
            using (var context = new DB_Entities())
            {
                var projectData = context.Projects.ToList();
                //var RevenueArray = projectData.Select(x => x.Revenue).ToArray();
                string RevenueMonth = string.Empty;
               
                foreach (var data in projectData)
                {
                    switch (data.Month)
                    {
                        case "January":
                        case "February":
                        case "March":
                        case "April":
                        case "May":
                        case "June":
                            RevenueArray.Add(projectData.Where(x=>x.Month==data.Month).Select(r =>r.Revenue).FirstOrDefault());
                            // code block
                            break;
                        default:
                            // code block
                            break;
                    }
                }

            }
            ViewBag.RevenueArray = RevenueArray.ToArray();
            return View();
        }
    }
}