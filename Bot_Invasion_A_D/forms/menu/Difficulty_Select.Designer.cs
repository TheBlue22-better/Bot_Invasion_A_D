namespace Bot_Invasion_A_D.forms.menu
{
    partial class Difficulty_Select
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_easy = new System.Windows.Forms.Button();
            this.btn_medium = new System.Windows.Forms.Button();
            this.btn_hard = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select the difficulty";
            // 
            // btn_easy
            // 
            this.btn_easy.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_easy.Location = new System.Drawing.Point(56, 136);
            this.btn_easy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_easy.Name = "btn_easy";
            this.btn_easy.Size = new System.Drawing.Size(131, 56);
            this.btn_easy.TabIndex = 1;
            this.btn_easy.Text = "EASY";
            this.btn_easy.UseVisualStyleBackColor = true;
            this.btn_easy.Click += new System.EventHandler(this.btn_easy_Click);
            // 
            // btn_medium
            // 
            this.btn_medium.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_medium.Location = new System.Drawing.Point(284, 136);
            this.btn_medium.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_medium.Name = "btn_medium";
            this.btn_medium.Size = new System.Drawing.Size(131, 56);
            this.btn_medium.TabIndex = 2;
            this.btn_medium.Text = "MEDIUM";
            this.btn_medium.UseVisualStyleBackColor = true;
            this.btn_medium.Click += new System.EventHandler(this.btn_medium_Click);
            // 
            // btn_hard
            // 
            this.btn_hard.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_hard.Location = new System.Drawing.Point(514, 136);
            this.btn_hard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_hard.Name = "btn_hard";
            this.btn_hard.Size = new System.Drawing.Size(131, 56);
            this.btn_hard.TabIndex = 3;
            this.btn_hard.Text = "HARD";
            this.btn_hard.UseVisualStyleBackColor = true;
            this.btn_hard.Click += new System.EventHandler(this.btn_hard_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(588, 307);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(102, 22);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 45);
            this.label2.TabIndex = 5;
            this.label2.Text = "Smaller Map\r\nLess Enemies\r\nNerfed Boss";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "Default Map\r\nRegular enemies\r\nBalanced Boss";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 75);
            this.label4.TabIndex = 7;
            this.label4.Text = "Large Map\r\nStronger enemies\r\nMore enemies\r\nOverpowered Boss\r\nGood luck!";
            // 
            // Difficulty_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_hard);
            this.Controls.Add(this.btn_medium);
            this.Controls.Add(this.btn_easy);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Difficulty_Select";
            this.Text = "Calm before the storm...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_easy;
        private Button btn_medium;
        private Button btn_hard;
        private Button btn_exit;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}