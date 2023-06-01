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

namespace Kontrolki
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class OcenaApki : UserControl
    {
        public OcenaApki()
        {
            InitializeComponent();
        }
        public event EventHandler<OcenaEventArgs> OcenaZmiana;

        private int ocena;
        public int Ocena
        {
            get => ocena;
            set
            {
                ocena = value;
                UpdateButtons();

                if(OcenaZmiana !=null)
                {
                    OcenaZmiana(sender: this, e: new OcenaEventArgs() { Ocena = value });
                }
            }
        }
        private void UpdateButtons()
        {
            foreach (Button g in GridGwiazd.Children)
            {
                 g.Background= new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka.png", UriKind.Relative)));
             


            }

            if (ocena>0)
            {
                ((Button) GridGwiazd.Children[ocena-1]).Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                if (ocena == 1)
                {
                this.a.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                }
                if (ocena==2)
                {
                    this.a.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.b.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                }
                if (ocena==3)
                {
                    this.a.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.b.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.c.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));

                }
                if (ocena==4)
                { 
                    this.a.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.b.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.c.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.d.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));

                }
                if (ocena==5)
                {
                    this.a.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.b.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.c.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.d.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));
                    this.e.Background = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\ivan0\source\repos\ConsoleApp10\Kontrolki\gwiazdka1.jpg", UriKind.Relative)));

                }

            }
         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           Ocena = GridGwiazd.Children.IndexOf((Button)sender) + 1;
          
        }

        public class OcenaEventArgs : EventArgs 
        {
            public int Ocena { get; set; }
        }


        private void Image_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }

     
    }
