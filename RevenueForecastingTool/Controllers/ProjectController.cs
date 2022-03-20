using RevenueForecastingTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RevenueForecastingTool.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            return View( new Project());
        }
        [HttpPost]
        public ActionResult Update(string clientName, string projectName, string jobNumber, string projectMonth, string projectStatus, string projectRevenue, string projectId)
        {
            Project updateData = new Project();
            updateData.Client = clientName;
            updateData.ProjectName = projectName;
            updateData.JobNumber = Int32.Parse(jobNumber);
            updateData.Month = projectMonth;
            updateData.Status = projectStatus;
            updateData.Revenue = decimal.Parse(projectRevenue);
            updateData.id = Int32.Parse(projectId);
            return View(updateData);
        }
        [HttpPost]
        public ActionResult UpdateForecast(Project projectData)
        {
            using (var context = new DB_Entities())
            {
                var data = context.Projects.FirstOrDefault(x => x.id == projectData.id);
                if (data != null)
                {
                    data.Client = projectData.Client;
                    data.ProjectName = projectData.ProjectName;
                    data.JobNumber = projectData.JobNumber;
                    data.Month = projectData.Month;
                    data.Status = projectData.Status;
                    data.Revenue = projectData.Revenue;
                    context.SaveChanges();
                    Session["projectUpdateMessage"] = "Record Updated";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("~/Views/Project/Update.cshtml", projectData);
                }
                    //return View(data);
                }

        }
        public ActionResult Delete(String id)
        {
            using (var context = new DB_Entities())
            {
                var projectIdToDelete = Int32.Parse(id);
                var data = context.Projects.FirstOrDefault(x => x.id == projectIdToDelete);
                if (data != null)
                {
                    context.Projects.Remove(data);
                    context.SaveChanges();
                    Session["projectUpdateMessage"] = "Record Deleted";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["projectUpdateMessage"] = "Record Not Deleted";
                    return RedirectToAction("Index", "Home");
                }
            }

            }
        public ActionResult Add(Project model)
        {
            // To open a connection to the database
            using (var context = new DB_Entities())
            {
                context.Projects.Add(model);
                context.SaveChanges();
                var projectData = context.Projects.ToList();
                Session["ProjectData"] = projectData;
            }
            
            string message = "Project Added Successfully";

            // To display the message on the screen
            // after the record is created successfully
            Session["projectUpdateMessage"] = "";
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return View("~/Views/Home/Index.cshtml");
        }
    }
}