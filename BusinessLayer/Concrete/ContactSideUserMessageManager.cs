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
    public class ContactSideUserMessageManager: IContactSideUserMessageService
    {
        private readonly IContactSideUserMessageDal _contactSideUserMessageDal;   
        public ContactSideUserMessageManager(IContactSideUserMessageDal contactSideUserMessageDal)
        {
            _contactSideUserMessageDal = contactSideUserMessageDal;
        }

        public void TAdd(ContactSideUserMessage t)
        {
            _contactSideUserMessageDal.Insert(t);

        }

        public List<ContactSideUserMessage> TContactUsChangeStatus(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ContactSideUserMessage t)
        {
            _contactSideUserMessageDal.Delete(t);
        }

        public ContactSideUserMessage TGetById(int id)
        {
           return _contactSideUserMessageDal.GetById(id);
        }

        public List<ContactSideUserMessage> TGetList()
        {
            return _contactSideUserMessageDal.GetList();
        }

        public List<ContactSideUserMessage> TGetListByStatusFalse()
        {
            return _contactSideUserMessageDal.GetListByStatusFalse();
        }

        public List<ContactSideUserMessage> TGetListByStatusTrue()
        {
           return _contactSideUserMessageDal.GetListByStatusTrue(); 
        }

        public void TUpdate(ContactSideUserMessage t)
        {
           _contactSideUserMessageDal.Update(t);
        }
    }
}
