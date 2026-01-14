namespace Proiect;

public class TipAbonament
{
    public string NumeAbonament { get; set; }
    public int Pret { get; set; }

    public TipAbonament(string numeAbonament, int pret)
    {
        NumeAbonament = numeAbonament;
        Pret = pret;
    }

    public override string ToString()
    {
        return $"Tipul abonamentului: {NumeAbonament}, pretul abonamentului: {Pret}";
    }
}