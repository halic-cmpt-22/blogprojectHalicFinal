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

       public class Handler : IRequestHandler<BlogQuery, (Blog, BlogRec)> //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
{
    public async Task<(Blog, BlogRec)> Handle(BlogQuery request, CancellationToken cancellationToken) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
    {
        var uow = new BlogUnitOfWork();
        var blog = await uow.blogRepository.GetQuery() //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .Include(b => b.Posts) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .FirstOrDefaultAsync(b => b.id == request.id, cancellationToken); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk

        var blogIds = await uow.blogRepository.GetQuery() //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .Where(b => b.id != request.id) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .Select(b => b.id) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .ToListAsync(cancellationToken); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk

        var random = new Random(); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
        var randBlogID = blogIds.OrderBy(x => random.Next()).FirstOrDefault(); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk

        var recBlog = await uow.blogRepository.GetQuery() //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .Where(b => b.id == randBlogID) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .Select(b => new BlogRec { RecBlog = b }) //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
                            .FirstOrDefaultAsync(cancellationToken); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk

        return (blog, recBlog); //Mehmet Faruk, Berke Çuhadar, Ömer Faruk
    }
}
    }
}
