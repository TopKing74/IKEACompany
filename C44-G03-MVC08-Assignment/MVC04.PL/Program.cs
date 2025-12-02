using MailKit;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVC04.BLL.Common.MappingProfiles;
using MVC04.BLL.Common.Services.Attachment;
using MVC04.BLL.Services.DepartmentServ;
using MVC04.BLL.Services.EmployeeServ;
using MVC04.DAL.Contexts;
using MVC04.DAL.Models.Auth;
using MVC04.DAL.Models.Employee;
using MVC04.DAL.Reposatories.DepartmentRepos;
using MVC04.DAL.Reposatories.EmployeeRepos;
using MVC04.DAL.UOW;
using MVC04.PL.Helper;
using MVC04.PL.Settings;

namespace MVC04.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAttachmentServices, AttachmentServices>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddAutoMapper(M=> M.AddMaps(typeof(ProjectMapperProfile).Assembly));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
            {
                options.Password.RequiredLength=8;
                options.User.RequireUniqueEmail=false;
            })
           .AddEntityFrameworkStores<ApplicationDbContext>()
           .AddDefaultTokenProviders();
            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
            //{
            //    options.LoginPath="/Account/Login";
            //    options.AccessDeniedPath="/Account/AccessDenied";
            //    options.ExpireTimeSpan= TimeSpan.FromHours(1);
            //});

           #region Mail
            builder.Services.Configure<MailSettings>(
        builder.Configuration.GetSection("MailSettings")
        ); 
            #endregion

            #region Twilio
            builder.Services.Configure<SMSSetting>(
                 builder.Configuration.GetSection("Twilio")
             ); 
            #endregion
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddTransient<ISMSService, SMSService>();
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            }).AddGoogle(o =>
            {
                IConfiguration GoogleAuthentication = builder.Configuration.GetSection("Authentication:Google");
                o.ClientId = GoogleAuthentication["ClientId"];
                o.ClientSecret = GoogleAuthentication["ClientSecret"];
            });

             var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
