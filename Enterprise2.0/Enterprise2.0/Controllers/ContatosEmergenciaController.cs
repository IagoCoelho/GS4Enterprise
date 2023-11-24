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
           
            _lista.RemoveAt(_lista.FindIndex(ce => ce.IdContatosEmergencia == id));
            TempData["msg"] = "Contato de emeregência removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(ContatosEmergencia emergencia)
        {
            var index = _lista.FindIndex(ce => ce.IdContatosEmergencia == ce.IdContatosEmergencia);
            _lista[index] = emergencia;
            TempData["msg"] = "Contato de emergência atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ListarGeneros();
 
            var index = _lista.FindIndex(ce => ce.IdContatosEmergencia == id);
            var emergencia = _lista[index];
            return View(emergencia);
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
        public IActionResult Cadastrar(ContatosEmergencia emergencia)
        {
            emergencia.IdContatosEmergencia = ++_id;
            _lista.Add(emergencia);
            TempData["msg"] = "Contato de emergêcia cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
