using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace Proiect;

public class Parcare
{
    [JsonInclude]
    public string IdParcare { get; private set; }
    [JsonInclude]
    public int NrLocuri { get; private set; }
    [JsonInclude]
    public int NrLocuriDisponibile { get; private set; }
    [JsonInclude]
    public List<Client> LocuriOcupate { get; private set; }

    public bool NrMatricolExist(string nrMatricol)
    {
        foreach (Client client in LocuriOcupate)
        {
            if (client.MasinaClient.NrInmatriculare == nrMatricol)
            {
                return true;
            }
        }
        return false;
    }
    public Parcare(string idParcare, int nrLocuri)
    {
        IdParcare = idParcare;
        NrLocuri = nrLocuri;
        NrLocuriDisponibile = nrLocuri;
        LocuriOcupate = new List<Client>();
    }
    public void ModifcareParcare(int NrLocuriNou)
    {
        if (NrLocuriNou < LocuriOcupate.Count)
        {
            Console.WriteLine("Nu se poate modifica parcarea");
            return;
        }
        NrLocuri = NrLocuriNou;
    }
    
    public void ModifcareParcare(string idParcareNou)
    {
        if (idParcareNou == IdParcare)
        {
            Console.WriteLine("Nu se poate modifica IdParcare");
            return;
        }
        IdParcare = idParcareNou;
    }
    
    public void AdaugareClient(Client client)
    {
        if (NrLocuriDisponibile==0)
        {
            Console.WriteLine("Nu se mai pot adauga clienti,parcarea este full");
            return;
        }
        else if (LocuriOcupate.Contains(client))
        {
            Console.WriteLine("Deja exista clientul in parcare");
            return;
        }
        LocuriOcupate.Add(client);
        NrLocuriDisponibile--;
    }
    //StergereClient supraincarcata pe baza de Nume,Cnp,NrMasina
    public void StergereClient(string Nume)
    {
        if (NrLocuriDisponibile == NrLocuri)
        {
            Console.WriteLine("Nu se poate sterge,parcarea este goala!");
            return;
        }

        foreach (Client client in LocuriOcupate)
        {
            if (client.DatePersonale.Nume == Nume)
            {
                LocuriOcupate.Remove(client);
                return;
            }
        }

        Console.WriteLine($"Nu exista clientul cu numele {Nume}");
    }
    public void StergereClient(int CNP)
    {
        if (NrLocuriDisponibile == NrLocuri)
        {
            Console.WriteLine("Nu se poate sterge,parcarea este goala!");
            return;
        }
        foreach (Client client in LocuriOcupate)
        {
            if (client.DatePersonale.Cnp == CNP)
            {
                LocuriOcupate.Remove(client);
                return;
            }
        }

        Console.WriteLine($"Nu exista clientul cu CNP-ul {CNP}");
    }
    public void StergereClientMasina(string NrMasina)
    {
        if (NrLocuriDisponibile == NrLocuri)
        {
            Console.WriteLine("Nu se poate sterge,parcarea este goala!");
            return;
        }

        foreach (Client client in LocuriOcupate)
        {
            if (client.MasinaClient.NrInmatriculare == NrMasina)
            {
                LocuriOcupate.Remove(client);
                return;
            }
        }
        Console.WriteLine($"Nu exista clientul cu numarul de inmatriculare {NrMasina}");
    }
}