using DependencyInjection.Services;

namespace DependencyInjection
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private IResponseFormatter formatter;

        public WeatherMiddleware(RequestDelegate nextDelegate, IResponseFormatter respFormatter)
        {
            next = nextDelegate;
            formatter = respFormatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/middleware/class")
            {
                //await context.Response.WriteAsync("Middleware Class: It is raining in London");
                await formatter.Format(context, "Middleware Class: It is raining in London");
            }
            else
            {
                await next(context);
            }
        }
    }
}
