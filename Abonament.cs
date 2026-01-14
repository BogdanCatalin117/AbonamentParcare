namespace Proiect;

public class Abonament
{
    public TipAbonament ClasaAbonament { get; set; }
    public DateTime DataInceput { get;  set; }
    public DateTime DataFinal { get;  set; }

    public Abonament(TipAbonament clasaAbonament, DateTime dataInceput, DateTime dataFinal)
    {
        ClasaAbonament = clasaAbonament;
        DataInceput = dataInceput;
        DataFinal = dataFinal;
    }
    
    public override string ToString()
    {
        return $"Tipul abonamentului este: {ClasaAbonament}, creat la data de: {DataInceput}, expira in data de: {DataFinal}";
    }
}