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
    public class ProdutoFaixaEtariaController : BaseController
    {
        private readonly TesteContext _context;

        private readonly IServicoProduto _servicoProduto;
        private readonly IServicoProdutoFaixaEtaria _servicoProdutoFaixaEtaria;
        public ProdutoFaixaEtariaController(TesteContext context, IServicoProduto servicoProduto, IServicoProdutoFaixaEtaria servicoProdutoFaixaEtaria)
        {
            _context = context;
            _servicoProduto = servicoProduto;
            _servicoProdutoFaixaEtaria = servicoProdutoFaixaEtaria;
    }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(await _servicoProdutoFaixaEtaria.BuscarTodos());

        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoFaixaEtaria = await _servicoProdutoFaixaEtaria.BuscarPeloId(id.Value);
            if (produtoFaixaEtaria == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoFaixaEtaria);
        }

        // GET: Usuario/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO)
        {
            ModelState.Remove("Produto");

            if (ModelState.IsValid)
            {
                var linhasAfetadas = await _servicoProdutoFaixaEtaria.Criar(produtoFaixaEtariaDTO);
                if (linhasAfetadas > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoFaixaEtariaDTO);
        }
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produtoFaixaEtaria = await _servicoProdutoFaixaEtaria.BuscarPeloId(id.Value);
            if (produtoFaixaEtaria == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoFaixaEtaria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoFaixaEtariaDTO produtoFaixaEtariaDTO)
        {
            if (id != produtoFaixaEtariaDTO.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Produto");
            if (ModelState.IsValid)
            {
                await _servicoProdutoFaixaEtaria.Edit(id, produtoFaixaEtariaDTO);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoFaixaEtariaDTO);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoFaixaEtaria = await _servicoProdutoFaixaEtaria.BuscarPeloId(id.Value);
            if (produtoFaixaEtaria == null)
            {
                return NotFound();
            }
            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return View(produtoFaixaEtaria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var produtoAbrangencia = await _servicoProdutoFaixaEtaria.BuscarPeloId(id);
            if (produtoAbrangencia != null)
            {
                await _servicoProdutoFaixaEtaria.Excluir(id);
            }

            ViewBag.ProdutoId = new SelectList(await _servicoProduto.BuscarTodos(), "Id", "NomeCodigo");
            return RedirectToAction(nameof(Index));
        }
    }
}
