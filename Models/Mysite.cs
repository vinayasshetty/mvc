using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNewSite.Models
{
    public class Mysite
    {
        public string username { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public SelectList usernames { get; set; }
    }
}