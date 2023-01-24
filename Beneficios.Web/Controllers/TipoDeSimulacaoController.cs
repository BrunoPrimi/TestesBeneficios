using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class TipoDeSimulacaoController : BaseController
    {
        private readonly TesteContext _context;

        public TipoDeSimulacaoController(TesteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}



