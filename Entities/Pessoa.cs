using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Entities
{
    public class Pessoa
    {
        public string Codigo { get; private set; }
        public  string Nome { get; private set; }
        private string endereco;
        private DateTime dataNascimento;
        private string filiacao;
        private DateTime dataAdmissao;
        private string senha;

        public Pessoa(string codigo, string nome, string Endereco, DateTime DataNascimento, string Filiacao, DateTime DataAdmissao, string Senha)
        {
            Codigo = codigo;
            Nome = nome;
            endereco = Endereco;
            dataNascimento = DataNascimento;
            filiacao = Filiacao;
            dataAdmissao = DataAdmissao;
            senha = Senha;
        }

        public bool VerificaSenha(string senha)
        {
            if(senha == this.senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
