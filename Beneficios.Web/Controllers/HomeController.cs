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
            var idade = ObterIdade(simulacaoDTO.DataNascimento);
            var produtos = await _context.Produtos
                                        .Include(x => x.Empresa)
                                        .Include(x => x.Abrangencias)
                                        .Include(x => x.FaixaEtaria)
                                        .Where(x => 
                                            (!x.Abrangencias.Any() ||(x.Abrangencias.Any() && x.Abrangencias.Any(y => y.Cidade.ToLower() == simulacaoDTO.Cidade.ToLower())))
                                            && x.FaixaEtaria.Any(y=>y.FaixaDe<=idade && y.FaixaAte>=idade)
                                        ).ToListAsync();

            var aa = produtos;

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