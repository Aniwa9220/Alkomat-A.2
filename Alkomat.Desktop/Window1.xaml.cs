using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Biblioteka;

namespace Alkomat.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            loadingGrid.Visibility = Visibility.Visible;

            Task loadTask = new Task(() => TakeData(tokenSource.Token));
            loadTask.Start();

            loadTask.ContinueWith(loadTask =>
            {
                Dispatcher.Invoke(() =>
                {
                    loadingGrid.Visibility = Visibility.Hidden;
                });
            });


        }
        private void Rodzaj_TextChanged(object sender, TextChangedEventArgs e)
        { }
        private void DataGridStaty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TakeData(CancellationToken token)
        {

            Task.Delay(10000, token).Wait();

            // symulacja długiego procesu ładowania danych
            LoadDb nowa = new LoadDb();
            Dispatcher.Invoke(() =>
            {
                DataGridStaty.ItemsSource = nowa.lista;
                loadingGrid.Visibility = Visibility.Hidden;
            });

        }
        private void Daty_Click(object sender, RoutedEventArgs e)
        {
            LoadDb2 nowa = new LoadDb2(Convert.ToDateTime(OD_data.Text), Convert.ToDateTime(DO_data.Text));
            DataGridStaty.ItemsSource = nowa.lista;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tokenSource.Cancel(); // anuluj
        }
        private CancellationTokenSource tokenSource;
    }
}
