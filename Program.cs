using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using AirTravels.Repository;

namespace AirTravels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<IPassangerRepository, PassangerRepository>();
            builder.Services.AddScoped<IPropertyRepository<City>, CityRepository>();
            builder.Services.AddScoped<IPropertyRepository<DocumentType>, DocumentTypeRepository>();
            builder.Services.AddScoped<IPropertyRepository<Company>, CompanyRepository>();
            builder.Services.AddDbContext<AirTravelContext>();

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
        }
    }
}