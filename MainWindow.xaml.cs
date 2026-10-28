using System.Windows;
using System.Windows.Input;

namespace StylishkidsConfections
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load POS Terminal view by default on startup
            // (You can create a POSPage.xaml for the catalog, or keep it in a user control)

            this.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    Application.Current.Shutdown();
                }
            };
        }
        private void NavAnalysis_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AnalysisPage());
        }

        private void NavReports_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ReportsPage());
        }
        private void NavSettings_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new SettingsPage());
        }
        private void NavStaff_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new StaffPage());
        }
        private void NavInventory_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new InventoryPage());
        }

        private void NavCustomers_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new CustomersPage());
        }

        private void ProductCard_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clothing item added to cart!", "POS Terminal", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CompletePurchase_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Payment successful! Receipt printed and inventory updated.", "Checkout Complete", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
        private void QuickBill_Click(object sender, RoutedEventArgs e)
        {
            QuickBillWindow quickBill = new QuickBillWindow();
            if (quickBill.ShowDialog() == true)
            {
                MessageBox.Show($"Added '{quickBill.ItemName}' (${quickBill.ItemPrice:F2}) to current cart!", "Quick Bill Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ScanBarcode_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scanner active: Point barcode gun at clothing tag...\n\n[Simulated Scan: Toddler Denim Jacket added]", "Barcode Scanner", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}