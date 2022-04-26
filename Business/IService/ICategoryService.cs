using DataAccess.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IService
{
    public interface ICategoryService : IBaseService<CategoryDTO, Category, CategoryDTO>
    {

    }
}
