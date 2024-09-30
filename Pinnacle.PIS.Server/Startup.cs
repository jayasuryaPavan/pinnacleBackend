using Microsoft.AspNetCore.Builder;
using Pinnacle.PIS.Repository;
using Pinnacle.PIS.Server.Services;
using Pinnacle.PIS.Server.Services.ProductService;

namespace Pinnacle.PIS.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<PISEntities>();
            services.AddTransient<IPdfFileHandler, PdfFileHandler>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Angular development server
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials(); // Optional if you're sending credentials (e.g., cookies)
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAngularApp");
            app.UseSwagger();
            app.UseRouting();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
