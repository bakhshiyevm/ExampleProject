using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repo.IRepos
{
    public interface IRepository
    {

    }

    public interface IRepository<TEntity> : IRepository
    {
        public IQueryable<TEntity> Get();
        public IQueryable<TEntity> Get(int page, int pageSize);
        public TEntity Get(int id);
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int pageSize);
        public void Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);



    }
}
