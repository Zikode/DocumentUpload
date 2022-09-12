using System;
using System.Collections.Generic;
using System.Text;

namespace IS_API.Entities.DTO
{
   public class RegisterDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentificationNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
