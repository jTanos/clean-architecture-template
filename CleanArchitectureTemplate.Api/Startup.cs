using CleanArchitectureTemplate.Core.Contracts.EntitiesValidators;
using CleanArchitectureTemplate.Core.Contracts.Repositories;
using CleanArchitectureTemplate.Core.Contracts.Repositories.SqlEngineSpecifications;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Create;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Delete;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetAll;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetById;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.GetByName;
using CleanArchitectureTemplate.Core.Contracts.UseCases.Cruds.FooCrudUseCases.Update;
using CleanArchitectureTemplate.Core.EntitiesValidation;
using CleanArchitectureTemplate.Core.UseCases.Cruds.FooCrudUseCases;
using CleanArchitectureTemplate.Infrastructure.Repositories.DapperRepositories;
using CleanArchitectureTemplate.Infrastructure.Repositories.SqlEngineSpecifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitectureTemplate.Api
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
            // TODO get from config
            const string connectionString = "";

            services.AddTransient<ISqlServerEngineSpecifications>(x => new SqlServerEngineSpecifications(connectionString));

            // Repositories
            services.AddTransient<IFooRepository, FooSqlServerDapperRepository>();

            // Entities Validators
            services.AddTransient<IFooValidator, FooValidator>();

            // UseCases
            services.AddTransient<ICreateFooUseCase, CreateFooUseCase>();
            services.AddTransient<IUpdateFooUseCase, UpdateFooUseCase>();
            services.AddTransient<IDeleteFooUseCase, DeleteFooUseCase>();
            services.AddTransient<IGetFooByNameUseCase, GetFooByNameUseCase>();
            services.AddTransient<IGetFooByIdUseCase, GetFooByIdUseCase>();
            services.AddTransient<IGetAllFoosUseCase, GetAllFoosUseCase>();

            services.AddControllers(
                options => options.SuppressAsyncSuffixInActionNames = false
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
