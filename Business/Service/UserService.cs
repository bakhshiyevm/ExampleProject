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
    public class UserService : BaseService<UserDTO, User, UserDTO>,
        IUserService
    {
        public UserService(IRepository<User> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }

        public UserDTO Login(UserDTO dto)
        {
            var res = repository.Find(user => user.Username == dto.Username
            && user.Password == dto.Password);

            if (res.Count() != 1) 
            {
                throw new Exception("Incorrect username or password!");
            }
            return mapper.Map<UserDTO>(res.First());
        }

        public override void Create(UserDTO dto)
        {
            var res = repository.Find(user => user.Username == dto.Username
            || user.Email == dto.Email || user.PhoneNumber == dto.PhoneNumber) ;
            if (res.Count() != 0) 
            {
                throw new Exception("Same username/email/password is already signed up!");
            }
            else 
            {
                base.Create(dto);
            }

        }
    }
}
