namespace Platform.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        public async Task Format(HttpContext httpContext, string content)
        {
            httpContext.Response.ContentType = "text/html";
            await httpContext.Response.WriteAsync($@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head><title>Response</title></head>
                <body>
                    <h2>Formatted Response From Betul</h2>
                    <span>{content}</span>
                </body>
                </html>"
                );
        }
    }
}
