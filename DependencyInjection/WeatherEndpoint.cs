using DependencyInjection.Services;

namespace DependencyInjection
{
    public class WeatherEndpoint
    {
        private IResponseFormatter formatter;
        //public static async Task Endpoint(HttpContext context)

        public WeatherEndpoint(IResponseFormatter responseFormatter)
        {
            formatter = responseFormatter;
        }

        public async Task Endpoint(HttpContext context)
        {
            //await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
            
            /*IResponseFormatter formatter =context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");*/

            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}
