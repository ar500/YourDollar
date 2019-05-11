using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourDollar.API.DTOs.BudgetCatDTOs;
using YourDollar.API.DTOs.ExpenseDTOs;
using YourDollar.API.DTOs.PersonDTOs;
using YourDollar.API.Infrastructure.Context;
using YourDollar.API.Infrastructure.Entities;
using YourDollar.API.Repositories.BudgetCategory;
using YourDollar.API.Repositories.Expense;
using YourDollar.API.Repositories.Person;

namespace YourDollar.API
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            var connectionString = Configuration["connectionStrings:yourDollarDbConnectionString"];
            services.AddDbContext<YourDollarContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("YourDollar.API.Infrastructure")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBudgetCategoryRepository, BudgetCategoryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, YourDollarContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            context.EnsurePeopleSeedDataForContext();
            context.EnsureBudgetCategorySeedDataForContext();
            context.EnsureExpenseSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PersonEntity, PersonDto>();
                cfg.CreateMap<PersonForAddOrUpdateDto, PersonEntity>();
                cfg.CreateMap<BudgetCategoryDto, BudgetCategoryEntity>();
                cfg.CreateMap<BudgetCategoryForAddOrUpdateDto, BudgetCategoryEntity>();
                cfg.CreateMap<ExpenseEntity, ExpenseDto>();
                cfg.CreateMap<ExpenseForUpdateDto, ExpenseEntity>();
                cfg.CreateMap<ExpenseForAddDto, ExpenseEntity>();
                //cfg.CreateMap<City, CityDto>();
                //cfg.CreateMap<PointOfInterest, PointOfInterestDto>();
                //cfg.CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
                //cfg.CreateMap<PointOfInterestForUpdateDto, PointOfInterest>();
                //cfg.CreateMap<PointOfInterest, PointOfInterestForUpdateDto>();
            });


            app.UseStatusCodePages();
            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
