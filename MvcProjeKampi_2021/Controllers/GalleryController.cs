using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    public class GalleryController : Controller
    {

        ImageFileManager im = new ImageFileManager(new EFImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}