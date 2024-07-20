using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Booking.Api.Options;
using Booking.DataAccess;
using Microsoft.EntityFrameworkCore;
using Booking.Domain.Abstraction.Services;
using Booking.Services.Services;
using Booking.DataAccess.Repositories;
using Booking.Domain.Abstraction.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Booking.Api;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}