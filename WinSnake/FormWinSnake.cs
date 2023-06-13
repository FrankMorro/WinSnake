using System.Drawing.Imaging; // add thiss for the JPG compressor

namespace WinSnake;

public partial class FormWinSnake : Form
{
    private readonly List<Circle> Snake = new();
    private Circle food = new();

    int maxWidth;
    int maxHeight;

    int score;
    int highScore;
    int speed;

    readonly Random rand = new();

    bool goLeft, goRight, goDown, goUp;

    Image img = Properties.Resources.icons8_apple_20;
    Image imgBody = Properties.Resources.skin_snake;

    //enum Direction
    //{
    //    Up, Right, Donw, Left
    //}

    public FormWinSnake()
    {
        InitializeComponent();

        new Settings();
    }

    private void KeyIsDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left && Settings.Directions != "right")
        {
            goLeft = true;
        }

        if (e.KeyCode == Keys.Right && Settings.Directions != "left")
        {
            goRight = true;
        }

        if (e.KeyCode == Keys.Up && Settings.Directions != "down")
        {
            goUp = true;
        }

        if (e.KeyCode == Keys.Down && Settings.Directions != "up")
        {
            goDown = true;
        }
    }

    private void KeyIsUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left)
        {
            goLeft = false;
        }

        if (e.KeyCode == Keys.Right)
        {
            goRight = false;
        }

        if (e.KeyCode == Keys.Up)
        {
            goUp = false;
        }

        if (e.KeyCode == Keys.Down)
        {
            goDown = false;
        }
    }

    private void StartGame(object sender, EventArgs e)
    {
        RestartGame();
    }

    private void TakeSnapShot(object sender, EventArgs e)
    {
        Label caption = new();
        caption.Text = $"I scored: {score} and my Highscore is {highScore} on the Snake Game from JMartinez";
        caption.Font = new Font("Arial", 12, FontStyle.Bold);
        caption.ForeColor = Color.Blue;
        caption.AutoSize = false;
        caption.Width = picCanvas.Width;
        caption.Height = 30;
        caption.TextAlign = ContentAlignment.MiddleCenter;
        picCanvas.Controls.Add(caption);

        SaveFileDialog dialog = new SaveFileDialog();
        dialog.FileName = "Snake Game SnapShop JMartinez";
        dialog.DefaultExt = "jpg";
        dialog.Filter = "JPG Image File | *.jpg";
        dialog.ValidateNames = true;

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            int width = Convert.ToInt32(picCanvas.Width);
            int height = Convert.ToInt32(picCanvas.Height);
            Bitmap bmp = new Bitmap(width, height);

            picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));

            bmp.Save(dialog.FileName, ImageFormat.Jpeg);

            picCanvas.Controls.Remove(caption);
        }
    }

    private void GameTimerEvent(object sender, EventArgs e)
    {
        // setting the Directions
        if (goLeft) Settings.Directions = "left";
        if (goRight) Settings.Directions = "right";
        if (goDown) Settings.Directions = "down";
        if (goUp) Settings.Directions = "up";

        //End of Directions
        for (int i = Snake.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                switch (Settings.Directions)
                {
                    case "left":
                        Snake[i].X--;
                        break;
                    case "right":
                        Snake[i].X++;
                        break;
                    case "down":
                        Snake[i].Y++;
                        break;
                    case "up":
                        Snake[i].Y--;
                        break;
                }

                // Eje X
                if (Snake[i].X == -1)
                {
                    Snake[i].X = maxWidth;
                }

                if (Snake[i].X > maxWidth)
                {
                    Snake[i].X = 0;
                }


                // Eje Y
                if (Snake[i].Y == -1)
                {
                    Snake[i].Y = maxHeight;
                }

                if (Snake[i].Y > maxHeight)
                {
                    Snake[i].Y = 0;
                }

                if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                {
                    EatFood();
                }

                // Comprobamos si la cabeza de la serpiente toca su cuerpo
                for (int j = 1; j < Snake.Count; j++)
                {
                    if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                    {
                        GameOver();
                    }
                }
            }
            else
            {
                Snake[i].X = Snake[i - 1].X;
                Snake[i].Y = Snake[i - 1].Y;
            }
        }

        picCanvas.Invalidate();
    }

    private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
    {
        Graphics canvas = e.Graphics;

        Color colorHead = Color.FromArgb(246, 250, 112);

        Brush snakeColour;

        for (int i = 0; i < Snake.Count; i++)
        {
            if (i == 0)
            {
                snakeColour = new SolidBrush(colorHead);
            }
            else
            {
                TextureBrush skinSnake = new TextureBrush(imgBody);
                snakeColour = skinSnake;
            }

            canvas.FillEllipse(snakeColour, new Rectangle
            (
                Snake[i].X * Settings.Width,
                Snake[i].Y * Settings.Height,
                Settings.Width,
                Settings.Height
            ));
        }

        TextureBrush brushAppel = new TextureBrush(img);
        canvas.FillEllipse(brushAppel, new Rectangle
        (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width,
            Settings.Height
        ));
    }

    private void RestartGame()
    {
        lblGameOver.Visible = false;
        maxWidth = picCanvas.Width / Settings.Width;
        maxHeight = picCanvas.Height / Settings.Height;

        Snake.Clear();

        btnStart.Enabled = false;
        btnSnap.Enabled = false;

        score = 0;
        speed = 10;

        gameTimer.Interval = 100;
        lblScore.Text = $"Score: {score}";
        lblSpeed.Text = $"Speed: {speed} p/sec";

        Circle head = new() { X = 10, Y = 5 };
        Snake.Add(head); // Adding the head part of the snake to the list

        for (int i = 0; i < 2; i++)
        {
            Circle body = new();
            Snake.Add(body);
        }

        food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

        gameTimer.Start();
    }

    private void EatFood()
    {
        score += 1;

        if (score % 10 == 0)
        {
            speed += 10;
            gameTimer.Interval -= 10;
        }

        lblScore.Text = $"Score: {score}";
        lblSpeed.Text = $"Speed: {speed} p/sec";

        Circle body = new()
        {
            X = Snake[Snake.Count - 1].X,
            Y = Snake[Snake.Count - 1].Y
        };

        Snake.Add(body);

        food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
    }

    private void GameOver()
    {
        lblGameOver.Visible = true;
        gameTimer.Stop();
        btnStart.Enabled = true;
        btnSnap.Enabled = true;

        if (score > highScore)
        {
            highScore = score;

            lblHighScore.Text = $"High Score: {Environment.NewLine + highScore}";
            lblHighScore.ForeColor = Color.Brown;
            lblHighScore.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}