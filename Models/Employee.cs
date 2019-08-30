using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloWorldMVC.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="ecode is mandatory")]
        [RegularExpression(@"\d{3,3}")]
        public int Ecode { get; set; }
        [Required]
        [StringLength(10,MinimumLength=5)]
        public string Ename { get; set; }
        [Required]
        [Range(10000,30000)]
        public int salary { get; set; }
        [Required]
        [DataType("System.Int32")]
        public int deptid { get; set; }
    }
}