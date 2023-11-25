using Microsoft.EntityFrameworkCore;
using Enterprise2._0.Data; // Certifique-se de usar o namespace correto para o seu ContextNewNewo de banco de dados

namespace Enterprise2._0
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
            // Configuração do Entity Framework Core com o seu ContextNewNewo de banco de dados
            services.AddDbContext<ContextNew>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("conexao")));

            // Configuração de outros serviços necessários
            services.AddControllersWithViews();
            // ... outros serviços podem ser adicionados aqui
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
