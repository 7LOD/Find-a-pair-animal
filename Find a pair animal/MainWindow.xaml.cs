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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
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
            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) //циклы который перебирает все элементы типа "TextBlock" нашей сетки
            {
                int index = random.Next(animalEmoji.Count); // Случайный индекс для заполнение таблицы
                string nextEmoji = animalEmoji[index]; // присвоение эмодзи новой переменной
                textBlock.Text = nextEmoji; // Присвоение эмодзи в текст текущей TextBlock 
                animalEmoji.RemoveAt(index); // Удаление уже использованного эмодзи по индексу
            }
        }
    }
}