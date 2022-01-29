using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal _writerDal)
        {
            this._writerDal = _writerDal;
        }

        public Writer GetById(int id) => _writerDal.Get(x => x.WriterID == id);


        public List<Writer> GetList() => _writerDal.GetList();


        public void WriterAdd(Writer writer) =>  _writerDal.Insert(writer);
        

        public void WriterDelete(Writer writer) =>     _writerDal.Delete(writer);

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
