using System.Drawing;
using System.Windows.Forms;


namespace PokerGame
{
    partial class Game
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
            this.mainCanvas = new System.Windows.Forms.PictureBox();
            this.controlerCanvas = new System.Windows.Forms.PictureBox();
            this.Community0 = new System.Windows.Forms.PictureBox();
            this.Community1 = new System.Windows.Forms.PictureBox();
            this.Community2 = new System.Windows.Forms.PictureBox();
            this.Community3 = new System.Windows.Forms.PictureBox();
            this.Community4 = new System.Windows.Forms.PictureBox();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Pot = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlerCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community4)).BeginInit();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            this.mainCanvas.BackColor = System.Drawing.Color.Silver;
            this.mainCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.mainCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainCanvas.InitialImage = null;
            this.mainCanvas.Location = new System.Drawing.Point(0, 0);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(792, 594);
            this.mainCanvas.TabIndex = 9;
            this.mainCanvas.TabStop = false;
            // 
            // controlerCanvas
            // 
            this.controlerCanvas.BackColor = System.Drawing.Color.Transparent;
            this.controlerCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlerCanvas.InitialImage = null;
            this.controlerCanvas.Location = new System.Drawing.Point(400, 427);
            this.controlerCanvas.Name = "controlerCanvas";
            this.controlerCanvas.Size = new System.Drawing.Size(327, 114);
            this.controlerCanvas.TabIndex = 0;
            this.controlerCanvas.TabStop = false;
            // 
            // Community0
            // 
            this.Community0.BackColor = System.Drawing.Color.Transparent;
            this.Community0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Community0.Location = new System.Drawing.Point(236, 195);
            this.Community0.Name = "Community0";
            this.Community0.Size = new System.Drawing.Size(61, 71);
            this.Community0.TabIndex = 12;
            this.Community0.TabStop = false;
            this.Community0.Visible = false;
            // 
            // Community1
            // 
            this.Community1.BackColor = System.Drawing.Color.Transparent;
            this.Community1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Community1.Location = new System.Drawing.Point(302, 195);
            this.Community1.Name = "Community1";
            this.Community1.Size = new System.Drawing.Size(61, 71);
            this.Community1.TabIndex = 11;
            this.Community1.TabStop = false;
            this.Community1.Visible = false;
            // 
            // Community2
            // 
            this.Community2.BackColor = System.Drawing.Color.Transparent;
            this.Community2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Community2.Location = new System.Drawing.Point(368, 195);
            this.Community2.Name = "Community2";
            this.Community2.Size = new System.Drawing.Size(61, 71);
            this.Community2.TabIndex = 10;
            this.Community2.TabStop = false;
            this.Community2.Visible = false;
            // 
            // Community3
            // 
            this.Community3.BackColor = System.Drawing.Color.Transparent;
            this.Community3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Community3.Location = new System.Drawing.Point(434, 195);
            this.Community3.Name = "Community3";
            this.Community3.Size = new System.Drawing.Size(61, 71);
            this.Community3.TabIndex = 9;
            this.Community3.TabStop = false;
            this.Community3.Visible = false;
            // 
            // Community4
            // 
            this.Community4.BackColor = System.Drawing.Color.Transparent;
            this.Community4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Community4.Location = new System.Drawing.Point(500, 195);
            this.Community4.Name = "Community4";
            this.Community4.Size = new System.Drawing.Size(61, 71);
            this.Community4.TabIndex = 8;
            this.Community4.TabStop = false;
            this.Community4.Visible = false;
            // 
            // button0
            // 
            this.button0.FlatAppearance.BorderSize = 0;
            this.button0.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button0.Location = new System.Drawing.Point(109, 75);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(19, 21);
            this.button0.TabIndex = 1;
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(144, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 21);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(179, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 21);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(214, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 21);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(249, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 21);
            this.button4.TabIndex = 5;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(284, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(19, 21);
            this.button5.TabIndex = 6;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Pot
            // 
            this.Pot.AutoSize = true;
            this.Pot.BackColor = System.Drawing.Color.Transparent;
            this.Pot.ForeColor = System.Drawing.Color.White;
            this.Pot.Location = new System.Drawing.Point(363, 121);
            this.Pot.Name = "Pot";
            this.Pot.Size = new System.Drawing.Size(13, 13);
            this.Pot.TabIndex = 7;
            this.Pot.Text = "0";
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.LightGray;
            this.Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Log.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Log.Location = new System.Drawing.Point(12, 483);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(368, 61);
            this.Log.TabIndex = 13;
            this.Log.TabStop = false;
            this.Log.Text = "";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(792, 594);
            this.Controls.Add(this.Community0);
            this.Controls.Add(this.Community2);
            this.Controls.Add(this.Community1);
            this.Controls.Add(this.Community3);
            this.Controls.Add(this.Community4);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Pot);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.mainCanvas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Table";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TableClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.controlerCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox Community0;
        public System.Windows.Forms.PictureBox Community1;
        public System.Windows.Forms.PictureBox Community2;
        public System.Windows.Forms.PictureBox Community3;
        public System.Windows.Forms.PictureBox Community4;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        
        public System.Windows.Forms.Label Pot;
        public System.Windows.Forms.RichTextBox Log;
        //private ControlPanel controlPanel1;
        private PictureBox mainCanvas;
        private PictureBox controlerCanvas;
    }
}