using Dustin.GPIO;
using Dustin.Services.Model;
using Restup.Webserver.Attributes;
using Restup.Webserver.Models.Contracts;
using Restup.Webserver.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dustin.Services.Controllers
{
    [RestController(InstanceCreationType.Singleton)]
    public class LightController
    {
        [UriFormat("/light/{id}/state/{state}")]
        public IGetResponse GetWithSimpleParameters(int id, string state)
        {
            return new GetResponse(
                GetResponse.ResponseStatus.OK,
                new LightDataReceived()
                {
                    Id = id,
                    State = state
                });
        }

        [UriFormat("/light/state/on")]
        public IPostResponse TurnOn()
        {
            //Call GPIO Service
            var light = new Light();
            light.TurnOn();

            return new PostResponse(PostResponse.ResponseStatus.Created);
        }

        [UriFormat("/light/state/off")]
        public IPostResponse TurnOff()
        {
            //Call GPIO Service
            var light = new Light();
            light.TurnOff();

            return new PostResponse(PostResponse.ResponseStatus.Created);
        }
    }
}
