using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{//Bütün sınıflarda geçerli Repository mimarisi kuruldu.Tek Tek yapmak zorunda değiliz.
    public class GenericRepository<T> : IRepository<T> where T : class //sana gelen T değeri class olmalı
    {
        Context c = new Context();
        DbSet<T> _object;   //T değerine karşılık gelen sınıfı tutar.
        //Constructur ile objeye değer ataması yapmalıyız.

        public GenericRepository()
        {
            _object = c.Set<T>();   //Context e bağlı T değerini Set eder.
        }

        public void Delete(T e)
        {
            var deletedEntity = c.Entry(e);
            deletedEntity.State = EntityState.Deleted;
            // _object.Remove(e);   işlemi Entity state üzerinden gerçekleştirildi.
            c.SaveChanges();
        }

        public List<T> GetList() => _object.ToList();


        public void Insert(T e)
        {
            var addedEntity = c.Entry(e);
            addedEntity.State = EntityState.Added; 
            // _object.Add(e);  Ekleme işlemi Entity state üzerinden gerçekleştirildi.
            c.SaveChanges();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter) => _object.Where(filter).ToList();


        public void Update(T e)
        {
            var updatedEntity = c.Entry(e);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter) => _object.SingleOrDefault(filter);
        
        
    }
}
