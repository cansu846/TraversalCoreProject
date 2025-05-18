using DataAccessLayer.Abstract.AbstractUnitOfWork;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository.RepositoryUnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework.EfUnitOfWork
{
    public class EfAccountDal : GenericUowRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context) : base(context)
        {
        }
    }
}
