using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
	public class Body
	{
		private int _size;
		private double _speed;
		private List<Ellipse> _snake;
        private Canvas _canvasMap;

        public int Size
		{
			get { return _size; }
		}
        public double Speed
        {
            get { return _speed; }
			set { _speed = value; }
        }

        public List<Ellipse> SnakeBody
        {
            get { return _snake; }
        }
        public double LastLeftPos
        {
            get { return Canvas.GetLeft(_snake.Last()); }
        }
        public double LastTopPos
        {
            get { return Canvas.GetTop(_snake.Last()); }
        }

        public double FirstLeftPos
        {
            get { return Canvas.GetLeft(_snake[0]); }
        }
        public double FirstTopPos
        {
            get { return Canvas.GetTop(_snake[0]); }
        }


        public Body(int size,int speed,Canvas canvas) 
		{
			_size = size;
			_speed = speed;
            _canvasMap = canvas;
            CreateSnake();

        }

        public void SnakeGrewUp()
        {
            Ellipse snake = new Ellipse();
            snake.Width = _size; snake.Height = _size;
            snake.Fill = Brushes.Black;
            Canvas.SetLeft(snake, LastLeftPos + _size);
            Canvas.SetTop(snake, LastTopPos);
            _canvasMap.Children.Add(snake);
            _snake.Add(snake);
        }

        private void CreateSnake()
        {
            Ellipse snake = new Ellipse();
            snake.Width = _size; snake.Height = _size;
            snake.Fill = Brushes.Black;
            Canvas.SetLeft(snake, 150);
            Canvas.SetTop(snake, 150);
            _canvasMap.Children.Add(snake);
            _snake = new List<Ellipse>();
            _snake.Add(snake);
        }

        public void GrewDown()
        {
            if (_snake.Count > 1)
            {
                _snake.RemoveAt(_snake.Count-1);
                _canvasMap.Children.RemoveAt(_canvasMap.Children.Count-1);
                
			}
		}
    }
}
