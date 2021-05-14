using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        HeadingManager hm = new HeadingManager(new EFHeadingDal());

        WriterManager wm = new WriterManager(new EFWriterDal());

        // GET: Statistics
        public ActionResult Index()
        {
            var CatList = cm.GetList();
            ViewBag.CatCount = CatList.Count();
            var CatTrue = CatList.Where(x => x.CategoryStatus == true).Count();
            var CatFalse = CatList.Where(x => x.CategoryStatus == false).Count();
            ViewBag.CatDiff = CatTrue - CatFalse;

            var HeadingList = hm.GetList();
            ViewBag.KitapCount = HeadingList.Count(x => x.CategoryId == 3);

            ViewBag.WriterNameWithA = wm.GetList().Where(x => x.WriterName.Contains('a')).Count();

            ViewBag.mostReapetedHeading = CatList.Where(u => u.CategoryId == (HeadingList.GroupBy(x => x.CategoryId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            return View();
        }
    }
}

/*
 * 1) Toplam kategori sayısı
2) Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
3) Yazar adında 'a' harfi geçen yazar sayısı
4) En fazla başlığa sahip kategori adı
5) Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
*/