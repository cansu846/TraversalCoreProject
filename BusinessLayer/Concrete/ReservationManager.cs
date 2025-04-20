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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        //public List<Reservation> GetListApprovalReservation(int userId)
        //{
        //    return _reservationDal.GetListByFilter(x=>x.AppUserId==userId && x.Status=="Onay Bekliyor");

        //}
        public List<Reservation> GetReservationListByUserId(int userId)
        {
            return _reservationDal.GetReservationListByUserId(userId);
        }
        public List<Reservation> GetListWithReservationByAccepted(int userId)
        {
            return _reservationDal.GetListWithReservationByAccepted(userId);
        }

        public List<Reservation> GetListWithReservationByApproval(int userId)
        {
            return _reservationDal.GetListWithReservationByApproval(userId);
        }

        public List<Reservation> GetListWithReservationByPrevious(int userId)
        {
            return _reservationDal.GetListWithReservationByPrevious(userId);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TGetById(int id)
        {
           return  _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
            return _reservationDal.GetList();
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
