using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInDocuments.Entities;
using DevInDocuments.Exceptions;

namespace DevInDocuments.UI
{
    public static class Menu
    {
        public static void Logo()
        {
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("");
            Console.WriteLine("\t 8888888b.                   8888888          ");
            Console.WriteLine("\t 888   Y88b                    888            ");
            Console.WriteLine("\t 888    888                    888            ");
            Console.WriteLine("\t 888    888  .d88b.  888  888  888   88888b.  ");
            Console.WriteLine("\t 888    888 d8P  Y8b 888  888  888   888  88b ");
            Console.WriteLine("\t 888    888 88888888 Y88  88P  888   888  888 ");
            Console.WriteLine("\t 888  .d88P Y8b.      Y8bd8P   888   888  888 ");
            Console.WriteLine("\t 8888888P     Y8888    Y88P  8888888 888  888 ");
            Console.WriteLine("");
            Console.WriteLine("\t 8888888b.                                                             888            ");
            Console.WriteLine("\t 888   Y88b                                                            888            ");
            Console.WriteLine("\t 888    888                                                            888            ");
            Console.WriteLine("\t 888    888  .d88b.   .d8888b 888  888 88888b.d88b.   .d88b.  88888b.  888888 .d8888b ");
            Console.WriteLine("\t 888    888 d88  88b d88P     888  888 888  888  88b d8P  Y8b 888  88b 888    88K");
            Console.WriteLine("\t 888    888 888  888 888      888  888 888  888  888 88888888 888  888 888     Y8888b.");
            Console.WriteLine("\t 888  .d88P Y88..88P Y88b.    Y88b 888 888  888  888 Y8b.     888  888 Y88b.       X88");
            Console.WriteLine("\t 8888888P     Y88P     Y8888P  Y88888  888  888  888   Y8888  888  888   Y888  88888P'");
            Console.WriteLine("");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Thread.Sleep(2500);
            Console.Clear();
        } 
        
        public static string Login(List<Pessoa> lista)
        {
            Console.Clear();
            Console.WriteLine("Digite seu código:");
            var codigoDigitado = Console.ReadLine();

            int controle = 0;
            foreach (Pessoa pessoa in lista)
            {
                if (pessoa.Codigo == codigoDigitado)
                {
                    Console.WriteLine("Digite a sua senha:");
                    var senhaDigitada = Console.ReadLine();
                    if (pessoa.VerificaSenha(senhaDigitada))
                    {
                        controle += 1;
                        Console.Clear();
                        SucessoConsole($"Seja bem vindo {pessoa.Nome}!");
                        return pessoa.Codigo;
                    }
                    
                }
            }
            if(controle == 0)
            {
                Console.Clear();
                ErroConsole("Código ou senha inválida");
                throw new UserNotFoundException();
            }
            else
            {
                return null;
            }

        }

        public static void Cadastrar(List<Pessoa> lista)
        {
            Console.Clear();
            int codigo = 1;
            foreach (Pessoa pessoa in lista)
            {
                codigo += 1;
            }
            string codigoUsuario = codigo.ToString();

            Console.WriteLine("Qual o Nome do novo usuário?:");
            var nomeUsuario = Console.ReadLine();
            Console.WriteLine("Qual o Endereço do novo usuário?:");
            var enderecoUsuario = Console.ReadLine();

            Console.WriteLine("Qual a data de nascimento do novo usuário? Utilizar formato(dd/mm/aaaa):");
            DateTime nascimento;
            while (true)
            {
                var nascimentoUsuario = Console.ReadLine();  
                bool isSuccess = DateTime.TryParse(nascimentoUsuario, out nascimento);
                if (isSuccess)
                {
                    break;
                }
                else
                {
                    ErroConsole("Formato invalido, utilize dd/mm/aaaa");
                    continue;
                }
            }

            Console.WriteLine("Qual a Filiação do novo usuário?:");
            var filiacaoUsuario = Console.ReadLine();

            string senha;
            while (true)
            {
                Console.WriteLine("Qual a Senha do novo usuário?:");
                var senhaUsuario = Console.ReadLine();
                Console.WriteLine("Por favor confirme a senha digitando novamente:");
                var senhaUsuario2 = Console.ReadLine();
                if(senhaUsuario == senhaUsuario2)
                {
                    senha = senhaUsuario;
                    break;
                }
                else
                {
                    ErroConsole("As senhas digitadas não são iguais");
                    continue;
                }
            }

            
            Pessoa novoFuncionario = new Pessoa(codigoUsuario, nomeUsuario, enderecoUsuario, nascimento, filiacaoUsuario, DateTime.Now, senha);
            lista.Add(novoFuncionario);
            Console.Clear();
            SucessoConsole($"Novo usuário criado com sucesso! O código de acesso é: {codigoUsuario}");
        }

        public static void AlterarDocumento(List<Documento> lista)
        {
            Console.WriteLine("Lista de documentos disponíveis");
            foreach (var documento in lista)
            {
                documento.ListarDocumento();
            }
            Console.WriteLine("\n Digite o código do documento que deseja alterar:");
            var documentoEscolhido = Console.ReadLine();
            int controle = 0;
            foreach (var documento in lista)
            {
                if (documentoEscolhido == documento.Codigo())
                {
                    controle += 1;
                    documento.AlterarDocumento();
                }
            }
            if (controle == 0)
            {
                ErroConsole("Não foi possível localizar o documento");
            }

        }

