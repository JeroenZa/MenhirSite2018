using System.Web;

namespace MenhirSite.App_Data
{
    public class OptionsModule : IHttpModule
    {
        public void Init(HttpApplication context) => context.BeginRequest += (sender, args) =>
        {
            var app = (HttpApplication)sender;

            if (app.Request.HttpMethod == "OPTIONS")
            {
                app.Response.StatusCode = 200;
                app.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
                app.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
                app.Response.AddHeader("Access-Control-Allow-Credentials", "true");
                app.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                app.Response.AddHeader("Content-Type", "application/json");
                app.Response.End();
            }
        };

        public void Dispose()
        {
        }
    }
}