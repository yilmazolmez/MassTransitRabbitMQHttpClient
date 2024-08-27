using MassTransit;
using MassTransitMessage.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MassTransitMessage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageSendtController : ControllerBase
    {
        private readonly IRequestClient<IMessageCommand> _requestClient;

        //private readonly ISendEndpointProvider _endpointProvider;


        public MessageSendtController(
            //ISendEndpointProvider endpointProvider
            IRequestClient<IMessageCommand> requestClient
            )
        {
            //_endpointProvider = endpointProvider;
            _requestClient = requestClient;
        }

        [HttpGet(Name = "SendTraceId")]
        public async Task<IActionResult> SendTraceId([FromQuery] string traceId)
        {
            //ISendEndpoint sendEndpoint;

            //sendEndpoint = await _endpointProvider.GetSendEndpoint(new Uri($"queue:MessageConsumerQueue"));

            //await sendEndpoint.Send<IMessageCommand>(new MessageCommand() { TraceId = traceId });


            var response = await _requestClient.GetResponse<MessageCommandResponse>(new MessageCommand() { TraceId = traceId });

            return Ok(response);
        }
    }
}
