using CompanyApp.Data.Entities;
using CompanyApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace CompanyApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var db = new CompanyAppDbContext();

            var user = db.Users.Include(x => x.Roles).FirstOrDefault(x => x.Name == model.UserName && x.Password == model.Password);

            if (user is not null)
            {
                List<Claim> claims = new List<Claim>();

                var claims1 = new Claim(ClaimTypes.Name, user.Name);
                var claims2 = new Claim(ClaimTypes.Name, user.Email);

                claims.Add(claims1);
                claims.Add(claims2);

                
                foreach( var role in user.Roles)
                {
                    var claims3 = new Claim(ClaimTypes.Role, role.Name);

                    claims.Add(claims3);
                }

                var identity = new ClaimsIdentity(claims, "EKOM1907");
                var claimPrincple = new ClaimsPrincipal(identity);
                var autoProps = new AuthenticationProperties();

                autoProps.IsPersistent = model.RememberMe;
                autoProps.ExpiresUtc = model.RememberMe ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(10);

                HttpContext.SignInAsync(claimPrincple, autoProps);

                return RedirectToAction("PersonelList", "Personel");
            }
            else
            {
                
                return View();
            }     
 
        }

        [Authorize]
        [HttpGet]

        public  IActionResult LogOut()
        {
            HttpContext.SignOutAsync("EKOM1907");
            return RedirectToAction("PersonelList", "Personel");
           
        }

    }

}
