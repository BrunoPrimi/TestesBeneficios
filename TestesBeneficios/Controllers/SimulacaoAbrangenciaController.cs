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
    public class SimulacaoAbrangenciaController : BaseController
    {

        private readonly IServicoSimulacaoAbrangencia _servicoSimulacaoAbrangencia;
        private readonly IServicoSimulacao _servicoSimulacao;

        public SimulacaoAbrangenciaController(IServicoSimulacaoAbrangencia servicoSimulacaoAbrangencia, IServicoSimulacao servicoSimulacao)
        {

            _servicoSimulacaoAbrangencia = servicoSimulacaoAbrangencia;
            _servicoSimulacao = servicoSimulacao;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _servicoSimulacaoAbrangencia.BuscarTodos());

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SimulacaoAbrangencia = await _servicoSimulacaoAbrangencia.BuscarPeloId(id.Value);
            if (SimulacaoAbrangencia == null)
            {
                return NotFound();
            }

            return View(SimulacaoAbrangencia);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SimulacaoId = new SelectList(await _servicoSimulacao.BuscarTodos(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO)
        {
            if (!simulacaoAbrangenciaDTO.EhValido())
            {
                simulacaoAbrangenciaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoSimulacaoAbrangencia.Criar(simulacaoAbrangenciaDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(simulacaoAbrangenciaDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacaoAbrangencia = await _servicoSimulacaoAbrangencia.BuscarPeloId(id.Value);
            if (simulacaoAbrangencia == null)
            {
                return NotFound();
            }
            return View(simulacaoAbrangencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, SimulacaoAbrangenciaDTO simulacaoAbrangenciaDTO)
        {
            if (id != simulacaoAbrangenciaDTO.Id)
            {
                return NotFound();
            }

            if (!simulacaoAbrangenciaDTO.EhValido())
            {
                simulacaoAbrangenciaDTO.ValidationResult.AddToModelState(ModelState);
            }

            ModelState.Remove("ValidationResult");
            if (ModelState.IsValid)
            {
                await _servicoSimulacaoAbrangencia.Edit(id, simulacaoAbrangenciaDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(simulacaoAbrangenciaDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var simulacaoAbrangencia = await _servicoSimulacaoAbrangencia.BuscarPeloId(id.Value);
            if (simulacaoAbrangencia == null)
            {
                return NotFound();
            }

            return View(simulacaoAbrangencia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var simulacaoAbrangencia = await _servicoSimulacaoAbrangencia.BuscarPeloId(id);
            if (simulacaoAbrangencia != null)
            {
                await _servicoSimulacaoAbrangencia.Excluir(id);
            }


            return RedirectToAction(nameof(Index));
        }


    }
}
