using DevInDocuments.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Entities
{
    public class LicencaFuncionamento : Documento
    {
        private string endereco;
        private string areaAtuacao;

        public LicencaFuncionamento(string codigo, DateTime dataCadastro, DateTime dataAlteracao, string nomeEstabelecimento, string cnpj, EnumStatus status, string codigoFuncionario, string endereco, string areaAtuacao) : base(codigo, dataCadastro, dataAlteracao, nomeEstabelecimento, cnpj, status, codigoFuncionario)
        {
            this.codigo = codigo;
            this.dataCadastro = dataCadastro;
            this.dataAlteracao = dataAlteracao;
            this.nomeEstabelecimento = nomeEstabelecimento;
            this.cnpj = cnpj;
            this.status = status;
            this.codigoFuncionario = codigoFuncionario;
            this.endereco = endereco;
            this.areaAtuacao = areaAtuacao;
        }

        public static void CadastrarDocumento(List<Documento> listaDocumentos, string codigoFuncionario)
        {
            int codigo = 1;
            foreach (Documento f in listaDocumentos)
            {
                codigo += 1;
            }
            string codigoDocumento = codigo.ToString();

            Console.WriteLine("Para cadastrar uma nova Licença de Funcionamento preencha os dados solicitados.");

            Console.WriteLine("O nome do estabelecimento:");
            var nomeEstabelecimento = Console.ReadLine();

            Console.WriteLine("O CNPJ:");
            var cnpj = Console.ReadLine();

            Console.WriteLine("O endereço do estabelecimento:");
            var endereco = Console.ReadLine();

            Console.WriteLine("A área de atuação:");
            var areaAtuacao = Console.ReadLine();

            Console.WriteLine("Você está prestes a cadastra uma nova Licença de Funcionamento!");
            Console.WriteLine($"Documento: {codigoDocumento} - Destinatário: {nomeEstabelecimento} - CNPJ: {cnpj} - Endereço: {endereco} - Área de atuação: {areaAtuacao}");
            Console.WriteLine("Digite 1 para confirmar ou 2 para cancelar");
            while (true)
            {
                var confirmar = Console.ReadLine();
                if (confirmar == "1")
                {
                    LicencaFuncionamento novaLicenca = new LicencaFuncionamento(codigoDocumento, DateTime.Now, DateTime.Now, nomeEstabelecimento, cnpj, EnumStatus.EmTramitacao, codigoFuncionario, endereco, areaAtuacao);
                    listaDocumentos.Add(novaLicenca);
                    break;
                }
                else if (confirmar == "2")
                {
                    break;
                }
                else
                {
                    Menu.ErroConsole("A opção selecionada não é valida.");
                    continue;
                }

            }

        }

        public override void ListarDocumento()
        {
            Console.WriteLine("------------------------------- Licença de Funcionamento ------------------------------");
            base.ListarDocumento();
            Console.WriteLine($"Endereço: {this.endereco}");
            Console.WriteLine($"Área de atuação: {this.areaAtuacao}");
            Console.WriteLine("--------------------------------------------------------------------------------------- \n");
        }

        public override void AlterarDocumento()
        {

            while (true)
            {
                Console.WriteLine("Qual informação gostaria de alterar?");
                Console.WriteLine("Digite 1 para alterar o nome do estabelecimento");
                Console.WriteLine("Digite 2 para alterar o CNPJ");
                Console.WriteLine("Digite 3 para alterar o Endereço");
                Console.WriteLine("Digite 4 para alterar a Área de atuação");
                Console.WriteLine("Digite 5 para SAIR");
                var escolhaAlteracao = Console.ReadLine();
                if (escolhaAlteracao == "1")
                {
                    Console.WriteLine($"O nome atual do estabelecimento é {this.nomeEstabelecimento}");
                    Console.WriteLine("Digite o novo nome:");
                    this.nomeEstabelecimento = Console.ReadLine();
                    Menu.SucessoConsole($"O nome do estabelecimento foi alterado para {this.nomeEstabelecimento} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "2")
                {
                    Console.WriteLine($"O CNPJ atual é {this.cnpj}");
                    Console.WriteLine("Digite o novo CNPJ:");
                    this.cnpj = Console.ReadLine();
                    Menu.SucessoConsole($"O CNPJ foi alterado para {this.cnpj} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "3")
                {
                    Console.WriteLine($"O endereço atual é {this.endereco}");
                    Console.WriteLine("Digite o novo endereço:");
                    this.endereco = Console.ReadLine();
                    Menu.SucessoConsole($"O endereço foi alterado para {this.endereco} com sucesso!");
                    continue;

                }
                else if (escolhaAlteracao == "4")
                {
                    Console.WriteLine($"A área de atuação atual é {this.areaAtuacao}");
                    Console.WriteLine("Digite a nova área de atuação:");
                    this.areaAtuacao = Console.ReadLine();
                    Menu.SucessoConsole($"A área de atuação foi alterado para {this.areaAtuacao} com sucesso!");
                    continue;
                }
                
                else if (escolhaAlteracao == "5")
                {
                    break;
                }
                else
                {
                    Menu.ErroConsole("A opção selecionada não é valida.");
                    continue;
                }
            }

            this.dataAlteracao = DateTime.Now;
        }
    }
    
}
