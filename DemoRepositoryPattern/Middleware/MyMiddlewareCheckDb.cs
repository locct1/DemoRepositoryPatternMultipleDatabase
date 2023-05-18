using DemoRepositoryPattern.LibraryDbProvider;

namespace DemoRepositoryPattern.Middleware
{
    public class MyMiddlewareCheckDb
    {
        private readonly RequestDelegate _next;
        public MyMiddlewareCheckDb(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

        }

        public async Task Invoke(HttpContext httpContext)
        {
            Type T = Type.GetType($"DemoRepositoryPattern.LibraryDbProvider.DbProvider.{GetStringAppsetting.DatabaseDefault()}");
            if (T is null)
            {
                await Task.Run(
                async () =>
                {
                    string html = "<h1>Config DatabaseDefault trong appsettings.json khong dung, cac database ho tro la :SqlServer, MySQL, PostGreSQL</h1>";
                    httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await httpContext.Response.WriteAsync(html);
                }
                );
            }
            else
            {
                await _next(httpContext); // calling next middleware
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddlewareCheckDb(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddlewareCheckDb>();
        }
    }
}
