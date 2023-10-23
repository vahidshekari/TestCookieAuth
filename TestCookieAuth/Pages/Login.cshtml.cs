using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestCookieAuth.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            string userName = Request.Form["txtUsername"];
            string password = Request.Form["txtPassword"];
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userName)
                    };
            if(userName == "HajAliNaqavi" && password == "123456")
            {
                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies")));
                return Redirect("/Index");
            }
           
            return Page();
        }
    }
}
