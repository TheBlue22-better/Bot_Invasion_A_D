namespace Bot_Invasion_A_D.forms.menu
{
    partial class Game_Over
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btn_menu = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 50F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(135, 41);
            label1.Name = "label1";
            label1.Size = new Size(534, 320);
            label1.TabIndex = 0;
            label1.Text = "<DEATH>\r\n\r\n<SEND IN \r\nANOTHER BOT!>";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_menu
            // 
            btn_menu.Anchor = AnchorStyles.None;
            btn_menu.Location = new Point(265, 364);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(254, 42);
            btn_menu.TabIndex = 2;
            btn_menu.Text = "Back to Main Menu";
            btn_menu.UseVisualStyleBackColor = true;
            btn_menu.Click += btn_menu_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.grave;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(346, 111);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // Game_Over
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(btn_menu);
            Controls.Add(label1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Game_Over";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "You Lose, lol!";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_menu;
        private PictureBox pictureBox1;
    }
}