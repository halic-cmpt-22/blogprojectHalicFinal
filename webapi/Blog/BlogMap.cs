using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using services.Query;
namespace webapi.Blog
{
    public static class BlogMap
    {
        public static void AddMap(WebApplication app)
        {
            app.MapGet("blog/{id}", async (int id, IMediator mediator) =>
            {
                var (blog, recBlog) = await mediator.Send(new BlogQuery { id = id });
                return new { Blog = blog, RecommendedBlog = recBlog };
            });
        }
    }
}
