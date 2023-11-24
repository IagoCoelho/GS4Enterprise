﻿using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class PacienteController : Controller
    {
        private static List<UsuarioPaciente> _lista = new List<UsuarioPaciente>();
        private static int _id = 0;

        [HttpPost]
        public IActionResult Remover(int id)
        {
           
            _lista.RemoveAt(_lista.FindIndex(p => p.IdPaciente == id));
            TempData["msg"] = "Paciente removido!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(UsuarioPaciente paciente)
        {
            var index = _lista.FindIndex(p => p.IdPaciente == p.IdPaciente);
            _lista[index] = paciente;
            TempData["msg"] = "Paciente atualizado!";
            return RedirectToAction("editar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            ListarGeneros();
 
            var index = _lista.FindIndex(p => p.IdPaciente == id);
            var paciente = _lista[index];
            return View(paciente);
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
        public IActionResult Cadastrar(UsuarioPaciente paciente)
        {
            paciente.IdPaciente = ++_id;
            _lista.Add(paciente);
            TempData["msg"] = "Paciente cadastrado!";
            return RedirectToAction("Cadastrar");
        }
    }
}
