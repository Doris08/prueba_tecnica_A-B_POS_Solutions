using TestApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApp.Controllers;
using CustomIdentity.ViewModels;

namespace TestApp.Controllers.Auth;

public class AccountController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager) : Controller
{
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(Login model, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Correo!, model.Password!, false, false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "No es posible ingresar!");
        }
        return View(model);
    }

    public IActionResult Register(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(Register register, string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            Usuario user = new()
            {
                Nombres = register.Nombres,
                Apellidos = register.Apellidos,
                UserName = register.Email,
                Email = register.Email
            };

            var result = await userManager.CreateAsync(user, register.Password!);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);

                return RedirectToLocal(returnUrl);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(register);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
            ? Redirect(returnUrl)
            : RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
    }
}