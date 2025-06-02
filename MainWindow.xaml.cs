using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pilots_GUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    AppContext context = new AppContext();

    public ObservableCollection<string> Genders { get; set; } // Férfi/Nő lehetőségek

    public ObservableCollection<Pilot> Pilots { get; set; }  // Megjelenített pilóták listája

    public Pilot SelectedPilot { get; set; } // Kiválasztott pilóta törléshez

    private Pilot newPilot = new Pilot(); // Ez tartalmazza az új pilóta adatait, amit az űrlapon töltünk ki.

    public Pilot NewPilot
    {
        get { return newPilot; }
        set { newPilot = value; OnPropertyChanged(nameof(NewPilot)); }
    }


    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        Genders = new ObservableCollection<string>() { "F", "M" };  // ComboBox lehetőségek
        context.Pilots.Load(); // Betölti az adatbázis tartalmát
        Pilots = context.Pilots.Local.ToObservableCollection();  // Megjeleníti a listát a DataGrid-ben
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if(SelectedPilot != null)
        {
            MessageBoxResult result = MessageBox.Show($"Biztosan törölni kívánja a(z) {SelectedPilot.Name} nevű pilótát?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                Pilots.Remove(SelectedPilot);
                context.SaveChanges();
            }
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (InputCheck())
        {
            Pilots.Add(NewPilot);
            context.SaveChanges();
            NewPilot = new Pilot();
        }
    }

    private bool InputCheck()
    {
        if (String.IsNullOrWhiteSpace(NewPilot.Name))
        {
            MessageBox.Show("A név mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (String.IsNullOrWhiteSpace(NewPilot.Gender))
        {
            MessageBox.Show("A nem mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if(NewPilot.Birthdate == null || NewPilot.Birthdate > DateTime.Now)
        {
            MessageBox.Show("A születés mező kitöltése kötelező és nem lehet nagyobb az aktuális dátumnál!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        if (String.IsNullOrWhiteSpace(NewPilot.Nation))
        {
            MessageBox.Show("A nemzet mező kitöltése kötelező!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        return true;
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string tulajdonsagNev)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagNev));
    }

}