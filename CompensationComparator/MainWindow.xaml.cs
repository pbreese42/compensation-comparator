using CompensationCalculator;
using System.Windows;

namespace CompensationComparator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            URLScraper test = new URLScraper();
            var col = test.LoadCOLTable("Kennesaw-GA", "San-Jose-CA");
            listBox.ItemsSource = col.MultiplierDict;

            DataContext = new MainWindowViewModel();
        }
    }
}
