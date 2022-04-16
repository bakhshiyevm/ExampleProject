using AutoMapper;
using Repo.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public abstract class BaseService
    {
    }

    public abstract class BaseService<TRqDTO, TEntity, TRsDTO> : BaseService
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly IMapper mapper;

        protected BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IEnumerable<TRsDTO> Get() 
        {
            var entities = repository.Get();
            var rs = mapper.Map<IEnumerable<TRsDTO>>(entities);
            return rs;
        }
        public virtual IEnumerable<TRsDTO> Get(int page, int pageSize) 
        {
            var entities = repository.Get(page,pageSize);
            var rs = mapper.Map<IEnumerable<TRsDTO>>(entities);
            return rs;
        }
        public virtual TRsDTO Get(int id) 
        {
            var entities = repository.Get(id);
            var rs = mapper.Map<TRsDTO>(entities);
            return rs;
        }
        public virtual void Create(TRqDTO dto) 
        {

            var entity = mapper.Map<TEntity>(dto);
            repository.Create(entity);

        }
        public virtual void Update(TRqDTO dto) 
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Update(entity);
        }
        public virtual void Delete(int id) 
        {
            repository.Delete(id);
        }
    }


}
