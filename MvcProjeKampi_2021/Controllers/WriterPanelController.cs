using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
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

        Context c = new Context();
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        int sessionWriterId;

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            sessionWriterId = c.Writers.Where(x => x.WriterMaile == p).Select(y => y.WriterID).FirstOrDefault();
            var values = hm.GetList(sessionWriterId);

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
            string p = (string)Session["WriterMail"];
            sessionWriterId = c.Writers.Where(x => x.WriterMaile == p).Select(y => y.WriterID).FirstOrDefault();
            h.WriterID = sessionWriterId;
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


        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetById(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
        
        public ActionResult AllHeading(int page = 1)
        {
            var headingsAllValues = hm.GetList().ToPagedList(page, 7);
            return View(headingsAllValues);
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