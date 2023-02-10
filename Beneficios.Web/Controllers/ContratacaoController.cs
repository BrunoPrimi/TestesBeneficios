using Beneficios.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace Beneficios.Web.Controllers
{
    public class ContratacaoController : BaseController
    {

        private readonly TesteContext _context;
        private readonly IServicoContratacao _servicoContratacao;

        public ContratacaoController(TesteContext context, IServicoContratacao servicoContratacao)
        {
            _context = context;
            _servicoContratacao = servicoContratacao;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index( ContratacaoDTO contratacaoDTO)
        {
       

            return View();
                

        }

      

      
    }
}