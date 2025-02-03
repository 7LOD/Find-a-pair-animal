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

namespace Find_a_pair_animal
{
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }
    

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tenthsOfSecondElapsed++;
            timeTextBlock.Text = (tenthsOfSecondElapsed / 10f).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + "Play again?";
            }
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>() // Список эмодзи для нашего приложения
            {
                "🐷", "🐷",
                "🐮", "🐮",
                "🐱", "🐱",
                "🐯", "🐯",
                "🐴", "🐴",
                "🦥", "🦥",
                "🐰", "🐰",
                "🐵", "🐵",
            };
            Random random = new Random(); // Генератор случайных чисел
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) //циклы который перебирает все элементы типа "TextBlock" нашей сетки
            {
                if (textBlock.Name == "")
                {
                    textBlock.Visibility = Visibility.Visible;
                    int index = random.Next(animalEmoji.Count); // Случайный индекс для заполнение таблицы
                    string nextEmoji = animalEmoji[index]; // присвоение эмодзи новой переменной
                    textBlock.Text = nextEmoji; // Присвоение эмодзи в текст текущей TextBlock 
                    animalEmoji.RemoveAt(index); // Удаление уже использованного эмодзи по индексу
                }
            }
            timer.Start();
            tenthsOfSecondElapsed = 0;
            matchesFound = 0;
        }
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            TextBlock? textBlock = sender as TextBlock;
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if(lastTextBlockClicked.Text == textBlock.Text)
            {
                matchesFound++; 
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                findingMatch = false;
                lastTextBlockClicked.Visibility = Visibility.Visible;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}