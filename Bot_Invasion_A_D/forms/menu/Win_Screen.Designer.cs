namespace Bot_Invasion_A_D.forms.menu
{
    partial class Win_Screen
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 72F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(144, 121);
            label1.Name = "label1";
            label1.Size = new Size(524, 114);
            label1.TabIndex = 0;
            label1.Text = "<VICTORY>";
            // 
            // btn_menu
            // 
            btn_menu.Anchor = AnchorStyles.None;
            btn_menu.Location = new Point(287, 261);
            btn_menu.Name = "btn_menu";
            btn_menu.Size = new Size(254, 42);
            btn_menu.TabIndex = 1;
            btn_menu.Text = "Back to Main Menu";
            btn_menu.UseVisualStyleBackColor = true;
            btn_menu.Click += btn_menu_Click;
            // 
            // Win_Screen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btn_menu);
            Controls.Add(label1);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "Win_Screen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "You Win!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_menu;
    }
}