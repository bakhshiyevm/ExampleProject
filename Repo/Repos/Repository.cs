using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repo.IRepos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repo.Repos
{
    //TODO: fix catch 
    public abstract class Repository : IRepository
    {
        protected readonly AppDbContext _context;


        public Repository(AppDbContext context)
        {
            _context = context;
        }
    }

    public class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(AppDbContext context) : base(context)
        {
            _dbSet = _context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            
                return _dbSet;
            
        }
        public IQueryable<TEntity> Get(int page, int pageSize)
        {
          
                return _dbSet.Skip((page - 1) * pageSize).Take(pageSize);
           
        }
        public TEntity Get(int id)
        {
          
                return _dbSet.Find(id);

        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
                return _dbSet.Where(expression);


        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int pageSize)
        {
                return _dbSet.Where(expression).Skip((page - 1) * pageSize).Take(pageSize);
            
        }
        public void Create(TEntity entity)
        {
           
                _dbSet.Add(entity);
                _context.SaveChanges();

        }
        public void Update(TEntity entity)
        {
           
                _dbSet.Update(entity);
                _context.SaveChanges();

        }
        public void Delete(int id)
        {
                var entity = Get(id);
                _dbSet.Add(entity);
                _context.SaveChanges();           
        }
    }
}
