    using Microsoft.Extensions.Logging;
    using System.Text.Json;
namespace Proiect;

class Program
{
    public static List<Zona> Zone = new List<Zona>();
    private static int Logare_Admin()
    {
        while (true)
        {
            int opt;
            Console.WriteLine("1.Selecteaza zona");
            Console.WriteLine("2.Vizualizeaza istoric");
            Console.WriteLine("3.Editeaza Reguli");
            Console.WriteLine("4.Editare tip abonament");
            Console.WriteLine("5.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }
            if (opt < 1 || opt > 5)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    int indice_zona = Selectare_zone();
                    Modificare_zone(indice_zona);
                    break;
                case 2:
                    Afisare_istoric();
                    break;
                case 3:
                    Editare_reguli();
                    break;
                case 4:
                    Editeaza_abonament();
                    break;
                case 5: return 1;
                default: return -1;
            }
        }
        return -1;
    }

    private static int Selectare_zone()
    {
        int opt;
        int nr = 1;
        foreach (var i in Zone)
        {
            Console.WriteLine(nr + "."+ i.Locatie);
            nr += 1;
        }

        if (!int.TryParse(Console.ReadLine(), out opt))
        {
            Console.WriteLine("Optiune invalida");
            return -1;
        }

        if (opt <= 0 || opt > nr)
        {
            Console.WriteLine("Optiune invalida");
            return -1;
        }

        return opt - 1;

    }

    private static int Modificare_zone(int indice)
    {
        int opt;
        while (true)
        {
            Console.WriteLine("1.Stergere zona");
            Console.WriteLine("2.Edit zona");
            Console.WriteLine("3.Selectare parcare");
            Console.WriteLine("4.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            if (opt <= 0 || opt > 4)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    Zone.RemoveAt(indice);
                    return 1;
                case 2:
                    Console.WriteLine("Introduce noul nume al zonei:");
                    Zone[indice].Locatie = Console.ReadLine();
                    return 1;
                case 3:
                    int indicep = Selectare_parcare(indice);
                    Modificare_parcare(indicep, indice);
                    return 1;
                case 4:
                    return 1;
            }
        }
    }

    public static int Selectare_parcare(int indice)
    {
        int opt;
        int nr = 1;
        foreach (var i in Zone[indice].Parcari)
        {
            Console.WriteLine(nr + "."+ i.IdParcare);
            nr += 1;
        }

        if (!int.TryParse(Console.ReadLine(), out opt))
        {
            Console.WriteLine("Optiune invalida");
            return -1;
        }

        if (opt <= 0 || opt > nr)
        {
            Console.WriteLine("Optiune invalida");
            return -1;
        }

        return opt - 1;

    }

    public static int Modificare_parcare(int indicep, int indicez)
    {
        int opt;
        while (true)
        {
            Console.WriteLine("1.Stergere parcare");
            Console.WriteLine("2.Edit parcare");
            Console.WriteLine("3.Adaugare parcare");
            Console.WriteLine("4.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            if (opt <= 0 || opt > 2)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    Zone[indicez].Parcari.RemoveAt(indicep);
                    return 1;

                case 2:
                    Edit_parcare(indicep, indicez);
                    return 1;

                case 3:
                    Console.WriteLine("Introduce nume parcare:");
                    string IdParcare = Console.ReadLine();
                    Console.WriteLine("Numar locuri:");
                    int NrLocuri = Convert.ToInt32(Console.ReadLine());
                    Parcare p = new Parcare(IdParcare, NrLocuri);
                    Zone[indicez].Parcari.Add(p);
                    return 1;
                case 4: return 1;
            }
        }
    }

