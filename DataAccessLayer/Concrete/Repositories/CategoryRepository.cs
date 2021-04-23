using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        DbSet<Category> _object;

        public void Delete(Category e)
        {
            _object.Remove(e);
            c.SaveChanges();
        }

        public List<Category> GetList()
        {
            return _object.ToList();
        }

        public void Insert(Category e)
        {
            _object.Add(e); //obje ye parametreyi ekle.
            c.SaveChanges();
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Category e)
        {
            c.SaveChanges();
        }
    }
}
