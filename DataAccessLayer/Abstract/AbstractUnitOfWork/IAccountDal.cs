using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.AbstractUnitOfWork
{
    public interface IAccountDal:IGenericUowDal<Account>
    {

    }
}
