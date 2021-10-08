using MrParker.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MrParker
{
    public class Startup
    {
        private readonly IWebHostEnvironment environment;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.environment = environment;

            // SQL Connection-String
            DataAccess.SqlConnectionProvider.Init(configuration.GetConnectionString("Main"));
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MrParker", Version = "v1" });
            });

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MrParker v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ClientsHub>("/hub");
            });


            //var providerRepo = new DataAccess.Repositories.ProviderRepository();
            //var insertResult = Task.Run(async () => await providerRepo.InsertAsync(new DataAccess.Models.Provider()
            //{
            //    Name = "Wankdorf Stadion",
            //    ProviderType = 0,
            //    ContactEmail = "info@wankdorfstadion.test",
            //    ContactPhone = "031 123 45 67"
            //})).Result;

            //var provider = Task.Run(async () => await providerRepo.SelectAsync()).Result.FirstOrDefault();


            //var parkSpaceRepo = new DataAccess.Repositories.ParkSpaceRepository();
            //var insertResult = Task.Run(async () => await parkSpaceRepo.InsertAsync(new DataAccess.Models.ParkSpace()
            //{
            //    //Id = Guid.NewGuid(),
            //    Name = "parking place",
            //    ProviderId = provider.Id,
            //    Longitude = 46.9634175M,
            //    Latitude = 7.4604527M,
            //    Street = "Papiermühlestrasse 91",
            //    Zip = "3014",
            //    City = "Bern",
            //    Country = "Schweiz",
            //    TotalParkingSlots = 50,
            //    Description = "Neben dem Wankdorf Stadion",
            //    CustomerInfo = "Parkuhr",
            //    RatePerMinute = 0.05M,
            //    Currency = "CHE"
            //})).Result;

            //var parkSpace = Task.Run(async () => await parkSpaceRepo.SelectAsync("ProviderId = @ProviderId", new { ProviderId = provider.Id })).Result.FirstOrDefault();
            //parkSpace.Currency = "CHF";
            //var updateResult = Task.Run(async () => await parkSpaceRepo.UpdateAsync(parkSpace, new[] { "Currency" })).Result;

            //var customerRepo = new DataAccess.Repositories.CustomerRepository();
            //bool insertPaker = Task.Run(async () => await customerRepo.InsertAsync(new DataAccess.Models.Customer() {
            //    FirstName = "Peter",
            //    LastName = "Parker",
            //    Street = "Parkerstreet 2021",
            //    Zip = "12345",
            //    City = "ParkerCity",
            //    Country = "Parkerland"
            //})).Result;

            //var parker = Task.Run(async () => await customerRepo.SelectAsync("Country = @Country", new { Country = "Parkerland" })).Result.FirstOrDefault();
            //var delResult = Task.Run(async () => await customerRepo.DeleteAsync(parker)).Result;
        }
    }
}
