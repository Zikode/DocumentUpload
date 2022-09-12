using IS_API.Contracts.BLL;
using IS_API.Contracts.Repository;
using IS_API.Entities;
using IS_API.Entities.DTO;
using System;
using System.Threading.Tasks;

namespace IS_API.BLL.BLL
{
    public class UserProfileBLL : IUserProfileBLL
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileBLL(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public int CalcAgeFromDOB(DateTime dateOfBirth)
        {
            var result = DateTime.Now.Year - dateOfBirth.Year;
            return result;
        }

        public Task<UserProfile> GetUserById(int userId)
        {
            return _userProfileRepository.GetUserById(userId);
        }

        public async Task<UserProfile> Login(string idNumber)
        {
            return await _userProfileRepository.Login(idNumber);
        }

        public int RegisterUser(RegisterDTO registerDTO)
        {
            registerDTO.Age = CalcAgeFromDOB(registerDTO.DateOfBirth);
            return _userProfileRepository.RegisterUser(registerDTO);
        }

    }
}
