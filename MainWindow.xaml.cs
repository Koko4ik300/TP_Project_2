using System.Windows;
using System.Windows.Navigation;

namespace TP_Project;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new HomePage());
    }
    
}