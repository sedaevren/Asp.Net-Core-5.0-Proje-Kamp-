using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> cityList = new List<SelectListItem>() {
                new SelectListItem {
                    Text = "İstanbul", Value = "1"
                },
                new SelectListItem {
                    Text = "Ankara", Value = "2"
                },
                new SelectListItem {
                    Text = "İzmir", Value = "3"
                },
            };
            ViewData["CityList"] = cityList;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            //Eklemeden önce fluent validationlar doğru mu kontrol et.
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.TAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
