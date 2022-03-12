using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            int id = c.Writers.Where(x => x.WriterMaile == p).Select(y => y.WriterID).FirstOrDefault();
            
            var contentValues = contentManager.GetListByWriterId(id);
            return View(contentValues);
        }
    }
}