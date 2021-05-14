using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void HeadingAddBL(Writer heading);
        Writer GetById(int id);
        void HeadingDelete(Writer heading);
        void HeadingUpdate(Writer heading);
    }
}
