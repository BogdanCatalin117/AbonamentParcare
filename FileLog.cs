using System.IO;
namespace Proiect;

public class FileLog:Ilogger
{
    private string CaleFisier="Ilogger.txt";

    public FileLog()
    {
        File.Create(CaleFisier).Close();
    }
    public void Eroare(string mesaj)
    {
        File.AppendAllText(CaleFisier, $"{DateTime.Now.ToString()}[EROARE]:"+mesaj+"\n");
    }
    public void Warn(string mesaj)
    {
        File.AppendAllText(CaleFisier, $"{DateTime.Now.ToString()}[AVERTIZARE]:"+mesaj+"\n");
    }
    public void Info(string mesaj)
    {
        File.AppendAllText(CaleFisier, $"{DateTime.Now.ToString()}[INFO]:"+mesaj+"\n");
    }
    public void DelLog()
    {
       File.Delete(CaleFisier);
    }
}