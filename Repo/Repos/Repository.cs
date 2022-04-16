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
            try
            {
                return _dbSet;
            }
            catch
            {
                return _dbSet;
            }
        }
        public IQueryable<TEntity> Get(int page, int pageSize)
        {
            try
            {
                return _dbSet.Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch
            {
                return _dbSet.Skip((page - 1) * pageSize).Take(pageSize);
            }
        }
        public TEntity Get(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch
            {
                return _dbSet.Find(id);
            }
        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _dbSet.Where(expression);
            }
            catch
            {
                return _dbSet.Where(expression);
            }

        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int pageSize)
        {
            try
            {
                return _dbSet.Where(expression).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception e)
            {
                return _dbSet.Where(expression).Skip((page - 1) * pageSize).Take(pageSize);
            }
        }
        public void Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
        public void Update(TEntity entity)
        {
            try
            {
                _dbSet.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
        public void Delete(int id)
        {
                var entity = Get(id);
                _dbSet.Add(entity);
                _context.SaveChanges();           
        }
    }
}
