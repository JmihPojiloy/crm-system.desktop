using desktop.Data;
using desktop.Models;
using desktop.Services;
using desktop.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace desktop
{
    /// <summary>
    /// Логика взаимодействия для LeadsCollectionWindows.xaml
    /// </summary>
    public partial class LeadsCollectionWindows : Window
    {
        private List<LeadModel> _leads;
        private Presenter _presenter;

        public LeadsCollectionWindows(string token)
        {
            InitializeComponent();
            _presenter = new Presenter(token);
            _leads = new List<LeadModel>();
            LoadLeadsAsync();
        }

        private async void RefreshButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            _leads = await _presenter.GetAll();
            LeadsDataGrid.ItemsSource = _leads;
        }

        private async void DeleteButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            if(LeadsDataGrid.SelectedItem is LeadModel selectedLead)
            {
                await _presenter.Delete(selectedLead.Id);
                _leads.Remove(selectedLead);
                LeadsDataGrid.Items.Refresh();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void LeadsDataGrid_MouseDoubleClickAsync(object sender, MouseButtonEventArgs e)
        {
            if(LeadsDataGrid.SelectedItem is LeadModel selectedLead)
            {
                LeadEditWindow leadEditWindow = new LeadEditWindow(selectedLead);

                if (leadEditWindow.ShowDialog() == true)
                {
                    LeadsDataGrid.CommitEdit(DataGridEditingUnit.Row, true);
                    LeadsDataGrid.Items.Refresh();
                    await _presenter.Update(selectedLead);
                }
            }
        }

        private async void LoadLeadsAsync()
        {
            _leads = await _presenter.GetAll();
            LeadsDataGrid.ItemsSource = _leads;
        }

    }
}
