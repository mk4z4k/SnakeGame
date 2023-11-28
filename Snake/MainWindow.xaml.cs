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

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SnakeGame _game;
        MainMenu _menu;
        public MainWindow(Settings set,MainMenu menu)
        {
            InitializeComponent();
            _settings = set;
            _menu = menu;
        }

        private Settings _settings;
		private void CanvasMap_Loaded(object sender, RoutedEventArgs e)
		{
            _game = new SnakeGame(CanvasMap, this, _menu);
            _game.StartGame(_settings);
        }


		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            {
                _game.KeyPressed(e.Key);
            }
            //if (e.Key == Key.M)
            //{
            //    _game.CheatsGrewUp();
            //}
           
        }

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            _game.Stop();
            _game = null;
		}
	}
}