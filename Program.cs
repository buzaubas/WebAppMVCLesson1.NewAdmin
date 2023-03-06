using Microsoft.EntityFrameworkCore;
using WebAppMVCLesson1.NewAdmin.DataContext;

var builder = WebApplication.CreateBuilder(args);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//dotnet user-secrets init
//Set UserSecretsId to '8615c9e4-eb13-49ea-ae46-ad8f1d883c46' for MSBuild project 'C:\Users\БексултановД\Desktop\ForDimash\WebAppMVCLesson1.NewAdmin\WebAppMVCLesson1.NewAdmin.csproj'.

