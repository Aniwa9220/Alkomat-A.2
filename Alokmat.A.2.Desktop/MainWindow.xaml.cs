using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alkomat_A._2.Logic;


namespace Alokmat.A._2.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Osoba Badana = new Osoba();
        Analizator analizator = new Analizator();
      
        public MainWindow()
        {
            InitializeComponent();

        }
        
        private void MężczyznaIndx_Checked(object sender, RoutedEventArgs e)
        {
            Badana.plec = 1;
        }


        private void MężczyznaIndx2_Checked(object sender, RoutedEventArgs e)
        {
            Badana.plec = 0;
        }
       

        private void AnalizatorStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime dt = DateTime.Now; ; double godz = Convert.ToInt32(dt.Hour);
                string InsrWaga = this.InsertWaga.Text;
                Badana.waga = Convert.ToDouble(InsrWaga);
                if (Badana.waga > 200)
                {
                    MessageBox.Show("Słonie nie piją!", "Ograniczenia Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                string InsrCzas = this.InsrCzas.Text;
                analizator.czas = Convert.ToDouble(InsrCzas);
                if (analizator.czas > 24)
                {
                    MessageBox.Show("Wiem, że szczęśliwi czasu nie liczą, ale doba ma 24, nie pij więcej.", "Ograniczenia Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                string InsrP = this.Piwo.Text;
                string InsrW = this.Wino.Text;
                string InsrWW = this.Wódka.Text;
                string InsrB = this.Bimber.Text;

                analizator.p = Convert.ToDouble(InsrP);
                analizator.w = Convert.ToDouble(InsrW);
                analizator.ww = Convert.ToDouble(InsrWW);
                analizator.b = Convert.ToDouble(InsrB);
                analizator.czas = Convert.ToDouble(InsrCzas);
              

                double porcje_p, porcje_w, porcje_ww, porcje_b;
                porcje_p = analizator.p * (1.0 / 25.0);
                porcje_w = analizator.w * (1.0 / 10.0);
                porcje_ww = analizator.ww * (1.0 / 3.0);
                porcje_b = analizator.b * (2.0 / 3.0);
                double suma_porcji = porcje_p + porcje_w + porcje_ww + porcje_b, promile_teraz_m, promile_teraz_k, wynik_promile; // w momencie wypicia
                double wsp_plci = 0;
                if (Badana.plec == 1)
                { wsp_plci = 0.7; }
                else if (Badana.plec == 0)
                { wsp_plci = 0.6; }
                wynik_promile = suma_porcji / (wsp_plci * Badana.waga);
                double czas_spalania;
                if (Badana.plec == 1)
                    czas_spalania = suma_porcji / 11;
                else
                    czas_spalania = suma_porcji / 9; // 10 - 12 g/h dot mezczyzn 8 - 10g/h dot kobiet // czas spalania podaje wartosc w h.
                Wynik_Czas.Text = Convert.ToString(String.Format("{0:N2}", wynik_promile)); // to zostaje
                double wynik_promile_teraz = 0;
                promile_teraz_m = wynik_promile - ((godz - analizator.czas) * 11 / (wsp_plci * Badana.waga));
                promile_teraz_k = wynik_promile - ((godz - analizator.czas) * 9 / (wsp_plci * Badana.waga));
                double trzezwosc = godz - analizator.czas - czas_spalania;
                if (Badana.plec == 1)
                    wynik_promile_teraz = promile_teraz_m;
                else if (Badana.plec == 0)
                    wynik_promile_teraz = promile_teraz_k;

                if (wynik_promile_teraz < 0 || wynik_promile_teraz == 0)
                    wynik_promile_teraz = 0;
                // zostaje 
                if (analizator.doba == 1)
                {
                    promile_teraz_m = 0; promile_teraz_k = 0; wynik_promile_teraz = 0;
                    double zmiana, zmiana1; zmiana = 24 - analizator.czas;
                    zmiana1 = godz + zmiana;
                    analizator.czas = zmiana1;
                    trzezwosc = analizator.czas - czas_spalania;
                    promile_teraz_m = wynik_promile - Math.Abs(((analizator.czas) * 11 / (wsp_plci * Badana.waga)));
                    promile_teraz_k = wynik_promile - Math.Abs(((analizator.czas) * 9 / (wsp_plci * Badana.waga)));
                    if (Badana.plec == 1)
                        wynik_promile_teraz = promile_teraz_m;
                    else if (Badana.plec == 0)
                        wynik_promile_teraz = promile_teraz_k;
                    if (wynik_promile_teraz < 0) wynik_promile_teraz = 0;
                }

              
               
                Wynik_godz.Text = Convert.ToString(String.Format("{0:N2}", wynik_promile_teraz)); // to zostaje

                // to zostaje 

                if (analizator.doba == 0)
                {
                    if (wynik_promile_teraz > 0.22)
                    
                            Uwaga.Text = Convert.ToString(" Jestes jeszcze pod wplywem alkoholu sprawdz sie ponownie za " + String.Format("{0:N0}", Math.Abs(godz - analizator.czas - czas_spalania)) + " godzine/y. ");
      
                    else 
                    {
                        Uwaga.Text = Convert.ToString(" Jestes trzezwy wg polskich przepisów od " + String.Format("{0:N0}", Math.Abs(godz - analizator.czas - czas_spalania)) + " godzin. ");
                    }
                 
                }
                else if (analizator.doba==1)
                {
                    
                        if (wynik_promile_teraz > 0.22)
                            Uwaga.Text = Convert.ToString(" Jestes jeszcze pod wplywem alkoholu sprawdz sie ponownie za " + String.Format("{0:N0}", Math.Abs(analizator.czas - czas_spalania)) + " godzine. ");
                    
                        else
                            Uwaga.Text = Convert.ToString(" Jestes trzezwy wg polskich przepisów od " + String.Format("{0:N0}", Math.Abs(analizator.czas - czas_spalania)) + " godzin. ");

                }

                wynik_promile_teraz = 0; trzezwosc = 0; analizator.czas = 0; czas_spalania = 0; //Uwaga.Text = "";//reset
            }
            catch
            {
                MessageBox.Show("Wpisałeś niepoprawne dane, używaj tylko liczb. Inne znaki są niedozwolone.", "Błąd Aplikacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    
        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       

        private void doba_Checked_1(object sender, RoutedEventArgs e)
        {
            analizator.doba = 1;
        }

        private void Zeruj_Click(object sender, RoutedEventArgs e)
        {
            Piwo.Text="0";
            Wino.Text = "0";
            Wódka.Text = "0";
            Bimber.Text = "0";
            InsertWaga.Text = "";
            InsrCzas.Text = "";
            Uwaga.Text = "";
            
        }
    }
}
