using System;
using System.Collections.Generic;
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

namespace WpfQuestionnaire
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            // Open the Main Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Close the current window
            this.Close();
        }
    }
}
