namespace Proiect;

public class Persoana
{
    public string Nume { get; private set; }
    public string Prenume { get; private set; }
    public int Cnp { get;private set; }

    public Persoana(string nume, string prenume, int cnp)
    {
        Nume = nume;
        Prenume = prenume;
        Cnp = cnp;
    }
}