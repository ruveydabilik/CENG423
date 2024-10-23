using Microsoft.Extensions.Caching.Distributed;
using Platform.Services;
using Platform.Models;

namespace Platform
{
    public class SumEndpoint
    {
        public async Task Endpoint(HttpContext context, CalculationContext calculationContext)
        {
            int count;
            int.TryParse((string?)context.Request.RouteValues["count"], out count);
            long total = calculationContext.Calculations?.FirstOrDefault(c =>
            c.Count == count)?.Result ?? 0;
            if (total == 0) {
                for (int i = 1; i <= count; i++)
                {
                    total += i;
                }
                calculationContext.Calculations?.Add(new()
                {
                    Count = count,
                    Result = total
                        
                });
                await calculationContext.SaveChangesAsync();
            }
           
            string totalString = $"({DateTime.Now.ToLongTimeString()}) {total}";

            await context.Response.WriteAsync(
            $"({DateTime.Now.ToLongTimeString()}) Total for {count}"
            + $" values:\n{totalString}\n" );
        }
    }
}