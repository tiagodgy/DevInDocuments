using DevInDocuments.UI;
using DevInDocuments.Entities;
using DevInDocuments.Exceptions;

List<Documento> documentos = new List<Documento>();
List<Pessoa> pessoas = new List<Pessoa>();

//Credenciais de teste
Pessoa tiago = new Pessoa("1", "Tiago", "Rua, Bairro", new DateTime(04 / 10 / 2000), "Empregado", DateTime.Now, "123");
pessoas.Add(tiago);
NotaFiscal notaFiscal = new NotaFiscal("1", DateTime.Now, DateTime.Now, "Associação Comércio Paulista LTDA", "05.453.997/0001-59", EnumStatus.EmTramitacao, tiago.Codigo, 100m, "Kit copo de vidro", EnumImpostos.ICMS, 10m);
LicencaFuncionamento licenca = new LicencaFuncionamento("2", DateTime.Now, DateTime.Now, "Comércio de Peças Curitibano LTDA", "46.205.061/0001-96", EnumStatus.Ativo, tiago.Codigo, "Rua da avenida, bairro da cidade", "Comércio de equipamentos industriais");
Contrato contrato = new Contrato("3", DateTime.Now, DateTime.Now, "Desenvolvimento de Software Tiago ME", "35.789.563/0001-95", EnumStatus.Suspenso, tiago.Codigo, "Aluguel de escritório", "Gustavo", "Guilherme",new DateTime(10/04/2023));
documentos.Add(notaFiscal);
documentos.Add(licenca);
documentos.Add(contrato);
//Credenciais terminam aqui

Menu.Logo();

Console.WriteLine("Bem vindo ao sistema DevInDocuments");
string codigoUsuario;
while (true)
{   
    Console.WriteLine("Digite 1 para fazer Login");
    Console.WriteLine("Digite 2 para criar um novo usuário");
    var opcaoMenu1 = Console.ReadLine();
    if (opcaoMenu1 == "1")
    {
        try
        {
            codigoUsuario = Menu.Login(pessoas);
            break;
        }
        catch (UserNotFoundException)
        {
            continue;
        }
    }
    else if(opcaoMenu1 == "2")
    {
        Menu.Cadastrar(pessoas);
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Opção selecionada não é válida \n");
        continue;
    }

}

while (true)
{
    Console.Clear();
    Console.WriteLine("Selecione a opção desejada \n");
    Console.WriteLine("Digite 1 para Cadastrar um novo documento");
    Console.WriteLine("Digite 2 para Alterar itens de um documento");
    Console.WriteLine("Digite 3 para Alterar o Status de um documento");
    Console.WriteLine("Digite 4 para  Pesquisar um documento(s)");
    Console.WriteLine("Digite 5 para  Sair");
    var opcaoMenu2 = Console.ReadLine();
    Console.Clear();
    if (opcaoMenu2 == "1")
    {
        Console.WriteLine("Qual tipo de documento deseja cadastrar? \n");
        Console.WriteLine("Digite 1 para Nota Fiscal");
        Console.WriteLine("Digite 2 para Licença de Funcionamento");
        Console.WriteLine("Digite 3 para  Contrato");
        while (true)
        {
            var opcaoMenuCadastro = Console.ReadLine();
            if (opcaoMenuCadastro == "1")
            {
                NotaFiscal.CadastrarDocumento(documentos, codigoUsuario);
                break;
            }
            else if (opcaoMenuCadastro == "2")
            {
                LicencaFuncionamento.CadastrarDocumento(documentos, codigoUsuario);
                break ;
            }
            else if (opcaoMenuCadastro == "3")
            {
                Contrato.CadastrarDocumento(documentos, codigoUsuario);
                break;
            }
            else
            {
                Console.WriteLine("Opção selecionada não é válida \n");
                continue;
            }
        }
        continue;

    }
    else if (opcaoMenu2 =="2")
    {
        Menu.AlterarDocumento(documentos);
    }
    else if(opcaoMenu2 == "3")
    {
        Menu.AlterarStatus(documentos);
    }
    else if (opcaoMenu2 == "4")
    {
        Menu.PesquisarDocumentos(documentos);
    }
    else if (opcaoMenu2 == "5")
    {
        break;
    }
    else
    {
        Console.WriteLine("Opção selecionada não é válida \n");
        continue;
    }

}