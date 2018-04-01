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

namespace okna
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public class Uzytkownik
    {
        protected string imie;
        protected string nazwisko;
        protected string email;

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko  
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Uzytkownik(string Imie, string Nazwisko, string Email)
            {
            imie = Imie;
            nazwisko = Nazwisko;
            email = Email;
            }
        public Uzytkownik()
        {

        }
    }

    public class Osoby:Uzytkownik
    {
        private List<Uzytkownik> osoby = new List<Uzytkownik>();
        public void addUzytkownik(Uzytkownik uz)
        {
            osoby.Add(uz);
        }
        public Uzytkownik getUzytkownik()
        {
            return osoby[osoby.Count-1];
        }
        public Uzytkownik getUzytkownik(int index)
        {
            return osoby[index];
        }
        public void insert(int index, Uzytkownik uz)
        {
            osoby.Insert(index, uz);
        }

        public void remove(int index)
        {
            osoby.RemoveAt(index);
        }

    }

    
    public partial class MainWindow : Window
    {
        private Osoby uzytkownicy = new Osoby();
        Window2 preview;
        int previewIndex=-1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1(uzytkownicy);
            window.Title = "Uzytkownik";
            window.Owner = this;
            window.ShowDialog();
            
        }

        private void Button_Click_Edytuj(object sender, RoutedEventArgs e)
        {
          
            Window1 EditWindow = new Window1(uzytkownicy, ListaUzytkownikow.SelectedIndex);
            EditWindow.Title = "Uzytkownik";
            EditWindow.Owner = this;
            EditWindow.ShowDialog();
        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć " + uzytkownicy.getUzytkownik(ListaUzytkownikow.SelectedIndex).Imie,"Uwaga" ,MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                uzytkownicy.remove(ListaUzytkownikow.SelectedIndex);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged -= ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;
                ListaUzytkownikow.Items.Remove(ListaUzytkownikow.SelectedItem);
                ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow.SelectionChanged += ((MainWindow)Application.Current.MainWindow).ListaUzytkownikow_SelectionChanged;

            }

        }

        private void Button_Click_Podglad(object sender, RoutedEventArgs e)
        {
            preview = new Window2(uzytkownicy,ListaUzytkownikow.SelectedIndex);
            preview.Title = "Podglad";
            preview.Owner = this;
            preview.Show();
        }

        public void ListaUzytkownikow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (preview != null && previewIndex!=ListaUzytkownikow.SelectedIndex)
            {
                
                preview.UpdateText(ListaUzytkownikow.SelectedIndex);
                previewIndex = ListaUzytkownikow.SelectedIndex;
                
            }
        }
    }
}
