namespace poker
{
    partial class ChronoCtr
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNextStruct = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCurrentStruct = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNextStruct
            // 
            this.labelNextStruct.AutoSize = true;
            this.labelNextStruct.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNextStruct.Location = new System.Drawing.Point(3, 10);
            this.labelNextStruct.Name = "labelNextStruct";
            this.labelNextStruct.Size = new System.Drawing.Size(0, 16);
            this.labelNextStruct.TabIndex = 0;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelTime.Location = new System.Drawing.Point(85, 10);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(53, 25);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "60 s";
            // 
            // labelCurrentStruct
            // 
            this.labelCurrentStruct.AutoSize = true;
            this.labelCurrentStruct.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentStruct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCurrentStruct.Location = new System.Drawing.Point(6, 35);
            this.labelCurrentStruct.Name = "labelCurrentStruct";
            this.labelCurrentStruct.Size = new System.Drawing.Size(147, 15);
            this.labelCurrentStruct.TabIndex = 2;
            this.labelCurrentStruct.Text = "Current Struct";
            // 
            // ChronoCtr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCurrentStruct);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelNextStruct);
            this.Name = "ChronoCtr";
            this.Size = new System.Drawing.Size(296, 90);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNextStruct;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelCurrentStruct;
    }
}
