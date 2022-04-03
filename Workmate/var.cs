using System;
public class var
{
    public static string db = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Workmate\";

    public static int cnc()
    {
        return Directory.GetFiles(db + @"Magazzino\").Length;
    }
    public static string[] carica_codici()
    {
        string[] codici_trovati = Directory.GetFiles(db + @"Magazzino\");
        return codici_trovati;
    }

    public static int cno()
    {
        return Directory.GetFiles(db + @"Ordini\").Length;
    }
    public static string[] carica_ordini()
    {
        string[] ordini_trovati = Directory.GetFiles(db + @"Ordini\");
        return ordini_trovati;
    }
}