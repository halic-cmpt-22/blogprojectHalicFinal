using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.repositories;
using data.tables;
namespace data.uows
{
    public class BlogUnitOfWork
    {
        private BlogContext _context;

        public BlogUnitOfWork() {
            _context = new BlogContext();
        }
        private Repository<Blog> _blogRepository;
        private Repository<Post> _postRepository;
        private Repository<Jokes> _jokesRepo;
        private Repository<Maxims> _maximRepo;
        public Repository<Blog> blogRepository {
            get {
                if (_blogRepository == null) {
                    _blogRepository = new Repository<Blog>(_context);
                }
                return _blogRepository;
            }
        }
        public Repository<Post> postRepository {
            get {
                if (_postRepository == null) {
                    _postRepository = new Repository<Post>(_context);
                }
                return _postRepository;
            }
        }
        public Repository<Jokes> jokesRepo {
            get {
                if (_jokesRepo == null) {
                    _jokesRepo = new Repository<Jokes>(_context);
                }
                return _jokesRepo;
            }
        }
        public Repository<Maxims> maximRepo {
            get {
                if (_maximRepo == null) {
                    _maximRepo = new Repository<Maxims>(_context);
                }
                return _maximRepo;
            }
        }

    }
}