using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using services.Query;

namespace webapi
{
    public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register MediatR services
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            cfg.RegisterServicesFromAssembly(typeof(BlogQuery).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(JokesQuery).Assembly);
            
        });

        // Way-2
        //services.AddMediatR(Assembly.GetExecutingAssembly());

        // Register MediatR services from multiple assembly.
        //services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(ICustomerService).Assembly);
    }
}
}