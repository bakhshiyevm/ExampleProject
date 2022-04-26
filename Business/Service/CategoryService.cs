using AutoMapper;
using Business.IService;
using DataAccess.Entities;
using DTO;
using Repo.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CategoryService : BaseService<CategoryDTO, Category, CategoryDTO>,
        ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IMapper mapper) 
            : base(repository, mapper)
        {

        }

    }
}
