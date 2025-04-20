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
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUser;   
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUser = appUserDal;
        }
        public void TAdd(AppUser t)
        {
            _appUser.Insert(t);
        }

        public void TDelete(AppUser t)
        {
            _appUser.Delete(t);
        }

        public AppUser TGetById(int id)
        {
            return _appUser.GetById(id);
        }

        public List<AppUser> TGetList()
        {
           return _appUser.GetList();
        }

        public void TUpdate(AppUser t)
        {
            _appUser.Update(t);    
        }
    }
}
