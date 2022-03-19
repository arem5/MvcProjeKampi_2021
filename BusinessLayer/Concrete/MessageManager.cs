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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id) => _messageDal.Get(x=>x.MessageId == id);

        public List<Message> GetListInbox(string mail) => _messageDal.GetList(x => x.ReceiverMail == mail);

        public List<Message> GetListSendbox(string mail) => _messageDal.GetList(x => x.SenderMail == mail);

        public void MessageAddBL(Message message) => _messageDal.Insert(message);

        public void MessageDelete(Message message) => _messageDal.Delete(message);

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
