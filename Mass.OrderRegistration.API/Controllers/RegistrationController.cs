using AutoMapper;
using Mass.Messaging.MaasTransit;
using Mass.Messaging.RabbitMQ;
using Mass.OrderRegistration.API.Models;
using Mass.Registration.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mass.OrderRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public ServerConfigurationHelper ServerConfigurationHelper { get; set; }

        public BusConfigurator BusConfigurator { get; set; }

        public IMapper Mapper { get; set; }

        public RegistrationController(ServerConfigurationHelper serverConfigurationHelper, BusConfigurator busConfigurator, IMapper mapper)
        {
            ServerConfigurationHelper = serverConfigurationHelper;
            BusConfigurator = busConfigurator;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterOrderCommandModel registerOrderCommandModel)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = ServerConfigurationHelper.GetUri(RegisterOrderConstants.RegisterOrderServiceQueue);

            var endPoint = await bus.GetSendEndpoint(sendToUri);

            var registerOrderCommand = Mapper.Map<RegisterOrder>(registerOrderCommandModel);

            await endPoint.Send(registerOrderCommand);

            return Ok();
        }
    }
}
