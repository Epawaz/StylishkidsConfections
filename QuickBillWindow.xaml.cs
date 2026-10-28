using System.Windows;

namespace StylishkidsConfections
{
    public partial class QuickBillWindow : Window
    {
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }

        public QuickBillWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ItemName = txtItemName.Text;
            if (decimal.TryParse(txtItemPrice.Text, out decimal price))
            {
                ItemPrice = price;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid price.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}