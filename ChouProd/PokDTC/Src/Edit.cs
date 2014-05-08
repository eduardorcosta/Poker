/*This file is part of PokDTC developed by Alexandre CHOUVELLON.

PokDTC is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

PokDTC is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with PokDTC; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace poker
{
    /// <summary>
    /// show player profil and avatar
    /// </summary>
    public class Edit : System.Windows.Forms.Form
    {
        private string statut = "";
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;

        private System.ComponentModel.Container components = null;
        private PropertiesGame properties = null;
        /// <summary>
        /// build the summary
        /// </summary>
        /// <param name="st"></param>
        /// <param name="prop">properties to get the name of profile</param>
        public Edit(string st, PropertiesGame prop)
        {

            this.properties = prop;
            InitializeComponent();
            this.textBox1.Text = "";
            statut = st;
            this.Text = st;
            Translation();
        }
        public Edit(string st)
        {
           
            InitializeComponent();
            this.textBox1.Text = "";
            statut = st;
            this.Text = st;
            Translation();
           
        }
        private Form1 mainW;
        public Edit(string st,Profil myprofil,Form1 form)
        {
            
            mainW = form;
            if (myprofil == null)
            {
                MessageBox.Show(mainW,Language.GetPleaseLoadEvents()+"\n");
                return;
            }
            InitializeComponent();
            this.textBox1.Text = "";
            statut = st;
            this.Text = st;
            profile = myprofil;
            if (profile.Avatar != "")
            {
                bmp = new Bitmap(Application.StartupPath + "//Avatars//" + profile.PlayerName + "Avatar.gif");

                this.pictureBox1.Image = bmp;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
           
            avatarPath = profile.Avatar;
            this.textBox1.Text = profile.PlayerName;
            this.statut = "Edit";
            this.Text = "Edit";
 
            Translation();

        }
        /// <summary>
        /// translation
        /// </summary>
        private void Translation()
        {
            this.button1.Text = Language.GetBrowseButton();
            this.button3.Text = Language.GetSaveButton();
            this.button4.Text = Language.GetLoadProfilButton();
            this.button2.Text = Language.GetSaveAndExitButton();
            this.button5.Text = Language.GetExitWithoutSavingButton();
            this.groupBox2.Text = Language.GetAvatarTitle();
            this.groupBox1.Text = Language.GetNameTitle();
            this.groupBox7.Text = Language.GetStatsTitle();
            this.label1.Text = Language.GetGamesPlayedLabel();
            this.label4.Text = Language.GetFlopHandLabel();
            this.label7.Text = Language.GetShowdownsWonLabel();
            this.label6.Text = Language.GetTakedownsLabel();
            this.label2.Text = Language.GetGamesWonLabel();
            this.label5.Text = Language.GetMoneyWonLabel();
            this.label3.Text = Language.GetAllInWonLabel();
            if (profile != null)
            {
                this.label1.Text = Language.GetGamesPlayedLabel() + " " + profile.GamesPlayed;
                this.label2.Text = Language.GetGamesWonLabel() + " " + profile.GamesWon;
                this.label3.Text = Language.GetAllInWonLabel() + " " + profile.AllIn + "/" + profile.AllInWon;
          
                float a = 0;
            if (profile.GamesPlayed != 0)
                a = 100.0f * (float)profile.PayedFlop / (float)profile.GamesPlayed;
            this.label4.Text = Language.GetFlopEvents() +"% "+ (int)a + "%";
            this.label5.Text =  Language.GetMoneyWonLabel() + " "+profile.MoneyWon;
            this.label6.Text = Language.GetTakedownsLabel() + " "  + profile.TakeDowns;
            float b = 0;
            if (profile.GamesWon != 0)
                b = 100.0f * (float)(profile.GamesWon - profile.WonWithoutShow) / (float)profile.GamesWon;
            this.label7.Text = Language.GetShowdownsWonLabel() + " "+profile.Showdowns + "/" + (int)b + "%";
        }
    }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(184, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 224);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avatar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 80);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(16, 376);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 192);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            this.groupBox3.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Location = new System.Drawing.Point(24, 136);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(208, 48);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Aggressivity";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(32, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 20);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "textBox4";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox3);
            this.groupBox5.Location = new System.Drawing.Point(24, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(208, 48);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Bluff";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(32, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "textBox3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Location = new System.Drawing.Point(24, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 48);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Intelligence";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(32, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "textBox2";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(688, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 56);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save and Exit";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(688, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "Save";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(688, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(88, 32);
            this.button4.TabIndex = 6;
            this.button4.Text = "Load Profil";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(184, 72);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(488, 152);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Stats";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Flop/Hand => 0";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Showdowns/Won => 0";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Takedowns => 0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(248, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Money Won => 0";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(248, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "All In/Won => 0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Games Won => 0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Games Played => 0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(688, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 48);
            this.button5.TabIndex = 8;
            this.button5.Text = "Exit without saving";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(792, 246);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Edit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        /// <summary>
        /// choose avatar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            
            this.openFileDialog1.InitialDirectory = Application.StartupPath + "//Avatars";
            this.openFileDialog1.Title = "Choose your avatar";
            this.openFileDialog1.DefaultExt = "jpg";
            //this.openFileDialog1.Filter="JPEG (*.jpg)|*.jpg|gif (*.gif)|*.gif|png (*.png)|*.png|bitmap (*.bmp)|*.bmp";
            this.openFileDialog1.Filter = "gif (*.gif)|*.gif";

            this.openFileDialog1.FilterIndex = 1;
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                if (this.bmp != null)
                {
                    bmp.Dispose();
                }
                bmp = new Bitmap(this.openFileDialog1.FileName);
                string file = this.openFileDialog1.FileName;
                char[] sep = new char[1];
                sep[0] = '\\';
                string[] obj = file.Split(sep);
                avatarPath = obj[obj.Length - 1].Remove(obj[obj.Length - 1].Length - 4, 4);
                this.pictureBox1.Image = bmp;
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }

          
        }
        /// <summary>
        /// create profile and save to disk
        /// </summary>
        private void CreateProfil()
        {
            if (this.Text.CompareTo("Create") == 0)
            {
                Profil profile = new Profil(this.textBox1.Text);
                profile.PlayerName = this.textBox1.Text;
                if (this.bmp != null)
                    profile.Avatar = profile.PlayerName + "Avatar.gif";
                else
                    profile.Avatar = "";

                profile.Save();
            }

            if (this.mainW != null)
            {
                this.mainW.Dispatcher.Profil.Avatar = avatarPath;
                this.mainW.ShowPicture();
            }
        }
        /// <summary>
        /// save and exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, System.EventArgs e)
        {
            
                button3_Click(sender, e);
                if(properties!=null)
                properties.AddCombo3();
          
           
            this.Hide();
        }
        /// <summary>
        /// save 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)//save
        {
            if (statut.CompareTo("Create") == 0)
            {

                CreateProfil();
                if (bmp != null)
                {//faut tester si l'image n'existe pas déjà
                    MessageBox.Show(mainW,Language.GetAvatarCopyBox());
                    if(File.Exists(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif"))
                        File.Delete(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif");
                    //bmp.Save(@"c:\kjbkj.gif",System.Drawing.Imaging.ImageFormat.Gif);
                    bmp.Save(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif", System.Drawing.Imaging.ImageFormat.Gif);

                }


            }
            if (statut.CompareTo("Edit") == 0)
            {
                profile.PlayerName = this.textBox1.Text;
                avatarPath = Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif";
                profile.Avatar = avatarPath;
                profile.Save();
                if (bmp != null)
                {//faut tester si l'image n'existe pas déjà
                   
                    
                    
                    MessageBox.Show(mainW, Language.GetAvatarCopyBox());
                    try
                    {
                        avatarPath = Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif";
                    if (File.Exists(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif"))
                        File.Delete(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif");
                    
                        bmp.Save(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif", System.Drawing.Imaging.ImageFormat.Gif);
                       
                    }
                    catch(Exception ex) {
                      //  MessageBox.Show("Process has failed creating avatar");
                        bmp.Save(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar2.gif", System.Drawing.Imaging.ImageFormat.Gif);
                        bmp.Dispose();
                        this.mainW.DisposeAvatar();
                        this.pictureBox1.Image.Dispose();
                        if (File.Exists(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif"))
                            File.Delete(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar.gif");
                      File.Move(Application.StartupPath + "//Avatars//" + this.textBox1.Text + "Avatar2.gif",avatarPath);
                    
                    
                    
                    }
                    }
            }
            if (this.mainW != null)
            {
                this.mainW.Dispatcher.Profil.Avatar = avatarPath;
                this.mainW.ShowPicture();
            }
        }
        /// <summary>
        /// load profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, System.EventArgs e)//load
        {
            
            this.openFileDialog1.InitialDirectory = Application.StartupPath + "//Profils";
            this.openFileDialog1.Title = "Choose a profil to load";
            this.openFileDialog1.DefaultExt = "pok";
            this.openFileDialog1.Filter = "PokDTC Profils (*.pok)|*.pok";
            this.openFileDialog1.FilterIndex = 1;
            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string file = this.openFileDialog1.FileName;
                char[] sep = new char[1];
                sep[0] = '\\';
                string[] obj = file.Split(sep);
                profile = new Profil();
                profile.Load(obj[obj.Length - 1].Remove(obj[obj.Length - 1].Length - 4, 4));
                if (profile.Avatar != "")
                {
                    bmp = new Bitmap(Application.StartupPath + "//Avatars//" + profile.PlayerName + "Avatar.gif");

                    this.pictureBox1.Image = bmp;
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                avatarPath = profile.Avatar;
                this.textBox1.Text = profile.PlayerName;
                this.statut = "Edit";
                this.Text = "Edit";
                this.label1.Text = "Games played => " + profile.GamesPlayed;
                this.label2.Text = "Games Won => " + profile.GamesWon;
                this.label3.Text = "AllIns/Won => " + profile.AllIn + "/" + profile.AllInWon;
                float a = 0;
                if (profile.GamesPlayed != 0)
                    a = 100.0f * (float)profile.PayedFlop / (float)profile.GamesPlayed;
                this.label4.Text = "Flop played => " + (int)a +"%";
                this.label5.Text = "Money Won => " + profile.MoneyWon;
                this.label6.Text = "Takedowns => " + profile.TakeDowns;
                float b = 0;
                if (profile.GamesWon != 0)
                    b = 100.0f * (float)(profile.GamesWon - profile.WonWithoutShow) /(float)profile.GamesWon ;
                this.label7.Text = "Showdowns/Won => " + profile.Showdowns + "/" + (int)b +"%";

            }



        }
        private string avatarPath;
        private Bitmap bmp;
        private Profil profile;

        private void Edit_Load(object sender, System.EventArgs e)
        {

        }
        /// <summary>
        /// exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, System.EventArgs e)
        {
          
            this.Hide();
        }
    }
}
