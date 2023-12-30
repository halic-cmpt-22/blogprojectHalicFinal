using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.tables;
using MediatR;
using data.uows;
using Microsoft.EntityFrameworkCore;

namespace services.Query
{
    public class JokesQuery: IRequest<Jokes>
    {

        public class Handler : IRequestHandler<JokesQuery,Jokes>
        {
            async Task<Jokes> IRequestHandler<JokesQuery, Jokes>.Handle(JokesQuery request, CancellationToken cancellationToken)
            {
                var uow = new BlogUnitOfWork();

                var jokesID = await uow.jokesRepo.GetQuery() 
                            .Select(b => b.id) 
                            .ToListAsync(); 

        var random = new Random(); 
        var randJokesID = jokesID.OrderBy(x => random.Next()).FirstOrDefault(); 

         var jokes = await uow.jokesRepo.GetQuery() 
                            .Where(b => b.id == randJokesID)  
                            .FirstOrDefaultAsync(cancellationToken); 
                            return jokes;
        }
    }
    }
}