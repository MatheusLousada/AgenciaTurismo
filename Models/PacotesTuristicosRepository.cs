using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AgenciaTurismo.Models
{
    public class PacotesTuristicosRepository
    {
        private const string DadosConexao = "DataBase=agenciaturismo; DataSource=localhost; User Id=root;";


        public void Cadastrar(PacotesTuristicos pacote)
        {
            
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "INSERT INTO pacotesturisticos (Nome, Origem, Destino, Atrativos, Saida, Retorno, Usuario) VALUES (@Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
            //Não precisa adicionar "Id"
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public void Editar(PacotesTuristicos pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "UPDATE pacotesturisticos SET Nome=@Nome, Origem=@Origem, Destino=@Destino, Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", pacote.Id);
            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public void Excluir(PacotesTuristicos pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "DELETE FROM pacotesturisticos WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", pacote.Id);
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            Comando.ExecuteNonQuery();
            //Executa o objeto "Comando"
            

            Conexao.Close();
            //Fecha conexão
        }

        public List<PacotesTuristicos> Listar()
        {
            //Esse método possui no escopo uma List<> invés do void porque ele serve para mostrar as informações desejadas que estão no banco de dados


            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            

            Conexao.Open();
            //Abre conexão

            String Query = "SELECT * FROM pacotesturisticos";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            MySqlDataReader Reader = Comando.ExecuteReader();
            //Comando para percorrer os registros do usuário

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>(); 

            while(Reader.Read())
            {
                PacotesTuristicos pacote = new PacotesTuristicos();
                pacote.Id = Reader.GetInt32("Id");

                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    pacote.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pacote.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pacote.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pacote.Atrativos = Reader.GetString("Atrativos");


                pacote.Saida = Reader.GetDateTime("Saida");
                pacote.Retorno = Reader.GetDateTime("Retorno");
                pacote.Usuario = Reader.GetInt32("Usuario");

                Lista.Add(pacote);
            }

            Conexao.Close();
            //Fecha conexão

            return Lista;
        }
        public PacotesTuristicos BuscarId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            //Esse método recebe atributos chamado "DadosConexao", para criar conexão entre o meu .netcore com o banco de dados MySql
            
            Conexao.Open();
            //Abre conexão

            String Query = "SELECT * FROM pacotesturisticos WHERE Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            //Comando que ta dentro da variável "Query" que será usado dentro do banco de dados pela conexão do tipo "Conexao"
            //Por isso se tem dois parâmetros de entrada, um para o comando e outro pra conexão

            Comando.Parameters.AddWithValue("@Id", Id);
            //Comando que insere dados/valores para manipular o banco de dados automaticamente
            //Faz uma tratativa para associar o Id recebido na View como o user.Id
            //Tem que sempre ser colocado no caso de MySqlInjection para proteger, relacionando a View com um objeto do Model

            MySqlDataReader Reader = Comando.ExecuteReader();
            PacotesTuristicos pacoteEncontrado = new PacotesTuristicos();

            if (Reader.Read())
            {
        
                pacoteEncontrado.Id = Reader.GetInt32("Id");

                
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                //Trativa para usar nos campos do tipo String, para que caso o valor seja NULL retorne em branco ao invés de "NULL"
                    pacoteEncontrado.Nome = Reader.GetString("Nome");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Origem")))
                    pacoteEncontrado.Origem = Reader.GetString("Origem");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    pacoteEncontrado.Destino = Reader.GetString("Destino");

                if (!Reader.IsDBNull(Reader.GetOrdinal("Atrativos")))
                    pacoteEncontrado.Atrativos = Reader.GetString("Atrativos");


                pacoteEncontrado.Saida = Reader.GetDateTime("Saida");
                pacoteEncontrado.Retorno = Reader.GetDateTime("Retorno");
                pacoteEncontrado.Usuario = Reader.GetInt32("Usuario");

            }
            
            Conexao.Close();
            //Fecha conexão

            return pacoteEncontrado;
        }
    }
}