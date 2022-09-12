using IS_API.Entities;
using IS_API.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Contracts.BLL
{
  public  interface IUserProfileBLL
    {
        public int RegisterUser(RegisterDTO registerDTO);
        public Task<UserProfile> Login(string idNumber);
        public int CalcAgeFromDOB(DateTime dateOfBirth);
        public Task<UserProfile> GetUserById(int userId);
    }
}
