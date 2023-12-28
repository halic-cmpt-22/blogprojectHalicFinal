using System.Linq;
using MediatR;
using data.uows;
using data.tables;
using Microsoft.EntityFrameworkCore;

namespace services.Query
{
    public class BlogQuery : IRequest<(Blog, BlogRec)>
    {
        public int id { get; set; }

       public class Handler : IRequestHandler<BlogQuery, (Blog, BlogRec)>
{
    public async Task<(Blog, BlogRec)> Handle(BlogQuery request, CancellationToken cancellationToken)
    {
        var uow = new BlogUnitOfWork();
        var blog = await uow.blogRepository.GetQuery()
                            .Include(b => b.Posts)
                            .FirstOrDefaultAsync(b => b.id == request.id, cancellationToken);

        var blogIds = await uow.blogRepository.GetQuery()
                            .Where(b => b.id != request.id)
                            .Select(b => b.id)
                            .ToListAsync(cancellationToken);

        var random = new Random();
        var randBlogID = blogIds.OrderBy(x => random.Next()).FirstOrDefault();

        var recBlog = await uow.blogRepository.GetQuery()
                            .Where(b => b.id == randBlogID)
                            .Select(b => new BlogRec { RecBlog = b })
                            .FirstOrDefaultAsync(cancellationToken);

        return (blog, recBlog);
    }
}
    }
}
