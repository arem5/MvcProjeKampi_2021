using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());

        public ActionResult Headings()
        {
            var headingList = hm.GetList();
            return View(headingList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentList = cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }


    }
}