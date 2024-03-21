namespace WinFormsApp1
{
    partial class Form1
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
            startButton = new Button();
            snapButton = new Button();
            pictureCanvas = new PictureBox();
            textScore = new Label();
            textHighScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureCanvas).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.BackColor = Color.SkyBlue;
            startButton.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            startButton.Location = new Point(612, 12);
            startButton.Name = "startButton";
            startButton.Size = new Size(115, 55);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += StartGame;
            // 
            // snapButton
            // 
            snapButton.BackColor = Color.LimeGreen;
            snapButton.Font = new Font("MS Reference Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            snapButton.Location = new Point(612, 73);
            snapButton.Name = "snapButton";
            snapButton.Size = new Size(115, 55);
            snapButton.TabIndex = 0;
            snapButton.Text = "Snap";
            snapButton.UseVisualStyleBackColor = false;
            snapButton.Click += TakeGameScreenShot;
            // 
            // pictureCanvas
            // 
            pictureCanvas.BackColor = Color.Silver;
            pictureCanvas.Location = new Point(12, 12);
            pictureCanvas.Name = "pictureCanvas";
            pictureCanvas.Size = new Size(580, 680);
            pictureCanvas.TabIndex = 1;
            pictureCanvas.TabStop = false;
            pictureCanvas.Paint += UpdatePictureBoxImage;
            // 
            // textScore
            // 
            textScore.AutoSize = true;
            textScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textScore.Location = new Point(612, 143);
            textScore.Name = "textScore";
            textScore.Size = new Size(76, 20);
            textScore.TabIndex = 2;
            textScore.Text = "Score: 0";
            // 
            // textHighScore
            // 
            textHighScore.AutoSize = true;
            textHighScore.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textHighScore.Location = new Point(612, 183);
            textHighScore.Name = "textHighScore";
            textHighScore.Size = new Size(98, 20);
            textHighScore.TabIndex = 2;
            textHighScore.Text = "High Score";
            // 
            // gameTimer
            // 
            gameTimer.Interval = 40;
            gameTimer.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(748, 709);
            Controls.Add(textHighScore);
            Controls.Add(textScore);
            Controls.Add(pictureCanvas);
            Controls.Add(snapButton);
            Controls.Add(startButton);
            Name = "Form1";
            Text = "Classic Snake";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)pictureCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button snapButton;
        private PictureBox pictureCanvas;
        private Label textScore;
        private Label textHighScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}
