namespace WinSnake
{
    partial class FormWinSnake
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWinSnake));
            btnStart = new Button();
            picCanvas = new PictureBox();
            btnSnap = new Button();
            lblScore = new Label();
            lblHighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            lblSpeed = new Label();
            label1 = new Label();
            lblGameOver = new Label();
            panelCentral = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(93, 156, 89);
            btnStart.Cursor = Cursors.Hand;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnStart.ForeColor = Color.WhiteSmoke;
            btnStart.Location = new Point(933, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(178, 49);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += StartGame;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.Transparent;
            picCanvas.Location = new Point(122, 86);
            picCanvas.Margin = new Padding(0);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(680, 580);
            picCanvas.SizeMode = PictureBoxSizeMode.StretchImage;
            picCanvas.TabIndex = 1;
            picCanvas.TabStop = false;
            picCanvas.Paint += UpdatePictureBoxGraphics;
            // 
            // btnSnap
            // 
            btnSnap.BackColor = Color.FromArgb(20, 108, 148);
            btnSnap.Cursor = Cursors.Hand;
            btnSnap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSnap.ForeColor = Color.WhiteSmoke;
            btnSnap.Location = new Point(933, 67);
            btnSnap.Name = "btnSnap";
            btnSnap.Size = new Size(178, 49);
            btnSnap.TabIndex = 0;
            btnSnap.Text = "Snap";
            btnSnap.UseVisualStyleBackColor = false;
            btnSnap.Click += TakeSnapShot;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblScore.ForeColor = Color.ForestGreen;
            lblScore.Location = new Point(933, 170);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(83, 25);
            lblScore.TabIndex = 2;
            lblScore.Text = "Score: 0";
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblHighScore.Location = new Point(930, 234);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(110, 25);
            lblHighScore.TabIndex = 2;
            lblHighScore.Text = "High Score";
            // 
            // gameTimer
            // 
            gameTimer.Tick += GameTimerEvent;
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblSpeed.ForeColor = Color.AliceBlue;
            lblSpeed.Location = new Point(933, 132);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(151, 25);
            lblSpeed.TabIndex = 3;
            lblSpeed.Text = "Speed: 10 p/sec";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(930, 198);
            label1.Name = "label1";
            label1.Size = new Size(181, 15);
            label1.TabIndex = 4;
            label1.Text = "__________________________________";
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            lblGameOver.ForeColor = Color.FromArgb(205, 24, 24);
            lblGameOver.Location = new Point(273, 333);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(372, 86);
            lblGameOver.TabIndex = 5;
            lblGameOver.Text = "Game Over";
            lblGameOver.Visible = false;
            // 
            // panelCentral
            // 
            panelCentral.BackColor = Color.Transparent;
            panelCentral.BackgroundImage = Properties.Resources._28021;
            panelCentral.BackgroundImageLayout = ImageLayout.Stretch;
            panelCentral.Controls.Add(lblGameOver);
            panelCentral.Controls.Add(picCanvas);
            panelCentral.Dock = DockStyle.Left;
            panelCentral.Location = new Point(0, 0);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(924, 753);
            panelCentral.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icons8_apple_20;
            pictureBox1.Location = new Point(1035, 172);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FormWinSnake
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1123, 753);
            Controls.Add(pictureBox1);
            Controls.Add(panelCentral);
            Controls.Add(label1);
            Controls.Add(lblSpeed);
            Controls.Add(lblHighScore);
            Controls.Add(lblScore);
            Controls.Add(btnSnap);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormWinSnake";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game Snakes by JMartinez";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private PictureBox picCanvas;
        private Button btnSnap;
        private Label lblScore;
        private Label lblHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private Label lblSpeed;
        private Label label1;
        private Label lblGameOver;
        private Panel panelCentral;
        private PictureBox pictureBox1;
    }
}