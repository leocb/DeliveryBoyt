using DeliveryBoyt.Core;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryBoyt.DisplayServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Bot.Token = Properties.Settings.Default.BotToken;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BotToken = TokenTextBox.Text;
            Properties.Settings.Default.Save();
            Bot.Token = Properties.Settings.Default.BotToken;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _ = Bot.InitBot();
        }
    }
}
