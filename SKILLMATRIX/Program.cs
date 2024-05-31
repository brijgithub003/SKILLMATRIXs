using Microsoft.AspNetCore.Authentication.Cookies;
using Oracle.ManagedDataAccess.Client;
using SKILLMATRIX.Repo;
using SKILLMATRIX.Repo.Implementations;
using SKILLMATRIX.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Oracle Connection String 
//Use (Oracle.EntityFrameworkCore) Packeg
//Use (Oracle.ManagedDataAccess.Client) packeg

builder.Services.AddDbContext<ApplicationDbContext>(options =>
		options.UseOracle(builder.Configuration.GetConnectionString("KMLG")));

#endregion

#region Json Serializer
//Json Serializer service add for convert to data json fromate (Newtonsoft.Json.Serialization)
builder.Services.AddControllersWithViews()
	   .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

#endregion

#region Interface and Implementation
//DI for services
//builder.Services.AddScoped<Interface, Implementation>();

builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IEducationRepo, EducationRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<ILineRepo, LineRepo>();
builder.Services.AddScoped<ILoginRepo, LoginRepo>();
builder.Services.AddScoped<IPlantRepo, PlantRepo>();
builder.Services.AddScoped<ISkillRepo, SkillRepo>();
builder.Services.AddScoped<IStationRepo, StationRepo>();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddRazorPages();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Account/Login";
//        options.AccessDeniedPath = "/Account/AccessDenied";
//    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
