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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPexeso
{
    /// <summary>
    /// Interaction logic for GameCard.xaml
    /// </summary>
    public partial class GameCard : UserControl
    {
        public bool IsFlipped => CardBack.Visibility == Visibility.Hidden;

        public string Symbol
        {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(string), typeof(GameCard), new PropertyMetadata(""));

        public GameCard()
        {
            InitializeComponent();
        }
        public void Flip()
        {
            if (CardBack.Visibility == Visibility.Visible)
                CardBack.Visibility = Visibility.Hidden;
            else
                CardBack.Visibility = Visibility.Visible;
        }
    }
}
