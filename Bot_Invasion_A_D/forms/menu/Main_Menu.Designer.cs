namespace Sem_Testing
{
    partial class MainMenu
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
            btnNewGame = new Button();
            btnCredits = new Button();
            btnExit = new Button();
            btnContinueGame = new Button();
            gameName = new Label();
            logoBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // btnNewGame
            // 
            btnNewGame.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnNewGame.Location = new Point(67, 106);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(153, 56);
            btnNewGame.TabIndex = 0;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // btnCredits
            // 
            btnCredits.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnCredits.Location = new Point(67, 231);
            btnCredits.Name = "btnCredits";
            btnCredits.Size = new Size(153, 56);
            btnCredits.TabIndex = 1;
            btnCredits.Text = "Credits";
            btnCredits.UseVisualStyleBackColor = true;
            btnCredits.Click += btnCredits_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.Location = new Point(67, 293);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(153, 56);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnContinueGame
            // 
            btnContinueGame.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnContinueGame.Location = new Point(67, 169);
            btnContinueGame.Name = "btnContinueGame";
            btnContinueGame.Size = new Size(153, 56);
            btnContinueGame.TabIndex = 3;
            btnContinueGame.Text = "Continue Game";
            btnContinueGame.UseVisualStyleBackColor = true;
            btnContinueGame.MouseEnter += btnContinueGame_MouseEnter;
            // 
            // gameName
            // 
            gameName.AutoSize = true;
            gameName.Font = new Font("Segoe UI", 40F, FontStyle.Regular, GraphicsUnit.Point);
            gameName.Location = new Point(20, 18);
            gameName.Name = "gameName";
            gameName.Size = new Size(435, 72);
            gameName.TabIndex = 4;
            gameName.Text = "Bot Invasion A.D.";
            // 
            // logoBox
            // 
            logoBox.Location = new Point(284, 106);
            logoBox.Margin = new Padding(3, 2, 3, 2);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(335, 243);
            logoBox.TabIndex = 5;
            logoBox.TabStop = false;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logoBox);
            Controls.Add(gameName);
            Controls.Add(btnContinueGame);
            Controls.Add(btnExit);
            Controls.Add(btnCredits);
            Controls.Add(btnNewGame);
            Name = "MainMenu";
            Text = "Bot Invasion A.D.";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnNewGame;
        private Button btnCredits;
        private Button btnExit;
        private Button btnContinueGame;
        private Label gameName;
        private PictureBox logoBox;
    }
}