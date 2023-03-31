using Microsoft.Extensions.Options;
using WebAppMVCLesson1.Models;
using WebAppMVCLesson1.NewAdmin.Modals;

namespace WebAppMVCLesson1.Middleware
{
    public class UsePageStatistics
    {
        private EFContext db;
        private RequestDelegate nextDelegate;
        public UsePageStatistics(RequestDelegate nextDelegate)
        {
            this.nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                db = new EFContext();

                PageStatistics pageStat = new PageStatistics();
                pageStat.PathBase = context.Request.PathBase;
                pageStat.Path = context.Request.Path;
                pageStat.CreateDate = DateTime.Now;

                db.PageStatistics.Add(pageStat);
                db.SaveChanges();
            }
            catch
            {
            }

            await nextDelegate.Invoke(context);
        }
    }
}
