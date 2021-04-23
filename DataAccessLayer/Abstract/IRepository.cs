using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>     
        //Bu şekilde Generic bir yapı kullanırız ve N sınıfımız olsa da tek bir haraketle işlemi gerçekleştirirz.
    {
        List<T> GetList();

        void Insert(T e);

        void Update(T e);

        void Delete(T e);

        List<T> GetList(Expression<Func<T, bool>> filter); //Şartlı Listeleme yapar.
    }
}
