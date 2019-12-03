using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using technology_tp1.Models;
using Technology_Tp1_React.General.CrudController;
using Technology_Tp1_React.General.Repository;
using Technology_Tp1_React.Models;

namespace Technology_Tp1_React
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
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/build";
			});

			services.AddScoped(typeof(IRepository<>), typeof(EFCoreRepository<>));

			services.AddDbContext<AppDbContext>((options) =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("Default"));
			});

			services.AddIdentity<User, IdentityRole>()
					.AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

            //services.ConfigureApplicationCookie(o =>
            //{
            //    o.Events = new CookieAuthenticationEvents()
            //    {
            //        OnRedirectToLogin = (ctx) =>
            //        {
            //            HttpContext httpContext = ctx.HttpContext;
            //            ErrorResponse.Forbiden(ref httpContext);
            //            return Task.CompletedTask;
            //        },
            //        OnRedirectToAccessDenied = (ctx) =>
            //        {
            //            HttpContext httpContext = ctx.HttpContext;
            //            ErrorResponse.Forbiden(ref httpContext);
            //            return Task.CompletedTask;
            //        }
            //    };
            //});
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			AppDbContext database)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

            app.UseAuthentication();

			database.Database.EnsureCreated();

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
			});
		}
	}
}
