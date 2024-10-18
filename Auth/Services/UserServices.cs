using System;
using System.Security.Claims;
using Jawlaty.Auth.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Jawlaty.Auth.Services
{
    public class UserServices : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserServices(
            UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser()
            {
                UserName = data.Username ,
                Email = data.Email,
            //    Email = data.Email
            };

            var result = await _userManager.CreateAsync(user, data.Password );

       


            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                     error.Code.Contains("Email") ? nameof(data.Email) :
                     "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;

        }




        public async Task<UserDTO> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);

                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)

                };
            }

            return null;

        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

  

        public async Task<UserDTO> GetUser(string username)
        {

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return null; 
            }

            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName,
            };



        }


        public async Task<List<ApplicationUser>> getAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<string> GetCurrentLoggedInDoctorId()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext?.User?.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(httpContext.User);
                if (user != null)
                {
                    return user.Id;
                }
            }

            return null; // If not authenticated or doctor not found
        }

    }
}