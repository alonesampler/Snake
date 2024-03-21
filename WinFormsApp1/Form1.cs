using System.Drawing.Imaging;

namespace WinFormsApp1
{   
    public partial class Form1 : Form
    {
        private List<Circle> _snake = new List<Circle>();
        private Circle _food = new Circle();

        private int _maxWidth;
        private int _maxHeight;

        private int _score;
        private int _highScore;

        Random rand = new Random();

        private bool _goLeft, _goRight, _goUp, _goDown;

        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.DirectionalMove != "right")
                _goLeft = true;

            if (e.KeyCode == Keys.Right && Settings.DirectionalMove != "left")
                _goRight = true;

            if (e.KeyCode == Keys.Up && Settings.DirectionalMove != "down")
                _goUp = true;

            if (e.KeyCode == Keys.Down && Settings.DirectionalMove != "up")
                _goDown = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                _goLeft = false;

            if (e.KeyCode == Keys.Right)
                _goRight = false;

            if (e.KeyCode == Keys.Up)
                _goUp = false;

            if (e.KeyCode == Keys.Down)
                _goDown = false;
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void TakeGameScreenShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = $"я набрал здесь счЄт равный {_score}. ћой рекордный счЄт в этой игре равен {_highScore}.";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Black;
            caption.AutoSize = false;
            caption.Width = pictureCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            pictureCanvas.Controls.Add(caption);

            SaveFileDialog screenShot = new SaveFileDialog();
            screenShot.FileName = "—крин«мейки";
            screenShot.DefaultExt = "jpg";
            screenShot.Filter = "JPG Image File | *.jpg";
            screenShot.ValidateNames = true;

            if(screenShot.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(pictureCanvas.Width);
                int height = Convert.ToInt32(pictureCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                pictureCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(screenShot.FileName, ImageFormat.Jpeg);
                pictureCanvas.Controls.Remove(caption);
            }


        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if(_goRight)
                Settings.DirectionalMove = "right";

            if (_goLeft)
                Settings.DirectionalMove = "left";

            if (_goUp)
                Settings.DirectionalMove = "up";

            if (_goDown)
                Settings.DirectionalMove = "down";

            for(int i = _snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch(Settings.DirectionalMove)
                    {
                        case "left":
                            _snake[i].X--;
                            break;
                        case "right":
                            _snake[i].X++;
                            break;
                        case "up":
                            _snake[i].Y--;
                            break;
                        case "down":
                            _snake[i].Y++;
                            break;
                    }

                    if (_snake[i].X < 0)
                        _snake[i].X = _maxWidth;

                    if (_snake[i].X > _maxWidth)
                        _snake[i].X = 0;

                    if (_snake[i].Y < 0)
                        _snake[i].Y = _maxHeight;

                    if (_snake[i].Y > _maxHeight)
                        _snake[i].Y = 0;

                    if (_snake[i].X == _food.X && _snake[i].Y == _food.Y)
                    {
                        EatFood();
                    }

                    for(int j = 1; j < _snake.Count; j++)
                    {
                        if (_snake[i].X == _snake[j].X && _snake[i].Y == _snake[j].Y)
                            EndGame();
                    }   
                }
                else
                {
                    _snake[i].X = _snake[i - 1].X;
                    _snake[i].Y = _snake[i - 1].Y;
                }
            }
            pictureCanvas.Invalidate();
        }

        private void UpdatePictureBoxImage(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for(int i = 0; i < _snake.Count; i++)
            {
                if(i == 0)
                    snakeColor = Brushes.Black;
                else
                    snakeColor = Brushes.DarkBlue;

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    _snake[i].X * Settings.Width,
                    _snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    _food.X * Settings.Width,
                    _food.Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
        }

        private void RestartGame()
        {
            _maxWidth = pictureCanvas.Width / Settings.Width - 1;
            _maxHeight = pictureCanvas.Height / Settings.Height - 1;

            _snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            _score = 0;
            textScore.Text = $"Score: {_score}";

            Circle head = new Circle
            {
                X = 10,
                Y = 5
            };

            _snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                _snake.Add(body);
            }

            _food = new Circle
            {
                X = rand.Next(2, _maxWidth),
                Y = rand.Next(2, _maxHeight)
            };

            gameTimer.Start();
        }

        private void EatFood()
        {
            _score++;

            textScore.Text = $"Score: {_score}";

            Circle body = new Circle
            {
                X = _snake[_snake.Count - 1].X,
                Y = _snake[_snake.Count - 1].Y
            };

            _snake.Add(body);

            _food = new Circle
            {
                X = rand.Next(2, _maxWidth),
                Y = rand.Next(2, _maxHeight)
            };

        }

        private void EndGame()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if(_score > _highScore)
            {
                _highScore = _score;
                textHighScore.Text = $"High Score: {Environment.NewLine + _highScore}";
                textHighScore.ForeColor = Color.Maroon;
                textHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }
    }
}
