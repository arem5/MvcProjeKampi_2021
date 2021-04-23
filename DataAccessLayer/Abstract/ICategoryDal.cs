using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepository<Category> //Kurumsalda böyle kullanılır.
    {

    }


}
//public interface ICategoryDal   //Kurumsal mimaride bu şekilde kullanılmaz.
//{
//    //CRUD işlemlerini method olarak tanımlarız. 

//    List<Category> GetList();

//    void Insert(Category e);

//    void Update(Category e);

//    void Delete(Category e);

//}