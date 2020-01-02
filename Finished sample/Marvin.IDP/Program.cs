// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using Wincap.IDP.Areas.Identity.Data;
using Wincap.IDP.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Linq;
using System.Security.Claims;

namespace Wincap.IDP
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                // uncomment to write to Azure diagnostics stream
                //.WriteTo.File(
                //    @"D:\home\LogFiles\Application\identityserver.txt",
                //    fileSizeLimitBytes: 1_000_000,
                //    rollOnFileSizeLimit: true,
                //    shared: true,
                //    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate)
                .CreateLogger();

            try
            {
                Log.Information("Starting host...");
                var host = CreateHostBuilder(args).Build();

                // seed the database.  Best practice = in Main, using service scope
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var context = scope.ServiceProvider.GetService<UserDbContext>();

                        // ensure the DB is migrated before seeding
                        context.Database.Migrate();

                        // use the user manager to create test users
                        var userManager = scope.ServiceProvider
                            .GetRequiredService<UserManager<ApplicationUser>>();

                        var rich = userManager.FindByNameAsync("Rich").Result;
                        if (rich == null)
                        {
                            rich = new ApplicationUser
                            {
                                UserName = "Rich",
                                EmailConfirmed = true
                            };

                            var result = userManager.CreateAsync(rich, "P@ssword1").Result;
                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }

                            result = userManager.AddClaimsAsync(rich, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Rich Gonyea"),
                                new Claim(JwtClaimTypes.GivenName, "Rich"),
                                new Claim(JwtClaimTypes.FamilyName, "Gonyea"),
                                new Claim(JwtClaimTypes.Email, "rich@email.com"),
                                new Claim("country", "BE")
                            }).Result;

                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }
                        }

                        var soumya = userManager.FindByNameAsync("Soumya").Result;
                        if (soumya == null)
                        {
                            soumya = new ApplicationUser
                            {
                                UserName = "Soumya",
                                EmailConfirmed = true
                            };

                            var result = userManager.CreateAsync(soumya, "P@ssword1").Result;
                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }

                            result = userManager.AddClaimsAsync(soumya, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Soumya Sengupta"),
                                new Claim(JwtClaimTypes.GivenName, "Soumya"),
                                new Claim(JwtClaimTypes.FamilyName, "Sengupta"),
                                new Claim(JwtClaimTypes.Email, "soumya@email.com"),
                                new Claim("country", "US")
                            }).Result;

                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }
                        }

                        var tony = userManager.FindByNameAsync("Tony").Result;
                        if (tony == null)
                        {
                            tony = new ApplicationUser
                            {
                                UserName = "Tony",
                                EmailConfirmed = true
                            };

                            var result = userManager.CreateAsync(tony, "P@ssword1").Result;
                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }

                            result = userManager.AddClaimsAsync(tony, new Claim[]{
                                new Claim(JwtClaimTypes.Name, "Tony Carganilla"),
                                new Claim(JwtClaimTypes.GivenName, "Tony"),
                                new Claim(JwtClaimTypes.FamilyName, "Carganilla"),
                                new Claim(JwtClaimTypes.Email, "tony@email.com"),
                                new Claim("country", "NL")
                            }).Result;

                            if (!result.Succeeded)
                            {
                                throw new Exception(result.Errors.First().Description);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }

                // run the web app
                host.Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });
    }
}