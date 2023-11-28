using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
	public class Food
	{
        private Ellipse _food;

       

        public Food(Canvas canvas)
        {
            _food = new Ellipse();
            AddFood();
            canvas.Children.Add( _food );
        }
        public void AddFood()
        {
            _food.Width = 10; _food.Height = 10;
            _food.Fill = Brushes.Green;
            Random rnd = new Random();
            Canvas.SetLeft(_food, rnd.Next(0, 37) * 10);
            Canvas.SetTop(_food, rnd.Next(0, 35) * 10);
        }

        public bool IsAteFood(double leftPos, double topPos)
        {
            double foodTop = Canvas.GetTop(_food);
            double foodLeft = Canvas.GetLeft(_food);
            if (leftPos == foodLeft && topPos == foodTop)
                return true;
            return false;
        }
    }
}
