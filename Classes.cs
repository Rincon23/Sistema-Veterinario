using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Especie
{
    public string EspecieId { get; set; }
    public string EspecieNome { get; set; }

    public Especie(string especieid, string especienome)
    {
        EspecieId = especieid;
        EspecieNome = especienome;
    }
}



public class Animal
        {
            public string Animalid { get; set; }
            public string Nomeanimal { get; set; }
            public string Animalapelido { get; set; }
            public string DataNasc { get; set; }
            public string Animalobs { get; set; }

            public Animal(string animalid, string animalapelido, string nomeanimal, string datanasc, string animalobs)
            {
                Animalid = animalid;
                Nomeanimal = nomeanimal;
                Animalapelido = animalapelido;
                DataNasc = datanasc;
                Animalobs = animalobs;
            }
        }

public class Clientes
{
    public string ClienteId { get; set; }
    public string ClienteNome { get; set; }
    public string ClienteCpf { get; set; }
    public string ClienteEmail { get; set; }
    public string ClienteDataCadastro { get; set; }

    public Clientes(string clienteid, string clientenome, string clientecpf, string clienteemail, string clientedatacadastro)
    {
        ClienteId = clienteid;
        ClienteNome = clientenome;
        ClienteCpf = clientecpf;
        ClienteEmail = clienteemail;
        ClienteDataCadastro = clientedatacadastro;
    }
}