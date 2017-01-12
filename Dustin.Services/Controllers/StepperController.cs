using Dustin.GPIO;
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
    [RestController(InstanceCreationType.PerCall)]
    public class StepperController
    {
        [UriFormat("/stepper/steponce/{id}")]
        public async Task<IPostResponse> RotateOneStepAsync(int id)
        {
            var stepper = await Stepper.Create();
            stepper.RotateOneStep(id);
            return new PostResponse(PostResponse.ResponseStatus.Created);
        }

        [UriFormat("/stepper/release/{id}")]
        public IPostResponse Release(int id)
        {
            var stepper = Stepper.Create();
            //stepper.Release(id);
            return new PostResponse(PostResponse.ResponseStatus.Created);
        }
    }
}
