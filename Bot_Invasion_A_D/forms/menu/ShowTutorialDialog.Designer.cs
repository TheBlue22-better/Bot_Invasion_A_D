namespace Bot_Invasion_A_D.forms.menu
{
    partial class ShowTutorialDialog
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
            btn_yes = new Button();
            btn_no = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.MaximumSize = new Size(396, 37);
            label1.MinimumSize = new Size(396, 37);
            label1.Name = "label1";
            label1.Size = new Size(396, 37);
            label1.TabIndex = 0;
            label1.Text = "Do you want to see the tutorial?";
            // 
            // btn_yes
            // 
            btn_yes.Location = new Point(60, 79);
            btn_yes.Name = "btn_yes";
            btn_yes.Size = new Size(102, 29);
            btn_yes.TabIndex = 1;
            btn_yes.Text = "YES";
            btn_yes.UseVisualStyleBackColor = true;
            btn_yes.Click += btn_yes_Click;
            // 
            // btn_no
            // 
            btn_no.Location = new Point(246, 79);
            btn_no.Name = "btn_no";
            btn_no.Size = new Size(102, 29);
            btn_no.TabIndex = 2;
            btn_no.Text = "NO";
            btn_no.UseVisualStyleBackColor = true;
            btn_no.Click += btn_no_Click;
            // 
            // ShowTutorialDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 147);
            ControlBox = false;
            Controls.Add(btn_no);
            Controls.Add(btn_yes);
            Controls.Add(label1);
            MaximumSize = new Size(450, 186);
            MinimumSize = new Size(450, 186);
            Name = "ShowTutorialDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "First Time?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btn_yes;
        private Button btn_no;
    }
}