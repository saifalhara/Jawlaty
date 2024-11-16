using Jawlaty.Auth.DTO;
using Jawlaty.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jawlaty.Controllers
{
    public class AuthController : Controller
    {

        private IUser userService;
        private IUserFavoriteService _userFavoriteService;



        public AuthController(IUser userSer, IUserFavoriteService userFavoriteService)
        { 
            userService = userSer;
            _userFavoriteService = userFavoriteService;

        }


        public IActionResult Index()
        {
            return View();
        }
  


        public IActionResult SignUp()
        {
            return View();
        }




        //[HttpPost]
        //public async Task <ActionResult<UserDto>> SignUp (RegisterUserDto data)
        //{
        //    var user = userService.Register(data, this.ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return View(data);
        //    }

        //    return RedirectToAction("Index", "Home");

        //}

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterUserDTO data)
        {
            UserDTO user = await userService.Register(data, this.ModelState);

            if (!ModelState.IsValid)
            {
                return View(data);
            }



            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Authenticate(LoginDTO loginDto)
        {

            var user = await userService.Authenticate(loginDto.Username, loginDto.Password);

            if (user == null)
            {

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View("index", loginDto);
            }
            if (user.Username == "admin")
            {
                // Redirect to the admin page for admin users
                return RedirectToAction("Index", "Admin");
            }
            else
            {  // Redirect to the home page for non-admin users
                  return RedirectToAction("Index", "Home");

            }




        }



        public IActionResult Logout()
        {
            userService.LogOut();
            return RedirectToAction("Index", "Home");
        }




        public IActionResult ChangePassword()
        {

            return View();


        }

        public IActionResult RestPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RestPassword(ResetPasswordDTO resetPasswordDTO)
        {
            await userService.ResetPasswordAsync(resetPasswordDTO);
            return Ok(resetPasswordDTO);
        }

        [Authorize]
        public IActionResult ViewFavourits()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userFavorites = _userFavoriteService.GetUserFavorites(userId); // Fetch user favorites

            return View(userFavorites);
        }




        //[HttpPost]
        //public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var userId = User.Identity.Name;
        //    var success = await userService.ChangePassword(userId, model.OldPassword, model.NewPassword);

        //    if (success)
        //    {
        //        // Check the user's role and redirect accordingly
        //        if (User.IsInRole("Admin"))
        //        {
        //            return RedirectToAction("Index", "Admin"); // Replace "AdminDashboard" with the actual action and controller names for the admin role.
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index", "Home"); // Replace "UserDashboard" with the actual action and controller names for the user role.
        //        }
        //        //else
        //        //{
        //        //    return RedirectToAction("DefaultAction"); // Replace "DefaultAction" with the default action you want to redirect to if the user doesn't have a specific role.
        //        //}
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Password change failed. Please check your old password.");
        //        return View(model);
        //    }
        //}







    }
}