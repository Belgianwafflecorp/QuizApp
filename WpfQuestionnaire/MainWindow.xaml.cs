using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuestionnaireLibrary;
using TriviaApiLibrary;
using ScoreboardLibrary;
using ConsoleQuizApp;

namespace WpfQuestionnaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public readonly IQuestionPageHandler handler;

        public MainWindow()
        {
            this.handler = handler;
            InitializeComponent();
        }

        







    }

}