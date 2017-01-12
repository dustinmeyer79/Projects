using Dustin.Services.Controllers;
using Restup.Webserver.Http;
using Restup.Webserver.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace WebServer
{
    public sealed class StartupTask : IBackgroundTask
    {
        private HttpServer _httpServer;

        private BackgroundTaskDeferral _deferral;

        /// <remarks>
        /// If you start any asynchronous methods here, prevent the task
        /// from closing prematurely by using BackgroundTaskDeferral as
        /// described in http://aka.ms/backgroundtaskdeferral
        /// </remarks>
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            // This deferral should have an instance reference, if it doesn't... the GC will
            // come some day, see that this method is not active anymore and the local variable
            // should be removed. Which results in the application being closed.
            _deferral = taskInstance.GetDeferral();
            var restRouteHandler = new RestRouteHandler();

            restRouteHandler.RegisterController<LightController>();
            restRouteHandler.RegisterController<StepperController>();

            var configuration = new HttpServerConfiguration()
                .ListenOnPort(8800)
                .RegisterRoute("api", restRouteHandler)
                //.RegisterRoute(new StaticFileRouteHandler(@"Restup.DemoStaticFiles\Web"))
                .EnableCors(); // allow cors requests on all origins
            //  .EnableCors(x => x.AddAllowedOrigin("http://specificserver:<listen-port>"));

            var httpServer = new HttpServer(configuration);
            _httpServer = httpServer;

            await httpServer.StartServerAsync();

            // Dont release deferral, otherwise app will stop
        }
    }
}
