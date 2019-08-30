using MyNewSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MyNewSite.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayAll()
        {

            using (var dbctx = new MVCEntities())
            {
                var res = dbctx.tbl_site.Select(o => new Mysite
                {
                    username=o.username,
                    city=o.city,
                    state=o.state,
                    country=o.country

                });
                return View(res.ToList());
            } ;
           
        }
        [HttpGet]
        public ActionResult Display()
        {

            List<string> dd;
                using (var dbctx = new MVCEntities())
                {
                    dd = new List<string>();
                    var res = dbctx.tbl_site.Select(o => o.username);
                 
                    foreach(string item in res)
                    {
                        dd.Add(item);
                    }   
                }
            
            Mysite ms = new Mysite
            {
                usernames = new SelectList(dd)
            };

            return View(ms);
        }
        [HttpPost]
        public ActionResult GetDetails(string username)
        {
            using (var dbctx = new MVCEntities())
            {
                var res = dbctx.tbl_site.Where(o => o.username == username).Select(o=>new Mysite
            
                {
                    username = o.username,
                    city = o.city,
                    state = o.state,
                    country = o.country
                }).SingleOrDefault() ;
                return View(res);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Insertdetails(Mysite ms)
        {
            using (var dbctx = new MVCEntities())
            {
                dbctx.tbl_site.Add(new tbl_site
                {
                    username = ms.username,
                    city = ms.city,
                    state = ms.state,
                    country = ms.country
                });
                 dbctx.SaveChanges();
            }
            

            return RedirectToAction("DisplayAll");

        }
    }
}