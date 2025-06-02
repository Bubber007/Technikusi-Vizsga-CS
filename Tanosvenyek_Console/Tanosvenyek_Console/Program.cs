// See https://aka.ms/new-console-template for more information
using Tanosvenyek_Console;

Console.WriteLine($"6.feladat: Összesen {Solution.GetRoutes.Count} tanösvény van, melynek neve tartalmazza a hegy vagy völgy szót, ezek az alábbiak:");
foreach (var route in Solution.GetRoutes)
{
    Console.WriteLine($"\t{route.nev}");
}

var dict = Solution.GetDictionary();
Console.WriteLine("\n7.feladat: Útvonalak településenként:");
foreach (var item in dict)
{
    if (item.Value[0] >= 3)
        Console.WriteLine($"\t{item.Key.nev}: {item.Value[0]} db útvonal található - leghosszabb {item.Value[1]} km");
}
