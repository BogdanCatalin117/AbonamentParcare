using System.Text.Json;
using System.Text.Json.Serialization;

namespace Proiect;

public class Zona
{
    [JsonInclude]
    public string Locatie { get;  set; }
    [JsonInclude]
    public List<Parcare> Parcari { get;  set; }

    public Zona() { }

    public Zona(string locatie)
    {
        Locatie = locatie;
        Parcari = new List<Parcare>();
    }
    
    public Zona(string locatie, List<Parcare> parcari)
    {
        Locatie = locatie;
        Parcari = parcari;
    }
    
    public int CautareClient(Client c)
    {
        for(int i=0;i<Parcari.Count;i++)
        {
            if (Parcari[i].LocuriOcupate.Contains(c))
            {
                return i;
            }
        }
        return -1;
    }
    public void AdaugareParcare(Parcare parcare)
    {
        if (Parcari.Contains(parcare))
        {
            Console.WriteLine("Parcarea exista deja!");
            return;
        }

        Parcari.Add(parcare);
    }

    public void StergereParcare(Parcare parcare)
    {
        if (!Parcari.Contains(parcare))
        {
            Console.WriteLine("Parcarea nu exista!");
            return;
        }

        Parcari.Remove(parcare);
    }
    
    
    //Editarea se face cu parcare
}