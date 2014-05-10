namespace Poker_Cards
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titleLabel = new System.Windows.Forms.Label();
            this.aceSpadesBox = new System.Windows.Forms.PictureBox();
            this.queenHeartsBox = new System.Windows.Forms.PictureBox();
            this.blackJokerBox = new System.Windows.Forms.PictureBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.tenClubsBox = new System.Windows.Forms.PictureBox();
            this.threeDiamondsBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aceSpadesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queenHeartsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackJokerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenClubsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDiamondsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 19);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(260, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Click a card below to display it\'s name";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aceSpadesBox
            // 
            this.aceSpadesBox.Image = ((System.Drawing.Image)(resources.GetObject("aceSpadesBox.Image")));
            this.aceSpadesBox.Location = new System.Drawing.Point(6, 62);
            this.aceSpadesBox.Name = "aceSpadesBox";
            this.aceSpadesBox.Size = new System.Drawing.Size(50, 70);
            this.aceSpadesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.aceSpadesBox.TabIndex = 1;
            this.aceSpadesBox.TabStop = false;
            this.aceSpadesBox.Click += new System.EventHandler(this.aceSpadesBox_Click);
            // 
            // queenHeartsBox
            // 
            this.queenHeartsBox.Image = ((System.Drawing.Image)(resources.GetObject("queenHeartsBox.Image")));
            this.queenHeartsBox.Location = new System.Drawing.Point(118, 62);
            this.queenHeartsBox.Name = "queenHeartsBox";
            this.queenHeartsBox.Size = new System.Drawing.Size(50, 70);
            this.queenHeartsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.queenHeartsBox.TabIndex = 2;
            this.queenHeartsBox.TabStop = false;
            this.queenHeartsBox.Click += new System.EventHandler(this.queenHeartsBox_Click);
            // 
            // blackJokerBox
            // 
            this.blackJokerBox.Image = ((System.Drawing.Image)(resources.GetObject("blackJokerBox.Image")));
            this.blackJokerBox.Location = new System.Drawing.Point(230, 62);
            this.blackJokerBox.Name = "blackJokerBox";
            this.blackJokerBox.Size = new System.Drawing.Size(50, 70);
            this.blackJokerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.blackJokerBox.TabIndex = 3;
            this.blackJokerBox.TabStop = false;
            this.blackJokerBox.Click += new System.EventHandler(this.blackJokerBox_Click);
            // 
            // answerLabel
            // 
            this.answerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerLabel.Location = new System.Drawing.Point(47, 161);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(190, 40);
            this.answerLabel.TabIndex = 4;
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tenClubsBox
            // 
            this.tenClubsBox.Image = ((System.Drawing.Image)(resources.GetObject("tenClubsBox.Image")));
            this.tenClubsBox.Location = new System.Drawing.Point(62, 62);
            this.tenClubsBox.Name = "tenClubsBox";
            this.tenClubsBox.Size = new System.Drawing.Size(50, 70);
            this.tenClubsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.tenClubsBox.TabIndex = 5;
            this.tenClubsBox.TabStop = false;
            this.tenClubsBox.Click += new System.EventHandler(this.tenClubsBox_Click);
            // 
            // threeDiamondsBox
            // 
            this.threeDiamondsBox.Image = ((System.Drawing.Image)(resources.GetObject("threeDiamondsBox.Image")));
            this.threeDiamondsBox.Location = new System.Drawing.Point(174, 62);
            this.threeDiamondsBox.Name = "threeDiamondsBox";
            this.threeDiamondsBox.Size = new System.Drawing.Size(50, 70);
            this.threeDiamondsBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.threeDiamondsBox.TabIndex = 6;
            this.threeDiamondsBox.TabStop = false;
            this.threeDiamondsBox.Click += new System.EventHandler(this.threeDiamondsBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "By: Kyle McBride A02609917 for IS 107 602";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.threeDiamondsBox);
            this.Controls.Add(this.tenClubsBox);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.blackJokerBox);
            this.Controls.Add(this.queenHeartsBox);
            this.Controls.Add(this.aceSpadesBox);
            this.Controls.Add(this.titleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Card Identifier";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aceSpadesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queenHeartsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackJokerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenClubsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDiamondsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox aceSpadesBox;
        private System.Windows.Forms.PictureBox queenHeartsBox;
        private System.Windows.Forms.PictureBox blackJokerBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.PictureBox tenClubsBox;
        private System.Windows.Forms.PictureBox threeDiamondsBox;
        private System.Windows.Forms.Label label1;
    }
}

