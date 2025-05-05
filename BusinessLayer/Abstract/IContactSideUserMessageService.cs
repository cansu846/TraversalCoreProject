using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactSideUserMessageService : IGenericService<ContactSideUserMessage> 
    {
        List<ContactSideUserMessage> TGetListByStatusTrue();  
        List<ContactSideUserMessage> TGetListByStatusFalse();  
        List<ContactSideUserMessage> TContactUsChangeStatus(int id);  
    }
    
}
