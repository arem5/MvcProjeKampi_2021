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
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetList();
            return View(categoryValues);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResults = categoryValidator.Validate(p); //Burada ValidationResult eklerken dikkat etmek gerekiyor. DataAnatations dan değil FluentVal dan eklememiz gerek. Bunun için NuGetden yüklemeliyiz.

            if (validationResults.IsValid)
            {
                cm.CategoryAddBL(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in validationResults.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//Burada result listesinden error'ları alarak modele ekleriz.
                    //ve bu mesajları view tarafında gösteririz.

                }
            }
            return View();

        }
    }
}