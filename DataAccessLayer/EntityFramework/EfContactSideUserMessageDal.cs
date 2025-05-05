using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactSideUserMessageDal : GenericRepository<ContactSideUserMessage>, IContactSideUserMessageDal
    {
        Context context = new Context();
        public List<ContactSideUserMessage> ContactUsChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactSideUserMessage> GetListByStatusFalse()
        {
            
            return context.ContactSideUserMessages.Where(x=>x.MessageStatus==false).ToList();
        }

        public List<ContactSideUserMessage> GetListByStatusTrue()
        {
            return context.ContactSideUserMessages.Where(x => x.MessageStatus == true).ToList();
        }
    }
}
