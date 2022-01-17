using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MES_WEB_API.Controllers
{
    public class AccountController : Controller
    {
        // GET: login
        [HttpGet]
        public ActionResult Index()
        {


            return View();
        }

        [HttpPost]
        public ActionResult loginform(FormCollection collection)
        {
            string email = collection.Get("email");
            string Password = collection.Get("Password");
            if (email == "srinickraj@gmail.com" && Password == "1234")
            {
                Response.Redirect("http://www.neerajcodesolutions.com");
            }
            else
            {
                ViewBag.Message = "Please enter valid Email ID and Password";

            }
            return View("Index");
        }
    }
}