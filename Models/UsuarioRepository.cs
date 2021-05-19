using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace AgenciaTurismo.Models
{
    public class UsuarioRepository //Interligar banco de dados com MODEL Usuario//
    {
        private const string DadosConexao = "DataBase=agenciaturismo; DataSource=localhost; User Id=root;";
        // atributos para conectar com o banco de dados

        public Usuario ValidarLogin(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM Usuario WHERE Login=@Login and Senha=@Senha";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = null;
            if(Reader.Read())
            {
                 UsuarioEncontrado = new Usuario();
                 UsuarioEncontrado.Id = Reader.GetInt32("Id");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    UsuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");

                UsuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }

            Conexao.Close(); 
            return (UsuarioEncontrado);

        }

        public void Cadastrar(Usuario usuario)
        {
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "INSERT INTO usuario (Nome, Login, Senha, DataNascimento) VALUES (@Nome, @Login, @Senha, @DataNascimento)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
            //Não precisa adicionar "Id"
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public void Editar(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "UPDATE usuario SET Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
    
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public void Excluir(Usuario usuario)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "DELETE FROM usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public List<Usuario> Listar()
        {
            //Esse método possui no escopo uma List<> invés do void porque ele serve para mostrar as informações desejadas que estão no banco de dados


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "SELECT * FROM usuario";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            MySqlDataReader Reader = Comando.ExecuteReader();
            //Comando para percorrer os registros do usuário

            List<Usuario> Lista = new List<Usuario>(); 

            while(Reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = Reader.GetInt32("Id");

                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    usuario.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    usuario.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    usuario.Senha = Reader.GetString("Senha");


                usuario.DataNascimento = Reader.GetDateTime("DataNascimento");
           

                Lista.Add(usuario);
            }

            Conexao.Close();
            //Fecha conexão

            return Lista;
        }
        public Usuario BuscarId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            
            Conexao.Open();
            //Abre conexão

            String Query = "SELECT * FROM usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", Id);
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            MySqlDataReader Reader = Comando.ExecuteReader();
            Usuario usuarioEncontrado = new Usuario();

            if (Reader.Read())
            {
        
                usuarioEncontrado.Id = Reader.GetInt32("Id");

                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    usuarioEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
                    usuarioEncontrado.Login = Reader.GetString("Login");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
                    usuarioEncontrado.Senha = Reader.GetString("Senha");


                usuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
            }
            
            Conexao.Close();
            //Fecha conexão

            return usuarioEncontrado;
        }



    }
}