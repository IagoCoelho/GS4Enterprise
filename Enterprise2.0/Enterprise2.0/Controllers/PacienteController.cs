using Enterprise2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise2._0.Controllers
{
    public class PacienteController : Controller
    {
        //Lista de carro para simular o banco de dados
        private static List<UsuarioPaciente> _lista = new List<UsuarioPaciente>();
        private static int _id = 0; //Controla o ID

        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Remover o carro da lista
            _lista.RemoveAt(_lista.FindIndex(p => p.IdPaciente == id));
            //Mensagem de sucesso
            TempData["msg"] = "Paciente removido!";
            //Redirecionar para a listagem
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(UsuarioPaciente paciente)
        {
            //Atualizar o carro na lista
            var index = _lista.FindIndex(p => p.IdPaciente == p.IdPaciente);
            //Substitui o objeto na posição do carro antigo
            _lista[index] = paciente;
            //Mensagem de sucesso
            TempData["msg"] = "Paciente atualizado!";
            //Redirect para a listagem/editar
            return RedirectToAction("editar");
        }

        [HttpGet] //Abrir o formulário com os dados preenchidos
        public IActionResult Editar(int id)
        {
            //Enviar as opções do select de marcas
            ListarGeneros();
            //Recuperar a posição do carro na lista através do id
            var index = _lista.FindIndex(p => p.IdPaciente == id);
            //Recuperar o carro através do ID
            var paciente = _lista[index];
            //Enviar o carro para a view
            return View(paciente);
        }

        public IActionResult Index()
        {
            //Enviar a lista de carro para a view
            return View(_lista);
        }

        [HttpGet] //Abrir a página com o formulário HTML
        public IActionResult Cadastrar()
        {
            ListarGeneros();
            return View();
        }

        private void ListarGeneros()
        {
            //Criar uma lista de string com as marcas
            var lista = new List<string>(new string[] {"Masculino", "Feminino"});
            //Envia as opções do select da marca para a view
            ViewBag.genero = new SelectList(lista);
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioPaciente paciente)
        {
            //Setar o código do carro
            paciente.IdPaciente = ++_id;
            //Adicionar o carro na lista
            _lista.Add(paciente);
            //Mandar uma mensagem de sucesso para a view
            TempData["msg"] = "Paciente cadastrado!";
            //Redireciona para o método Cadastrar
            return RedirectToAction("Cadastrar");
        }
    }
}
