using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funcionario
{
    internal class CadastroFuncionarios
    {
        private int id;
        private string nome;
        private string email;
        private string cpf;
        private string endereco;

        public int Id
        {
            get { return id; } 
            set {  id = value; }
        }

        public string Nome
        { 
            get { return nome; } 
            set {  nome = value; } 
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public bool CadastrarFuncionarios() 
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);

                MysqlConexaoBanco.Open();

                string insert = $"insert into funcionarios (nome, email, cpf, endereco) value ('{Nome}', '{Email}', '{Cpf}', '{Endereco}')";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText = insert;
                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados - método CadastrarFuncionarios: " + ex.Message);

                return false;
            }
        }

        public MySqlDataReader LocalizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = $"select id, nome, email, cpf, endereco from funcionarios where cpf = '{cpf}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;
                MySqlDataReader reader = comandoSql.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no bando de dados - método LocalizarFuncionario: " + ex.Message);
                return null;
            }
        }

        public bool AtualizarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string update = $"update funcionarios set email = '{email}', endereco = '{endereco}' where id = '{Id}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText = update;
                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no bando de dados - método AtualizarFuncionario: " + ex.Message);
                return false;
            }
        }

        public bool DeletarFuncionario()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string delete = $"delete from funcionarios where id = '{Id}';";

                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText = delete;
                comandoSql.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no bando de dados - método DeletarFuncionario: " + ex.Message);
                return false;
            }
        }
    }
}
