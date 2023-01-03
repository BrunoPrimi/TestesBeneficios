using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;
using TestesBeneficios.Infra.Data.Migrations;

namespace Beneficios.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly SignInManager<Usuario> _signManager;
        private readonly UserManager<Usuario> _userManager;
        public LoginController(SignInManager<Usuario> signManager, UserManager<Usuario> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(LoginDTO logindto)
        {
            if (ModelState.IsValid)
            {
                var resutado = await _signManager.PasswordSignInAsync(logindto.Email, logindto.Senha, false, false);
                if (resutado.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            return View(logindto);
        }
        public async Task<IActionResult> Cadastro()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Cadastro(CadastroDTO cadastrodto)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario();
                usuario.Id = Guid.NewGuid().ToString();
                usuario.Nome = cadastrodto.Nome;
                usuario.Email = cadastrodto.Email;
                usuario.UserName = usuario.Email;
                usuario.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(usuario, cadastrodto.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }
            return View(cadastrodto);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GoogleLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("GoogleResponse", "Login", new { returnUrl });

            var propriedades = _signManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return new ChallengeResult("Google", propriedades);
        }

        [AllowAnonymous]
        [HttpGet]
        //[Route("signin-google")]
        public async Task<IActionResult> GoogleResponse(string returnUrl)
        {
            var info = await _signManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(LoginController.Index), "Login");
            }

            var signInResult = await _signManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (signInResult.Succeeded)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            var usuario = new Usuario();
            usuario.Id = Guid.NewGuid().ToString();
            usuario.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
            usuario.Nome = info.Principal.FindFirst(ClaimTypes.Name).Value;
            usuario.UserName = usuario.Email;
            usuario.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(usuario);
            if (result.Succeeded)
            {
                var _identityResult = await _userManager.AddLoginAsync(usuario, info);
            
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }


            return View();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult FacebookLogin(string returnUrl)
        {
            string redirectUrl = Url.Action("FacebookResponse", "Login", new { returnUrl });

            var propriedades = _signManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);

            return new ChallengeResult("Facebook", propriedades);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> FacebookResponse(string returnUrl)
        {
            var info = await _signManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return RedirectToAction(nameof(LoginController.Index), "Login");
            }

            var signInResult = await _signManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);

            if (signInResult.Succeeded)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            var usuario = new Usuario();
            usuario.Id = Guid.NewGuid().ToString();
            usuario.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
            usuario.Nome = info.Principal.FindFirst(ClaimTypes.Name).Value;
            usuario.UserName = usuario.Email;
            usuario.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(usuario);
            if (result.Succeeded)
            {
                var _identityResult = await _userManager.AddLoginAsync(usuario, info);

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }


            return RedirectToAction(nameof(LoginController.Index), "Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
