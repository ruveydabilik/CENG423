namespace Platform.Services
{
    public class TextOneResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        public async Task Format(HttpContext httpContext, string content)
        {
            await httpContext.Response.WriteAsync($"Response {++responseCounter}: \n {content}");
        }
    }
}
