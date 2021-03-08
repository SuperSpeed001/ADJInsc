namespace ADJInsc.Core.Api
{
    using ADJInsc.Core.Api.Service.Interface;
    using ADJInsc.Core.Api.Service.Metodos;
    using ADJInsc.Core.Api.Service.Settings;
    using ADJInsc.Models.Models.DBInsc;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Linq;

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

            services.AddCors();
            // Add MVC services to the services container.
            services.AddMvc();
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));

            services.AddDbContext<dbActuContext>(cfg =>
            {
                //cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));   Produccion
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));     //  Base Test 
            });

            services.AddTransient<IMailService, MailService>();

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Ivuj {groupName}",
                    Version = groupName,
                    Description = "Ivuj API",
                    Contact = new OpenApiContact
                    {
                        Name = "IVUJ",
                        Email = string.Empty,
                        Url = new Uri("https://ivuj.gob.ar/"),
                    }
                });
                options.ResolveConflictingActions(apiDescription => apiDescription.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Ivuj V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
