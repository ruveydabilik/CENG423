using Microsoft.AspNetCore.Routing;
using System.Reflection;

namespace Platform.Services
{
    public static class EndpointExtention
    {

        public static void MapWeather<T>(this IEndpointRouteBuilder endpointRouteBuilder, string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new System.Exception("Method cannot be used");
            }
            T endpoint = ActivatorUtilities.CreateInstance<T>(endpointRouteBuilder.ServiceProvider);
            IResponseFormatter formatter = endpointRouteBuilder.ServiceProvider.GetRequiredService<IResponseFormatter>();
            endpointRouteBuilder.MapGet(path, (RequestDelegate)methodInfo.CreateDelegate(typeof(RequestDelegate), endpoint));
            //endpointRouteBuilder.MapGet(path, context => WeatherEndpoint.Endpoint(context, formatter));
        }

    }
}
