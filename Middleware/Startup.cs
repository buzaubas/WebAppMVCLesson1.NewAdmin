namespace WebAppMVCLesson1.NewAdmin.Middleware
{
    public class Startup
    {
        RequestDelegate nextDelegate;
        public void Configure(IApplicationBuilder app, IHostEnvironment hostEnvironment, HttpContext context)
        {
            app.Map("/path1", branch =>
            {
                branch.Run(async context =>
                {
                    string path = context.Request.Path.ToString();
                    string pathBase = context.Request.PathBase;
                    await context.Response.WriteAsync($"Path: {path} PathBase: {pathBase}");
                });
            });
        }

        public async Task Invoke(HttpContext context)
        {
            if(userCount > 5)
            {
                context.Response.WriteAsync("Wait a minute");
            }
            else
                nextDelegate(context);
        }
    }
}
