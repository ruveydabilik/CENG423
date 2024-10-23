namespace Platform.Services
{
    public interface IResponseFormatter
    {
        Task Format(HttpContext httpContext, string content);
    }
}
