namespace Jala.Custom.Middleware.API.Middlewares;

public class ParamsMiddleware
{

    private readonly RequestDelegate _next;
    
    public ParamsMiddleware(RequestDelegate next)
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
        if (context.Request.Path.HasValue && context.Request.Path.Value.Contains("WeatherForecast"))
            Console.WriteLine("Yes");
    }
}

public static class ParamsMiddlewareClass
{
    public static IApplicationBuilder UseParamsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ParamsMiddleware>();
    }
    
}