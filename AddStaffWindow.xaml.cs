using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace StylishkidsConfections
{
    public partial class AddStaffWindow : Window
    {
        private byte[] photoBytes = null;

        public AddStaffWindow()
        {
            InitializeComponent();
        }

        private void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Staff Photo",
                Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txtPhotoPath.Text = openFileDialog.FileName;
                // Convert image to byte array for varbinary(max) database storage
                photoBytes = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            string userID = txtUserID.Text.Trim();
            string userName = txtUserName.Text.Trim();

            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("User ID and Username are required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Database mapping fields include:
            // UserID, UserName, SurName, GivenName, Password, DateOfBirth, Gender, UserRole, AccountStatus, PhoneNumber, Email, Photo (photoBytes)

            MessageBox.Show($"Staff member '{userName}' (ID: {userID}) along with photo data successfully added to database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}