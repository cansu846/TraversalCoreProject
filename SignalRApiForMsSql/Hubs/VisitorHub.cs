using Microsoft.AspNetCore.SignalR;
using SignalRApiForMsSql.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SignalRApiForMsSql.Hubs
{
    public class VisitorHub:Hub
    {
        private readonly VisitorService _visitorService;    
        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;   
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitorList","veri girişi yapılacak");
        }
    }
}
