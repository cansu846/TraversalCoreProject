using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation> 
    {
        //List<Reservation> GetListApprovalReservation(int userId);
        List<Reservation> GetListWithReservationByAccepted(int userId);
        List<Reservation> GetListWithReservationByPrevious(int userId);
        List<Reservation> GetListWithReservationByApproval(int userId);
        List<Reservation> GetReservationListByUserId(int userId);
    }
    
}