    public static int Edit_parcare(int indicep, int indicez)
    {
        int opt;
        while (true)
        {
            Console.WriteLine("1.Modificare numar de locuri");
            Console.WriteLine("2.Modificare nume");
            Console.WriteLine("3.Stergere client");
            Console.WriteLine("4.Adaugare client");
            Console.WriteLine("5.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            if (opt <= 0 || opt > 5)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Introduce numarul de parcarii:");
                    int NrLocuriNou = Convert.ToInt32(Console.ReadLine());
                    Zone[indicez].Parcari[indicep].ModifcareParcare(NrLocuriNou);
                    return 1;

                case 2:
                    Console.WriteLine("Introduce numele parcarii");
                    Zone[indicez].Parcari[indicep].ModifcareParcare(Console.ReadLine());
                    return 1;
                case 3:
                    Console.WriteLine("Introduce numarul masinii:");
                    Zone[indicez].Parcari[indicep].StergereClientMasina(Console.ReadLine());
                    return 1;
                case 4:
                    string nume, prenume;
                    int CNP;
                    string nrmatricol;
                    Console.WriteLine("Introduce numele clientului:");
                    nume = Console.ReadLine();
                    Console.WriteLine("Introduce prenumele clientului:");
                    prenume = Console.ReadLine();
                    Console.WriteLine("Introduce CNP-ul clientului:");
                    CNP = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Introduce numarul masinii clientului:");
                    nrmatricol = Console.ReadLine();
                    Console.WriteLine("Selecteaza abonamentul clientului:");
                    TipAbonament tab = Selectare_abonament();
                    Console.WriteLine("Perioada abonamentului clientului:");
                    DateTime datainceput = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    DateTime datafinal = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    Persoana p = new Persoana(nume, prenume, CNP);
                    Masina m = new Masina(nrmatricol);
                    Abonament a = new Abonament(tab, datainceput, datafinal);
                    Client c = new Client(p, a, m);
                    Zone[indicez].Parcari[indicep].AdaugareClient(c);
                    return 1;
                case 5: return 1;
            }
        }
    }

    public static TipAbonament Selectare_abonament()
    {
        if (Administrator.TipuriAbonamente == null || Administrator.TipuriAbonamente.Count == 0)
        {
            Console.WriteLine("Nu exista tipuri de abonamente definite.");
            return null; // 2. Returnam null, nu -1, pentru ca tipul funcției este o clasă
        }

        int nr = 1;
        Console.WriteLine("\nSelecteaza tipul de abonament:");
        foreach (var i in Administrator.TipuriAbonamente)
        {
            Console.WriteLine($"{nr}. {i.ToString()}");
            nr++;
        }

        Console.Write("Optiunea ta: ");
        int opt;
    
        if (!int.TryParse(Console.ReadLine(), out opt))
        {
            Console.WriteLine("Optiune invalida.");
            return null; 
        }
    
        if (opt <= 0 || opt > Administrator.TipuriAbonamente.Count)
        {
            Console.WriteLine("Optiune invalida.");
            return null; 
        }
        
        return Administrator.TipuriAbonamente[opt - 1];
    }

    private static void Afisare_istoric()
    {
        string caleFisier = "istoric_Zone.json";

        if (!File.Exists(caleFisier))
        {
            Console.WriteLine("Fisierul de istoric nu a fost gasit.");
            return;
        }

        foreach (string linie in File.ReadLines(caleFisier))
        {
            try
            {
                Zona stareSalvata = JsonSerializer.Deserialize<Zona>(linie);

                if (stareSalvata != null)
                {
                    Console.WriteLine($"Locatie: {stareSalvata.Locatie}");
                    Console.WriteLine($"Numar Parcari: {stareSalvata.Parcari.Count}");

                    foreach (var p in stareSalvata.Parcari)
                    {
                        Console.WriteLine($"Parcare: {p.IdParcare}, Locuri ocupate: {p.LocuriOcupate.Count}");
                    }

                    Console.WriteLine(new string('-', 30));
                }
            }
            catch (JsonException)
            {
                Console.WriteLine("Eroare la citirea unei linii corupte.");
            }
        }
    }

    private static int indice_reg()
    {
        if (Administrator.Reguli == null || Administrator.Reguli.Count == 0)
        {
            Console.WriteLine("Nu exista reguli inregistrate.");
            return -1; 
        }
    
        int nr = 1;
        foreach (var i in Administrator.Reguli)
        {
            
            Console.WriteLine(nr + ". " + i);
            nr++;
        }

        Console.Write("Alege numarul regulii: "); 
        int opt;
        
        if (!int.TryParse(Console.ReadLine(), out opt))
        {
            Console.WriteLine("Optiune invalida.");
            return -1;
        }
        
        if (opt <= 0 || opt > Administrator.Reguli.Count)
        {
            Console.WriteLine("Optiune invalida (numar inexistent).");
            return -1;
        }
        
        return opt - 1;
    }

  private static void Editare_reguli()
{
    int opt;
    while (true)
    {
        Console.WriteLine("1.Modificare regula");
        Console.WriteLine("2.Stergere regula");
        Console.WriteLine("3.Adaugare regula");
        Console.WriteLine("4.Vizualizare reguli");
        Console.WriteLine("5.Back");
        Console.Write("Alege optiunea:");
        
        if (!int.TryParse(Console.ReadLine(), out opt))
        {
            Console.WriteLine("Optiune invalida.");
            continue;
        }
        
        if (opt <= 0 || opt > 5)
        {
            Console.WriteLine("Optiune invalida.");
            continue;
        }

        switch (opt)
        {
            case 1:
                int idMod = indice_reg(); 
                if (idMod != -1) 
                {
                    Console.WriteLine("Regula actuala: " + Administrator.Reguli[idMod]);
                    Console.WriteLine("Introduce regula modificata:");
                    Administrator.ModificareRegula(Administrator.Reguli[idMod], Console.ReadLine());
                    Console.WriteLine("Regula schimbata cu succes");
                }
                break;

            case 2: 
                int idSterg = indice_reg();
                if (idSterg != -1)
                {
                    Administrator.StergeRegula(Administrator.Reguli[idSterg]);
                    Console.WriteLine("Regula stearsa!");
                }
                break;

            case 3:
                Console.WriteLine("Adauga regula noua:");
                Administrator.CreareRegula(Console.ReadLine());
                Console.WriteLine("Regula adaugata!");
                break;

            case 4:
                if (Administrator.Reguli == null || Administrator.Reguli.Count == 0)
                {
                    Console.WriteLine("Nu exista reguli in lista.");
                }
                else
                {
                    Console.WriteLine("\nLista de reguli:");
                    int nr = 1;
                    foreach (var regula in Administrator.Reguli)
                    {
                        Console.WriteLine($"{nr}.{regula}");
                        nr++;
                    }
                }
          
                Console.WriteLine("Apasa orice tasta pentru a continua...");
                Console.ReadKey(); 
                break;

            case 5:
                return; 
        }
    }
}

    private static int Editeaza_abonament()
    {
        int opt;
        while (true)
        {
            Console.WriteLine("1.Stergere abonament");
            Console.WriteLine("2.Edit abonament");
            Console.WriteLine("3.Adaugare abonament");
            Console.WriteLine("4.Vizualizare abonamente");
            Console.WriteLine("5.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            if (opt <= 0 || opt > 5)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1: Administrator.StergereTipAbonament(Selectare_abonament());
                    return 1;
                case 2:Console.WriteLine("Introduce numele abonamentului:");
                       string nume = Console.ReadLine();
                       Console.WriteLine("Introduce pretul abonamentului:");
                       int pret = Int32.Parse(Console.ReadLine()); 
                       Administrator.ModificaTipAbonament(Selectare_abonament(),nume, pret);
                       return 1;
                case 3: Console.WriteLine("Introduce numele abonamentului:");
                    string nume2 = Console.ReadLine();
                    Console.WriteLine("Introduce pretul abonamentului:");
                    int pret2 = Int32.Parse(Console.ReadLine()); 
                    Administrator.CreareTipAbonament(nume2, pret2);
                    return 1;
                case 4: 
                    Administrator.VizualizareTipAbonamente();
                    return 1;
                case 5: return 1;
            }
        }
    }
    
     private static Client EditeazaAbonamentClient(Client c)
    {
        int opt;
        int indiceP=-1, indiceZ=-1;
        for (int i = 0; i < Zone.Count; i++)
        {
            int aux = Zone[i].CautareClient(c);
            if (aux != -1)
            {
                indiceP = aux;
                indiceZ = i;
            }
        }

        if (indiceP == -1)
        {
            Console.WriteLine("Nu exista clientul");
            return c;
        }
        while (true)
        {
            Console.WriteLine("1.Stergere abonament");
            Console.WriteLine("2.Schimba clasa abonament");
            Console.WriteLine("3.Schimba masina");
            Console.WriteLine("4.Reinoieste abonamentul");
            Console.WriteLine("5.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            if (opt <= 0 || opt > 5)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1: 
                    Zone[indiceZ].Parcari[indiceP].LocuriOcupate.Remove(c);
                    c.AnuleazaAbonament();
                    return c;
                case 2:
                    Console.WriteLine("Selecteaza abonamentul nou:");
                    TipAbonament tab = Selectare_abonament();
                    c.SchimbaTipAbonament(tab);
                    return c;
                case 3: 
                    Console.WriteLine("Introduce numarul masinii noi:");
                    string nrmatricol = Console.ReadLine();
                    c.SchimbaMasina(new Masina(nrmatricol));
                    return c;
                case 4: 
                    Console.WriteLine("Perioada abonamentului nou:");
                    DateTime datainceput = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    DateTime datafinal = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    c.ReinnoiesteAbonament(datainceput,datafinal);
                    return c;
                case 5: return c;
            }
        }
    }
    
    public static int LogareClient()
    {
        /*
         * TODO
         * 1.IMPLEMENTARE PAROLA
         * 2.LOGINUL SE FACE IN WHILE,LA 3 INTRODUCERI GRESITE IESE DIN WHILE SI INTRA IN MENIUL PRINCIPAL
         * 3.SALVAREA PAROLEI PENTRU CLIENTI SE FACE INTR UN FISIER !!!!
         * 4.AICI TREBUIE FACUTA O FUNCTIE CARE SA RECUNOASCA CLIENTUL PE BAZA PAROLEI
         * -IN FISIERUL CE CONTINE PAROLA PENTRU FIECARE CLIENT VEI SCRIE PE LANGA PAROLA OBIECTU IN FORMAT JSON CU NUMELE CLIENTULUI
         * -CAND SE APELEAZA FUNCTIA LOGARECLIENT() VEI CAUTA PE BAZA DE PAROLA FIECARE CLIENT
         * -DACA ESTE INTRODUSA CORECT,V-A CAUTA IN FISIER CLIENTUL SI VA INCARCA DATELE SALE
         *
         *
         *
         * DACA AI ALTE IDEI POTI SA LE FACI
         * CE AM SCRIS EU MAI SUS NU E NEAPARAT NECESAR DAR II INDICAT SA FACI,PT CA ALTFEL TREBUIE SA SCHIMBI CODUL DE MAI JOS
         *DUPA CE TERMINI STERGI COMENTARILE SI AICI SI LA ADMIN
         */
        Client client=
            new Client(new Persoana("Bogdan","Dinca",12),new Abonament(new TipAbonament("Premium",420),
                new DateTime(2025,11,11),new DateTime(2030,12,14)),
                new Masina("1231")); //STERGI PARTEA de dupa egal si inlocuiesti cu datele citite din fisier
                                  //DE INTRODUS DATE IN EL DIN FISIER SI DUPA RESCRISE
        while (true)
        {
            int opt;
            Console.WriteLine("1.Creare abonament");
            Console.WriteLine("2.Editare abonament");
            Console.WriteLine("3.Vizualizare abonament");
            Console.WriteLine("4.Vizualizare istoric");
            Console.WriteLine("5.Vizualizare reguli");
            Console.WriteLine("6.Back");
            if (!int.TryParse(Console.ReadLine(), out opt))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }
            if (opt < 1 || opt > 5)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Selecteaza abonamentul:");
                    TipAbonament tab = Selectare_abonament();
                    Console.WriteLine("Perioada abonamentului:");
                    DateTime datainceput = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    DateTime datafinal = DateTime.Parse(Console.ReadLine() + DateTime.Now.TimeOfDay.ToString());
                    Abonament a = new Abonament(tab, datainceput, datafinal);
                    client.Abonament = a;
                    break;
                case 2:
                    client=EditeazaAbonamentClient(client);
                    break;
                case 3:
                    client.VizualizeazaAbonament();
                    break;
                case 4: 
                    //TODO IMPLEMENTEAZA VIZUALIZAREA ISTORICULUI
                    return 1;
                case 5:
                    client.VizReguli(Administrator.Reguli);
                    break;
                default: return -1;
            }
        }
        //RESCRIE IN FISIER DATELE CLIENTULUI DACA VREI
        //in caz de introducere a parolii gresite 
        return -1;
    }
    static void Main(string[] args)
    {
        //IN PLUS SA FACI O FUNCTIE CARE SALVEAZA TIPURILE DE ABONAMENTE
        int alege,cod=1;
        Administrator.IncarcareTipuri();
        Fisier.IncarcaUltimaStareDinFisier();
        Administrator.IncarcareReguliDinFisier();
        Zone = JsonSerializer.Deserialize<List<Zona>>(Fisier.UltimaSalvare);
        while (cod==1)
        {
            Console.WriteLine("1.Logare Admin");
            Console.WriteLine("2.Logare Client");
            Console.WriteLine("3.Exit");

            if (!int.TryParse(Console.ReadLine(), out alege))
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }
            if (alege < 1 || alege > 3)
            {
                Console.WriteLine("Optiune invalida");
                continue;
            }
            switch (alege)
            {
                case 1:
                    Logare_Admin();
                    break;
                case 2:
                    LogareClient();
                    break;
                case 3:
                    cod=0;
                    break;
                default: break;
            }
        }
        Fisier.SalveazaStareaInFisier();
        Administrator.SalvareReguliInFisier();
        Administrator.SalvareTipuri();
    }
}
    

