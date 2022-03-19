using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi_2021.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }     
        
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x=>x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (adminUserInfo !=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Context c = new Context();
            var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMaile == writer.WriterMaile && x.WriterPassword == writer.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMaile, false);
                Session["WriterMail"] = writerUserInfo.WriterMaile;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }
    }
}