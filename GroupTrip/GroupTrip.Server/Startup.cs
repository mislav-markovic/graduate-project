using System.Linq;
using System.Net.Mime;
using GroupTrip.Server.DataAccess;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GroupTrip.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<GroupTripDAL>();

            //var connection =
            //    @"Server=(localdb)\mssqllocaldb;Database=GroupTrip.Db;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<GroupTripContext>
            //    (options => options.UseSqlServer(connection));

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc(routes => { routes.MapRoute("default", "{controller}/{action}/{id?}"); });

            app.UseBlazor<Client.Startup>();
        }
    }
}