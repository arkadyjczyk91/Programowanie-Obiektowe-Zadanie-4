using System;
using System.Collections.Generic;

public class Produkt
{
    public string Nazwa { get; set; }
    private decimal cenaNetto;
    public decimal CenaNetto
    {
        get => cenaNetto;
        set
        {
            if (value < 0)
                throw new ArgumentException("Cena netto nie może być ujemna.");
            cenaNetto = value;
        }
    }
    public string KategoriaVAT { get; set; }
    public decimal CenaBrutto
    {
        get
        {
            // Tu można rzucić NotImplementedException lub zaimplementować obliczenia
            throw new NotImplementedException();
        }
    }
    public string KrajPochodzenia { get; set; }
}

public abstract class ProduktSpożywczy : Produkt
{
    public ProduktSpożywczy()
    {
        // Domyślne ustawienia dla spożywczych
        KategoriaVAT = "Spożywcze";
    }
    public decimal Kalorie { get; set; }
    public HashSet<string> Alergeny { get; set; }
}

public class ProduktSpożywczyNaWagę : ProduktSpożywczy
{
    public decimal Waga { get; set; }
}

public class ProduktSpożywczyPaczka : ProduktSpożywczy
{
    public decimal Waga { get; set; }
}

public class ProduktSpożywczyNapój : ProduktSpożywczyPaczka
{
    public decimal Objętość { get; set; }
}

public class Wielopak : Produkt
{
    public Produkt Produkt { get; set; }
    public ushort Ilość { get; set; }
    public decimal CenaNetto { get; set; }
    public decimal CenaBrutto
    {
        get
        {
            // Tutaj można zaimplementować logikę obliczania ceny brutto
            throw new NotImplementedException();
        }
    }
    public string KategoriaVAT => Produkt.KategoriaVAT;
    public string KrajPochodzenia => Produkt.KrajPochodzenia;
}

class Program
{
    static void Main(string[] args)
    {
        // Przykładowe użycie
        ProduktSpożywczyNaWagę produkt1 = new ProduktSpożywczyNaWagę
        {
            Nazwa = "Ser",
            CenaNetto = 10.50m,
            KategoriaVAT = "Spożywcze",
            KrajPochodzenia = "Polska",
            Kalorie = 200,
            Waga = 0.5m
        };

        ProduktSpożywczyPaczka produkt2 = new ProduktSpożywczyPaczka
        {
            Nazwa = "Chleb",
            CenaNetto = 5.20m,
            KategoriaVAT = "Spożywcze",
            KrajPochodzenia = "Polska",
            Kalorie = 300,
            Waga = 0.5m
        };

        Wielopak wielopak = new Wielopak
        {
            Produkt = produkt1,
            Ilość = 2,
            CenaNetto = 20m // Cena za 2 sztuki sera
        };

        Console.WriteLine($"Nazwa: {wielopak.Produkt.Nazwa}");
        Console.WriteLine($"Ilość: {wielopak.Ilość}");
        Console.WriteLine($"Cena netto: {wielopak.CenaNetto}");
        Console.WriteLine($"Cena brutto: {wielopak.CenaBrutto}");
    }
}
