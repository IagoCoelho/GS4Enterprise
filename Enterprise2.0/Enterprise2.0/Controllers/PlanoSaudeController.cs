using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Enterprise2._0.Controllers
{
    public class PlanoSaudeController : Controller
    {
        private readonly ContextNew _ContextNew;

        public PlanoSaudeController(ContextNew ContextNewNew)
        {
            _ContextNew = ContextNewNew;
        }

        [HttpPost]
        public async Task<IActionResult?> Remover(int id)
        {
            var plano = await _ContextNew.PlanosSaude.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }

            _ContextNew.PlanosSaude.Remove(plano);
            await _ContextNew.SaveChangesAsync();
            TempData["msg"] = "Plano de saúde removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult?> Editar(int id)
        {
            var plano = await _ContextNew.PlanosSaude.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(plano);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult?> Editar(PlanoSaude plano)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Update(plano);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Plano de Saúde atualizado!";
                return RedirectToAction(nameof(Editar), new { id = plano.IdPlanoSaude });
            }
            return View(plano);
        }

        public async Task<IActionResult?> Index()
        {
            var planos = await _ContextNew.PlanosSaude.ToListAsync();
            return View(planos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult?> Cadastrar(PlanoSaude plano)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(plano);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Plano de Saúde cadastrado!";
                return RedirectToAction(nameof(Cadastrar));
            }
            return View(plano);
        }
    }
}