using System.Text.Json.Serialization;
namespace Proiect;

public class Client
{
    [JsonInclude]
    public Persoana DatePersonale { get; private set; }
    [JsonInclude]
    public Abonament Abonament { get; set; }
    [JsonInclude]
    public Masina MasinaClient { get; private set; }

     public Client(Persoana datePersonale, Abonament abonament, Masina masinaClient)
    {
        DatePersonale = datePersonale;
        Abonament = abonament;
        MasinaClient = masinaClient;
    }
    public void VizReguli(List<string> reguli)
    {
        if (reguli == null || reguli.Count == 0)
        {
            Console.WriteLine("Nu exista reguli disponibile.");
            return;
        }

        Console.WriteLine("Regulile sunt:");
        for (int i = 0; i < reguli.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {reguli[i]}");
        }
    }

    public void CreeazaAbonament(TipAbonament tip, DateTime dataInceput, DateTime dataFinal)
    {
        if (Abonament != null)
        {
            Console.WriteLine("Clientul are deja un abonament. Folositi functia de editare.");
            return;
        }

        Abonament = new Abonament(tip, dataInceput, dataFinal);
        Console.WriteLine($"Abonament {tip.NumeAbonament} creat cu succes.");
    }
    public void SchimbaTipAbonament(TipAbonament nouTip)
    {
        if (Abonament == null)
        {
            Console.WriteLine("Nu exista abonament de editat.");
            return;
        }

        Abonament.ClasaAbonament = nouTip;
        Console.WriteLine($"Tip abonament schimbat in {nouTip.NumeAbonament}.");
    }

    public void ReinnoiesteAbonament(DateTime dataInceput, DateTime dataFinal)
    {
        if (Abonament == null)
        {
            Console.WriteLine("Nu exista abonament de editat.");
            return;
        }

        if ((Abonament.DataInceput<=Abonament.DataFinal) && (dataInceput>=Abonament.DataFinal) &&(dataFinal>=dataInceput))
        {
            Abonament = new Abonament(Abonament.ClasaAbonament, dataInceput, dataFinal);
            Console.WriteLine("Abonament reînnoit cu succes.");
        }
    }

    public void AnuleazaAbonament()
    {
        if (Abonament == null)
        {
            Console.WriteLine("Clientul nu are abonament de anulat.");
            return;
        }

        Console.WriteLine($"Abonament {Abonament.ClasaAbonament.NumeAbonament} a fost anulat cu succes.");
        Abonament = null;
    }

    public void SchimbaMasina(Masina masinaNoua)
    {   
        if (MasinaClient.NrInmatriculare == masinaNoua.NrInmatriculare)
        {
            Console.WriteLine("Este aceeasi masina!");
            return;
        }
        MasinaClient = masinaNoua;
        Console.WriteLine($"Masina abonamentului schimbata la {masinaNoua.NrInmatriculare}.");
    }
    public void VizualizeazaAbonament()
    {
        if (Abonament == null)
        {
            Console.WriteLine("Clientul nu are abonament.");
            return;
        }

        Console.WriteLine("=== Detalii Abonament ===");
        Console.WriteLine($"Tip abonament: {Abonament.ClasaAbonament.NumeAbonament}");
        Console.WriteLine($"Pret: {Abonament.ClasaAbonament.Pret} RON");
        Console.WriteLine($"Data inceput: {Abonament.DataInceput.ToShortDateString()}");
        Console.WriteLine($"Data final: {Abonament.DataFinal.ToShortDateString()}");
        Console.WriteLine($"Masina: {MasinaClient.NrInmatriculare}");
        Console.WriteLine("==========================");
    }
}