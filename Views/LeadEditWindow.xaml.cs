using System.Windows;
using desktop.Models;

namespace desktop.Views
{
    /// <summary>
    /// Логика взаимодействия для LeadEditWindow.xaml
    /// </summary>
    public partial class LeadEditWindow : Window
    {
        public LeadModel CurrentLeadModel { get; private set; }
        public Status[] StatusValues { get; private set; }

        public LeadEditWindow(LeadModel leadModel)
        {
            InitializeComponent();
            CurrentLeadModel = leadModel;
            StatusValues = Enum.GetValues(typeof(Status)).Cast<Status>().ToArray();
            this.DataContext = CurrentLeadModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
