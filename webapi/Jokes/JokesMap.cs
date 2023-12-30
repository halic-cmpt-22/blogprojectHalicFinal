using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using services.Query;
namespace webapi.Jokes
{
    public static class JokesMap
    {
        public static void AddMap(WebApplication app)
        {
            app.MapGet("joke", async (IMediator mediator) => 
            {
                var joke = await mediator.Send(new JokesQuery());
                return new { Jokes = joke };
            });
        }
    }
}
