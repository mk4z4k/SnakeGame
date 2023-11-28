using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake;

public class SnakeGame
{
    private Canvas _canvasMap;
    private Window _window;
    private MainMenu _menu;
    Body _snake;
    Food _food;
    public Movement _move;
	public int multi;

    public bool ghost;
    public bool grewDown;

	public SnakeGame(Canvas canvas,Window window,MainMenu menu)
    {
        _canvasMap = canvas;
        _window= window;
        _menu = menu;
    }

    public void StartGame(Settings set)
    {
		int speed = set.Speed;
		ghost = set.Ghost;
        grewDown = set.GrewDown;
		multi = speed == 25 ? 3 : speed == 50 ? 2 : 1;
		_canvasMap.Children.Clear();
		if (!ghost)
		{
			Rectangle border = new Rectangle();
			border.Stroke = Brushes.Blue;
			border.Width = 384;
			border.Height = 361;
			_canvasMap.Children.Add(border);
		}
		_snake = new Body(10, speed, _canvasMap);
		_food = new Food(_canvasMap);
		_move = new Movement(_snake, 10, _food, this);
	}
    
      
    public void KeyPressed(Key direction)
    {
        _move.ChangeDirection(direction);
    }

    public void CheatsGrewUp()
    {
        _snake.SnakeGrewUp();
    }

    public void EndGame()
    {
        MessageBox.Show($"Вы набрали {(_snake.SnakeBody.Count - 1) * multi} очко(в)", "Игра окончена!", MessageBoxButton.OK);
        _window.Close();
    }

    public void Stop()
    {
        _move.Stop();
    }

}