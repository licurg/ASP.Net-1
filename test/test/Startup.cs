using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;


namespace test
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Підключаємо MVC(ModelViewController)
            // Що таке MVC: http://rsdn.org/article/patterns/generic-mvc.xml
            //              https://habrahabr.ru/post/181772/
            //              https://docs.microsoft.com/en-us/aspnet/core/mvc/overview

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Назначаємо шляхи, за якими можна звертатись на сервер
            app.UseMvc(routes =>
            {
                // Додаємо новий шлях
                routes.MapRoute(
                // Даємо назву
                name: "home",
                // Прив'язуємо контроллер "HomeController". Вказуємо який метод спрацює, якщо звернутися до сервера
                template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
