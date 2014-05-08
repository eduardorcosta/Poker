namespace Poker
{
    partial class Stats
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
            this.labelF = new System.Windows.Forms.Label();
            this.labelС = new System.Windows.Forms.Label();
            this.labelH = new System.Windows.Forms.Label();
            this.labelW = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelFolds = new System.Windows.Forms.Label();
            this.labelRaises = new System.Windows.Forms.Label();
            this.labelHands = new System.Windows.Forms.Label();
            this.labelWins = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelF.Location = new System.Drawing.Point(12, 9);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(75, 16);
            this.labelF.TabIndex = 0;
			this.labelF.Text = "Descargas:";
            // 
            // labelС
            // 
            this.labelС.AutoSize = true;
            this.labelС.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelС.Location = new System.Drawing.Point(12, 46);
            this.labelС.Name = "labelС";
            this.labelС.Size = new System.Drawing.Size(90, 16);
            this.labelС.TabIndex = 1;
			this.labelС.Text = "PodeMov:";
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelH.Location = new System.Drawing.Point(12, 84);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(175, 16);
            this.labelH.TabIndex = 2;
			this.labelH.Text = "Total de distribuições jogados:";
            // 
            // labelW
            // 
            this.labelW.AutoSize = true;
            this.labelW.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelW.Location = new System.Drawing.Point(12, 125);
            this.labelW.Name = "labelW";
            this.labelW.Size = new System.Drawing.Size(60, 16);
            this.labelW.TabIndex = 3;
			this.labelW.Text = "relacao:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(51, 173);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(143, 35);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelFolds
            // 
            this.labelFolds.AutoSize = true;
            this.labelFolds.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFolds.Location = new System.Drawing.Point(200, 14);
            this.labelFolds.Name = "labelFolds";
            this.labelFolds.Size = new System.Drawing.Size(0, 18);
            this.labelFolds.TabIndex = 5;
            // 
            // labelRaises
            // 
            this.labelRaises.AutoSize = true;
            this.labelRaises.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRaises.Location = new System.Drawing.Point(200, 51);
            this.labelRaises.Name = "labelRaises";
            this.labelRaises.Size = new System.Drawing.Size(0, 18);
            this.labelRaises.TabIndex = 6;
            // 
            // labelHands
            // 
            this.labelHands.AutoSize = true;
            this.labelHands.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHands.Location = new System.Drawing.Point(200, 84);
            this.labelHands.Name = "labelHands";
            this.labelHands.Size = new System.Drawing.Size(0, 18);
            this.labelHands.TabIndex = 7;
            // 
            // labelWins
            // 
            this.labelWins.AutoSize = true;
            this.labelWins.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWins.Location = new System.Drawing.Point(200, 125);
            this.labelWins.Name = "labelWins";
            this.labelWins.Size = new System.Drawing.Size(0, 18);
            this.labelWins.TabIndex = 8;
            // 
            // Stats
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 220);
            this.Controls.Add(this.labelWins);
            this.Controls.Add(this.labelHands);
            this.Controls.Add(this.labelRaises);
            this.Controls.Add(this.labelFolds);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelW);
            this.Controls.Add(this.labelH);
            this.Controls.Add(this.labelС);
            this.Controls.Add(this.labelF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Estatisticas dos Jogos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelС;
        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelW;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.Label labelFolds;
        public System.Windows.Forms.Label labelRaises;
        public System.Windows.Forms.Label labelHands;
        public System.Windows.Forms.Label labelWins;
    }
}