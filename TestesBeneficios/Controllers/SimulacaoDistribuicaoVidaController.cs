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
    public class SimulacaoDistribuicaoVidaController : BaseController
    {

        private readonly IServicoSimulacaoDistribuicaoVida _servicoSimulacaoDistribuicaoVida;

        public SimulacaoDistribuicaoVidaController(IServicoSimulacaoDistribuicaoVida servicoSimulacaoDistribuicaoVida)
        {

            _servicoSimulacaoDistribuicaoVida = servicoSimulacaoDistribuicaoVida;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _servicoSimulacaoDistribuicaoVida.BuscarTodos());

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SimulacaoDistribuicaoVida = await _servicoSimulacaoDistribuicaoVida.BuscarPeloId(id.Value);
            if (SimulacaoDistribuicaoVida == null)
            {
                return NotFound();
            }

            return View(SimulacaoDistribuicaoVida);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
        {
            if (!simulacaoDistribuicaoVidaDTO.EhValido())
            {
                simulacaoDistribuicaoVidaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoSimulacaoDistribuicaoVida.Criar(simulacaoDistribuicaoVidaDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(simulacaoDistribuicaoVidaDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacaoDistribuicaoVida = await _servicoSimulacaoDistribuicaoVida.BuscarPeloId(id.Value);
            if (simulacaoDistribuicaoVida == null)
            {
                return NotFound();
            }
            return View(simulacaoDistribuicaoVida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SimulacaoDistribuicaoVidaDTO simulacaoDistribuicaoVidaDTO)
        {
            if (id != simulacaoDistribuicaoVidaDTO.Id)
            {
                return NotFound();
            }

            if (!simulacaoDistribuicaoVidaDTO.EhValido())
            {
                simulacaoDistribuicaoVidaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                await _servicoSimulacaoDistribuicaoVida.Edit(id, simulacaoDistribuicaoVidaDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(simulacaoDistribuicaoVidaDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacaoDistribuicaoVida = await _servicoSimulacaoDistribuicaoVida.BuscarPeloId(id.Value);
            if (simulacaoDistribuicaoVida == null)
            {
                return NotFound();
            }

            return View(simulacaoDistribuicaoVida);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var simulacaoDistribuicaoVida = await _servicoSimulacaoDistribuicaoVida.BuscarPeloId(id);
            if (simulacaoDistribuicaoVida != null)
            {
                await _servicoSimulacaoDistribuicaoVida.Excluir(id);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
