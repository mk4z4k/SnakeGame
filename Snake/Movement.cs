using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Snake
{
	public class Movement
	{
		private DirectionEnum _lastStep ;
        private DirectionEnum _direction;
        private Body _Snake;
        private int _step;
        private DispatcherTimer _timer;
        private Food _Food;
        private SnakeGame _Game;
        List<DirectionEnum> steps;

        public Movement(Body snake,int step,Food food,SnakeGame game) 
		{
            _Snake = snake;
            _direction = DirectionEnum.Left;
            _step = step;
            _Food = food;
            _Game = game;
            steps = new List<DirectionEnum>();
            steps.Add(DirectionEnum.Left);

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_Snake.Speed);
            _timer.Tick += SnakeMove;
            _timer.Start();
           
        }

        public void ChangeDirection(Key direction)
        {
			switch (direction)
            {
                case Key.Left:
                    if (_direction != DirectionEnum.Right)
                        _direction = DirectionEnum.Left; 
                    break;
                case Key.Right:
                    if (_direction != DirectionEnum.Left)
                        _direction = DirectionEnum.Right;
                    break;
                case Key.Up:
                    if (_direction != DirectionEnum.Down)
                        _direction = DirectionEnum.Up;
                    break;
                case Key.Down:
                    if (_direction != DirectionEnum.Up)
                        _direction = DirectionEnum.Down;
                    break;
            }
            if (steps[0] != _direction)
                steps.Add(_direction);
        }

        private void SnakeMove(object sender, EventArgs e)
        {
            
            double prevLeft = _Snake.FirstLeftPos;
            double prevTop = _Snake.FirstTopPos;
			if (IsGameOver(_Snake.FirstLeftPos, _Snake.FirstTopPos))
			{
				_timer.Stop();
				_Game.EndGame();
			}
			for (int i = 0; i < _Snake.SnakeBody.Count; i++)
            {
                if (i == 0)
                {
                    if (steps.Count > 1 && _lastStep == steps[0])
                    {
                        steps.RemoveAt(0);
                    }
                    bool teleport = false;
                    switch (steps[0])
                    {
                        case DirectionEnum.Left:
							if (_Game.ghost && (prevLeft - _step < 0))
							{
								Canvas.SetLeft(_Snake.SnakeBody[0], 370);
                                teleport = true;
							}
							else
							{
								Canvas.SetLeft(_Snake.SnakeBody[0], prevLeft - _step);
							}
							break;
                        case DirectionEnum.Right:
                            if (_Game.ghost && prevLeft + _step > 370)
                            {
								Canvas.SetLeft(_Snake.SnakeBody[0], 0);
								teleport = true;
							}
                            else
                            {
								Canvas.SetLeft(_Snake.SnakeBody[0], prevLeft + _step);
							}
                            break;
                        case DirectionEnum.Up:
                            if (_Game.ghost && prevTop - _step < 0)
                            {
								Canvas.SetTop(_Snake.SnakeBody[0], 350);
								teleport = true;
							}
                            else
                            {
								Canvas.SetTop(_Snake.SnakeBody[0], prevTop - _step);
							}
							break;
                        case DirectionEnum.Down:
                            if (_Game.ghost && prevTop + _step > 350 )
                            {
								Canvas.SetTop(_Snake.SnakeBody[0], 0);
								teleport = true;
							}
                            else
                            {
								Canvas.SetTop(_Snake.SnakeBody[0], prevTop + _step);
							}
                            break;
                    }
					if (_Game.grewDown && teleport)
					{
						_Snake.GrewDown();
					}
					_lastStep = steps[0];
                    if (_Food.IsAteFood(_Snake.FirstLeftPos, _Snake.FirstTopPos))
                    {
                        _Snake.SnakeGrewUp();
                        _Snake.Speed -= 0.5;
                        _timer.Interval = TimeSpan.FromMilliseconds(_Snake.Speed);
                        _Food.AddFood();
                    }
                }
                else
                {
                    double topPos = Canvas.GetTop(_Snake.SnakeBody[i]);
                    double leftPos = Canvas.GetLeft(_Snake.SnakeBody[i]);
                    Canvas.SetLeft(_Snake.SnakeBody[i], prevLeft);
                    Canvas.SetTop(_Snake.SnakeBody[i], prevTop);
                    prevLeft = leftPos; prevTop = topPos;
                }

            }
        }

        private bool IsGameOver(double leftPos, double topPos)
        {
            if (!_Game.ghost)
            {
				if (leftPos < 0 || leftPos > 370 || topPos < 0 || topPos > 350)
				{
					return true;
				}
			}

            for (int i = 1; i < _Snake.SnakeBody.Count; i++)
            {
                if (leftPos == Canvas.GetLeft(_Snake.SnakeBody[i]) && topPos == Canvas.GetTop(_Snake.SnakeBody[i]))
                {
					_Snake.SnakeBody[0].Fill = Brushes.Red;
					_Snake.SnakeBody[i].Fill = Brushes.Red;
					return true; 
                }
            }
            return false;
        }

        public void Stop()
        {
            _timer.Stop();
            _timer = null;
        }

    }
}
