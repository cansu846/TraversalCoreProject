using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByAccepted(int userId);
        List<Reservation> GetListWithReservationByPrevious(int userId);
        List<Reservation> GetListWithReservationByApproval(int userId);
    }
}
