using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.ClsTests;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        ClsTest tstobj = new ClsTest();
        ClsTestView tstview = new ClsTestView();
        public ActionResult Index()
        {
            var list= tstview.GetTasks();
            return View(list);
        }
        [HttpPost]
        public ActionResult Index(TaskModel obj)
        {
            if (!string.IsNullOrWhiteSpace(obj.title) && !string.IsNullOrWhiteSpace(obj.description) && !string.IsNullOrWhiteSpace(obj.remarks))
            {
                if (tstobj.AddTest(obj))
                {
                    ViewBag.Mess = "Task Added Successfully";
                }
                else
                {
                    ViewBag.Error = "Task Added Fail";
                }
            }
            else
            {
                ViewBag.Error = "Plese Fill The All Field";
            }
            var list = tstview.GetTasks();
            return View(list);

        }
        [HttpPost]
        public JsonResult DeleteData(int id)
        {
            string str = "";
            if(tstobj.DeleteTest(id))
            {
                str = "success";
            }
            else
            {
                str = "fail";
            }
            return Json(new { result = str });
        }

        [HttpPost]
        public JsonResult updateTask(TaskModel obj)
        {
            string str = "";
            try
            {
                if (!string.IsNullOrWhiteSpace(obj.title) && !string.IsNullOrWhiteSpace(obj.description) && !string.IsNullOrWhiteSpace(obj.remarks))
                {
                    if (tstobj.UpdateTest(obj))
                    {
                        str = "success";
                    }
                    else
                    {
                        ViewBag.Error = "fail";
                    }
                }
                else
                {
                    ViewBag.Error = "Plese Fill The All Field";
                }
                

            }
            catch(Exception ex)
            {
                str = "error";
            }
            return Json(new { result = str }, JsonRequestBehavior.AllowGet);
        }
    }
}