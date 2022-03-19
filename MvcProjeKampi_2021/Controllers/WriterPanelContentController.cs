using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent

        ContentManager contentManager = new ContentManager(new EFContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            int id = c.Writers.Where(x => x.WriterMaile == p).Select(y => y.WriterID).FirstOrDefault();

            var contentValues = contentManager.GetListByWriterId(id);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(string p)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            int id = c.Writers.Where(x => x.WriterMaile == mail).Select(y => y.WriterID).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = id;
            content.ContentStatus = true;
            contentManager.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }



    }
}