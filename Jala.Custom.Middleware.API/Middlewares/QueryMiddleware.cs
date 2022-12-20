namespace Jala.Custom.Middleware.API.Middlewares;


public class QueryMiddleware
{

    private readonly RequestDelegate _next;
    
    public QueryMiddleware(RequestDelegate next)
    {

        _next = next;

    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        ParamHandler(context);
        await _next(context);
    }


    public void ParamHandler(HttpContext context)
    {
        if (context.Request.QueryString.HasValue)
            Console.WriteLine(context.Request.QueryString.Value);
    }
}

public static class QueryMiddlewareClass
{
    public static IApplicationBuilder UseQueryParamsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<QueryMiddleware>();
    }
    
}