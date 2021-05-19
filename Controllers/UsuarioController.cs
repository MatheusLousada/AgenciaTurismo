using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AgenciaTurismo.Models;
using System;



namespace AgenciaTurismo.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario){
            
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuarioSessao = ur.ValidarLogin(usuario);

            if (usuarioSessao != null){
                HttpContext.Session.SetInt32("IdUsuario",usuarioSessao.Id);
                HttpContext.Session.SetString("NomeUsuario",usuarioSessao.Nome);

                        ViewBag.Mensagem = "Você está logado!";

                return RedirectToAction("Lista");
            } else {
                ViewBag.Mensagem = "Falha no login"; 

                return View();
            }
        }

        public IActionResult Logout(){

            HttpContext.Session.Clear();
            //Limpa todos os dados de uma sessão
            return View("Login");
        }

        public IActionResult Lista(){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"
            
            UsuarioRepository pt = new UsuarioRepository();
            //Instacia um objeto da Model que conecta com o banco de dados

            List<Usuario> Listagem = pt.Listar();
            //Chama o método pretendido no caso "Listar()"

            return View(Listagem);
            //Retorno pra View a List<> feita a partir do método "Listar()" no Model "PacotesTuristicosRepository"
        }

        public IActionResult Cadastrar(){

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario){
            // Precisa-se acesssar o banco de dados, para persistir(gravar) o objeto recebido


            UsuarioRepository pt = new UsuarioRepository();
            //Cria um objeto "pt" da classe "UsuarioRepository" que conecta-se com o banco de dados

            pt.Cadastrar(usuario);
            //Usa o método "Cadastrar" no objeto "pt", o que conecta a Controller com a Model, passando o objeto "pacote" do tipo "PacotesTuristicos"

            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            //Mensagem enviada pra View

            return View();
        }

        public IActionResult Excluir(int Id){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            UsuarioRepository pt = new UsuarioRepository();
            //"pt" é o objeto que conecta com a classe(model) que conecta no banco

            Usuario usuarioEncontrado = pt.BuscarId(Id);
            //Cria objeto "pacoteEncontrado" da classe "PacotesTuristicos" com valor "pt.BuscarId(Id)" que irá receber esse "Id" para poder excluí-lo do banco de dados posteriormente
         
            pt.Excluir(usuarioEncontrado);
            //Exclui "pacoteEncontrado" através do método "Excluir" dentro de "pt"

            return RedirectToAction("Lista");
            //Após excluir irá chamar o método "Listar" mostrando a lista completa e atualizada
        }

        public IActionResult Editar(int Id){

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            UsuarioRepository pt = new UsuarioRepository();
            //"pt" é o objeto que conecta com a classe(model) que conecta no banco

            Usuario usuario = pt.BuscarId(Id);
            //Cria objeto "pacote" da classe "PacotesTuristicos" com valor "pt.BuscarId(Id)" que irá receber esse "Id" para poder editá-lo no banco de dados posteriormente 
         
            return View(usuario);
            //Retorno o "pacoteEncontrado" para a view "Editar"
        }

         [HttpPost]
        public IActionResult Editar(Usuario usuario){
            // Precisa-se acesssar o banco de dados, para persistir(gravar) o objeto recebido

            if(HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login");
            //Uma validação que se o usuário estiver nulo redireciona para a rota "Login" que manda pra view "Login"

            UsuarioRepository pt = new UsuarioRepository();
            //Cria um objeto "pt" da classe "PacotesTuristicosRepository" que conecta-se com o banco de dados

            pt.Editar(usuario);
            //Usa o método "Editar" no objeto "pt", o que conecta a Controller com a Model, passando o objeto "pacote" do tipo "PacotesTuristicos"

            return RedirectToAction("Lista");
        }

    }
}