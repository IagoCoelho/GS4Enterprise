using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise2._0.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ContextNew _ContextNew;

        public MedicoController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int id)
        {
            var medico = await _ContextNew.UsuariosMedicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _ContextNew.UsuariosMedicos.Remove(medico);
            await _ContextNew.SaveChangesAsync();
            TempData["msg"] = "Médico removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(UsuarioMedico medico)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Update(medico);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Médico atualizado!";
                return RedirectToAction(nameof(Editar), new { id = medico.IdMedico });
            }
            ListarGeneros();
            return View(medico);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var medico = await _ContextNew.UsuariosMedicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            ListarGeneros();
            return View(medico);
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _ContextNew.UsuariosMedicos.ToListAsync();
            return View(medicos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ListarGeneros();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(UsuarioMedico medico)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(medico);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Médico cadastrado!";
                return RedirectToAction(nameof(Cadastrar));
            }
            ListarGeneros();
            return View(medico);
        }

        private void ListarGeneros()
        {
            var lista = new List<string>(new string[] { "Masculino", "Feminino" });
            ViewBag.genero = new SelectList(lista);
        }
    }
}