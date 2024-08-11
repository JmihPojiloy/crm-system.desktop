using desktop.Services;
using System.Windows;
using System.Windows.Controls;

namespace desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly AuthService _authService;
    public MainWindow()
    {
        InitializeComponent();
        _authService = new AuthService();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;

        string token = await _authService.LiginAsync(username, password);

        if (!string.IsNullOrEmpty(token))
        {
            this.Hide();

            var leadsWindow = new LeadsCollectionWindows(token);
            leadsWindow.Show();

            leadsWindow.Closed += (s, args) => this.Close();
        }
        else
        {
            MessageBox.Show("Connection error or invalid credentials!");
        }
    }
}