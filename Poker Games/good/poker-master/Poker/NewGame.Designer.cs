namespace Poker
{
    partial class NewGame
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudInitStack = new System.Windows.Forms.NumericUpDown();
            this.buttonNewGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInitStack)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
			this.label2.Text = "Seu Nome:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(78, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(114, 20);
            this.tbName.TabIndex = 3;
			this.tbName.Text = "Jogador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
			this.label3.Text = "Pilha Inicial:";
            // 
            // nudInitStack
            // 
            this.nudInitStack.Location = new System.Drawing.Point(111, 69);
            this.nudInitStack.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudInitStack.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudInitStack.Name = "nudInitStack";
            this.nudInitStack.Size = new System.Drawing.Size(81, 20);
            this.nudInitStack.TabIndex = 5;
            this.nudInitStack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudInitStack.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(40, 107);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(126, 32);
            this.buttonNewGame.TabIndex = 6;
			this.buttonNewGame.Text = "Comece o Jogo!";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // NewGame
            // 
            this.AcceptButton = this.buttonNewGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 152);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.nudInitStack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Game";
            ((System.ComponentModel.ISupportInitialize)(this.nudInitStack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNewGame;
        public System.Windows.Forms.TextBox tbName;
        public System.Windows.Forms.NumericUpDown nudInitStack;
    }
}