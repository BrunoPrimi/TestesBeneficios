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

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class SimulacaoController : BaseController
    {
       
        private readonly IServicoSimulacao _servicoSimulacao;

        public SimulacaoController(IServicoSimulacao servicoSimulacao)
        {
            
            _servicoSimulacao = servicoSimulacao;
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

        public IActionResult Create()
        {
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

            ModelState.Remove("Produtos");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoSimulacao.Criar(simulacaoDTO);
                if (linhasAfetadas > 0 )
                    return RedirectToAction(nameof(Index));
            }
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

            ModelState.Remove("Produtos");
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