using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestesBeneficios.Domain.DTO;
using TestesBeneficios.Domain.Entidades;
using TestesBeneficios.Domain.Servicos.Implementacoes;
using TestesBeneficios.Domain.Servicos.Interfaces;
using TestesBeneficios.Infra.Data.Context;

namespace TestesBeneficios.Controllers
{
    [Authorize]
    public class ProdutoAbrangenciaController : BaseController
    {
       

        private readonly IServicoProduto _servicoProduto;

        private readonly IServicoProdutoAbrangencia _servicoProdutoAbrangencia;


        public ProdutoAbrangenciaController( IServicoProduto servicoProduto, IServicoProdutoAbrangencia servicoProdutoAbrangencia)
        {
           

            _servicoProduto = servicoProduto;

            _servicoProdutoAbrangencia = servicoProdutoAbrangencia;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(await _servicoProdutoAbrangencia.BuscarTodos());

        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoAbrangencia = await _servicoProdutoAbrangencia.BuscarPeloId(id.Value);
            if (produtoAbrangencia == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoAbrangencia);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoAbrangenciaDTO produtoAbrangenciaDTO)
        {
            ModelState.Remove("Produto");

            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoProdutoAbrangencia.Criar(produtoAbrangenciaDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoAbrangenciaDTO);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produtoAbrangencia = await _servicoProdutoAbrangencia.BuscarPeloId(id.Value);
            if (produtoAbrangencia == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoAbrangencia);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoAbrangenciaDTO produtoAbrangenciaDTO)
        {
            if (id != produtoAbrangenciaDTO.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Produto");
            if (ModelState.IsValid)
            {
                await _servicoProdutoAbrangencia.Edit(id, produtoAbrangenciaDTO);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoAbrangenciaDTO);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoAbrangencia = await _servicoProdutoAbrangencia.BuscarPeloId(id.Value);
            if (produtoAbrangencia == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoAbrangencia);
        }
        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var produtoAbrangencia = await _servicoProdutoAbrangencia.BuscarPeloId(id);
            if (produtoAbrangencia != null)
            {
                await _servicoProdutoAbrangencia.Excluir(id);
            }

            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return RedirectToAction(nameof(Index));
        }
    }
}
