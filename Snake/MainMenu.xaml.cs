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

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            _settings = new Settings(); 
        }

        private bool closeWindow = true;
        private Settings _settings; 
		private void button_Click(object sender, RoutedEventArgs e)
		{
            MainWindow start = new MainWindow(_settings, this) ;
            start.Show();
            this.closeWindow = false;
        }

		private void button1_Click(object sender, RoutedEventArgs e)
		{
           
			if (_settings.ShowDialog() == true)
            { return; }
            
        }

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			_settings.closeWindow = true;
			_settings.Close();	
            
		}
	}
}
