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
        IHeadingDal _headingDal;        //

        public HeadingManager(IHeadingDal _headingDal)
        {
            this._headingDal = _headingDal;
        }

        public Heading GetById(int id) => _headingDal.Get(x => x.HeadingId == id);


        public List<Heading> GetList() => _headingDal.GetList();

        public List<Heading> GetList(int id) => _headingDal.GetList(x => x.WriterID == id);


        public void HeadingAddBL(Heading heading) => _headingDal.Insert(heading);


        public void HeadingDelete(Heading heading) => _headingDal.Update(heading);


        public void HeadingUpdate(Heading heading) => _headingDal.Update(heading);

    }
}
