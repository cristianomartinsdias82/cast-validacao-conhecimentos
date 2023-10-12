using Assinaturas.WebUI.Core.Integrations.AssinaturasApi;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Assinaturas.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAssinaturasApiIntegrationServiceClient(builder.Configuration);
            
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services
              .AddMvc()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("pt-BR"),
                    new CultureInfo("en-US")
                };

                options.SetDefaultCulture(supportedCultures[0].Name)
                        .AddSupportedCultures(supportedCultures.Select(cul => cul.Name).ToArray())
                        .AddSupportedUICultures(supportedCultures.Select(cul => cul.Name).ToArray());
            });

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

            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

            app.Run();
        }
    }
}