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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Osoby uzytkownicy;
        bool IsEdited;
        int SelectedIndex;
        public Window1(Osoby uz)
        {
            IsEdited = false;
            uzytkownicy = uz;
            InitializeComponent();
            
        }

        public Window1(Osoby uz, int SelectedIndex)
        {
            InitializeComponent();
            uzytkownicy = uz;
            imie.Text = uzytkownicy.getUzytkownik(SelectedIndex).Imie;
            nazwisko.Text = uzytkownicy.getUzytkownik(SelectedIndex).Nazwisko;
            email.Text = uzytkownicy.getUzytkownik(SelectedIndex).Email;
            IsEdited = true;
            this.SelectedIndex = SelectedIndex;
        }

        

        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            Uzytkownik uzytkownik = new Uzytkownik(imie.Text,nazwisko.Text,email.Text);

            if (IsEdited)
            {
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged -= ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;
               ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Remove(((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectedItem);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Insert(SelectedIndex, uzytkownik.Imie + " " + uzytkownik.Nazwisko + " " + uzytkownik.Email);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged += ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;

                uzytkownicy.remove(SelectedIndex);
                uzytkownicy.insert(SelectedIndex, uzytkownik);

            }
            else
            {
                uzytkownicy.addUzytkownik(uzytkownik);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Add(uzytkownicy.getUzytkownik().Imie + " " + uzytkownicy.getUzytkownik().Nazwisko + " " + uzytkownicy.getUzytkownik().Email);
            } 
            ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.Items.Refresh();
            Close();

        }

        private void Button_Click_Anuluj(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
