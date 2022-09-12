using IS_API.Contracts.BLL;
using IS_API.Entities;
using IS_API.Entities.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserProfileBLL _userProfileBLL;

        public UsersController(IUserProfileBLL userProfileBLL)
        {
            _userProfileBLL = userProfileBLL;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            try
            {
                if (registerDTO.IdentificationNumber.Length > 13)
                {
                    return BadRequest("Invalid Id Number");
                }
                _userProfileBLL.RegisterUser(registerDTO);
                return Ok(registerDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<LoginResponse> Login(LoginDTO loginDTO)
        {
            try
            {
                if (loginDTO.IdNumber.Length > 13)
                {
                    return new LoginResponse { IsSuccessful = false, Message = LoginCustomMessages.InvalidID, StatusCode= CustomStatusCode.InvalidID };
                }
                var result = await _userProfileBLL.Login(loginDTO.IdNumber);
                if (result == null)
                {
                return new LoginResponse { IsSuccessful = false, Message = LoginCustomMessages.UserNotFound, StatusCode =CustomStatusCode.UserNotFound };
                }
                return new LoginResponse { IsSuccessful = true, Message = LoginCustomMessages.SuccessfulLogin,Username = result.Name + " " + result.Surname, StatusCode = CustomStatusCode.SuccessfulLogin };
            }
            catch (Exception ex)
            {
                return new LoginResponse { IsSuccessful = false, Message = LoginCustomMessages.ErrorOccured, StatusCode=CustomStatusCode.ErrorOccured};

            }
        }
    }
}
