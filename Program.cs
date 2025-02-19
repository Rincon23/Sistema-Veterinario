using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;

namespace Sisvet_certo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Especie> BancodeEspecies = new List<Especie>();
            List<Animal> BancodeAnimais = new List<Animal>();
            List<Clientes> BancodeClientes = new List<Clientes>();

            string caminho = ConfigurationManager.AppSettings["caminho"];
            string NomeBancoAnimais = ConfigurationManager.AppSettings["NomeBancoAnimais"];
            string NomeBancoEspecies = ConfigurationManager.AppSettings["NomeBancoEspecies"];
            string NomeBancoClientes = ConfigurationManager.AppSettings["NomeBancoClientes"];


            BancodeEspecies = SalvarCarregarEspecie.CarregarListaEspecie(caminho + NomeBancoEspecies);
            BancodeAnimais = SalvarCarregarAnimais.CarregarListaAnimais(caminho + NomeBancoAnimais);
            BancodeClientes = SalvarCarregarCliente.CarregarListaCliente(caminho + NomeBancoClientes);

            
            int opc = 0;
            while (opc != 9)
            {
                int subopc = 0;
                Console.WriteLine("::Sistema Veterinario::");
                Console.WriteLine("1. Especie");
                Console.WriteLine("2. Animal");
                Console.WriteLine("3. Cliente");
                Console.WriteLine("9. Sair do sistema");
                Console.WriteLine();
                Console.Write("Digite a opcao: ");
                opc = int.Parse(Console.ReadLine());
                if (opc == 1)
                {
                    while (subopc != 9)
                    {
                        Console.WriteLine("1. Inserir Especie");
                        Console.WriteLine("2. Alterar Especie");
                        Console.WriteLine("3. Excluir Especie");
                        Console.WriteLine("4. Pesquisar Especie");
                        Console.WriteLine("5. Exibir Lista Especie");
                        Console.WriteLine("9. Sair do sistema");
                        Console.Write("Digite a opcao: ");
                        subopc = int.Parse(Console.ReadLine());
                        switch (subopc)
                        {
                            case 1:
                                Console.Write("Digite o Id: ");
                                string especieid = Console.ReadLine();
                                Console.Write("Digite a especie: ");
                                string especienome = Console.ReadLine();
                                BancodeEspecies.Add(new Especie(especieid, especienome));
                                Console.WriteLine("Especie inserido com sucesso.");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.Write("Digite o Id do animal que deseja alterar: ");
                                string alter = Console.ReadLine();
                                foreach (var especie in BancodeEspecies)
                                {
                                    if (especie.EspecieId == alter)
                                    {
                                        int sub2opc = 0;
                                        while (sub2opc != 9)
                                        {

                                            Console.WriteLine("1. Alterar Id");
                                            Console.WriteLine("2. Alterar Nome");
                                            Console.WriteLine("9. Sair");
                                            Console.WriteLine("Digite a opcao");
                                            sub2opc = int.Parse(Console.ReadLine());

                                            switch (sub2opc)
                                            {
                                                case 1:
                                                    Console.Write("Digite o novo Id: ");
                                                    especie.EspecieId = Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.Write("Digite a nova especie: ");
                                                    especie.EspecieNome = Console.ReadLine();
                                                    break;
                                            }
                                        }
                                    }

                                }

                                break;
                            case 3:
                                int Codigodevalidacao = 0;
                                Console.Write("Digite o Id do animal que deseja excluir: ");
                                string excluir = Console.ReadLine();
                                foreach (var especie in BancodeEspecies)
                                {
                                    if (especie.EspecieId == excluir)
                                    {
                                        BancodeEspecies.Remove(especie);
                                        Codigodevalidacao = 1;
                                        break;
                                    }
                                }
                                if (Codigodevalidacao != 1)
                                {
                                    Console.WriteLine("Id nao encontrado!");
                                    Codigodevalidacao = 0;
                                }
                                break;
                            case 4:
                                Console.Write("Digite o Id do animal que deseja pesquisar: ");
                                string pesquisa = Console.ReadLine();
                                foreach (var especie in BancodeEspecies)
                                {
                                    if (especie.EspecieId == pesquisa)
                                    {
                                        Console.WriteLine(especie.EspecieId
                                                          + " - " + especie.EspecieNome);
                                    }
                                }
                                break;
                            case 5:
                                if (BancodeEspecies.Count == 0)
                                {
                                    Console.WriteLine("Banco de Especies vazia");
                                }
                                else
                                {
                                    Console.WriteLine("Lista de Especies:");
                                    foreach (var especie in BancodeEspecies)
                                    {
                                        Console.WriteLine(especie.EspecieId
                                                          + " - " + especie.EspecieNome);
                                    }
                                }
                                break;
                        }

                    }
                }

                else if (opc == 2)
                {
                    while (subopc != 9)
                    {
                        Console.WriteLine("1. Inserir Animal");
                        Console.WriteLine("2. Alterar Animal");
                        Console.WriteLine("3. Excluir Animal");
                        Console.WriteLine("4. Pesquisar Animal");
                        Console.WriteLine("5. Exibir Lista Animal");
                        Console.WriteLine("9. Sair do sistema");
                        Console.Write("Digite a opcao: ");
                        subopc = int.Parse(Console.ReadLine());
                        switch (subopc)
                        {
                            case 1:
                                Console.Write("Digite o Id: ");
                                string animalid = Console.ReadLine();
                                Console.Write("Digite a Nome: ");
                                string nomeanimal = Console.ReadLine();
                                Console.Write("Digite a Apelido: ");
                                string animalapelido = Console.ReadLine();
                                Console.Write("Digite a Data de Nascimento: ");
                                string datanasc = Console.ReadLine();
                                Console.Write("Digite as Observacoes: ");
                                string animalobs = Console.ReadLine();
                                BancodeAnimais.Add(new Animal(animalid, nomeanimal, animalapelido, datanasc, animalobs));
                                Console.WriteLine("Animal inserido com sucesso.");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.Write("Digite o Id do animal que deseja alterar: ");
                                string alter = Console.ReadLine();
                                foreach (var animal in BancodeAnimais)
                                {
                                    if (animal.Animalid == alter)
                                    {
                                        int sub2opc = 0;
                                        while (sub2opc != 9)
                                        {

                                            Console.WriteLine("1. Alterar Id");
                                            Console.WriteLine("2. Alterar Nome");
                                            Console.WriteLine("3. Alterar Apelido");
                                            Console.WriteLine("4. Alterar Data de Nascimento");
                                            Console.WriteLine("5. Alterar Observacoes");
                                            Console.WriteLine("9. Sair");
                                            Console.WriteLine("Digite a opcao");
                                            sub2opc = int.Parse(Console.ReadLine());

                                            switch (sub2opc)
                                            {
                                                case 1:
                                                    Console.Write("Digite o novo Id: ");
                                                    animal.Animalid = Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.Write("Digite o novo Nome: ");
                                                    animal.Nomeanimal = Console.ReadLine();
                                                    break;
                                                case 3:
                                                    Console.Write("Digite o novo Apelido: ");
                                                    animal.Animalapelido = Console.ReadLine();
                                                    break;
                                                case 4:
                                                    Console.Write("Digite a nova Data de Nascimento: ");
                                                    animal.DataNasc = Console.ReadLine();
                                                    break;
                                                case 5:
                                                    Console.Write("Digite a nova Observacao: ");
                                                    animal.Animalobs = Console.ReadLine();
                                                    break;
                                            }
                                        }
                                    }

                                }
                                break;
                            case 3:
                                int Codigodevalidacao = 0;
                                Console.Write("Digite o Id do animal que deseja excluir: ");
                                string excluir = Console.ReadLine();
                                foreach (var animal in BancodeAnimais)
                                {
                                    if (animal.Animalid == excluir)
                                    {
                                        BancodeAnimais.Remove(animal);
                                        Codigodevalidacao = 1;
                                        break;
                                    }
                                }
                                if (Codigodevalidacao != 1)
                                {
                                    Console.WriteLine("Id nao encontrado!");
                                    Codigodevalidacao = 0;
                                }
                                break;
                            case 4:
                                Console.Write("Digite o Id do animal que deseja pesquisar: ");
                                string pesquisa = Console.ReadLine();
                                foreach (var animal in BancodeAnimais)
                                {
                                    if (animal.Animalid == pesquisa)
                                    {
                                        Console.WriteLine(animal.Animalid
                                                          + " - " + animal.Nomeanimal
                                                          + " - " + animal.Animalapelido
                                                          + " - " + animal.DataNasc
                                                          + " - " + animal.Animalobs);
                                    }
                                }
                                break;
                            case 5:
                                if (BancodeAnimais.Count == 0)
                                {
                                    Console.WriteLine("Banco de Animais vazio");
                                }
                                else
                                {
                                    Console.WriteLine("Lista de Animais:");
                                    foreach (var animais in BancodeAnimais)
                                    {
                                        Console.WriteLine(animais.Animalid
                                                          + " - " + animais.Nomeanimal
                                                          + " - " + animais.Animalapelido
                                                          + " - " + animais.DataNasc
                                                          + " - " + animais.Animalobs);
                                    }
                                }
                                break;
                        }
                    }
                }
                else if (opc == 3)
                {
                    while (subopc != 9)
                    {

                        Console.WriteLine("1. Inserir Clientes");
                        Console.WriteLine("2. Alterar Clientes");
                        Console.WriteLine("3. Excluir Clientes");
                        Console.WriteLine("4. Pesquisar Clientes");
                        Console.WriteLine("5. Exibir Lista Clientes");
                        Console.WriteLine("9. Sair do sistema");
                        Console.Write("Digite a opcao: ");
                        subopc = int.Parse(Console.ReadLine());
                        switch (subopc)
                        {
                            case 1:
                                Console.Write("Digite o Id: ");
                                string clienteid = Console.ReadLine();
                                Console.Write("Digite a Nome: ");
                                string clientenome = Console.ReadLine();
                                Console.Write("Digite o Cpf: ");
                                string clientecpf = Console.ReadLine();
                                Console.Write("Digite o Email: ");
                                string clienteemail = Console.ReadLine();
                                Console.Write("Digite a Data do Cadastro: ");
                                string clientedatacadastro = Console.ReadLine();
                                BancodeClientes.Add(new Clientes(clienteid, clientenome, clientecpf, clienteemail, clientedatacadastro));
                                Console.WriteLine("Cliente inserido com sucesso.");
                                Console.WriteLine();
                                break;
                            case 2:
                                Console.Write("Digite o Id do cliente que deseja alterar: ");
                                string alter = Console.ReadLine();
                                foreach (var cliente in BancodeClientes)
                                {
                                    if (cliente.ClienteId == alter)
                                    {
                                        int sub2opc = 0;
                                        while (sub2opc != 9)
                                        {

                                            Console.WriteLine("1. Alterar Id");
                                            Console.WriteLine("2. Alterar Nome");
                                            Console.WriteLine("3. Alterar Cpf");
                                            Console.WriteLine("4. Alterar email");
                                            Console.WriteLine("5. Alterar Data Cadastro");
                                            Console.WriteLine("9. Sair");
                                            Console.WriteLine("Digite a opcao");
                                            sub2opc = int.Parse(Console.ReadLine());

                                            switch (sub2opc)
                                            {
                                                case 1:
                                                    Console.Write("Digite o novo Id: ");
                                                    cliente.ClienteId = Console.ReadLine();
                                                    break;
                                                case 2:
                                                    Console.Write("Digite o novo Nome: ");
                                                    cliente.ClienteNome = Console.ReadLine();
                                                    break;
                                                case 3:
                                                    Console.Write("Digite o novo Cpf: ");
                                                    cliente.ClienteCpf = Console.ReadLine();
                                                    break;
                                                case 4:
                                                    Console.Write("Digite o novo Email: ");
                                                    cliente.ClienteEmail = Console.ReadLine();
                                                    break;
                                                case 5:
                                                    Console.Write("Digite a nova Data do Cadastro: ");
                                                    cliente.ClienteDataCadastro = Console.ReadLine();
                                                    break;
                                            }
                                        }
                                    }

                                }
                                break;
                            case 3:
                                int Codigodevalidacao = 0;
                                Console.Write("Digite o Id do cliente que deseja excluir: ");
                                string excluir = Console.ReadLine();
                                foreach (var cliente in BancodeClientes)
                                {
                                    if (cliente.ClienteId == excluir)
                                    {
                                        BancodeClientes.Remove(cliente);
                                        Codigodevalidacao = 1;
                                        break;
                                    }
                                }
                                if (Codigodevalidacao != 1)
                                {
                                    Console.WriteLine("Id nao encontrado!");
                                    Codigodevalidacao = 0;
                                }
                                break;
                            case 4:
                                Console.Write("Digite o Id do cliente que deseja pesquisar: ");
                                string pesquisa = Console.ReadLine();
                                foreach (var cliente in BancodeClientes)
                                {
                                    if (cliente.ClienteId == pesquisa)
                                    {
                                        Console.WriteLine(cliente.ClienteId
                                                          + " - " + cliente.ClienteNome
                                                          + " - " + cliente.ClienteCpf
                                                          + " - " + cliente.ClienteEmail
                                                          + " - " + cliente.ClienteDataCadastro);
                                    }
                                }
                                break;
                            case 5:
                                if (BancodeClientes.Count == 0)
                                {
                                    Console.WriteLine("Banco de Clientes vazio");
                                }
                                else
                                {
                                    Console.WriteLine("Lista de CLientes:");
                                    foreach (var cliente in BancodeClientes)
                                    {
                                        Console.WriteLine(cliente.ClienteId
                                                          + " - " + cliente.ClienteNome
                                                          + " - " + cliente.ClienteCpf
                                                          + " - " + cliente.ClienteEmail
                                                          + " - " + cliente.ClienteDataCadastro);
                                    }
                                }
                                break;
                        }
                    }
                }
                else if (opc == 9)
                {
                    SalvarCarregarEspecie.SalvarListaEspecie(BancodeEspecies, caminho + NomeBancoEspecies);
                    SalvarCarregarAnimais.SalvarListaAnimais(BancodeAnimais, caminho + NomeBancoAnimais);
                    SalvarCarregarCliente.SalvarListaCliente(BancodeClientes, caminho + NomeBancoClientes);
                    string test = Console.ReadLine();
                }
            }
        }
    }
}
        
