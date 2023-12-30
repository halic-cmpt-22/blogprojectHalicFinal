using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using data.tables;
using MediatR;
using data.uows;
using Microsoft.EntityFrameworkCore;

namespace services.Query
{
    public class MaximQuery : IRequest<Maxims>
    {
        public class Handler : IRequestHandler<MaximQuery, Maxims>
        {
            public async Task<Maxims> Handle(MaximQuery request, CancellationToken cancellationToken)
            {
                var uow = new BlogUnitOfWork();

                var maximID = await uow.maximRepo.GetQuery()
                    .Select(b => b.id)
                    .ToListAsync(cancellationToken);

                var random = new Random();
                var randMaximID = maximID.OrderBy(x => random.Next()).FirstOrDefault();

                var maxim = await uow.maximRepo.GetQuery()
                    .Where(b => b.id == randMaximID)
                    .FirstOrDefaultAsync();

                return maxim;
            }
        }
    }
}
