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
using System.Windows.Threading;

namespace FishGame
{
    public partial class MainWindow : Window
    {
        bool goLeft, goRight, goUp, goDown;
        int playerSpeed = 8;
        public int playerScore = 0;
        Obstacles _obstacles;
        Fish _fish;

        DispatcherTimer gameTimer = new DispatcherTimer();
        DispatcherTimer fishTimer = new DispatcherTimer();
        DispatcherTimer sharkTimerGoRight = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            _obstacles = new Obstacles(this);
            _fish = new Fish(this);

            myCanvas.Focus();
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            fishTimer.Tick += Fish_Timer_Tick;
            fishTimer.Interval = TimeSpan.FromMilliseconds(800);
            fishTimer.Start();

            sharkTimerGoRight.Tick += Shark_Timer_Tick;
            sharkTimerGoRight.Interval = TimeSpan.FromMilliseconds(6000);
            sharkTimerGoRight.Start();

            _fish.CreateFish();
            _fish.CreateFish();
            _fish.CreateFish();
            _fish.CreateFish();
        }
        private void Shark_Timer_Tick(object sender, EventArgs e)
        {
            _obstacles.CreateShark();
            _obstacles.RemoveShark();
        }
        private void Fish_Timer_Tick(object sender, EventArgs e)
        {
            _fish.CreateFish();
            _fish.CreateNewFish();
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {
            ImageBrush playerImage = new ImageBrush();
            if(goLeft && Canvas.GetLeft(player) > 50)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - playerSpeed);
                playerImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish1.png", UriKind.Relative));
                player.Fill = playerImage;
            }
            if(goRight && Canvas.GetLeft(player) + (player.Width) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + playerSpeed);
                playerImage.ImageSource = new BitmapImage(new Uri(@"../../image/fish1pos1..png", UriKind.Relative));
                player.Fill=playerImage;
            }
            if(goUp && Canvas.GetTop(player) > 10)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - playerSpeed);
            }
            if(goDown && Canvas.GetTop(player) + (player.Height + 30) < Application.Current.MainWindow.Height-10)
            {
                Canvas.SetTop(player, Canvas.GetTop(player)+playerSpeed);
            }
            _obstacles.SharkROnPlayer();
            _obstacles.SharkLOnPlayer();
            _obstacles.SharkLDirection();
            _obstacles.SharkRDirection();
            
            _fish.FishGoLeft();
            _fish.FishGoRight();
            _fish.PlayerOnFishR();
            _fish.PlayerOnFishL();
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                goLeft = false;
            }
            if (e.Key == Key.Right)
            {
                goRight = false;
            }
            if (e.Key == Key.Up)
            {
                goUp = false;
            }
            if (e.Key == Key.Down)
            {
                goDown = false;
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                goLeft = true;
            }
            if (e.Key == Key.Right)
            {
                goRight = true;
            }
            if (e.Key == Key.Up)
            {
                goUp = true;
            }
            if (e.Key == Key.Down)
            {
                goDown = true;
            }
        }
        public void GameOver()
        {
            {
                MessageBoxResult result;
                result = MessageBox.Show($"Game Over!\nDo you want to coninue to play?", "GAME OVER!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    Close();
                    return;
                }
                ResetGame();
            }
        }
        public void ResetGame()
        {
            myCanvas.Children.Clear();
            Canvas.SetLeft(player, 381);
            Canvas.SetTop(player, 276);

            goDown = false;
            goLeft = false;
            goRight = false;
            goUp = false;

            Canvas.SetLeft(_obstacles.shark, 800);
            Canvas.SetTop(_obstacles.shark, 250);
  
            _fish.fishesGoLeft.Clear();
            _fish.fishesGoRight.Clear();
            _obstacles.sharkGoRight.Clear();
            _obstacles.sharkGoRight.Clear();
            myCanvas.Children.Add(seaWeed3);           
            myCanvas.Children.Add(seaWeed4);
            myCanvas.Children.Add(boot);
            myCanvas.Children.Add(seaEgel);
            myCanvas.Children.Add(seaBrunnen);
            myCanvas.Children.Add(seaWeed1);
            player.Height = 16;
            player.Width = 34;
            myCanvas.Children.Add(player);
            myCanvas.Children.Add(_obstacles.shark);
            _fish.CreateFish();
            _fish.CreateFish();
            _fish.CreateFish();
            _fish.CreateFish();
            _obstacles.CreateShark();
            myCanvas.Children.Add(koral);            
            myCanvas.Children.Add(seaWeed2);           
            myCanvas.Children.Add(seaWeed5);
            myCanvas.Children.Add(seaWeed6);
            myCanvas.Children.Add(seaWeed7);
        }
    }   
}
