using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;
using TestesBeneficios.Domain.Servicos.Implementacoes;

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class SimulacaoController : BaseController
    {
       
        private readonly IServicoSimulacao _servicoSimulacao;

        private readonly IServicoProfissao _servicoProfissao;

        private readonly IServicoEntidadeDeClasse _servicoEntidadeDeClasse;

        public SimulacaoController(IServicoSimulacao servicoSimulacao, IServicoProfissao servicoProfissao, IServicoEntidadeDeClasse servicoEntidadeDeClasse)
        {

            _servicoSimulacao = servicoSimulacao;
            _servicoProfissao = servicoProfissao;
            _servicoEntidadeDeClasse = servicoEntidadeDeClasse;
        }

        public async Task<IActionResult> Index()
        {
            return View( await _servicoSimulacao.BuscarTodos());
                       
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var simulacao = await _servicoSimulacao.BuscarPeloId(id.Value);
            if (simulacao == null)
            {
                return NotFound();
            }

            return View(simulacao);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id","Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id","Apelido");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SimulacaoDTO simulacaoDTO)
        {
           
            if (!simulacaoDTO.EhValido())
            {
                simulacaoDTO.ValidationResult.AddToModelState(ModelState);
            }
            ModelState.Remove("Profissao");
            ModelState.Remove("EntidadeDeClasse");
            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoSimulacao.Criar(simulacaoDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.ProfissaoId = new SelectList(await _servicoProfissao.BuscarTodos(), "Id", "Nome");
            ViewBag.EntidadeDeClasseId = new SelectList(await _servicoEntidadeDeClasse.BuscarTodos(), "Id", "Apelido");
            return View(simulacaoDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null )
            {   
                return NotFound();
            }

            var Simulacao = await _servicoSimulacao.BuscarPeloId(id.Value);
            if (Simulacao == null)
            {
                return NotFound();
            }
            return View(Simulacao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SimulacaoDTO simulacaoDTO)
        {
            if (id != simulacaoDTO.Id)
            {
                return NotFound();
            }

            if (!simulacaoDTO.EhValido())
            {
                simulacaoDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                await _servicoSimulacao.Edit(id, simulacaoDTO);
                
                return RedirectToAction(nameof(Index));
            }
            return View(simulacaoDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var simulacao = await _servicoSimulacao.BuscarPeloId(id.Value);
            if (simulacao == null)
            {
                return NotFound();
            }

            return View(simulacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
           
            var simulacao = await _servicoSimulacao.BuscarPeloId(id);
            if (simulacao != null)
            {
             await _servicoSimulacao.Excluir(id);
            }

            
            return RedirectToAction(nameof(Index));
        }

     
    }
}
