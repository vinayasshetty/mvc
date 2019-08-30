using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onlinerecipes.Models
{
    public class Recipe
    {
        public int categoryid { get; set; }
        public string recipename { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
    }
}