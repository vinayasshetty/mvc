using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldMVC.Models
{
    public class EmpFormModel
    {
        public int Ecode { get; set; }
        public string Ename { get; set; }
        public int salary { get; set; }
        public int Deptid { get; set; }//while posting only on value is posted so
        public SelectList Deptids { get; set; }

       
    }
}