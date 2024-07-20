namespace Booking.Api.Middleware;

public class DateTimeHeader
{
    
    private readonly RequestDelegate _next;

    public DateTimeHeader(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        httpContext.Request.Headers.Add("My Header", DateTime.Now.ToString());
        await _next(httpContext);
    }
    
    public static class DateTimeHeaderExtensions
    {
        public static IApplicationBuilder UseDateTimeHeader(IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateTimeHeader>();
        }
    }

}