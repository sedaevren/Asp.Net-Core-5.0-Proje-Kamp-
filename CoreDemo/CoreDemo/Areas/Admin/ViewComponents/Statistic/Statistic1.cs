using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();
            /* Hava durumu için API'den data çekme işlemi yapılmıştır. */
            string apiID = "22368a82ccdb35f3e6292ec95b59850c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&lang=tr&units=metric&appid=" + apiID;
            XDocument document = XDocument.Load(connection); // direkt xml dataları döner.

            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value; // xmlden değere erişir.
            return View();
        }
    }
}
