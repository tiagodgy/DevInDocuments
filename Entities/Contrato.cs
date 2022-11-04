using DevInDocuments.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Entities
{
    internal class Contrato : Documento
    {
        private string finalidade;
        private string testemunha1;
        private string testemunha2;
        private DateTime dataExpiracao;

        public Contrato(string codigo, DateTime dataCadastro, DateTime dataAlteracao, string nomeEstabelecimento, string cnpj, EnumStatus status, string codigoFuncionario, string finalidade, string testemunha1, string testemunha2, DateTime dataExpiracao) : base(codigo, dataCadastro, dataAlteracao, nomeEstabelecimento, cnpj, status, codigoFuncionario)
        {
            this.codigo = codigo;
            this.dataCadastro = dataCadastro;
            this.dataAlteracao = dataAlteracao;
            this.nomeEstabelecimento = nomeEstabelecimento;
            this.cnpj = cnpj;
            this.status = status;
            this.codigoFuncionario = codigoFuncionario;
            this.finalidade = finalidade;
            this.testemunha1 = testemunha1;
            this.testemunha2 = testemunha2;
            this.dataExpiracao = dataExpiracao;
            
        }

        public static void CadastrarDocumento(List<Documento> listaDocumentos, string codigoFuncionario)
        {
            int codigo = 1;
            foreach (Documento f in listaDocumentos)
            {
                codigo += 1;
            }
            string codigoDocumento = codigo.ToString();

            Console.WriteLine("Para cadastrar um novo Contrato preencha os dados solicitados.");

            Console.WriteLine("O nome do estabelecimento:");
            var nomeEstabelecimento = Console.ReadLine();

            Console.WriteLine("O CNPJ:");
            var cnpj = Console.ReadLine();

            Console.WriteLine("A finalidade do contrato:");
            var finalidade = Console.ReadLine();

            Console.WriteLine("O nome da primeira testemunha:");
            var testemunha1 = Console.ReadLine();

            Console.WriteLine("O nome da segunda testemunha:");
            var testemunha2 = Console.ReadLine();

            Console.WriteLine("A data de expiração do contrato:");
            DateTime dataExpiracao;
            while (true)
            {
                var dataExpiracaoInput = Console.ReadLine();
                bool isSuccess = DateTime.TryParse(dataExpiracaoInput, out dataExpiracao);
                if (isSuccess)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Formato invalido, utilize dd/mm/aaaa");
                    continue;
                }
            }

            Console.WriteLine("Você está prestes a cadastra um novo Contrato!");
            Console.WriteLine($"Documento: {codigoDocumento} - Destinatário: {nomeEstabelecimento} - CNPJ: {cnpj} - Finalidade: {finalidade} \n - Testemunhas: {testemunha1}, {testemunha2} - Data Expiração: {dataExpiracao}");
            Console.WriteLine("Digite 1 para confirmar ou 2 para cancelar");
            while (true)
            {
                var confirmar = Console.ReadLine();
                if (confirmar == "1")
                {
                    Contrato novoContrato = new Contrato(codigoDocumento, DateTime.Now, DateTime.Now, nomeEstabelecimento, cnpj, EnumStatus.EmTramitacao, codigoFuncionario, finalidade, testemunha1, testemunha2, dataExpiracao);
                    listaDocumentos.Add(novoContrato);
                    break;
                }
                else if (confirmar == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("A opção selecionada não é valida.");
                    continue;
                }

            }

        }

        public override void ListarDocumento()
        {
            Console.WriteLine("--------------------------------------- Contrato --------------------------------------");
            base.ListarDocumento();
            Console.WriteLine($"Finalidade: {this.finalidade}");
            Console.WriteLine($"Primeira testemunha: {this.testemunha1}");
            Console.WriteLine($"Segunda testemunha: {this.testemunha2}");
            Console.WriteLine($"Data de expiração: {this.dataExpiracao}");
            Console.WriteLine("--------------------------------------------------------------------------------------- \n");
        }

        public override void AlterarDocumento()
        {

            while (true)
            {
                Console.WriteLine("Qual informação gostaria de alterar?");
                Console.WriteLine("Digite 1 para alterar o nome do estabelecimento");
                Console.WriteLine("Digite 2 para alterar o CNPJ");
                Console.WriteLine("Digite 3 para alterar a Finalidade");
                Console.WriteLine("Digite 4 para alterar a Primeira Testemunha");
                Console.WriteLine("Digite 5 para alterar a Segunda Testemunha");
                Console.WriteLine("Digite 6 para alterar a Data de Expiração");
                Console.WriteLine("Digite 7 para SAIR");
                var escolhaAlteracao = Console.ReadLine();
                if (escolhaAlteracao == "1")
                {
                    Console.WriteLine($"O nome atual do estabelecimento é {this.nomeEstabelecimento}");
                    Console.WriteLine("Digite o novo nome:");
                    this.nomeEstabelecimento = Console.ReadLine();
                    Console.WriteLine($"O nome do estabelecimento foi alterado para {this.nomeEstabelecimento} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "2")
                {
                    Console.WriteLine($"O CNPJ atual é {this.cnpj}");
                    Console.WriteLine("Digite o novo CNPJ:");
                    this.cnpj = Console.ReadLine();
                    Console.WriteLine($"O CNPJ foi alterado para {this.cnpj} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "3")
                {
                    Console.WriteLine($"A finalidade atual é {this.finalidade}");
                    Console.WriteLine("Digite a nova finalidade:");
                    this.finalidade = Console.ReadLine();
                    Console.WriteLine($"A finalidade foi alterado para {this.finalidade} com sucesso!");
                    continue;

                }
                else if (escolhaAlteracao == "4")
                {
                    Console.WriteLine($"O nome da primeira testemunha atual é {this.testemunha1}");
                    Console.WriteLine("Digite o nome da nova testemunha:");
                    this.testemunha1 = Console.ReadLine();
                    Console.WriteLine($"O nome da primeira testemunha foi alterado para {this.testemunha1} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "5")
                {
                    Console.WriteLine($"O nome da segunda testeminha atual é {this.testemunha2}");
                    Console.WriteLine("Digite o nome da nova testemunha:");
                    this.testemunha2 = Console.ReadLine();
                    Console.WriteLine($"O nome da segunda testemunha foi alterado para {this.testemunha2} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "6")
                {
                    Console.WriteLine($"A data de expiração atual é {this.dataExpiracao}");
                    Console.WriteLine("Digite a nova data de expiração:");
                    DateTime dataExpiracao;
                    while (true)
                    {
                        var dataExpiracaoInput = Console.ReadLine();
                        bool isSuccess = DateTime.TryParse(dataExpiracaoInput, out dataExpiracao);
                        if (isSuccess)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Formato invalido, utilize dd/mm/aaaa");
                            continue;
                        }
                    }
                    this.dataExpiracao = dataExpiracao;
                    Console.WriteLine($"O data de expiração foi alterado para {this.testemunha2} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "7")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("A opção selecionada não é valida.");
                    continue;
                }
            }

            this.dataAlteracao = DateTime.Now;
        }
    }
}
