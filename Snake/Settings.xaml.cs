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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private int _speed = 50;
		private bool _ghostWalls = false;
		private bool _grewDown = false;

		public int Speed { get { return _speed; } }
		public bool Ghost { get { return _ghostWalls; } }
		public bool GrewDown { get { return _ghostWalls; } }

		public bool closeWindow = false;
		private void radioButton_Checked(object sender, RoutedEventArgs e)
		{
            _speed = 75;
		}

		private void radioButton1_Checked(object sender, RoutedEventArgs e)
		{
            _speed = 50;
		}

		private void radioButton2_Checked(object sender, RoutedEventArgs e)
		{
            _speed= 25;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			_ghostWalls = (bool)this.checkBox.IsChecked;
			_grewDown = (bool)this.checkBox1.IsChecked;
			this.DialogResult = true;
			this.Close();

		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (!closeWindow)
			{
				e.Cancel = true;
				this.Visibility = Visibility.Hidden;
			}
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			this.checkBox1.IsEnabled = true;
        }

		private void checkBox_Unchecked(object sender, RoutedEventArgs e)
		{
			this.checkBox1.IsChecked = false;
			this.checkBox1.IsEnabled = false;
		}
	}
}
