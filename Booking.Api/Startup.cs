using Booking.DataAccess.Repositories;
using Booking.DataAccess;
using Booking.Domain.Abstraction.Services;
using Booking.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Booking.Domain.Abstraction.Repositories;

namespace Booking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CwkBooking.Api", Version = "v1" });
            });
            services.AddHttpContextAccessor();

            var cs = Configuration.GetConnectionString("Default");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(cs));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IReservationService, ReservationService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CwkBooking.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseDateTimeHeader();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
