using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        
        public List<Category> GetAllBL()
        {
            return repo.GetList();
        }

        public void CategoryAddBL(Category p)
        {
            if (p.CategoryName == "" || p.CategoryName.Length <=3 || p.CategoryName.Length >51 || p.CategoryDescription =="" ) //Gibi bussines lar verilir , ancak urada vermeyeceğiz.
            {
                // Hata sınıfından mesaj yazılacak.
            }
            else
            {
                repo.Insert(p);
            }
        }
    }
}
