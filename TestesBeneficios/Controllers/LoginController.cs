using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;
using TestesBeneficios.Infra.Data.Migrations;

namespace TestesBeneficios.Controllers
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

        public async Task<IActionResult>Index(LoginDTO logindto)
        {
            if (ModelState.IsValid)
            {
                var resutado = await _signManager.PasswordSignInAsync(logindto.Email, logindto.Senha, false, false);
                if (resutado.Succeeded)
                {
                    return RedirectToAction(nameof(Index),nameof(HomeController));
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
                usuario.UserName = usuario.Email;
                var result = await _userManager.CreateAsync(usuario,cadastrodto.Senha);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), nameof(HomeController));
                }

            }
            return View(cadastrodto);
        }
    }
}
