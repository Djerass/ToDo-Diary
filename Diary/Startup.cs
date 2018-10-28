using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo_Diary.Models;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;

namespace ToDoDiaryWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:ToDoDb:ConnectionString"]));
            
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ToDoContext>();
            services.AddTransient<IToDoRepository,ToDoRepository>();
            services.AddTransient<Iid,ForId>();
            services.AddTransient<IMuscle, MuscleRepo>();
            services.AddTransient<IExercise, ExerciseRepo>();
            services.AddTransient<ITraining, TrainingRepo>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
