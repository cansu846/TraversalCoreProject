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
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterDal _newsletterDal;   
        public NewsletterService(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }
        public void TAdd(Newsletter t)
        {
            _newsletterDal.Insert(t);
        }

        public void TDelete(Newsletter t)
        {
            _newsletterDal.Delete(t);
        }

        public Newsletter TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newsletter> TGetList()
        {
           return _newsletterDal.GetList();
        }

        public void TUpdate(Newsletter t)
        {
            _newsletterDal.Update(t);    
        }
    }
}
