using System;
using System.Collections.Generic;
using System.Text;



namespace Alkomat.Biblioteka
{
	public class Analizator : Osoba
	{ 
		public Analizator() { }
		public double p;
		public double w;
		public double ww;
		public double b;
		public double czas;
		public double doba=0;
		public void analiza(double waga, double plec, double czas, double p, double w, double ww, double b)
		{
			double porcje_p, porcje_w, porcje_ww, porcje_b;
			porcje_p = p * (1.0 / 25.0);
			porcje_w = w * (1.0 / 10.0);
			porcje_ww = ww * (1.0 / 3.0);
			porcje_b = b * (2.0 / 3.0);
			double suma_porcji = porcje_p + porcje_w + porcje_ww + porcje_b, promile_teraz_m, promile_teraz_k, wynik_promile; // w momencie wypicia
			double wsp_plci = 0;
			if (plec == 1)
			{ wsp_plci = 0.7; }
			else if (plec == 0)
			{ wsp_plci = 0.6; }			
			wynik_promile = suma_porcji / (wsp_plci * waga);
			double czas_spalania;
			if (plec == 1)
				 czas_spalania = suma_porcji / 11;
			else
				czas_spalania = suma_porcji / 9; // 10 - 12 g/h dot mezczyzn 8 - 10g/h dot kobiet // czas spalania podaje wartosc w h.
			Console.WriteLine("\nStezenie alkoholu w wydychanym powietrzu w momencie zakonczenia spozycia wynosil : " + wynik_promile + " promila. ");
			DateTime dt = DateTime.Now; ; double godz = Convert.ToInt32(dt.Hour);
			double trzezwosc = godz - czas - czas_spalania;
			double wynik_promile_teraz=0;
			promile_teraz_m = wynik_promile - ((godz - czas) * 11 / (wsp_plci * waga));
			promile_teraz_k = wynik_promile - ((godz - czas) * 9 / (wsp_plci * waga));
			if (plec == 1)
				wynik_promile_teraz = promile_teraz_m;
			else if (plec == 0)
				wynik_promile_teraz = promile_teraz_k;
			if (wynik_promile_teraz < 0 || wynik_promile_teraz==0)
				wynik_promile_teraz = 0;
			Console.WriteLine("\nObecnie twoj stan alkoholu w wydychanym powietrzu o godzinie " + godz + " wynosi " + wynik_promile_teraz +" promili. ");
			if (wynik_promile_teraz < 0.22)
				Console.WriteLine("\n\nJesteś wg polskich przepisow - trzezwy - twoj stan jest ponizej 0.22 promila");
			else if (wynik_promile_teraz>= 0.22 && wynik_promile_teraz < 0.5)
				Console.WriteLine("\n\nJestes w stanie po uzyciu alkoholu");
			else
				Console.WriteLine("\n\n!! JESTES W STANIE NIETRZEZWOSCI !! ");
			if (trzezwosc < 0)
				Console.WriteLine("\nJestes jeszcze pod wplywem alkoholu sprawdz sie ponownie za " + (godz - czas) + " godzin(e). ") ;
			else
				Console.WriteLine("\nJestes juz calkowicie trzezwy od " + (godz  - czas) + " godzin(y). ");
		}
		public void analizaWPF(double waga, double plec, double czas, double p, double w, double ww, double b)
		{ 
		}
	}
}
