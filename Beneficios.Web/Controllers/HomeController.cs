using Beneficios.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Infra.Data.Context;

namespace Beneficios.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly TesteContext _context;

        public HomeController(TesteContext context)
        {
            _context = context;
        }
     
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( SimulacaoDTO simulacaoDTO)
        {
       

            return View();
                

        }

        private int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if (dataNascimento > DateTime.Now.AddYears(-idade)) idade--;
           return idade;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}