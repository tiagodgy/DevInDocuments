using DevInDocuments.Exceptions;
using DevInDocuments.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInDocuments.Entities
{
    public class NotaFiscal:Documento
    {
        private decimal valorTotal;
        private string nomeProduto;
        private EnumImpostos tipoImposto;
        private decimal valorTotalImposto;

        public NotaFiscal(string codigo, DateTime dataCadastro, DateTime dataAlteracao, string nomeEstabelecimento, string cnpj, EnumStatus status, string codigoFuncionario, decimal valorTotal, string nomeProduto, EnumImpostos tipoImposto, decimal valorTotalImposto):base(codigo, dataCadastro, dataAlteracao, nomeEstabelecimento, cnpj, status, codigoFuncionario)
        {
            this.codigo = codigo;
            this.dataCadastro = dataCadastro;
            this.dataAlteracao = dataAlteracao;
            this.nomeEstabelecimento = nomeEstabelecimento;
            this.cnpj = cnpj;
            this.status = status;
            this.codigoFuncionario = codigoFuncionario;
            this.valorTotal = valorTotal;
            this.nomeProduto = nomeProduto;
            this.tipoImposto = tipoImposto;
            this.valorTotalImposto = valorTotalImposto;
        }

        public static void CadastrarDocumento(List<Documento> listaDocumentos, string codigoFuncionario)
        {
            int codigo = 1;
            foreach (Documento f in listaDocumentos)
            {
                codigo += 1; 
            }
            string codigoDocumento = codigo.ToString();

            Console.WriteLine("Para cadastrar um nova nota fiscal preencha os dados solicitados.");
            
            Console.WriteLine("O nome do estabelecimento:");
            var nomeEstabelecimento = Console.ReadLine();
            
            Console.WriteLine("O CNPJ:");
            var cnpj = Console.ReadLine();

            Console.WriteLine("O valor total da nota:");
            Decimal valorTotal;
            while (true)
            {
                try
                {
                    valorTotal = Decimal.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("O valor inserido não é valido. Insira um valor válido:");
                    continue;
                }
                
            }
            
            

            Console.WriteLine("O nome do produto:");
            var nomeProduto = Console.ReadLine();

            Console.WriteLine("Qual tipo de imposto será aplicado?");
            Console.WriteLine("Digite 1 para selecionar ICMS");
            Console.WriteLine("Digite 2 para selecionar IPI");
            Console.WriteLine("Digite 3 para selecionar IOF");
            Console.WriteLine("Digite 4 para selecionar outro");
            EnumImpostos tipoImposto;
            while (true)
            {
                var tipoImpostoSelecionado = Console.ReadLine();
                if (tipoImpostoSelecionado == "1")
                {
                    tipoImposto = EnumImpostos.ICMS;
                    break;
                }
                else if (tipoImpostoSelecionado == "2")
                {
                    tipoImposto = EnumImpostos.IPI;
                    break;
                }
                else if (tipoImpostoSelecionado == "3")
                {
                    tipoImposto = EnumImpostos.IOF;
                    break;
                }
                else if (tipoImpostoSelecionado == "4")
                {
                    tipoImposto = EnumImpostos.Outro;
                    break;
                }
                else
                {
                    Console.WriteLine("Opção escolhida não é válida, escolha uma opção válida:");
                    continue;
                }
            }
            Console.WriteLine("O valor dos impostos:");
            Decimal valorTotalImpostos;
            while (true)
            {
                try
                {
                    valorTotalImpostos = Decimal.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("O valor inserido não é valido. Insira um valor válido:");
                    continue;
                }

            }

            Console.WriteLine("Você está prestes a cadastra uma nova notal fiscal!");
            Console.WriteLine($"Documento: {codigoDocumento} - Destinatário: {nomeEstabelecimento} - CNPJ: {cnpj} - Valor Total {valorTotal}");
            Console.WriteLine("Digite 1 para confirmar ou 2 para cancelar");
            while (true)
            {
                var confirmar = Console.ReadLine();
                if (confirmar == "1")
                {
                    NotaFiscal novaNota = new NotaFiscal(codigoDocumento, DateTime.Now, DateTime.Now, nomeEstabelecimento, cnpj, EnumStatus.EmTramitacao, codigoFuncionario, valorTotal, nomeProduto, tipoImposto, valorTotalImpostos);
                    listaDocumentos.Add(novaNota);
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

        public override void AlterarDocumento()
        {
            
            while (true)
            {
                Console.WriteLine("Qual informação gostaria de alterar?");
                Console.WriteLine("Digite 1 para alterar o nome do estabelecimento");
                Console.WriteLine("Digite 2 para alterar o CNPJ");
                Console.WriteLine("Digite 3 para alterar o valor total da nota");
                Console.WriteLine("Digite 4 para alterar o nome do produto");
                Console.WriteLine("Digite 5 para alterar o tipo do imposto");
                Console.WriteLine("Digite 6 para alterar o valor total do imposto");
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
                    Console.WriteLine($"O valor total atual é {this.valorTotal}");
                    Console.WriteLine("Digite o novo valor total:");
                    while (true)
                    {
                        try
                        {
                            this.valorTotal = Decimal.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("O valor inserido não é valido. Insira um valor válido:");
                            continue;
                        }

                    }
                    Console.WriteLine($"O valor total foi alterado para {this.valorTotal} com sucesso!");
                    continue;
                }
                else if (escolhaAlteracao == "4")
                {
                    Console.WriteLine($"O nome do produto atual é {this.nomeProduto}");
                    Console.WriteLine("Digite o novo nome do produto:");
                    this.nomeProduto = Console.ReadLine();
                    Console.WriteLine($"O nome do produto foi alterado para {this.nomeProduto} com sucesso!");
                    continue;

                }
                else if (escolhaAlteracao == "5")
                {
                    Console.WriteLine($"O tipo de imposto aplicado atual {this.tipoImposto}");
                    Console.WriteLine("Qual tipo de imposto será aplicado agora?");
                    Console.WriteLine("Digite 1 para selecionar ICMS");
                    Console.WriteLine("Digite 2 para selecionar IPI");
                    Console.WriteLine("Digite 3 para selecionar IOF");
                    Console.WriteLine("Digite 4 para selecionar outro");
                    while (true)
                    {
                        var tipoImpostoSelecionado = Console.ReadLine();
                        if (tipoImpostoSelecionado == "1")
                        {
                            this.tipoImposto = EnumImpostos.ICMS;
                            break;
                        }
                        else if (tipoImpostoSelecionado == "2")
                        {
                            this.tipoImposto = EnumImpostos.IPI;
                            break;
                        }
                        else if (tipoImpostoSelecionado == "3")
                        {
                            this.tipoImposto = EnumImpostos.IOF;
                            break;
                        }
                        else if (tipoImpostoSelecionado == "4")
                        {
                            this.tipoImposto = EnumImpostos.Outro;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Opção escolhida não é válida, escolha uma opção válida:");
                            continue;
                        }
                    }
                    Console.WriteLine($"O tipo de imposto foi alterado para {this.tipoImposto} com sucesso!");

                }
                else if (escolhaAlteracao == "6")
                {
                    Console.WriteLine($"O valor total atual é {this.valorTotalImposto}");
                    Console.WriteLine("Digite o novo valor total de impostos:");
                    while (true)
                    {
                        try
                        {
                            this.valorTotalImposto = Decimal.Parse(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("O valor inserido não é valido. Insira um valor válido:");
                            continue;
                        }

                    }
                    Console.WriteLine($"O valor total de impostos foi alterado para {this.valorTotalImposto} com sucesso!");
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

        public override void ListarDocumento()
        {
            Console.WriteLine("------------------------------------- Nota Fiscal -------------------------------------");
            base.ListarDocumento();
            Console.WriteLine($"Valor total: R${this.valorTotal}");
            Console.WriteLine($"Nome do produto: {this.nomeProduto}");
            Console.WriteLine($"Tipo do imposto: {this.tipoImposto}");
            Console.WriteLine($"Valor total do imposto: R${this.valorTotalImposto}");
            Console.WriteLine("--------------------------------------------------------------------------------------- \n");
        }
    }
}
