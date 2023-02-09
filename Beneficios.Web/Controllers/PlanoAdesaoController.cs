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
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
                var id = await _servicoSimulacao.Criar(simulacaoDTO);
                
                    return RedirectToAction(nameof(Passo1), new {Id=id});
            }
            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id", "Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id", "Apelido");
            return View(simulacaoDTO);
        }


        public async Task<IActionResult> Passo1(Guid? id)
        {
            if (id == null || id == Guid.Empty)
                return NotFound();

            ViewData["id"] = id;

            var simulacaoDTO = await _servicoSimulacao.BuscarPeloId(id.Value);

            if (simulacaoDTO.SimulacaoDistribuicaoVida == null || !simulacaoDTO.SimulacaoDistribuicaoVida.Any()) 
            {
                simulacaoDTO.SimulacaoDistribuicaoVida = new List<SimulacaoDistribuicaoVidaDTO>();
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
                simulacaoDTO.SimulacaoDistribuicaoVida.Add(new SimulacaoDistribuicaoVidaDTO());
            }

            return View(simulacaoDTO);

        }

        [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Passo1(Guid id,SimulacaoDTO simulacaoDTO)
    {
            ModelState.RemoveAll<SimulacaoDTO>(x => x.SimulacaoDistribuicaoVida);
        if (!simulacaoDTO.EhValido_Distribuicao())
        {
            simulacaoDTO.ValidationResult.AddToModelState(ModelState);
        }
            ModelState.Remove("Profissao");
            ModelState.Remove("EntidadeDeClasse");
            ModelState.Remove("SimulacaoAbrangencia");
            ModelState.Remove("Simulacao");
            ModelState.Remove("ValidationResult");
            ModelState.Remove("Nome");
            ModelState.Remove("Cpf");
            ModelState.Remove("Email");

            if (ModelState.IsValid)
        {
          var _id = await _servicoSimulacao.CriarDistribuicaoVida(simulacaoDTO.SimulacaoDistribuicaoVida);
          return RedirectToAction(nameof(Passo2), new {Id=id});
        }
        ViewBag.SimulacaoId = new SelectList(await _servicoSimulacao.BuscarTodos(), "Id", "Nome");

        return View(simulacaoDTO);
    }

        public async Task<IActionResult> Passo2(Guid? id)
        {

            if (id == null || id == Guid.Empty)
                return NotFound();

            ViewData["id"] = id;

            var simulacaoDTO = await _servicoSimulacao.BuscarPeloId(id.Value);


            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id", "Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id", "Apelido");
            return View(simulacaoDTO);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Passo2( Guid id, SimulacaoDTO simulacaoDTO)
        {

            if (!simulacaoDTO.EhValido_Abrangencia())
            {
                simulacaoDTO.ValidationResult.AddToModelState(ModelState);
            }
            ModelState.Remove("Profissao");
            ModelState.Remove("EntidadeDeClasse");
            ModelState.Remove("ValidationResult");
            ModelState.Remove("SimulacaoAbrangencia");
            ModelState.Remove("SimulacaoDistribuicaoVida");
            ModelState.Remove("Nome");
            ModelState.Remove("Cpf");
            ModelState.Remove("Email");
            if (ModelState.IsValid)
            {
                var _id = await _servicoSimulacao.Edit(id,simulacaoDTO);

                return RedirectToAction(nameof(Passo3), new { Id = id });
            }
            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id", "Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id", "Apelido");
            return View(simulacaoDTO);
        }
        public async Task<IActionResult> Passo3(Guid? id)
        {

            if (id == null || id == Guid.Empty)
                return NotFound();

            ViewData["id"] = id;

            var produtoDTO = await _servicoSimulacao.BuscarProduto(id.Value);


            return View(produtoDTO);

        }
    }
}



