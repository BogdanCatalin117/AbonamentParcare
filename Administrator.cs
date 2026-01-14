using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
namespace Proiect;

public class Administrator
{
    //De implementat Ilogger
    public string Parola {get; private set;}
    [JsonInclude] public static List<TipAbonament> TipuriAbonamente { get; private set; } = new List<TipAbonament>();
    public static List<string> Reguli { get; private set; } = new List<string>();
    
    public Administrator(List<TipAbonament> tipuriAbonamente, List<string> reguli,string parola)
    {
        TipuriAbonamente = tipuriAbonamente;
        Reguli = reguli;
        Parola = parola;
    }
    //PENTRU TIPURI DE ABONAMENTE
    public static void CreareTipAbonament(string numeAbonament,int pret)
    {
        TipAbonament Ab=new TipAbonament(numeAbonament,pret);
        foreach(var abf in TipuriAbonamente)
        {
            if (abf.NumeAbonament == numeAbonament && abf.Pret == pret)
            {
                Console.WriteLine("Abonamentul exista deja!");
                return;
            }
        }
        TipuriAbonamente.Add(Ab);
    }
    public static void StergereTipAbonament(TipAbonament Ab)
    {
        if (TipuriAbonamente.Contains(Ab))
        {
            Console.WriteLine("Nu exista abonamentul!");
            return;
        }
        TipuriAbonamente.Remove(Ab);
    }
    public static void StergereTipAbonament(string numeAbonament, int pret)
    {
        TipAbonament Ab=new TipAbonament(numeAbonament,pret);
        if (TipuriAbonamente.Contains(Ab))
        {
            Console.WriteLine("Nu exista abonamentul!");
            return;
        }
        TipuriAbonamente.Remove(Ab);
    }
    public static void StergereTipAbonament(string numeAbonament)
    {
        foreach (var ab in TipuriAbonamente)
        {
            if (numeAbonament == ab.NumeAbonament)
            {
                TipuriAbonamente.Remove(ab);
                return;
            }
        }
        Console.WriteLine("Nu exista abonamentul!");
    }
    public static void StergereTipAbonament(int pret)
    {
        foreach (var ab in TipuriAbonamente)
        {
            if (pret == ab.Pret)
            {
                TipuriAbonamente.Remove(ab);
                return;
            }
        }
        Console.WriteLine("Nu exista abonamentul!");
    }
    public static void ModificaTipAbonament(TipAbonament TipAbonamentVechi,string numeAbonament, int pret)
    {
        int ok = 0;
        TipAbonament TipAbonamentNou=new TipAbonament(numeAbonament,pret); 
        foreach (var tipAb in TipuriAbonamente)
        {
            if (tipAb.NumeAbonament == TipAbonamentVechi.NumeAbonament && tipAb.Pret == TipAbonamentNou.Pret)
            {
                TipuriAbonamente.Remove(tipAb);
                ok = 1;
            }
        }

        if (ok==0)
        {
            Console.WriteLine("Abonamentul ");
        } 
        TipuriAbonamente.Add(TipAbonamentNou);
        CreareTipAbonament(numeAbonament, pret);
    }
    public static void VizualizareTipAbonamente()
    {
        Console.WriteLine("---Afisare Tip Abonamente---");
        foreach (var ab in TipuriAbonamente)
        {
            Console.WriteLine(ab.ToString());
        }
    }
    //PENTRU ABONAMENTE CLIENTI
    public Abonament ModificareAbonament(Abonament Ab,TipAbonament clasaAbonament)
    {
        if (Ab == null)
        {
            Console.WriteLine("Nu extista abonamentul!");
        }
        else if (!TipuriAbonamente.Contains(clasaAbonament))
        {
            Console.WriteLine("Nu extista clasa de abonament!");
        }
        Ab.ClasaAbonament = clasaAbonament;
        return Ab;
    }
    public Abonament ModificareAbonament(Abonament Ab,DateTime dataFinal)
    {
        if (Ab == null)
        {
            Console.WriteLine("Nu extista abonamentul!");
        }
        else if (dataFinal<=Ab.DataInceput)
        {
            Console.WriteLine("Data nu este valida!");
        }
        Ab.DataFinal=dataFinal;
        return Ab;
    }
    public Abonament ModificareAbonament(Abonament Ab,DateTime dataInceput,DateTime dataFinal)
    {
        if (Ab == null)
        {
            Console.WriteLine("Nu extista abonamentul!");
        }
        else if (dataFinal<=Ab.DataInceput || dataInceput>=dataFinal || dataInceput>=Ab.DataFinal)
        {
            Console.WriteLine("Datele nu sunt valide!");
        }
        Ab.DataFinal=dataFinal;
        Ab.DataInceput=dataInceput;
        return Ab;
    }
    private static string fisierTipuri = "tipuri_abonament.json";
    
    public static void SalvareTipuri()
    {
        var optiuni = new JsonSerializerOptions { WriteIndented = true };
        string tip = JsonSerializer.Serialize(TipuriAbonamente, optiuni);
        File.WriteAllText(fisierTipuri, tip);
    }

    
    public static void IncarcareTipuri()
    {
        if (!File.Exists(fisierTipuri))
        {
            TipuriAbonamente = new List<TipAbonament>();
            return;
        }

        string tip = File.ReadAllText(fisierTipuri);
        if (tip.Length == 0)
        {
            return;
        }
        TipuriAbonamente = JsonSerializer.Deserialize<List<TipAbonament>>(tip);
    }

    public static void CreareRegula(string regNou)
    {
        foreach (var reg in Reguli)
        {
            if (regNou == reg)
            {
                Console.WriteLine("Regula exista deja!");
                return;
            }
        }
        Reguli.Add(regNou);
    }
    public static void ModificareRegula(string regVeche,string regNou)
    {
        foreach (var reg in Reguli)
        {
            if (regNou == regVeche)
            {
                Console.WriteLine("Regula exista deja!");
                return;
            }
        }
        Reguli.Remove(regVeche);
        Reguli.Add(regNou);
    }

    public static void StergeRegula(string Regula)
    {
        if (!Reguli.Contains(Regula))
        {
            Console.WriteLine("Regula nu exista!");
        }
        Reguli.Remove(Regula);
    }
    private static string caleFisier = "reguli.json";

    public static void SalvareReguliInFisier()
    {
        var optiuni = new JsonSerializerOptions { WriteIndented = true };
        
        string jsonString = JsonSerializer.Serialize(Reguli, optiuni);
        
        File.WriteAllText(caleFisier, jsonString);
    }

    public static void IncarcareReguliDinFisier()
    {
        if (!File.Exists(caleFisier))
        {
            Reguli = new List<string>();
            return;
        }
        
        string jsonString = File.ReadAllText(caleFisier);
        
        Reguli = JsonSerializer.Deserialize<List<string>>(jsonString) ?? new List<string>();
    }

    public void FiseierAbonamente()
    {
        try
        {
            string caleFisier = "istoric_Abonamente.json";

            string AbonamentLinie = "";

            foreach (var i in TipuriAbonamente)
            {
                 AbonamentLinie += JsonSerializer.Serialize(i) +"\n";
            }
            
            File.AppendAllLines(caleFisier, new[] { AbonamentLinie });
        }
        catch (Exception exeptie)
        {
            Console.WriteLine("Nu s a putut realiza adaugarea");
        }
    }
}