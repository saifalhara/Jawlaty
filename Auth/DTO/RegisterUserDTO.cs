﻿using System;
namespace Jawlaty.Auth.DTO
{

      public class RegisterUserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }
}
