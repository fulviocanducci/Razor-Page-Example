using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication19.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            await CreateCookie("fulviocanducci@hotmail.com");
            return RedirectToPage("/admin/index");
        }


        public async Task CreateCookie (string email)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email)
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}