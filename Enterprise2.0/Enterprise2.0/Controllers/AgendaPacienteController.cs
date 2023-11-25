using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise2._0.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ContextNew _ContextNew;

        public AgendaController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
        }

        public async Task<IActionResult> Index()
        {
            var agendas = await _ContextNew.AgendasPacientes.ToListAsync();
            return View(agendas);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _ContextNew.AgendasPacientes.FirstOrDefaultAsync(a => a.IdAgenda == id);

            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(AgendaPaciente agenda)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(agenda);
                await _ContextNew.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _ContextNew.AgendasPacientes.FindAsync(id);

            if (agenda == null)
            {
                return NotFound();
            }
            return View(agenda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, AgendaPaciente agenda)
        {
            if (id != agenda.IdAgenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ContextNew.Update(agenda);
                await _ContextNew.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(agenda);
        }

        public async Task<IActionResult> Remover(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _ContextNew.AgendasPacientes.FirstOrDefaultAsync(a => a.IdAgenda == id);

            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarRemover(int id)
        {
            var agenda = await _ContextNew.AgendasPacientes.FindAsync(id);
            _ContextNew.AgendasPacientes.Remove(agenda);
            await _ContextNew.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}