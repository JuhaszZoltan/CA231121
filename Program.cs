using CA231121;
using System.Text;


List<JatekosLovese> lovesek = new();
using StreamReader sr = new(@"..\..\..\src\lovesek.txt", Encoding.UTF8);
var cel = sr.ReadLine().Split(';');
JatekosLovese.Cel = (double.Parse(cel[0]), double.Parse(cel[1]));
int sorszam = 1;
while(!sr.EndOfStream)
{
    lovesek.Add(new(sr.ReadLine(), sorszam));
    sorszam++;
}

Console.WriteLine($"5. feladat: Lövések száma: {lovesek.Count} db");

Console.WriteLine("7. feladat: Legpontosabb lövés:");
var f7 = lovesek.MinBy(l => l.Tavolsag);
Console.WriteLine(
    $"\t{f7.LovesSorszam}.\n" +
    $"\t{f7.Nev}\n" +
    $"\tx={f7.Loves.X}\n" +
    $"\ty={f7.Loves.Y}\n" +
    $"\ttávolság: {f7.Tavolsag}");

var f9 = lovesek.Count(l => l.Pontszam == 0d);
Console.WriteLine($"9. feladat: Nulla pontos lövések száma: {f9} db");

var f10 = lovesek.Select(l => l.Nev).Distinct().Count();
Console.WriteLine($"10. feladat: játékosok száma: {f10}");

Console.WriteLine($"Lövések száma (játékosonként):");
var dic = lovesek
    .GroupBy(l => l.Nev)
    .ToDictionary(d => d.Key, d => d.ToList());
foreach (var kvp in dic)
    Console.WriteLine($"\t{kvp.Key} - {kvp.Value.Count} db");

Console.WriteLine("Átlagpontszámok (játékosonként):");
foreach (var kvp in dic)
    Console.WriteLine($"{kvp.Key} - {kvp.Value.Average(l => l.Pontszam)}");

string f13 = dic.MaxBy(d => d.Value.Average(l => l.Pontszam)).Key;
Console.WriteLine($"13. feladat: A játék nyertese: {f13}");