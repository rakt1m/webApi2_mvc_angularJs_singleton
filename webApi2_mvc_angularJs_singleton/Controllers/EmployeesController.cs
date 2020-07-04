using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApi2_mvc_angularJs_singleton.Controllers
{
    public class EmployeesController : Controller
    {
       
        public ActionResult Employee()
        {
            return View();
        }
    }
}