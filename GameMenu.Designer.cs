
namespace Asteroids
{
    partial class GameMenu
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GamemodeBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Stencil", 43.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(178, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 88);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASTEROIDS";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(328, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gamemode:";
            // 
            // GamemodeBox
            // 
            this.GamemodeBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.GamemodeBox.FormattingEnabled = true;
            this.GamemodeBox.Items.AddRange(new object[] {
            "Binary Conversions",
            "Binary Calculations",
            "Hexadecimal Conversions",
            "Hexadecimal Calculations",
            "Octal Conversions",
            "Octal Calculations",
            "Fun (Non-Educational)"});
            this.GamemodeBox.Location = new System.Drawing.Point(233, 222);
            this.GamemodeBox.Name = "GamemodeBox";
            this.GamemodeBox.Size = new System.Drawing.Size(322, 28);
            this.GamemodeBox.TabIndex = 2;
            this.GamemodeBox.SelectedIndexChanged += new System.EventHandler(this.GamemodeBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Gill Sans MT", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(300, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 88);
            this.button1.TabIndex = 3;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tick
            // 
            this.tick.Interval = 16;
            this.tick.Tick += new System.EventHandler(this.tick_Tick);
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GamemodeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GameMenu";
            this.Text = "GameMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tick;
        public System.Windows.Forms.ComboBox GamemodeBox;
    }
}