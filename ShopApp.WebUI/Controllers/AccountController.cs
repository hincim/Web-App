using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.EmailServices;
using ShopApp.WebUI.Extensions;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;
using System;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        private ICartService _cartService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender,
            ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _cartService = cartService;
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var user = await _userManager.FindByNameAsync(model.UserName);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View(model);
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Email hesabınıza gelen link ile hesabınızı onaylayın");
                return View(model);
            }

            var result = await _signInManager
                .PasswordSignInAsync(user, model.Password, true, false);

            if (result.Succeeded)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Oturuma giriş yapıldı",
                    AlertType = "warning",
                    Message = "Hesabınıza güvenli bir giriş yapıldı."
                });
                return Redirect(model.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Girilen kullanıcı adı veya parola yanlış");

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // card object will be created
                _cartService.InitializeCard(user.Id);

                // generate token
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail","Account", new
                {
                    userId = user.Id,
                    token = token
                });
                Console.WriteLine(url);

                // email
                //await _emailSender.SendEmailAsync(model.Email,"Hesabınızı onaylayınız",
                //    $"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:44355{url}'>tıklayınız.</a>");

                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("", "Lütfen tekrar deneyiniz");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData.Put("message", new AlertMessage()
            {
                Title = "Oturum kapatıldı",
                AlertType = "warning",
                Message = "Hesabınızdan güvenli bir şekilde çıkış yapıldı."
            });
            return Redirect("~/");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message",new AlertMessage()
                {
                    Title = "Error",
                    AlertType = "danger",
                    Message = "Geçersiz token"
                });
                //CreateMessage("Geçersin token", "danger");
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {

                    TempData.Put("message", new AlertMessage()
                    {
                        Title = "success",
                        AlertType = "success",
                        Message = "Hesabınız onaylandı"
                    });
                    //CreateMessage("Hesabınız onaylandı", "success");
                    return View();
                }
            }
            TempData.Put("message", new AlertMessage()
            {
                Title = "warning",
                AlertType = "warning",
                Message = "Hesabınızı onaylayamadık"
            });
            //CreateMessage("Hesabınızı onaylayamadık", "warning");
            return View();
        }
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return View();
            }

            // generate token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = token
            });
            Console.WriteLine(url);

            // email
            await _emailSender.SendEmailAsync(email, "Reset Password",
                $"Lütfen şirenizi yenilemek için linke <a href='https://localhost:44355{url}'>tıklayınız.</a>");
            return View();
        }

        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage()
                {
                    Title = "danger",
                    AlertType = "danger",
                    Message = "Geçersin token"
                });
                //CreateMessage("Geçersin token", "danger");
                return RedirectToAction("Index","Home");
            }
            var model = new ResetPasswordModel
            {
                Token = token
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token,model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }
            return View(model);
        }

        //private void CreateMessage(string message, string alertType)
        //{
        //    var msg = new AlertMessage()
        //    {
        //        Message = message,
        //        AlertType = alertType
        //    };

        //    TempData["message"] = JsonConvert.SerializeObject(msg);
        //}
    }
}
