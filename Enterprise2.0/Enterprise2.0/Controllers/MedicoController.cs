using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class MedicoController : Controller
    {
        private static List<UsuarioMedico> _lista = new List<UsuarioMedico>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.RemoveAt(_lista.FindIndex(m => m.IdMedico== id));
            TempData["msg"] = "Médico removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(UsuarioMedico medico)
        {
            var index = _lista.FindIndex(m => m.IdMedico == m.IdMedico);
            _lista[index] = medico;
            TempData["msg"] = "Médoco atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ListarGeneros();
            var index = _lista.FindIndex(m => m.IdMedico == id);
            var medico = _lista[index];
            return View(medico);
        }

        public IActionResult Index()
        {
            return View(_lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ListarGeneros();
            return View();
        }

        private void ListarGeneros()
        {
            var lista = new List<string>(new string[] {"Masculino", "Feminino"});
            ViewBag.genero = new SelectList(lista);
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioMedico medico)
        {
            medico.IdMedico = ++_id;
            _lista.Add(medico);
            TempData["msg"] = "Médico cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
