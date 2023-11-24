using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Enterprise2._0.Controllers
{
    public class AgendaPacienteController : Controller
    {
        private static List<AgendaPaciente> _lista = new List<AgendaPaciente>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.RemoveAt(_lista.FindIndex(ap => ap.IdAgenda == id));
            TempData["msg"] = "Agenda removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(AgendaPaciente agenda)
        {
            var index = _lista.FindIndex(ap => ap.IdAgenda == ap.IdAgenda);
            _lista[index] = agenda;
            TempData["msg"] = "Agenda atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var index = _lista.FindIndex(ap => ap.IdAgenda == id);
            var agenda = _lista[index];
            return View(agenda);
        }

        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Cadastrar(AgendaPaciente agenda)
        {
            agenda.IdAgenda = ++_id;
            _lista.Add(agenda);
            TempData["msg"] = "Agenda cadastrada!";
            return RedirectToAction("Cadastrar");
        }
    }
}
