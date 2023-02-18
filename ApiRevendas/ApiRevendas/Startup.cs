using ApiRevenda.Interfaces;
using ApiRevenda.Repositorys;
using ApiRevenda.Services;
using CategoriaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace CategoriaApi
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
            services.AddDbContext<DatabaseContext>(opt => opt.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("CategoriaConnection")));
            services.AddScoped<IServiceCliente, ClienteService>();
            services.AddScoped<IRepositoryCliente, ClienteRepository>();
            services.AddScoped<EnderecoService>();
            services.AddScoped<EnderecoRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CategoriaApi", Version = "v1" });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CategoriaApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
