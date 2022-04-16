using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface IBaseService
    {
    }
    public interface IBaseService<TRqDTO, TEntity, TRsDTO> : IBaseService
    {
        public IEnumerable<TRsDTO> Get();
        public IEnumerable<TRsDTO> Get(int page, int pageSize);
        public TRsDTO Get(int id);
        public void Create(TRqDTO dto);
        public void Update(TRqDTO dto);
        public void Delete(int id);
    }
}
