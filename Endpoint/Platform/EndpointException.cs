using Platform.Models;
using System.Reflection;

namespace Platform
{
    public static class EndpointExtention
    {
        public static void MapEndpoint<T>(this IEndpointRouteBuilder app,
            string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if (methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new System.Exception("Method cannot be used");
            }
            T endpointInstance =
            ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

            /*app.MapGet(path, (RequestDelegate)methodInfo
            .CreateDelegate(typeof(RequestDelegate), endpointInstance));*/

            app.MapGet(path, async (context) => {
                using (var scope = app.ServiceProvider.CreateScope())
                {
                    CalculationContext dataContext = scope.ServiceProvider.GetRequiredService<CalculationContext>();
                    // Create an instance of the endpoint class
                    T endpointInstance = ActivatorUtilities.CreateInstance<T>(scope.ServiceProvider);
                    // Invoke the endpoint method
                    object?[] arguments = {
                       context,
                       dataContext
                   };
                    Task task = (Task)methodInfo.Invoke(endpointInstance, arguments);
                    await task.ConfigureAwait(false);
                }
            });
        }
    }
}
