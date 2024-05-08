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
using System.Windows.Threading;

namespace WpfPexeso
{
    enum GameStage { Intro, GuessFirst, GuessSecond, FlipBack, Outro }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameStage _stage;

        private int _cols;
        private int _rows;
        private GameCard _currentCard;
        private GameCard _previousCard;



        public int Clicks
        {
            get { return (int)GetValue(ClicksProperty); }
            set { SetValue(ClicksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Points.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClicksProperty =
            DependencyProperty.Register("Clicks", typeof(int), typeof(MainWindow), new PropertyMetadata(0));



        private DispatcherTimer _flipBackTimer;

        public MainWindow()
        {
            InitializeComponent();

            _flipBackTimer = new DispatcherTimer();
            _flipBackTimer.Interval = TimeSpan.FromMilliseconds(500);
            _flipBackTimer.IsEnabled = false;
            _flipBackTimer.Tick += _flipBackTimer_Tick;

            _stage = GameStage.Intro;
            SetVisibility();

        }

        private void _flipBackTimer_Tick(object? sender, EventArgs e)
        {
            NextStage();
        }

        private void NextStage()
        {
            switch (_stage)
            {
                case GameStage.Intro:
                    //spustit hru
                    _stage = GameStage.GuessFirst;
                    SetUpBoard();
                    break;

                case GameStage.GuessFirst:
                    //otočím a jdu na druhou
                    _previousCard = _currentCard;
                    _stage = GameStage.GuessSecond;
                    break;

                case GameStage.GuessSecond:
                    //kontrola, body, otočím zpět
                    Clicks++;
                    _stage = GameStage.FlipBack;
                    _flipBackTimer.Start();
                    break;

                case GameStage.FlipBack:
                    //buď konec hry
                    //nebo znovu na GuessFirst
                    _flipBackTimer.Stop();

                    if (_previousCard.Symbol == _currentCard.Symbol)
                    {
                        Board.Children.Remove(_previousCard);
                        Board.Children.Remove(_currentCard);
                    }
                    else
                    {
                        _previousCard.Flip();
                        _currentCard.Flip();
                    }

                    if (Board.Children.Count == 0)
                    {
                        _stage = GameStage.Outro;
                    }
                    else
                    {
                        _stage = GameStage.GuessFirst;
                    }

                    break;

                case GameStage.Outro:
                    //zobrazit skore
                    //výběr hrat znovu / ukončit
                    _stage = GameStage.Intro;
                    break;

            }

            SetVisibility();
        }

        private void SetVisibility()
        {
            ConfigPanel.Visibility = _stage == GameStage.Intro ? Visibility.Visible : Visibility.Hidden;
            GamePanel.Visibility = (_stage != GameStage.Intro && _stage != GameStage.Outro) ? Visibility.Visible : Visibility.Hidden;
            ResultsPanel.Visibility = _stage == GameStage.Outro ? Visibility.Visible : Visibility.Hidden;
        }

        private void SetUpBoard()
        {
            Board.ColumnDefinitions.Clear();
            Board.RowDefinitions.Clear();
            Board.Children.Clear();

            Clicks = 0;

            for (int i = 0; i < _cols; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < _rows; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
            }

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _cols; x++)
                {
                    GameCard card = new GameCard();                    
                    card.MouseLeftButtonDown += Card_MouseLeftButtonDown;

                    Grid.SetColumn(card, x);
                    Grid.SetRow(card, y);
                    Board.Children.Add(card);

                    //Rectangle rectangle = new Rectangle();
                    //rectangle.Fill = Brushes.Aqua;
                    //rectangle.Stroke = Brushes.Black;
                    //rectangle.StrokeThickness = 3;

                    //Grid.SetColumn(rectangle, x);
                    //Grid.SetRow(rectangle, y);

                    //Board.Children.Add(rectangle);
                }
            }

            RandomizeSymbols();
        }

        private void RandomizeSymbols()
        {
            int count = _rows * _cols;

            int[] symbols = new int[count];
            for (int i = 0; i < count / 2; i++)
            {
                symbols[i] = i + 1;
                symbols[count / 2 + i] = i + 1;
            }

            Random random = new Random();
            symbols = symbols.OrderBy(x => random.NextDouble()).ToArray();

            for (int i = 0; i < count; i++)
            {
                GameCard card = (GameCard)Board.Children[i];
                card.Symbol = symbols[i].ToString();
            }
        }

        private void Card_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_stage == GameStage.FlipBack)
                return;

            GameCard card = (GameCard)sender;
            if (card.IsFlipped)
                return;

            card.Flip();
            _currentCard = card;

            NextStage();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            switch (pressed.Content.ToString())
            {
                case "2x2":
                    _rows = 2;
                    _cols = 2;
                    break;

                case "4x4":
                    _rows = 4;
                    _cols = 4;
                    break;

                case "6x6":
                    _rows = 6;
                    _cols = 6;
                    break;
            }
            NextStage();
        }

        private void PlayAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            NextStage();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}