using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onlinerecipes.Models;

namespace Onlinerecipes.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Recipes()
        {
            using (var dbctx = new Online_RecipeEntities())
            {
                var res = dbctx.categories.Select(o => new Category
                {
                    categoryname = o.categoryname,
                    categoryid=o.categoryid
                });
                return View(res.ToList());
            }
            
        }
        [HttpGet]
        public ActionResult GetRecipes(int categoryid)
        {
            using (var dbctx = new Online_RecipeEntities())
            {
                var res = dbctx.recipes.Where(o=>o.categoryid==categoryid).Select(o => new Recipe
                {
                    categoryid=(int)o.categoryid,
                    recipename = o.recipename,
                    picture = o.picture,
                    description = o.description
                });
                TempData["count"] = res.Count();
                return View(res.ToList());

            }
        }
    }
}