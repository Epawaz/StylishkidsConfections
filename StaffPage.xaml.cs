using System.Windows;
using System.Windows.Controls;

namespace StylishkidsConfections
{
    public partial class StaffPage : Page
    {
        public StaffPage()
        {
            InitializeComponent();
        }

        private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWindow addWindow = new AddStaffWindow();
            addWindow.ShowDialog();
        }
    }
}