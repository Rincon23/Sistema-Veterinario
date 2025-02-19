using System.Collections.Generic;
using System.IO;
using System;

public class SalvarCarregarEspecie
{
    public static void SalvarListaEspecie(List<Especie> BancodeEspecies, string caminho)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("Id,Nome");

                foreach (var especie in BancodeEspecies)
                {
                    writer.WriteLine(
                        $"{especie.EspecieId},{especie.EspecieNome}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
    }

    public static List<Especie> CarregarListaEspecie(string caminho)
    {
        var especie = new List<Especie>();

        try
        {
            if (File.Exists(caminho) == true)
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    string linha = reader.ReadLine();
                    while ((linha = reader.ReadLine()) != null)
                    {
                        var partes = linha.Split(',');
                        if (partes.Length == 2)
                        {
                            string especieid = partes[0];
                            string especienome = partes[1];
                            especie.Add(new Especie(especieid, especienome));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
        }
        return especie;
    }
}

public class SalvarCarregarAnimais
{
    public static void SalvarListaAnimais(List<Animal> BancodeAnimais, string caminho)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("codigo,Nome do Animal,Especie,Cliente");

                foreach (var animal in BancodeAnimais)
                {
                    writer.WriteLine(
                        $"{animal.Animalid},{animal.Nomeanimal},{animal.Animalapelido},{animal.DataNasc},{animal.Animalobs}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
    }

    public static List<Animal> CarregarListaAnimais(string caminho)
    {
        var animais = new List<Animal>();

        try
        {
            if (File.Exists(caminho) == true)
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    string linha = reader.ReadLine();
                    while ((linha = reader.ReadLine()) != null)
                    {
                        var partes = linha.Split(',');
                        if (partes.Length == 5)
                        {
                            string animalid = partes[0];
                            string nomeanimal = partes[1];
                            string animalapelido = partes[2];
                            string datanasc = partes[3];
                            string animalobs = partes[4];
                            animais.Add(new Animal(animalid, nomeanimal, animalapelido, datanasc, animalobs));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
        }
        return animais;
    }
}

public class SalvarCarregarCliente
{
    public static void SalvarListaCliente(List<Clientes> BancodeClientes, string caminho)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(caminho))
            {
                writer.WriteLine("Id,Nome, Cpf, Email, Data Cadastro");

                foreach (var cliente in BancodeClientes)
                {
                    writer.WriteLine(
                        $"{cliente.ClienteId},{cliente.ClienteNome},{cliente.ClienteCpf},{cliente.ClienteEmail},{cliente.ClienteDataCadastro}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message);
        }
    }

    public static List<Clientes> CarregarListaCliente(string caminho)
    {
        var cliente = new List<Clientes>();

        try
        {
            if (File.Exists(caminho) == true)
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    string linha = reader.ReadLine();
                    while ((linha = reader.ReadLine()) != null)
                    {
                        var partes = linha.Split(',');
                        if (partes.Length == 5)
                        {
                            string clienteid = partes[0];
                            string clientenome = partes[1];
                            string clientecpf = partes[2];
                            string clienteemail = partes[3];
                            string clientedatacadastro = partes[4];
                            cliente.Add(new Clientes(clienteid, clientenome, clientecpf, clienteemail, clientedatacadastro));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro: " + ex.Message); throw;
        }
        return cliente;
    }
}