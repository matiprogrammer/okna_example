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
using System.Windows.Shapes;

namespace okna
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Osoby uzytkownicy;
        Uzytkownik uzytkownik;
        private int SelectedIndex;
        bool IsLoaded, IsUpdate;
        public Window2(Osoby uz, int index)
        {
            InitializeComponent();
            uzytkownicy = uz;
            this.SelectedIndex = index;
           
           

        }
       
        public void UpdateText(int index)
        {
            IsLoaded = false;
            SelectedIndex = index;
            imie.Text = uzytkownicy.getUzytkownik(SelectedIndex).Imie;
            nazwisko.Text = uzytkownicy.getUzytkownik(SelectedIndex).Nazwisko;
            email.Text = uzytkownicy.getUzytkownik(SelectedIndex).Email;
            IsLoaded = true;
            
        }
        private void Button_Click_Zamknij(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeText(object sender, TextChangedEventArgs e)
        {if (IsLoaded)
            {
                uzytkownicy.getUzytkownik(SelectedIndex).Imie = imie.Text;
                uzytkownicy.getUzytkownik(SelectedIndex).Nazwisko = nazwisko.Text;
                uzytkownicy.getUzytkownik(SelectedIndex).Email = email.Text;
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged -= ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.RemoveAt(SelectedIndex);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Insert(SelectedIndex, uzytkownicy.getUzytkownik(SelectedIndex).Imie +" " + uzytkownicy.getUzytkownik(SelectedIndex).Nazwisko + " " + uzytkownicy.getUzytkownik(SelectedIndex).Email);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged += ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Refresh();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsLoaded = false;
            imie.Text = uzytkownicy.getUzytkownik(SelectedIndex).Imie;
            nazwisko.Text = uzytkownicy.getUzytkownik(SelectedIndex).Nazwisko;
            email.Text = uzytkownicy.getUzytkownik(SelectedIndex).Email;
            IsLoaded = true;

        }
    }
}
