using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }


        public ActionResult MyHeading()
        {
            var values = hm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = ValueCategory();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.HeadingStatus = true;
            h.WriterID = 3;
            hm.HeadingAddBL(h);
            return RedirectToAction("MyHeading");
        }

        public ActionResult EditHeading(int id)
        {
            ViewBag.vlc = ValueCategory();
            var Headingvalue = hm.GetById(id);
            return View(Headingvalue);

        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }



        private List<SelectListItem> ValueCategory()
        {
            return (from x in cm.GetList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString()
                    }).ToList();
        }
    }
}