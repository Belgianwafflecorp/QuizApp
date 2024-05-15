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
    /// Interaction logic for Scoreboard.xaml
    /// </summary>
    public partial class Scoreboard : Window
    {
        public Scoreboard()
        {
            InitializeComponent();
        }

        public void CloseApp_click(object sender, RoutedEventArgs e)
        {
            // Close the current window
            this.Close();
        }

    }
}
