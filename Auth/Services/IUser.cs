using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Jawlaty.Auth.DTO;

namespace Jawlaty.Auth.Services
{
    public interface IUser
    {
        //Register Method
        public Task<UserDTO> Register(RegisterUserDTO registerDto, ModelStateDictionary modelstate);
        //login Method

        public Task<UserDTO> Authenticate(string username, string password);

        public Task<UserDTO> GetUser(string username);
        // logout method
        public Task LogOut();
        public Task<List<ApplicationUser>> getAll();
        public Task<string> GetCurrentLoggedInDoctorId();

    }
}