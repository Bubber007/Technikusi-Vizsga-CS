// See https://aka.ms/new-console-template for more information

using Pilots_Console;

// A pilóták listájának betöltése a JSON fájlból
List<Pilot>? pilots = Pilot.LoadFromJSON("pilots.json");

Console.Write("5.feladat: Adja meg egy név részletét: ");

string? input = Console.ReadLine();

Keres(pilots, input);
FileWrite(pilots);

static void FileWrite(List<Pilot> pilots)
{
	try
	{
        // Fájl megnyitása írásra
        StreamWriter sw = new StreamWriter("pilot_groups.txt");

        // Összes különböző nemzet kiválogatása, majd ABC sorrendbe rendezés
        List<string> countries = pilots.Select(x => x.nation).Distinct().Order().ToList();

        // Végigmegyünk minden nemzeten
        foreach (var c in countries)
        {
            // Az adott nemzethez tartozó pilóták kigyűjtése
            List<Pilot> nationPilots = pilots.Where(x => x.nation == c).ToList();

            // Csoport fejlécének kiírása: "Nemzet (X fő):"
            sw.WriteLine($"{c} ({nationPilots.Count}) fő:");

            // Az adott nemzet pilótáinak listázása név és születési dátum szerint
            foreach (var n in nationPilots)
            {
                sw.WriteLine($"\t{n.name} - {n.birthdate}");
            }
        }
        sw.Close();
        Console.WriteLine("6.feladat: pilot_groups.txt sikeresen megírva!");
    }
	catch (Exception)
	{
        Console.WriteLine("Hiba! Fájl írása sikertelen!");
	}
	
}

static void Keres(List<Pilot>? pilots, string? input)
{
    bool ok = false;
    // Végigmegyünk az összes pilótán
    foreach (var p in pilots)
	{
        // A teljes nevet szóköz mentén kettéválasztjuk (pl. "John Smith" → ["John", "Smith"])
        string[] nameSlices = p.name.Split();

        // Vizsgáljuk, hogy az első vagy második névrész kezdődik-e a beírt karakterlánccal
        if (nameSlices[0].ToLower().StartsWith(input.ToLower()) || nameSlices[1].ToLower().StartsWith(input.ToLower()))
		{
            ok = true;
            // Megfelelő pilóta adatainak kiírása
            Console.WriteLine($"\t{p.id}\t{p.name}\t{p.birthdate}\t{p.gender}\t{p.nation}");
		}
	}

    // Ha nem volt találat, akkor hibaüzenetet írunk ki
    if (!ok)
        Console.WriteLine($"\tNem található pilóta {input} névrészlettel!");
}
