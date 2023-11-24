using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class PlanoSaudeController : Controller
    {
        private static List<PlanoSaude> _lista = new List<PlanoSaude>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
            _lista.RemoveAt(_lista.FindIndex(ps => ps.IdPlanoSaude== id));
            TempData["msg"] = "Plano de saúde removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(PlanoSaude plano)
        {
            var index = _lista.FindIndex(ps => ps.IdPlanoSaude == ps.IdPlanoSaude);
            _lista[index] = plano;
            TempData["msg"] = "Plano de Saúde atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var index = _lista.FindIndex(ps => ps.IdPlanoSaude== id);
            var plano = _lista[index];
            return View(plano);
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
        public IActionResult Cadastrar(PlanoSaude plano)
        {
            plano.IdPlanoSaude = ++_id;
            _lista.Add(plano);
            TempData["msg"] = "Plano de Saúde cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
