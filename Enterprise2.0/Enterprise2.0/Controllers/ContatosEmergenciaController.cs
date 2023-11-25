using Enterprise2._0.Data;
using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise2._0.Controllers
{
    public class ContatosEmergenciaController : Controller
    {
        private readonly ContextNew _ContextNew;

        public ContatosEmergenciaController(ContextNew ContextNew)
        {
            _ContextNew = ContextNew;
        }

        [HttpPost]
        public async Task<IActionResult> Remover(int id)
        {
            var contato = await _ContextNew.ContatosEmergencia.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }

            _ContextNew.ContatosEmergencia.Remove(contato);
            await _ContextNew.SaveChangesAsync();
            TempData["msg"] = "Contato removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ContatosEmergencia contato)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Update(contato);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Contato atualizado!";
                return RedirectToAction(nameof(Editar), new { id = contato.IdContatosEmergencia });
            }
            return View(contato);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var contato = await _ContextNew.ContatosEmergencia.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            ListarGeneros();
            return View(contato);
        }

        public async Task<IActionResult> Index()
        {
            var contatos = await _ContextNew.ContatosEmergencia.ToListAsync();
            return View(contatos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ListarGeneros();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(ContatosEmergencia contato)
        {
            if (ModelState.IsValid)
            {
                _ContextNew.Add(contato);
                await _ContextNew.SaveChangesAsync();
                TempData["msg"] = "Contato cadastrado!";
                return RedirectToAction(nameof(Cadastrar));
            }
            ListarGeneros();
            return View(contato);
        }

        private void ListarGeneros()
        {
            var lista = new List<string>(new string[] { "Masculino", "Feminino" });
            ViewBag.genero = new SelectList(lista);
        }
    }
}