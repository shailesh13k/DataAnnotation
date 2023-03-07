using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotation.Models;

namespace DataAnnotation.Controllers
{
    public class DataAnnotaionController : Controller
    {
        MVCDBEntities dbc = new MVCDBEntities();
        // GET: DataAnnotaion
        public ActionResult GetAllEmp()
        {
            var l1 = dbc.Emps.ToList();
            return View(l1);
        }


        public ActionResult GetDetails( int id)
        {
            Emp e1 = dbc.Emps.Find(id);
            return View(e1);       
        }
        
        
        [HttpGet]
        public ActionResult AddNewEmp()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddNewEmp(Emp e)
        {
            dbc.Emps.Add(e);
            dbc.SaveChanges();
            return RedirectToAction("GetAllEmp");
        }




        [HttpGet]
        public ActionResult UpdateEmpDetails( int id)
        {
            Emp e1 = dbc.Emps.Find(id);
            return View(e1);
        }
        
        [HttpPost]

        public ActionResult UpdateEmpDetails(int id, Emp e2)
        {
            Emp e1 = dbc.Emps.Find(id);
            e1.ename = e2.ename;
            e1.city = e2.city;
            e1.dcode = e2.dcode;
            dbc.SaveChanges();
            return RedirectToAction("GetAllEmp");
        }



        //Login

        [HttpGet]
        public ActionResult Login()
        {
            var l1 = dbc.Users.Select(x => x.role).Distinct().OrderBy(y => y);
            ViewBag.Roles = new SelectList(l1.ToList());
            return View();

        }


            [HttpPost]
        public ActionResult Login( FormCollection f1)
        {
            var l1 = dbc.Users.Select(x => x.role).Distinct().OrderBy(y => y);
            ViewBag.Roles = new SelectList(l1.ToList());
            string s1 = Request["t1"];
            string s2 = Request["t2"];
            User obj = dbc.Users.FirstOrDefault(x => x.username == s1 && x.password == s2);
            if (obj == null)
                return View();
            else
                return RedirectToAction("GetAllEmp");

        }
    }
}