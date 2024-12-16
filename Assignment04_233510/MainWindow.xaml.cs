using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AssignmentNo4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Players { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Players = new ObservableCollection<string>();
            PlayerListBox.ItemsSource = Players;
        }
        private void PlayerNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PlayerNameTextBox.Text == "Enter player's name")
            {
                PlayerNameTextBox.Text = string.Empty;
                PlayerNameTextBox.Foreground = Brushes.Black;
            }
        }
        private void PlayerNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlayerNameTextBox.Text))
            {
                PlayerNameTextBox.Text = "Enter player's name";
                PlayerNameTextBox.Foreground = Brushes.Gray;
            }
        }
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("Player already exists in the team!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Players.Add(playerName);
            MessageBox.Show($"Player '{playerName}' added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            PlayerNameTextBox.Clear();
        }
        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a player to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string selectedPlayer = PlayerListBox.SelectedItem.ToString();
            Players.Remove(selectedPlayer);
            MessageBox.Show($"Player '{selectedPlayer}' removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
