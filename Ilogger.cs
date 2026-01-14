namespace Proiect;

public interface Ilogger
{
    public void Eroare(string mesaj);
    public void Warn(string mesaj);
    public void Info(string mesaj);
    public void DelLog();
}