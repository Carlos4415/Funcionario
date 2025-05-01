using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionario
{
    static class ConexaoBanco
    {
        private const string servidor = "localhost";
        private const string porta = "3306";
        private const string bancoDados = "dbFuncionarios";
        private const string usuario = "root";
        private const string senha = "root";

        static public string bancoServidor = $"server={servidor}; port={porta}; user id={usuario}; database={bancoDados}; password={senha}";
    }
}
