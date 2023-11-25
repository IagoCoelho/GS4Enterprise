using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise2._0.Controllers
{
    public class FichaController : Controller
    {
        private readonly ContextNew _ContextNew;

        public FichaController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int id)
        {
            var ficha = await _ContextNew.Fichas.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }

            _ContextNew.Fichas.Remove(ficha);
            await _ContextNew.SaveChangesAsync();
            TempData["msg"] = "Ficha removida!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Update(ficha);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Ficha atualizada!";
                return RedirectToAction(nameof(Editar), new { id = ficha.IdFicha });
            }
            return View(ficha);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var ficha = await _ContextNew.Fichas.FindAsync(id);
            if (ficha == null)
            {
                return NotFound();
            }
            return View(ficha);
        }

        public async Task<IActionResult> Index()
        {
            var fichas = await _ContextNew.Fichas.ToListAsync();
            return View(fichas);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(ficha);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Ficha cadastrada!";
                return RedirectToAction(nameof(Cadastrar));
            }
            return View(ficha);
        }
    }
}