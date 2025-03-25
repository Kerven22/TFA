using TFA.Storage.DatabaseContext;

namespace TFA.Extentions
{
    public static class ForumServiceExtentions
    {
        public static void SqlConnectionConfig(this IServiceCollection services, IConfiguration configuration) =>
            services.AddSqlServer<ForumDbContext>(configuration.GetConnectionString("sqlconnection"),b=>b.MigrationsAssembly("TFA")); 
    }
}
