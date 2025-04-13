using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByAccepted(int userId)
        {
            using (var context = new Context())
                //Inclu kullanılmasının sebebi, ilişkili olan Detination tablosunun verilerini alabilmektir. Kullanılmazsa veri null geliyor.
                //Include ile Eager (onceden) yukleme yapılır
            {
               return context.Reservations.Include(x=>x.Destination).Where(x=>x.Status=="Onaylandı" && x.AppUserId==userId).ToList();
            };

        }

        public List<Reservation> GetListWithReservationByApproval(int userId)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == userId).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int userId)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == userId).ToList();
            }
        }
    }
}
