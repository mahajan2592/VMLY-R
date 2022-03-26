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
            List<string> RevenueMonthArray = new List<string>();
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
                        case "July":
                        case "August":
                            // RevenueArray.Add(projectData.Where(x=>x.Month==data.Month).Select(r =>r.Revenue).FirstOrDefault());
                            if (!RevenueMonthArray.Contains(data.Month))
                            {
                                decimal sum = 0;
                                var listOfRev = projectData.Where(x => x.Month == data.Month).Select(r => r.Revenue);
                                foreach (decimal x in listOfRev)
                                {
                                    sum += x;
                                }
                                RevenueArray.Add(sum);
                                RevenueMonthArray.Add(data.Month);
                            }
                            // code block
                            break;
                        default:
                            // code block
                            break;
                    }
                }

            }
            ViewBag.RevenueArray = RevenueArray.ToArray(); 
            ViewBag.RevenueMonthArray = RevenueMonthArray.Distinct().ToArray();

            return View();
        }
    }
}