using Microsoft.OpenApi.Models;

namespace ApiMakeUpStore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabaseService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<DataContext>((options) =>
            {
                options.UseSqlServer(connectionString);
            });


        }

        public static void AddRepositories(this IServiceCollection services)
        {
           // services.AddTransient<IRepository<Equipment>, EquipmentRepository>();
           

        }

        public static void AddServices(this IServiceCollection services)
        {
            //services.AddTransient<ILogsService, LogsService>();
           

        }
        public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var enableBasicAuth = configuration.GetValue<bool>("EnableBasicAuth");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiMakeUpStrore", Version = "v1" });
            });
        }
    }
}
