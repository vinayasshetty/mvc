using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HelloWorldMVC.Models;
using EFDalLib;
namespace HelloWorldMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            string msg = "WELCOME TO VALTECH_";
            //TempData["msg"] = msg;
            Session.Add("msg", msg);
            return View();
        }
        public ActionResult DoTask()
        {
            var msg = Session["msg"].ToString();
            //ViewData.Add("msg", msg);
            //Employee emp = new Employee
            //{
            //    Ecode = 201,
            //    Ename = "trupti",
            //    salary = 20000,
            //    deptid = 4
            //};
            //ViewData.Add("Employee", emp);
            return View();
        }
        public ActionResult DoTask2()
        {
            var msg = Session["msg"].ToString();
            return View();
        }
        public ActionResult DisplayEmp()
        {
            Employee emp = new Employee
            {
                Ecode = 201,
                Ename = "trupti",
                salary = 20000,
                deptid = 4
            };
            return View(emp);
        }
        public ActionResult DisplayAllEmps()
        {
            EFDal dal = new EFDal();
            var emplst = dal.GetAllEmps()
                .Select(o=>new Employee
                 {
                  Ecode=o.Ecode,
                  Ename=o.Ename,
                salary=(int)o.salary,
                deptid=(int)o.deptid

                  });
            if(emplst.Count()==0)
            {
                ViewData["msg"] = "no records";
            }
           
            return View(emplst);
        }

        //to call just a form
        [HttpGet]
        public ActionResult AddEmp()
        {
            return View();
        }



        //to post the data from model
        [HttpPost]
        public ActionResult AddEmp(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EFDal dal = new EFDal();
                dal.AddEmployee(new tbl_employee
                {
                    Ecode = emp.Ecode,
                    Ename = emp.Ename,
                    salary = emp.salary,
                    deptid = emp.deptid
                });
                //return View();//to return in same page
                return RedirectToAction("DisplayAllEmps");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            EFDal dal = new EFDal();
            dal.DeleteById(id);
            return RedirectToAction("DisplayAllEmps");
        }
        //display the contents in the text field
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EFDal dal = new EFDal();
            var emp = dal.GetEmpById(id);
            Employee e = new Employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                salary = (int)emp.salary,
                deptid = (int)emp.deptid
            };
            return View(e);
        }
        [HttpPost]
        public ActionResult UpdateEmp(Employee emp)
        {
            EFDal dal = new EFDal();
            tbl_employee e = new tbl_employee
            {
                Ecode = emp.Ecode,
                Ename = emp.Ename,
                salary = emp.salary,
                deptid = emp.deptid
            };
            dal.UpdateEmp(e);
            return RedirectToAction("DisplayAllEmps");
           
        }
        [HttpGet]
        public ActionResult GetdetailsById(int id)
        {
            EFDal dal = new EFDal();
            var recrd = dal.GetEmpById(id);
            Employee emp = new Employee
            {
                Ecode = recrd.Ecode,
                Ename=recrd.Ename,
                salary=(int)recrd.salary,
                deptid=(int)recrd.deptid

            };
            return View(emp);
        }
        public ActionResult CreateForm()
        {
            List<int> dids = new List<int> { 201, 202, 203, 204 };
            EmpFormModel empmodel = new EmpFormModel
            {
                Deptids = new SelectList(dids)
            };
            return View(empmodel);
        }
        [HttpPost]
        public ActionResult CreateForm(EmpFormModel emp)
        {
            return View();
        }
       
    }
}