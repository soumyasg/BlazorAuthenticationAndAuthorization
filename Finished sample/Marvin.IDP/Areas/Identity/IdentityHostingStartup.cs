using System;
using Wincap.IDP.Areas.Identity.Data;
using Wincap.IDP.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Wincap.IDP.Areas.Identity.IdentityHostingStartup))]
namespace Wincap.IDP.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserDbContextConnection")));

                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<UserDbContext>();

                services.AddIdentity<ApplicationUser, IdentityRole>(options => 
                options.SignIn.RequireConfirmedAccount = true)
                       .AddEntityFrameworkStores<UserDbContext>() 
                       .AddDefaultTokenProviders();

                services.AddTransient<IEmailSender, DummyEmailSender>();
            });
        }
    }
}