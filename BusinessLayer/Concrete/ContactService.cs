﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IContactDal _contactDal;   
        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void TAdd(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> TGetList()
        {
           return _contactDal.GetList();
        }
        
        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);    
        }

    }
}
