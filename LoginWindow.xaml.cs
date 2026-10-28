using System.Windows;
using System.Windows.Input;

namespace StylishkidsConfections
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                MainWindow mainDashboard = new MainWindow();
                mainDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your login details.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}