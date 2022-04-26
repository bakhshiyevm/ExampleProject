using AutoMapper;
using Business.Helper;
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

            var res = repository.Find(user => user.Username == dto.Username);
            if (res.Count() == 1) 
            {
                var user = res.FirstOrDefault();
                var dbHash = Crypto.GenerateSHA256Hash(dto.Password, user.Salt);
                if (user.PasswordHash != dbHash) 
                {
                    throw new PasswordException();
                }
            }
            else 
            {
                throw new UsernameException();
            }
            return mapper.Map<UserDTO>(res.First());
        }

        public override void Create(UserDTO dto)
        {
            var res = repository.Find(user => user.Username == dto.Username
            || user.Email == dto.Email || user.PhoneNumber == dto.PhoneNumber) ;
            if (res.Count() != 0) 
            {
                throw new UsernameExistsException(); ;
            }
            else 
            {
                dto.Salt = Crypto.GenerateSalt();
                dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);
                base.Create(dto);
            }

        }
    }
}
