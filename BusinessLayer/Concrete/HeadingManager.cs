using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;        

        public HeadingManager(IHeadingDal _headingDal)
        {
            this._headingDal = _headingDal;
        }

        public Heading GetById(int id) => _headingDal.Get(x => x.HeadingId == id);


        public List<Heading> GetList()=> _headingDal.GetList();

        public void HeadingAddBL(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void HeadingDelete(Heading heading)
        {
            throw new NotImplementedException();
        }

        public void HeadingUpdate(Heading heading)
        {
            throw new NotImplementedException();
        }

    }
}
