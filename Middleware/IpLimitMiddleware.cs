using System.Net;
using System.Net.Sockets;

namespace WebAppMVCLesson1.NewAdmin.Middleware
{
    public class IpLimitMiddleware
    {
        RequestDelegate nextDelegate;
        IPAddress Ip;

        public IpLimitMiddleware(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var ip = GetLocalIPAddress();

                if (ip.Contains("192.168.111.28"))
                    context.Response.WriteAsync("Get out of here");
                else
                    nextDelegate(context);
            }
            catch (Exception ex)
            {
                nextDelegate(context);
            }  
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }

    public static class IpLimitMiddlewareExtension
    {
        public static IApplicationBuilder UseIpLimit(this IApplicationBuilder app)
        {
            return app.UseMiddleware<IpLimitMiddleware>();
        }
    }
}
