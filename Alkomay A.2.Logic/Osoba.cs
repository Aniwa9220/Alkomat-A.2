using System;
using System.Collections.Generic;
using System.Text;

namespace Alkomat_A._2.Logic
{
   public class Osoba
    {
        public Osoba() { }
        public int plec;
        public double waga;
        int Plec {
            get { return plec; }
            set { plec = value; }
        }
        double Waga
        {
            get { return waga; }
            set { Waga = value; }
        }

        public void podaj()
        {
          
            Console.WriteLine("Podaj płeć, mężyczna <1> kobieta <0>: ");
            string wejscie = Console.ReadLine();
            Int32.TryParse(wejscie,out plec);
            string wejscie2 = Console.ReadLine();
            double.TryParse(wejscie2, out waga);
        }
    }
}
