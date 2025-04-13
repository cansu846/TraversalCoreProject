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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _GuideDal;   
        public GuideManager(IGuideDal GuideDal)
        {
            _GuideDal = GuideDal;
        }
        public void TAdd(Guide t)
        {
            _GuideDal.Insert(t);
        }

        public void TDelete(Guide t)
        {
            _GuideDal.Delete(t);
        }

        public Guide TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Guide> TGetList()
        {
           return _GuideDal.GetList();
        }

        public void TUpdate(Guide t)
        {
            _GuideDal.Update(t);    
        }
    }
}
