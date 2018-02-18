using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alone_Revisal.Context;
using Alone_Revisal.Interfaces;
using Alone_Revisal.Models;
using Alone_Revisal.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Alone_Revisal.Utils;
using Microsoft.AspNetCore.HttpOverrides;

namespace Alone_Revisal
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add SQLlite database
            services.AddDbContext<RevisalContext>(options => options.UseSqlite(Helper.GetRevisalConfigurationConnectionString(Configuration, Env)));
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Helper.GetLocalConfigurationConnectionString(Configuration, Env)));
            services.AddIdentity<Utilizator, ApplicationRole>().AddEntityFrameworkStores<AppDbContext>();

            //add Transient for ReposytoryRevisal
            services.AddTransient<IRevisalRepository, RepositoryRevisal>();
            services.AddTransient<IAppRepository, RepositoryApp>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //template: "{controller=Account}/{action=Login}/{id?}");
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
