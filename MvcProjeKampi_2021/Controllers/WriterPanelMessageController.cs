using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi_2021.Controllers
{
    public class WriterPanelMessageController : Controller
    {

        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator messageVal = new MessageValidator();

        // GET: WriterPanelMessage
        
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(mail);
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = mm.GetListSendbox(mail);
            return View(messageList);
        }


        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }


        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageVal.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.SenderMail = (string)Session["WriterMail"];
                mm.MessageAddBL(message);
                return RedirectToAction("Sendbox");
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

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}