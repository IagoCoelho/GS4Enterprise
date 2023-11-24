using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class ContatosEmergenciaController : Controller
    {
        private static List<ContatosEmergencia> _lista = new List<ContatosEmergencia>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
           
            _lista.RemoveAt(_lista.FindIndex(c => c.IdContatosEmergencia == id));
            TempData["msg"] = "Contato removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatosEmergencia contato)
        {
            var index = _lista.FindIndex(c => c.IdContatosEmergencia == c.IdContatosEmergencia);
            _lista[index] = contato;
            TempData["msg"] = "Contato atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ListarGeneros();
 
            var index = _lista.FindIndex(c => c.IdContatosEmergencia == id);
            var contato = _lista[index];
            return View(contato);
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
        public IActionResult Cadastrar(ContatosEmergencia contato)
        {
            contato.IdContatosEmergencia = ++_id;
            _lista.Add(contato);
            TempData["msg"] = "Contato cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
