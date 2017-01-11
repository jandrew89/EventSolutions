using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using User.Repository;
using User.Repository.Entities;
using EventSolutions.Services;
using EventSolutions.ViewModels;
using RestSharp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EventSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageSerivce;
        private IHostingEnvironment _environment;

        public HomeController(IMessageService messageService, IHostingEnvironment environment)
        {
            _environment = environment;
            _messageSerivce = messageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeaveFeedback()
        {
            return View("LeaveFeedback");
        }

        [HttpPost]
        public async Task<IActionResult> LeaveFeedback([Bind("Phone,Email,Message,FullName")] FeedBackViewModel FVM)
        {
            string email = "jasonandrewchristman@gmail.com";
            string subject = $"Email from [{FVM.FullName}] EmailAddress: [{FVM.Email}]";
            string message = $"[{FVM.FullName}] has the following message [{FVM.Message}]";

            await _messageSerivce.SendEmailAsync(email, subject, message);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn(string returnUrl)
        {
            var viewModel = new UserViewModel
            {
                RedirectUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([Bind("UserName,Password")] UserViewModel model)
        {

            using (UserRepository context = new UserRepository(new UserContext()))
            {
                var user = context.GetUser(model.UserName, model.Password);

                if (user == null)
                {
                    return View();
                }
              
                var userClaims = context.GetUserClaims(user.Subject);


                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Subject)
                };

                var userIdentity = new ClaimsIdentity(claims, "Cookies");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.Authentication.SignInAsync("UserAuthentication", userPrincipal);

                user.IsActive = true;

                return RedirectToAction("Index", "Home");
            }
        }

        private string GetRedirectUrl(string redirectUrl)
        {
            if (string.IsNullOrEmpty(redirectUrl) || !Url.IsLocalUrl(redirectUrl))
            {
                return Url.Action("/duties");
            }

            return redirectUrl;
        }

        [HttpPost]
        public IActionResult Register([Bind("UserName,Password,FirstName,LastName,Email")] UserViewModel model)
        {
            using (UserRepository context = new UserRepository(new UserContext()))
            {

                var newUser = new User.Repository.Entities.User();
                newUser.IsActive = true;
                newUser.Subject = Guid.NewGuid().ToString();
                newUser.Password = model.Password;
                newUser.UserName = model.UserName;
                context.AddUser(newUser);

                UserClaim userClaim = new UserClaim()
                {
                    Id = Guid.NewGuid().ToString(),
                    Subject = newUser.Subject,
                    ClaimType = "given_name",
                    ClaimValue = model.FirstName
                };

                context.AddUserClaim(userClaim);

                userClaim = new UserClaim()
                {
                    Id = Guid.NewGuid().ToString(),
                    Subject = newUser.Subject,
                    ClaimType = "email",
                    ClaimValue = model.Email
                };

                context.AddUserClaim(userClaim);

                userClaim = new UserClaim()
                {
                    Id = Guid.NewGuid().ToString(),
                    Subject = newUser.Subject,
                    ClaimType = "family_name",
                    ClaimValue = model.LastName
                };

                context.AddUserClaim(userClaim);


                return View("Index");
            }

        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.Authentication.SignOutAsync("UserAuthentication");
            return View("SignIn");

        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }

    } 
}
