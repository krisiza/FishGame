using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;
using System.Windows.Shapes;
using System.Windows.Media;
using System.ComponentModel.Design;

namespace FishGame
{
    enum SharkDirection
    {
        LEFT,
        RIGHT
    }
    internal class Obstacles
    {
        MainWindow _mainWindow;
        int sharkSpeed = 13;
        public Rectangle shark;
        public List<Rectangle> sharkGoRight = new List<Rectangle>();
        public List<Rectangle> sharkGoLeft = new List<Rectangle>();
        ImageBrush sharkImage = new ImageBrush();
        Random rnd = new Random();

        SharkDirection _sharkDirection;
        public Obstacles(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public Rectangle CreateShark()
        {
            Random rnd2 = new Random();
            ImageBrush sharkImage = new ImageBrush();
            int sharkDirection = this.rnd.Next(1, 3);
            int y = rnd.Next(30, 500);
            shark = new Rectangle();
            shark.Width = 200;
            shark.Height = 80;
            switch (sharkDirection)
            {
                case 1:
                    sharkImage.ImageSource = new BitmapImage(new Uri(@"../../image/SharkgoesRight.png", UriKind.Relative));
                    Canvas.SetLeft(shark, 0);
                    Canvas.SetTop(shark, y);
                    _sharkDirection = SharkDirection.RIGHT;
                    sharkGoRight.Add(shark);
                    break;
                case 2:
                    sharkImage.ImageSource = new BitmapImage(new Uri(@"../../image/SharkgoesLeft.png", UriKind.Relative));
                    Canvas.SetLeft(shark, 800);
                    Canvas.SetTop(shark, y);
                    _sharkDirection = SharkDirection.LEFT;
                    sharkGoLeft.Add(shark);
                    break;

            }
            shark.Fill = sharkImage;
            _mainWindow.myCanvas.Children.Add(shark);
            return shark;
        }
        public void SharkRDirection()
        {
            for (int i = 0; i < sharkGoRight.Count; i++)
            {
                _sharkDirection = SharkDirection.RIGHT;
                Canvas.SetLeft(sharkGoRight[i], Canvas.GetLeft(sharkGoRight[i]) + sharkSpeed);
            }
        }
        public void SharkLDirection()
        {
            for (int i = 0; i < sharkGoLeft.Count; i++)
            {
                _sharkDirection = SharkDirection.LEFT;
                Canvas.SetLeft(sharkGoLeft[i], Canvas.GetLeft(sharkGoLeft[i]) - sharkSpeed);
            }
        }
        public void SharkROnPlayer()
        {
            for (int i = 0; i < sharkGoRight.Count; i++)
            {
                Rect rPlayer = new Rect(Canvas.GetLeft(_mainWindow.player), Canvas.GetTop(_mainWindow.player), _mainWindow.player.Width, _mainWindow.player.Height);
                Rect rSharkR = new Rect(Canvas.GetLeft(sharkGoRight[i]), Canvas.GetTop(sharkGoRight[i]), sharkGoRight[i].Width, sharkGoRight[i].Height);

                if (rPlayer.IntersectsWith(rSharkR) && (_mainWindow.player.Width > shark.Width && _mainWindow.player.Height > shark.Height))
                {
                    _mainWindow.myCanvas.Children.Remove(sharkGoRight[i]);
                    sharkGoRight.Clear();
                    MessageBox.Show("Congratulations!!!\nYOU WON!!!", "WINNER!!!", MessageBoxButton.OK);
                    _mainWindow.Close();
                }
                else if (rPlayer.IntersectsWith(rSharkR) && (_mainWindow.player.Width < shark.Width))
                {
                    _mainWindow.GameOver();
                }
            }
        }
        public void SharkLOnPlayer()
        {
            for (int i = 0; i < sharkGoLeft.Count; i++)
            {

                Rect rPlayer = new Rect(Canvas.GetLeft(_mainWindow.player), Canvas.GetTop(_mainWindow.player), _mainWindow.player.Width, _mainWindow.player.Height);
                Rect rSharkL = new Rect(Canvas.GetLeft(sharkGoLeft[i]), Canvas.GetTop(sharkGoLeft[i]), sharkGoLeft[i].Width, sharkGoLeft[i].Height);

                if (rPlayer.IntersectsWith(rSharkL) && (_mainWindow.player.Width > shark.Width && _mainWindow.player.Height > shark.Height))
                {
                    _mainWindow.myCanvas.Children.Remove(sharkGoLeft[i]);
                    sharkGoLeft.Clear();
                    MessageBox.Show("Congratulations!!!\nYOU WON!!!", "WINNER!!!", MessageBoxButton.OK);
                    _mainWindow.Close();
                }
                else if (rPlayer.IntersectsWith(rSharkL) && (_mainWindow.player.Width < shark.Width))
                {
                    _mainWindow.GameOver();
                }
            }
        }
        public void RemoveShark()
        {
            for (int i = 0; i < sharkGoRight.Count; i++)
            {
                if (Canvas.GetLeft(sharkGoRight[i]) > System.Windows.Application.Current.MainWindow.Width)
                {
                    _mainWindow.myCanvas.Children.Remove(sharkGoRight[i]);
                    sharkGoRight.Remove(sharkGoRight[i]);
                }
            }
            for (int i = 0; i < sharkGoLeft.Count; i++)
            {
                if (Canvas.GetLeft(sharkGoLeft[i]) < 0)
                {
                    _mainWindow.myCanvas.Children.Remove(sharkGoLeft[i]);
                    sharkGoLeft.Remove(sharkGoLeft[i]);
                }
            }
        }
    }
}
