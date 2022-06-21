using System;
public class var
{
    public static string db = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Workmate\";
    
    public static bool ended = false;

    public static string nfotohome = "";
    
    public static void check_db()
    {
        if(Workmate.Properties.Settings.Default.percorso_db != "")
        {
            db = Workmate.Properties.Settings.Default.percorso_db + @"\Workmate\";
        }
    }
    public static int cnc()
    {
        return Directory.GetFiles(db + @"Magazzino\").Length;
    }
    public static string[] carica_codici()
    {
        string[] codici_trovati = Directory.GetFiles(db + @"Magazzino\", "*.xml");
        return codici_trovati;
    }

    public static int cno()
    {
        return Directory.GetFiles(db + @"Ordini\").Length;
    }
    public static string[] carica_ordini()
    {
        string[] ordini_trovati = Directory.GetFiles(db + @"Ordini\", "*.xml");
        return ordini_trovati;
    }

    public static string[] carica_prodotti()
    {
        string[] prodotti_trovati = Directory.GetFiles(db + @"Prodotti\", "*.xml");
        return prodotti_trovati;
    }

    public static string[] carica_clienti()
    {
        string[] clienti_trovati = Directory.GetFiles(db + @"Clienti\", "*.xml");
        return clienti_trovati;
    }
}