        public static void AlterarStatus(List<Documento> lista)
        {
            Console.WriteLine("Lista de documentos disponíveis");
            foreach (var documento in lista)
            {
                documento.ListarDocumento();
            }
            Console.WriteLine("\n Digite o código do documento que deseja alterar o status:");
            var documentoEscolhido = Console.ReadLine();
            int controle = 0;
            foreach (var documento in lista)
            {
                if (documentoEscolhido == documento.Codigo())
                {
                    controle += 1;
                    documento.AlterarStatus();
                }
            }
            if (controle == 0)
            {
                ErroConsole("Não foi possível localizar o documento");
            }

        }

        public static void PesquisarDocumentos(List<Documento> lista)
        {
            while (true)
            {
                Console.WriteLine("Digite 1 para exibir todos os documentos");
                Console.WriteLine("Digite 2 para exibir documentos por status");
                Console.WriteLine("Digite 3 para exibir documentos conforme o tipo");
                Console.WriteLine("Digite 4 para exibir um documento conforme o seu código");
                Console.WriteLine("Digite 5 para exibir o total de documentos");
                Console.WriteLine("Digite 6 para SAIR");

                var escolhaPesquisa = Console.ReadLine();
                Console.Clear();
                if (escolhaPesquisa == "1")
                {
                    foreach(var documento in lista)
                    {
                        documento.ListarDocumento();
                    }
                    continue;
                }
                else if (escolhaPesquisa == "2")
                {
                    int controleStatus = 0;
                    while (true)
                    {
                        Console.WriteLine("Digite 1 para exibir documentos Ativos");
                        Console.WriteLine("Digite 2 para exibir documentos Em tramitação");
                        Console.WriteLine("Digite 3 para exibir documentos Suspensos");
                        
                        var escolhaStatus = Console.ReadLine();
                        if(escolhaStatus == "1")
                        {
                            foreach (var documento in lista)
                            {
                                if(documento.Status() == EnumStatus.Ativo)
                                {
                                    controleStatus += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break;

                        }
                        else if(escolhaStatus == "2")
                        {
                            foreach (var documento in lista)
                            {
                                if (documento.Status() == EnumStatus.EmTramitacao)
                                {
                                    controleStatus += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break;

                        }
                        else if (escolhaStatus == "3")
                        {
                            foreach (var documento in lista)
                            {
                                if (documento.Status() == EnumStatus.Suspenso)
                                {
                                    controleStatus += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break;

                        }
                        else
                        {
                            ErroConsole("Opção selecionada não é valida");
                            continue;
                        }


                    }
                    if(controleStatus == 0)
                    {
                        ErroConsole("Não foi possível localizar nenhum documento com esse filtro");
                    }
                    continue;

                }
                else if (escolhaPesquisa == "3")
                {
                    int controleTipo = 0;
                    while (true)
                    {
                        Console.WriteLine("Digite 1 para exibir Notas Fiscais");
                        Console.WriteLine("Digite 2 para exibir Licenças de Funcionamento");
                        Console.WriteLine("Digite 3 para exibir Contratos");

                        var escolhaTipo = Console.ReadLine();
                        if (escolhaTipo == "1")
                        {
                            foreach (var documento in lista)
                            {
                                if (documento.GetType() == typeof(NotaFiscal))
                                {
                                    controleTipo += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break ;
                        }
                        else if (escolhaTipo == "2")
                        {
                            foreach (var documento in lista)
                            {
                                if (documento.GetType() == typeof(LicencaFuncionamento))
                                {
                                    controleTipo += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break;
                        }
                        else if (escolhaTipo == "3")
                        {
                            foreach(var documento in lista)
                            {
                                if (documento.GetType() == typeof(Contrato))
                                {
                                    controleTipo += 1;
                                    documento.ListarDocumento();
                                }
                            }
                            break;
                        }
                        else
                        {
                            continue;
                        }


                    }
                    if (controleTipo == 0)
                    {
                        ErroConsole("Não foi possível localizar nenhum documento com esse filtro");
                    }
                    continue;

                }
                else if (escolhaPesquisa == "4")
                {
                    Console.WriteLine("Digite o código do documento para exibir-lo:");
                    var documentoEscolhido = Console.ReadLine();
                    int controleCodigo = 0;
                    foreach (var documento in lista)
                    {
                        if (documentoEscolhido == documento.Codigo())
                        {
                            controleCodigo += 1;
                            documento.ListarDocumento();
                        }
                    }
                    if (controleCodigo == 0)
                    {
                        ErroConsole("Não foi possível localizar o documento");
                    }
                    continue;

                }
                else if (escolhaPesquisa == "5")
                {
                    int controleTotal = 0;
                    foreach (var documento in lista)
                    {
                        controleTotal += 1;
                    }
                    SucessoConsole($"O total de documentos cadastrados: {controleTotal} \n");
                    continue;


                }
                else if (escolhaPesquisa == "6")
                {
                    break;
                }
                else
                {
                    ErroConsole("Opção selecionada não é valida");
                    continue;
                }
            }
            

        }

        public static void ErroConsole(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n {mensagem} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SucessoConsole(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n {mensagem} \n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
}