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
    public class PacienteController : Controller
    {
        private readonly ContextNew _ContextNew;

        public PacienteController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int id)
        {
            var paciente = await _ContextNew.UsuariosPacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            _ContextNew.UsuariosPacientes.Remove(paciente);
            await _ContextNew.SaveChangesAsync();
            TempData["msg"] = "Paciente removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(UsuarioPaciente paciente)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Update(paciente);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Paciente atualizado!";
                return RedirectToAction(nameof(Editar), new { id = paciente.IdPaciente });
            }
            ListarGeneros();
            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var paciente = await _ContextNew.UsuariosPacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ListarGeneros();
            return View(paciente);
        }

        public async Task<IActionResult> Index()
        {
            var pacientes = await _ContextNew.UsuariosPacientes.ToListAsync();
            return View(pacientes);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ListarGeneros();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(UsuarioPaciente paciente)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(paciente);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Paciente cadastrado!";
                return RedirectToAction(nameof(Cadastrar));
            }
            ListarGeneros();
            return View(paciente);
        }

        private void ListarGeneros()
        {
            var lista = new List<string>(new string[] { "Masculino", "Feminino" });
            ViewBag.genero = new SelectList(lista);
        }
    }
}
