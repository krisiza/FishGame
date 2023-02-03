using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FishGame
{
    enum Direction
    {
        goLeft,
        goRight
    }
    internal class Fish
    {
        Direction _direction;
        MainWindow _mainWindow;
        int fishSpeed = 7;
        public Rectangle fish;
        public List<Rectangle> fishesGoLeft = new List<Rectangle>();
        public List<Rectangle> fishesGoRight = new List<Rectangle>();
        public Fish(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public Rectangle CreateFish()
        {
            Random random = new Random();
            ImageBrush fishImage = new ImageBrush();
            int fishwähl = random.Next(1, 15);
            int y = random.Next(50, 500);
            fish = new Rectangle();
            switch (fishwähl)
            {
                case 1:
                    fish.Height = 15;
                    fish.Width = 15;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish2.png", UriKind.Relative));                   
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 2:
                    fish.Height = 27;
                    fish.Width = 40;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish10.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 3:
                    fish.Height = 30;
                    fish.Width = 40;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish4.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 4:
                    fish.Height = 35;
                    fish.Width = 45;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish6.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 5:
                    fish.Height = 40;
                    fish.Width = 50;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish11.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 6:
                    fish.Height = 60;
                    fish.Width = 70;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/34.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 800);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goLeft;
                    fishesGoLeft.Add(fish);
                    break;
                case 7:
                    fish.Height = 60;
                    fish.Width = 70;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish12.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 8:
                    fish.Height = 40;
                    fish.Width = 50;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish11 goright.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 9:
                    fish.Height = 60;
                    fish.Width = 70;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish12.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 11:
                    fish.Height = 30;
                    fish.Width = 40;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish4gor.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 12:
                    fish.Height = 35;
                    fish.Width = 45;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish6gor.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 13:
                    fish.Height = 60;
                    fish.Width = 70;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish8.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
                case 14:
                    fish.Height = 30;
                    fish.Width = 40;
                    fishImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish9.png", UriKind.Relative));
                    Canvas.SetLeft(fish, 10);
                    Canvas.SetTop(fish, y);
                    _direction = Direction.goRight;
                    fishesGoRight.Add(fish);
                    break;
            }
            fish.Fill = fishImage;
            _mainWindow.myCanvas.Children.Add(fish);
            return fish;
        }
        public void FishGoLeft()
        {
            for (int i = 0; i < fishesGoLeft.Count; i++)
            {
                _direction = Direction.goLeft;
                Canvas.SetLeft(fishesGoLeft[i], Canvas.GetLeft(fishesGoLeft[i]) - fishSpeed);
            }
        }
        public void FishGoRight()
        {
            for (int i = 0; i < fishesGoRight.Count; i++)
            {
                _direction = Direction.goRight;
                Canvas.SetLeft(fishesGoRight[i], Canvas.GetLeft(fishesGoRight[i]) + fishSpeed);
            }
        }
        public void PlayerOnFishL()
        {
            for (int i = 0; i < fishesGoLeft.Count; i++)
            {
                Rect rPlayer = new Rect(Canvas.GetLeft(_mainWindow.player), Canvas.GetTop(_mainWindow.player), _mainWindow.player.Width, _mainWindow.player.Height);
                Rect rFish = new Rect(Canvas.GetLeft(fishesGoLeft[i]), Canvas.GetTop(fishesGoLeft[i]), fishesGoLeft[i].Width, fishesGoLeft[i].Height);

                if (rPlayer.IntersectsWith(rFish))
                {
                    if (_mainWindow.player.Height > fishesGoLeft[i].Height || _mainWindow.player.Width > fishesGoLeft[i].Width)
                    {
                        _mainWindow.myCanvas.Children.Remove(fishesGoLeft[i]);
                        _mainWindow.player.Width += 0.01;
                        _mainWindow.player.Height += 0.01;
                    }
                    else
                    {
                        _mainWindow.GameOver();
                    }
                }
            }
        }
        public void PlayerOnFishR()
        {
            for (int i = 0; i < fishesGoRight.Count; i++)
            {
                Rect rPlayer = new Rect(Canvas.GetLeft(_mainWindow.player), Canvas.GetTop(_mainWindow.player), _mainWindow.player.Width, _mainWindow.player.Height);
                Rect rFish = new Rect(Canvas.GetLeft(fishesGoRight[i]), Canvas.GetTop(fishesGoRight[i]), fishesGoRight[i].Width, fishesGoRight[i].Height);

                if (rPlayer.IntersectsWith(rFish))
                {
                    if (_mainWindow.player.Height > fishesGoRight[i].Height || _mainWindow.player.Width > fishesGoRight[i].Width)
                    {
                        _mainWindow.myCanvas.Children.Remove(fishesGoRight[i]);
                        _mainWindow.player.Width += 0.01;
                        _mainWindow.player.Height += 0.01;
                    }
                    else
                    {
                        _mainWindow.GameOver();
                    }
                }
            }
        }
        public void CreateNewFish()
        {
            for (int i = 0; i < fishesGoLeft.Count; i++)
            {
                if (Canvas.GetLeft(fishesGoLeft[i]) < 0)
                {
                    _mainWindow.myCanvas.Children.Remove(fishesGoLeft[i]);
                    fishesGoLeft.Remove(fishesGoLeft[i]);
                    CreateFish();
                }
            }
            for (int i = 0; i < fishesGoRight.Count; i++)
            {
                if (Canvas.GetLeft(fishesGoRight[i]) > Application.Current.MainWindow.Width)
                {
                    _mainWindow.myCanvas.Children.Remove(fishesGoRight[i]);
                    fishesGoRight.Remove(fishesGoRight[i]);
                    CreateFish();
                }
            }
        }
    }
}
