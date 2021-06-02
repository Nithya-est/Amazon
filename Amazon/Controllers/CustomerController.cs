using Amazon.Context;
using Amazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amazon.Controllers
{
    public class CustomerController : Controller
    {
        db_customerEntities dbObj = new db_customerEntities();
        public ActionResult Index()
        {
            return View("Website");
        }
      
        [HttpPost]
        public ActionResult Customer(tbl_customer model)
        {

            tbl_customer obj = new tbl_customer();
          
            obj.Id = model.Id;
            obj.Fname = model.Fname;
            obj.Lname = model.Lname;
            obj.Email = model.Email;
            obj.Mobile = model.Mobile;
            obj.Addresss = model.Addresss;
            dbObj.tbl_customer.Add(obj);
            dbObj.SaveChanges();
            return View();
           
        }
        public ActionResult Customerview()
        {
            return View("Customer");
        }
        public ActionResult Views()
        {
            Dbconnection obj = new Dbconnection();//creating obj for dbconnection class
            var values = obj.dbconnect();
           //ViewBag.pro = values;
           

            return View();
        }

    }
}