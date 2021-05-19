using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AgenciaTurismo.Models;



namespace AgenciaTurismo.Controllers
{
    public class PacotesTuristicosController: Controller
    {
        public IActionResult Listar(){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"
            
            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            //Instacia um objeto da Model que conecta com o banco de dados

            List<PacotesTuristicos> Listagem = pt.Listar();
            //Chama o método pretendido no caso "Listar()"

            return View(Listagem);
            //Retorno pra View a List<> feita a partir do método "Listar()" no Model "PacotesTuristicosRepository"
        }

        public IActionResult Cadastrar(){

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PacotesTuristicos pacote){
            // Precisa-se acesssar o banco de dados, para persistir(gravar) o objeto recebido


            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            //Cria um objeto "pt" da classe "PacotesTuristicosRepository" que conecta-se com o banco de dados

            pt.Cadastrar(pacote);
            //Usa o método "Cadastrar" no objeto "pt", o que conecta a Controller com a Model, passando o objeto "pacote" do tipo "PacotesTuristicos"

            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            //Mensagem enviada pra View

            return View();
        }

        public IActionResult Excluir(int Id){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            //"pt" é o objeto que conecta com a classe(model) que conecta no banco

            PacotesTuristicos pacoteEncontrado = pt.BuscarId(Id);
            //Cria objeto "pacoteEncontrado" da classe "PacotesTuristicos" com valor "pt.BuscarId(Id)" que irá receber esse "Id" para poder excluí-lo do banco de dados posteriormente
         
            pt.Excluir(pacoteEncontrado);
            //Exclui "pacoteEncontrado" através do método "Excluir" dentro de "pt"

            return RedirectToAction("Listar");
            //Após excluir irá chamar o método "Listar" mostrando a lista completa e atualizada
        }

        public IActionResult Editar(int Id){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            //"pt" é o objeto que conecta com a classe(model) que conecta no banco

            PacotesTuristicos pacote = pt.BuscarId(Id);
            //Cria objeto "pacote" da classe "PacotesTuristicos" com valor "pt.BuscarId(Id)" que irá receber esse "Id" para poder editá-lo no banco de dados posteriormente 
         
            return View(pacote);
            //Retorno o "pacoteEncontrado" para a view "Editar"
        }

         [HttpPost]
        public IActionResult Editar(PacotesTuristicos pacote){
            // Precisa-se acesssar o banco de dados, para persistir(gravar) o objeto recebido

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            PacotesTuristicosRepository pt = new PacotesTuristicosRepository();
            //Cria um objeto "pt" da classe "PacotesTuristicosRepository" que conecta-se com o banco de dados

            pt.Editar(pacote);
            //Usa o método "Editar" no objeto "pt", o que conecta a Controller com a Model, passando o objeto "pacote" do tipo "PacotesTuristicos"

            return RedirectToAction("Listar");
        }


    }
}