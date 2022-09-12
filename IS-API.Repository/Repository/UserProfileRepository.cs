using IS_API.Contracts.Repository;
using IS_API.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IS_API.Repository.Repository
{
   public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IDapperRepository _dapper;

        public UserProfileRepository(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public async Task<UserProfile> GetUserById(int userId)
        {
            var results = await _dapper.QuerySingleWithParameter<UserProfile>("[dbo].[GetUserByIdentificationNumber]",
                 new { IdentificationNumber = userId });
            return results;
        }

        public async Task<UserProfile> Login(string idNumber)
        {
            var results = await _dapper.QuerySingleWithParameter<UserProfile>("[dbo].[GetUserByIdentificationNumber]",
                new {IdentificationNumber = idNumber});
            return results;
        }

        public int RegisterUser(UserProfile userProfile)
        {
            var parameters = new
            {
                @Name = userProfile.Name,
                @Surname = userProfile.Surname,
                @Age = userProfile.Age,
                @DateOfBirth = userProfile.DateOfBirth,
                @IdentificationNumber = userProfile.IdentificationNumber,
            };
            return _dapper.Execute("[dbo].[InsertUser]", parameters);
        }

    }
}
