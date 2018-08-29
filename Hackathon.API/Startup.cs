using Hackathon.Repositories.Interfaces;
using Hackathon.Repositories.SQLLite;
using Hackathon.Services;
using Hackathon.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.API
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
            services.AddDbContext<SQLLiteContext>(options => 
                options.UseSqlite(Configuration.GetConnectionString("HackathonDatabase")));

            services.AddCors(o => o.AddPolicy("allowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IGoalService, GoalService>();
            services.AddTransient<IUserRepository, SQLLiteUserRepository>();
            services.AddTransient<IGoalTypeRepository, SQLLiteGoalTypeRepository>();

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
                app.UseHsts();
            }
            
            app.UseCors("allowAll");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
