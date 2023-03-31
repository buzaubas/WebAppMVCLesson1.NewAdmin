namespace WebAppMVCLesson1.NewAdmin.Middleware
{
    public class EMiddleware
    {
        RequestDelegate nextDelegate;

        public EMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            //Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; WOW64; Trident/6.0)

            try
            {
                var userAgent = context.Request.Headers["User-Agent"].ToString();

                if (userAgent.Contains("Edge"))
                    //context.Response.WriteAsync("You are using outdated browser");
                    context.Response.Redirect("/Home/Wrong");
                else
                    await nextDelegate.Invoke(context);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
