using System;
using Alkomat_A._2.Logic;
namespace Alokmat_A._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba Badana = new Osoba();
            Analizator analizator = new Analizator();
            Badana.podaj();
            Console.WriteLine(" \nIle wypiles piwa, wina, wodki, bimbru? wartosci podaj w 'ml' wg kolejnosci prosze wpisz: ");
            analizator.p = double.Parse(Console.ReadLine());
            analizator.w = double.Parse(Console.ReadLine());
            analizator.ww = double.Parse(Console.ReadLine());
            analizator.b = double.Parse(Console.ReadLine());
            Console.WriteLine("\nKiedy skonczyles(las) spozywac ostanio alkohol? [std 0-24]: ");
            analizator.czas = double.Parse(Console.ReadLine());
            analizator.analiza(Badana.waga, Badana.plec, analizator.czas, analizator.p, analizator.w, analizator.ww, analizator.b);
        }
    }
}
