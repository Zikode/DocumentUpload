using IS_API.Entities;
using IS_API.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Contracts.Repository
{
   public interface IUserProfileRepository
    {
        public int RegisterUser(RegisterDTO registerDTO);
        public Task<UserProfile> Login(string idNumber);

        public Task<UserProfile> GetUserById(int userId);
    }
}
