
using System.Windows.Forms;

namespace Asteroids
{
    partial class Asteroids_Game
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.One1 = new System.Windows.Forms.Label();
            this.Zero1 = new System.Windows.Forms.Label();
            this.Zero2 = new System.Windows.Forms.Label();
            this.One2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.theTick);
            // 
            // One1
            // 
            this.One1.AutoSize = true;
            this.One1.BackColor = System.Drawing.Color.Transparent;
            this.One1.Enabled = false;
            this.One1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.One1.ForeColor = System.Drawing.Color.White;
            this.One1.Location = new System.Drawing.Point(642, 261);
            this.One1.Name = "One1";
            this.One1.Size = new System.Drawing.Size(49, 50);
            this.One1.TabIndex = 0;
            this.One1.Text = "w";
            this.One1.Visible = false;
            // 
            // Zero1
            // 
            this.Zero1.AutoSize = true;
            this.Zero1.BackColor = System.Drawing.Color.Transparent;
            this.Zero1.Enabled = false;
            this.Zero1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Zero1.ForeColor = System.Drawing.Color.White;
            this.Zero1.Location = new System.Drawing.Point(642, 109);
            this.Zero1.Name = "Zero1";
            this.Zero1.Size = new System.Drawing.Size(49, 50);
            this.Zero1.TabIndex = 1;
            this.Zero1.Text = "w";
            this.Zero1.Visible = false;
            // 
            // Zero2
            // 
            this.Zero2.AutoSize = true;
            this.Zero2.BackColor = System.Drawing.Color.Transparent;
            this.Zero2.Enabled = false;
            this.Zero2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Zero2.ForeColor = System.Drawing.Color.White;
            this.Zero2.Location = new System.Drawing.Point(395, 261);
            this.Zero2.Name = "Zero2";
            this.Zero2.Size = new System.Drawing.Size(49, 50);
            this.Zero2.TabIndex = 2;
            this.Zero2.Text = "w";
            this.Zero2.Visible = false;
            // 
            // One2
            // 
            this.One2.AutoSize = true;
            this.One2.BackColor = System.Drawing.Color.Transparent;
            this.One2.Enabled = false;
            this.One2.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.One2.ForeColor = System.Drawing.Color.White;
            this.One2.Location = new System.Drawing.Point(1029, 261);
            this.One2.Name = "One2";
            this.One2.Size = new System.Drawing.Size(49, 50);
            this.One2.TabIndex = 3;
            this.One2.Text = "w";
            this.One2.Visible = false;
            // 
            // Asteroids_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 517);
            this.Controls.Add(this.One2);
            this.Controls.Add(this.Zero2);
            this.Controls.Add(this.Zero1);
            this.Controls.Add(this.One1);
            this.Location = new System.Drawing.Point(200, 200);
            this.Name = "Asteroids_Game";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Asteroids_Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Asteroids_Game_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer timer1;
        private Label One1;
        private Label Zero1;
        private Label Zero2;
        private Label One2;
    }
}

