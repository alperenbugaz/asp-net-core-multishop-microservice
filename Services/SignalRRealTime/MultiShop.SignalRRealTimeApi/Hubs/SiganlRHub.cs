using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        //private readonly ISignalRMessageService _signalRSMessageervice;

        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRMessageService signalRMessageService, ISignalRCommentService signalRCommentService)
        {
            //_signalRSMessageervice = signalRMessageService;
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            //var getTotlaMessageCount = await _signalRSMessageervice.GetTotalMessageCountByReceiverId(id);
            var getCommentCount = await _signalRCommentService.GetCommentCount();
            await Clients.All.SendAsync("ReceiveStatisticCount",  getCommentCount);
            //await Clients.All.SendAsync("ReceiveMessage", getTotalMessageCount);
        }
    }
}
