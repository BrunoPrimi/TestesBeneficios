using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Implementacoes;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;
using TestesBeneficios.Infra.Data.Migrations;

namespace Beneficios.Web.Controllers
{
    public class PlanoAdesaoController : BaseController
    {
        private readonly TesteContext _context;

        private readonly IServicoSimulacao _servicoSimulacao;

        private readonly IServicoProfissao _servicoProfissao;

        private readonly IServicoEntidadeDeClasse _servicoEntidadeDeClasse;

        private readonly IServicoSimulacaoDistribuicaoVida _servicoSimulacaoDistribuicaoVida;

        public PlanoAdesaoController(TesteContext context, IServicoSimulacao servicoSimulacao, IServicoProfissao servicoProfissao, IServicoEntidadeDeClasse servicoEntidadeDeClasse, IServicoSimulacaoDistribuicaoVida servicoSimulacaoDistribuicaoVida)
        {
            _context = context;
            _servicoSimulacao = servicoSimulacao;
            _servicoProfissao = servicoProfissao;
            _servicoEntidadeDeClasse = servicoEntidadeDeClasse;
            _servicoSimulacaoDistribuicaoVida = servicoSimulacaoDistribuicaoVida;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(SimulacaoDTO simulacaoDTO)
        {

            if (!simulacaoDTO.EhValido())
            {
                simulacaoDTO.ValidationResult.AddToModelState(ModelState);
            }
            ModelState.Remove("Profissao");
            ModelState.Remove("EntidadeDeClasse");
            ModelState.Remove("ValidationResult");
            ModelState.Remove("SimulacaoAbrangencia");
            ModelState.Remove("SimulacaoDistribuicaoVida");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoSimulacao.Criar(simulacaoDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id", "Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id", "Apelido");
            return View(simulacaoDTO);
        }
    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Passo1(SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
    {
        if (!simulacaoDistribuicaoVidaDTO.EhValido())
        {
            simulacaoDistribuicaoVidaDTO.ValidationResult.AddToModelState(ModelState);
        }

        ModelState.Remove("Simulacao");
        ModelState.Remove("ValidationResult");
        if (ModelState.IsValid)
        {
            var linhasAfetadas = await _servicoSimulacaoDistribuicaoVida.Criar(simulacaoDistribuicaoVidaDTO);
            if (linhasAfetadas > 0)
                return RedirectToAction(nameof(Index));
        }
        ViewBag.SimulacaoId = new SelectList(await _servicoSimulacao.BuscarTodos(), "Id", "Nome");

        return View(simulacaoDistribuicaoVidaDTO);
    }
}
}



