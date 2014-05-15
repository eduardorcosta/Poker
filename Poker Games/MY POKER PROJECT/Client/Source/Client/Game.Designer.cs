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
            this.Community0 = new System.Windows.Forms.PictureBox();
            this.Community1 = new System.Windows.Forms.PictureBox();
            this.Community2 = new System.Windows.Forms.PictureBox();
            this.Community3 = new System.Windows.Forms.PictureBox();
            this.Community4 = new System.Windows.Forms.PictureBox();
            this.Pot = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.controlPanel1 = new PokerGame.ControlPanel();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Community4)).BeginInit();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            
            this.mainCanvas.Size = new System.Drawing.Size(791, 592);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.TabIndex = 9;
            this.mainCanvas.TabStop = false;
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
            // controlPanel1
            // 
            this.controlPanel1.Location = new System.Drawing.Point(400,425);
            this.controlPanel1.Name = "controlPanel1";
            //this.controlPanel1.Size = new System.Drawing.Size(150, 150);
            this.controlPanel1.TabIndex = 14;
            //this.controlPanel1.BackgroundImage = global::PokerGame.Properties.Resources.face;
            this.controlPanel1.Size = global::PokerGame.Properties.Resources.face.Size;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 594);
            this.Controls.Add(this.controlPanel1);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Community0);
            this.Controls.Add(this.Community4);
            this.Controls.Add(this.Community3);
            this.Controls.Add(this.Community2);
            this.Controls.Add(this.Community1);
            this.Controls.Add(this.Pot);
            this.Controls.Add(this.mainCanvas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.Text = "Table";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.TableClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
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
        
        public System.Windows.Forms.Label Pot;
        public System.Windows.Forms.RichTextBox Log;

        public System.Windows.Forms.PictureBox mainCanvas;
        private ControlPanel controlPanel1;
    }
}