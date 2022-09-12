using System;
using System.Collections.Generic;
using System.Text;

namespace IS_API.Entities.DTO
{
   public class LoginResponse
    {
        public string Username { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }
    }

}
