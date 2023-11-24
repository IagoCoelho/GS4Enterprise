using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class FichaController : Controller
    {
        private static List<Ficha> _lista = new List<Ficha>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
           
            _lista.RemoveAt(_lista.FindIndex(f => f.IdFicha == id));
            TempData["msg"] = "Ficha removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Ficha ficha)
        {
            var index = _lista.FindIndex(f => f.IdFicha == f.IdFicha);
            _lista[index] = ficha;
            TempData["msg"] = "Ficha atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var index = _lista.FindIndex(f => f.IdFicha == id);
            var ficha = _lista[index];
            return View(ficha);
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
        public IActionResult Cadastrar(Ficha ficha)
        {
            ficha.IdFicha = ++_id;
            _lista.Add(ficha);
            TempData["msg"] = "Ficha cadastrada!";
            return RedirectToAction("Cadastrar");
        }
    }
}
