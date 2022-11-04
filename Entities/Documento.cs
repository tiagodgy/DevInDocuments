using DevInDocuments.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Entities
{
    public abstract class Documento
    {
        private protected string codigo;
        private protected DateTime dataCadastro;
        private protected DateTime dataAlteracao;
        private protected string nomeEstabelecimento;
        private protected string cnpj;
        private protected EnumStatus status;
        private protected string codigoFuncionario;

        

        private protected Documento(string codigo, DateTime dataCadastro, DateTime dataAlteracao, string nomeEstabelecimento, string cnpj, EnumStatus status, string codigoFuncionario)
        {
            this.codigo = codigo;
            this.dataCadastro = dataCadastro;
            this.dataAlteracao = dataAlteracao;
            this.nomeEstabelecimento = nomeEstabelecimento;
            this.cnpj = cnpj;
            this.status = status;
            this.codigoFuncionario = codigoFuncionario;
        }

        public string Codigo()
        {
            return codigo;
        }
        public EnumStatus Status()
        {
            return status;
        }

        public static void CadastrarDocumento(List<Documento> listaDocumentos, string codigoFuncionario)
        {

        }
        public virtual void ListarDocumento()
        { 
            Console.WriteLine($"Código do documento: {this.codigo}:");
            Console.WriteLine($"Data de cadastro: {this.dataCadastro}");
            Console.WriteLine($"Data da última alteração: {this.dataAlteracao}");
            Console.WriteLine($"Nome do estabelecimento: {this.nomeEstabelecimento}");
            Console.WriteLine($"CNPJ: {this.cnpj}");
            Console.WriteLine($"Status do documento: {this.status}");
            Console.WriteLine($"Funcionário responsável: {this.codigoFuncionario}");
        }
        public virtual void AlterarDocumento()
        {
            

        }
        public void AlterarStatus()
        {
            Console.WriteLine("Digite 1 para alterar o estatus do documento para Ativo");
            Console.WriteLine("Digite 2 para alterar o estatus do documento para Em tramitação");
            Console.WriteLine("Digite 3 para alterar o estatus do documento para Suspenso");
            while (true)
            {
                var escolhaStatus = Console.ReadLine();
                if (escolhaStatus == "1")
                {
                    this.status = EnumStatus.Ativo;
                    break;
                }
                else if (escolhaStatus == "2")
                {
                    this.status=EnumStatus.EmTramitacao;
                    break;
                }
                else if (escolhaStatus == "3")
                {
                    this.status = EnumStatus.Suspenso;
                    break;
                }
                else
                {
                    Menu.ErroConsole("A opção selecionada não é valida.");
                    continue;
                }
            }
            this.dataAlteracao = DateTime.Now;
            Menu.SucessoConsole($"O status do documento foi alterado para {this.status}");
        }
    }
}
