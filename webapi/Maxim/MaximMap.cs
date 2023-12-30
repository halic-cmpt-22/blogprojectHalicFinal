using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.tables;
using MediatR;
using services.Query;
namespace webapi.Maxim
{
    public static class MaximMap
    {
        public static void AddMap(WebApplication app)
        {
            app.MapGet("maxim", async (IMediator mediator) => 
            {
                var maxim = await mediator.Send(new MaximQuery()); 
                return new { Maxim = maxim };
            });
        }
    }
}
