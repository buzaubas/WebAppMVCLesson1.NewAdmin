using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Sinks.MSSqlServer;
using WebAppMVCLesson1.NewAdmin.DataContext;
using WebAppMVCLesson1.NewAdmin.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

int userCount = 0;

//var columnOptions = new ColumnOptions
//{
//    AdditionalColumns = new Collection<SqlColumn>
//    {
//        new SqlColumn("UserName", System.Data.SqlDbType.VarChar),
//        new SqlColumn("IP", System.Data.SqlDbType.VarChar)
//    }
//};

//Log.Logger = new LoggerConfiguration()
//                    .WriteTo.Seq("http://localhost:5341/")
//                    .WriteTo.Debug(new RenderedCompactJsonFormatter())
//                    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
//                    .WriteTo.MSSqlServerbuilder.Configuration["ConnectionStrings:DefaultConnection"], sinkOptionsSection: new MSSqlServerSinkOptions { TableName = "Log"}, null, null, LogEventLevel.Information, null, columnOptions, null, null)
//                    .CreateLogger();

//builder.Host.ConfigureLogging(logingBuilder => {
//    logingBuilder.ClearProviders();
//    /*logingBuilder.AddSeq()*/;
//                    //.AddDebug().AddEventLog().AddConsole();
//});



// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddUserSecret<Program>();
//builder.addusersecrets<Program>();

var test = builder.Configuration["Movies:ServiceApiKey"];
builder.Services.AddDbContext<WebAppMVCLesson1DbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));//with secret


//builder.Services.AddDbContext<WebAppMVCLesson1DbContext>(options =>
//options.UseSqlServer(builder
//.Configuration
//.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<IpLimitMiddleware>();

app.UseMiddleware<EMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//dotnet user-secrets init
//Set UserSecretsId to '8615c9e4-eb13-49ea-ae46-ad8f1d883c46' for MSBuild project 'C:\Users\БексултановД\Desktop\ForDimash\WebAppMVCLesson1.NewAdmin\WebAppMVCLesson1.NewAdmin.csproj'.

