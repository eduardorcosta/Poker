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
using System.IO;
using System.Drawing;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace poker
{
    /// <summary>
    /// Allow editing gamedata
    /// </summary>
    public class PropertiesGame : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private GroupBox groupBox9;
        private Label label1;
        private Label labelAggr;
        private GroupBox groupBox10;
        private Label labelHardcore;
        private Label label2;
        private Label label3;
        private GroupBox groupBoxTime2Mind;
        private TextBox textBoxTime2Mind;
        private GroupBox groupBox11;
        private CheckBox checkBoxIncreaseBlind;
        private DataGridView dataGridView1;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTableBlinds;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private TextBox textBoxTimeBLinds;
        private Button buttonAddRow;
        private DataGridViewTextBoxColumn ColumnAnte;
        private DataGridViewTextBoxColumn ColumnSB;
        private DataGridViewTextBoxColumn ColumnBB;
        private Label label4;
        private Button buttonLoadBlinds;
        private Button buttonSaveBlinds;
        private IContainer components;

        public PropertiesGame(Dispatcher dis, bool launch)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            dispatcher = dis;
            this.textBox1.Text = dispatcher.GameData.Name;
            this.textBox2.Text = dispatcher.GameData.SmallBlind.ToString();
            this.textBox3.Text = dispatcher.GameData.Ante.ToString();
            this.textBox4.Text = dispatcher.GameData.Max.ToString();
            this.textBox5.Text = dispatcher.GameData.BigBlind.ToString();
            this.textBox6.Text = dispatcher.GameData.Money.ToString();
            this.comboBox2.SelectedIndex = dispatcher.GameData.Nbr - 2;
            if (dispatcher.GameData.Type == 1)
                this.comboBox1.SelectedIndex = 0;
            if (dispatcher.GameData.Type == 2)
                this.comboBox1.SelectedIndex = 1;
            if (dispatcher.GameData.Type == 3)
                this.comboBox1.SelectedIndex = 2;
            if (launch)
            {

                this.textBox2.Text = dispatcher.GameData.SmallBlind.ToString();
                this.textBox3.Text = dispatcher.GameData.Ante.ToString();
                this.textBox4.Text = dispatcher.GameData.Max.ToString();
                this.textBox5.Text = dispatcher.GameData.BigBlind.ToString();
                this.textBox6.ReadOnly = true;

                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.textBox2.Enabled = false;
                this.textBox3.Enabled = false;
                this.textBox4.Enabled = false;
                this.textBox5.Enabled = false;
                this.textBox6.Enabled = false;
            }
            AddCombo3();

        }

        private void Translation()
        {
            this.Text = Language.GetPropertiesMenu();
            this.groupBox1.Text = Language.GetPlayerProfilTitle();
            this.groupBox4.Text = Language.GetAnteTitle();
            this.groupBox2.Text = Language.GetSBEvents();
            this.groupBox7.Text = Language.GetBBEvents();
            this.groupBox3.Text = Language.GetTypeTitle();
            this.groupBox8.Text = Language.GetStartMoneysTitle();
            this.groupBox6.Text = Language.GetNumberOfPlayersTitle();
            this.groupBox5.Text = Language.GetLimitRaiseTitle();
            this.groupBox10.Text = Language.GetHardcoreModeTitle();
            this.groupBox9.Text = Language.GetAggressiveSurvivalModeTitle();
            this.button2.Text = Language.GetCreateProfilButton();
            this.button1.Text = Language.GetOkButton();
            this.labelHardcore.Text = Language.GetTryToFindTheCheaterLabel();
            this.labelAggr.Text = Language.GetTryLabel();
            this.label1.Text = "";
            this.label2.Text = Language.GetPropAreFixedLabel();
            this.buttonAddRow.Text = Language.GetAddRow();
            this.groupBox11.Text = Language.GetDynamicBlinds();
            this.checkBoxIncreaseBlind.Text = Language.GetActivateDynamicBlinds();
            this.label4.Text = Language.GetTimeBeforeIncreasing();
            this.groupBoxTime2Mind.Text = Language.GetTime2Mind();
            this.toolTip1.ToolTipTitle = Language.GetTryToSurvive();
            this.toolTip2.ToolTipTitle = Language.GetTryToFindTheCheaterLabel();
            this.toolTip1.SetToolTip(this.groupBox9, Language.GetTryLabel());
            this.toolTip1.SetToolTip(this.checkBox2, Language.GetTryLabel());

            this.toolTip2.SetToolTip(this.groupBox10, "\n");
            this.toolTip2.SetToolTip(this.checkBox1, "\n");

        }
        public void AddCombo3()
        {
            int k = 0;
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "//Profils");
            FileInfo[] rgFiles = di.GetFiles("*.pok");
            ArrayList liste = new ArrayList(10);

            foreach (FileInfo fi in rgFiles)
            {
                liste.Add(fi.Name.Remove((int)fi.Name.Length - 4, 4));
            }
            string[] str = new string[liste.Count];
            foreach (string st in liste)
            {
                str[k++] = st;
            }
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(str);
            if (str.Length != 0)
                this.comboBox3.SelectedIndex = 0;

        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesGame));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAggr = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.labelHardcore = new System.Windows.Forms.Label();
            this.groupBoxTime2Mind = new System.Windows.Forms.GroupBox();
            this.textBoxTime2Mind = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTimeBLinds = new System.Windows.Forms.TextBox();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnAnte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxIncreaseBlind = new System.Windows.Forms.CheckBox();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTableBlinds = new System.Data.DataTable();
            this.buttonSaveBlinds = new System.Windows.Forms.Button();
            this.buttonLoadBlinds = new System.Windows.Forms.Button();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBoxTime2Mind.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBlinds)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(24, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player\'s Profil";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(192, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Create a profile";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.Location = new System.Drawing.Point(16, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(160, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Chou";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(487, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 73);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(16, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(110, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(95, 56);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Blind";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "No Limit",
            "Pot Limit",
            "Limit"});
            this.comboBox1.Location = new System.Drawing.Point(16, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(328, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 64);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Type";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(24, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(80, 56);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ante";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(16, 24);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(48, 20);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(329, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(144, 56);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Limit Raise";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(16, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "2";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox2);
            this.groupBox6.Location = new System.Drawing.Point(185, 150);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(127, 48);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Number of Players";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox2.Location = new System.Drawing.Point(13, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(72, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(211, 88);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(101, 56);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "BigBlind";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(8, 24);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 20);
            this.textBox5.TabIndex = 0;
            this.textBox5.Text = "2";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox6);
            this.groupBox8.Location = new System.Drawing.Point(490, 88);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(191, 56);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "StartMoney";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(54, 24);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(72, 20);
            this.textBox6.TabIndex = 0;
            this.textBox6.Text = "200";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(16, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(139, 20);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Hardcore Mode ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Enter += new System.EventHandler(this.checkBox1_Enter);
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkBox2.Location = new System.Drawing.Point(13, 19);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(210, 20);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Aggressive/Survival Mode";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Enter += new System.EventHandler(this.checkBox2_Enter);
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 50;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toolTip2
            // 
            this.toolTip2.AutomaticDelay = 50;
            this.toolTip2.AutoPopDelay = 5000;
            this.toolTip2.InitialDelay = 50;
            this.toolTip2.IsBalloon = true;
            this.toolTip2.ReshowDelay = 10;
            this.toolTip2.ShowAlways = true;
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Try to avoid the cheater AI";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.labelAggr);
            this.groupBox9.Controls.Add(this.checkBox2);
            this.groupBox9.Location = new System.Drawing.Point(24, 204);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(288, 54);
            this.groupBox9.TabIndex = 13;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Aggressive/Survival Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Generate files for Web High Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Properties are fixed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "the maximum of takedowns";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelAggr
            // 
            this.labelAggr.AutoSize = true;
            this.labelAggr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAggr.Location = new System.Drawing.Point(6, 93);
            this.labelAggr.Name = "labelAggr";
            this.labelAggr.Size = new System.Drawing.Size(171, 16);
            this.labelAggr.TabIndex = 13;
            this.labelAggr.Text = "Try to survive and to realize";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.labelHardcore);
            this.groupBox10.Controls.Add(this.checkBox1);
            this.groupBox10.Location = new System.Drawing.Point(24, 275);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(288, 38);
            this.groupBox10.TabIndex = 14;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Hardcore Mode";
            // 
            // labelHardcore
            // 
            this.labelHardcore.AutoSize = true;
            this.labelHardcore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHardcore.Location = new System.Drawing.Point(20, 42);
            this.labelHardcore.Name = "labelHardcore";
            this.labelHardcore.Size = new System.Drawing.Size(135, 16);
            this.labelHardcore.TabIndex = 12;
            this.labelHardcore.Text = "Try to find the cheater";
            this.labelHardcore.Click += new System.EventHandler(this.labelHardcore_Click);
            // 
            // groupBoxTime2Mind
            // 
            this.groupBoxTime2Mind.Controls.Add(this.textBoxTime2Mind);
            this.groupBoxTime2Mind.Location = new System.Drawing.Point(24, 150);
            this.groupBoxTime2Mind.Name = "groupBoxTime2Mind";
            this.groupBoxTime2Mind.Size = new System.Drawing.Size(155, 48);
            this.groupBoxTime2Mind.TabIndex = 15;
            this.groupBoxTime2Mind.TabStop = false;
            this.groupBoxTime2Mind.Text = "Time to Think in secondes";
            // 
            // textBoxTime2Mind
            // 
            this.textBoxTime2Mind.Location = new System.Drawing.Point(38, 19);
            this.textBoxTime2Mind.Name = "textBoxTime2Mind";
            this.textBoxTime2Mind.Size = new System.Drawing.Size(100, 20);
            this.textBoxTime2Mind.TabIndex = 0;
            this.textBoxTime2Mind.Text = "60";
            this.textBoxTime2Mind.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTime2Mind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTime2Mind_KeyPress);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.buttonLoadBlinds);
            this.groupBox11.Controls.Add(this.buttonSaveBlinds);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.textBoxTimeBLinds);
            this.groupBox11.Controls.Add(this.buttonAddRow);
            this.groupBox11.Controls.Add(this.dataGridView1);
            this.groupBox11.Controls.Add(this.checkBoxIncreaseBlind);
            this.groupBox11.Location = new System.Drawing.Point(329, 150);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(352, 321);
            this.groupBox11.TabIndex = 16;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Dynamic Blinds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Time before increasing  in minute:\r\n";
            // 
            // textBoxTimeBLinds
            // 
            this.textBoxTimeBLinds.Location = new System.Drawing.Point(215, 36);
            this.textBoxTimeBLinds.Name = "textBoxTimeBLinds";
            this.textBoxTimeBLinds.Size = new System.Drawing.Size(39, 20);
            this.textBoxTimeBLinds.TabIndex = 3;
            this.textBoxTimeBLinds.Text = "15";
            this.textBoxTimeBLinds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTimeBLinds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTimeBLinds_KeyPress);
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAddRow.Location = new System.Drawing.Point(260, 15);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(86, 41);
            this.buttonAddRow.TabIndex = 2;
            this.buttonAddRow.Text = "Add Row";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAnte,
            this.ColumnSB,
            this.ColumnBB});
            this.dataGridView1.DataSource = this.dataSet1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(346, 231);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnAnte
            // 
            this.ColumnAnte.DataPropertyName = "ColumnAnte";
            this.ColumnAnte.HeaderText = "Ante";
            this.ColumnAnte.Name = "ColumnAnte";
            // 
            // ColumnSB
            // 
            this.ColumnSB.DataPropertyName = "ColumnSB";
            this.ColumnSB.HeaderText = "SmallBlind";
            this.ColumnSB.Name = "ColumnSB";
            // 
            // ColumnBB
            // 
            this.ColumnBB.DataPropertyName = "ColumnBB";
            this.ColumnBB.HeaderText = "BigBlind";
            this.ColumnBB.Name = "ColumnBB";
            // 
            // checkBoxIncreaseBlind
            // 
            this.checkBoxIncreaseBlind.AutoSize = true;
            this.checkBoxIncreaseBlind.Checked = true;
            this.checkBoxIncreaseBlind.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIncreaseBlind.Location = new System.Drawing.Point(17, 19);
            this.checkBoxIncreaseBlind.Name = "checkBoxIncreaseBlind";
            this.checkBoxIncreaseBlind.Size = new System.Drawing.Size(137, 17);
            this.checkBoxIncreaseBlind.TabIndex = 0;
            this.checkBoxIncreaseBlind.Text = "Activate dynamic blinds";
            this.checkBoxIncreaseBlind.UseVisualStyleBackColor = true;
            this.checkBoxIncreaseBlind.CheckedChanged += new System.EventHandler(this.checkBoxIncreaseBlind_CheckedChanged);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSetBlinds";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableBlinds});
            // 
            // dataTableBlinds
            // 
            this.dataTableBlinds.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.dataTableBlinds.MinimumCapacity = 1;
            this.dataTableBlinds.TableName = "Table1";
            this.dataTableBlinds.RowChanging += new System.Data.DataRowChangeEventHandler(this.dataTableBlinds_RowChanging);
            // 
            // buttonSaveBlinds
            // 
            this.buttonSaveBlinds.Location = new System.Drawing.Point(190, 58);
            this.buttonSaveBlinds.Name = "buttonSaveBlinds";
            this.buttonSaveBlinds.Size = new System.Drawing.Size(74, 29);
            this.buttonSaveBlinds.TabIndex = 5;
            this.buttonSaveBlinds.Text = "Save";
            this.buttonSaveBlinds.UseVisualStyleBackColor = true;
            this.buttonSaveBlinds.Click += new System.EventHandler(this.buttonSaveBlinds_Click);
            // 
            // buttonLoadBlinds
            // 
            this.buttonLoadBlinds.Location = new System.Drawing.Point(270, 58);
            this.buttonLoadBlinds.Name = "buttonLoadBlinds";
            this.buttonLoadBlinds.Size = new System.Drawing.Size(74, 29);
            this.buttonLoadBlinds.TabIndex = 6;
            this.buttonLoadBlinds.Text = "Load";
            this.buttonLoadBlinds.UseVisualStyleBackColor = true;
            this.buttonLoadBlinds.Click += new System.EventHandler(this.buttonLoadBlinds_Click);
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ColumnAnte";
            this.dataColumn1.DataType = typeof(object);
            this.dataColumn1.DefaultValue = ((ulong)(0ul));
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "ColumnSB";
            this.dataColumn2.DataType = typeof(object);
            this.dataColumn2.DefaultValue = ((ulong)(0ul));
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "ColumnBB";
            this.dataColumn3.DataType = typeof(object);
            this.dataColumn3.DefaultValue = ((ulong)(0ul));
            // 
            // PropertiesGame
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(690, 474);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBoxTime2Mind);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesGame";
            this.Opacity = 0.75;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.Properties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBoxTime2Mind.ResumeLayout(false);
            this.groupBoxTime2Mind.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableBlinds)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {
        }
        private void ChangeName(string old, string newn)
        {

            string msg2 = "{msg " + old + " is now known as " + newn + "\n";
            dispatcher.Form.Chat.AddChat(old + " is now known as " + newn + "\n");
            if (dispatcher.Form.Dispatcher.Communication.IsConnected())
                dispatcher.Form.Dispatcher.Communication.SendToServer(msg2);



            dispatcher.GameData.Name = newn;

        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            string sel;
            CheckAndChangeBlinds();
            BlindsStructure.RealLengthAggrBlinds=BlindsStructure.AggrBlinds.Length /3;

            if (this.dataTableBlinds.Rows.Count == 0)
            {
                this.checkBoxIncreaseBlind.Checked = false;
            }
            if (this.checkBox2.Checked) //aggr mode
            {
                this.textBox3.Text = "0";//ante
                this.textBox5.Text = "2000"; //bb
                this.textBox2.Text = "1000";
                this.textBox4.Text = "4000";
                this.textBox6.Text = "30000";
                this.dispatcher.GameData.AggrMode.AggressiveModeBool = true;
                this.comboBox2.SelectedItem = this.comboBox2.Items[this.comboBox2.Items.Count - 1];

            }
            else {

                this.dispatcher.GameData.AggrMode.AggressiveModeBool = false;
            }
            try
            {
                sel = this.comboBox3.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show(this, Language.GetNoprofilSelectedEvents());
                return;
            }
            dispatcher.Profil = new Profil(sel);
            dispatcher.Profil.Load();
            dispatcher.GameData.HardcoreMode = this.checkBox1.Checked;
            if (dispatcher.GameData.Name.CompareTo(this.textBox1.Text) != 0)
            {
                string name = this.textBox1.Text;
                if (name.Length > 10)
                    name = name.Substring(0, 10);
                ChangeName(dispatcher.GameData.Name, name);
                dispatcher.GameData.Name = name;

            }
            try
            {
                dispatcher.GameData.Nbr = (int)Convert.ToInt32(this.comboBox2.SelectedItem.ToString());
                string type = this.comboBox1.SelectedItem.ToString();
                if (type.CompareTo("Limit") == 0)
                    dispatcher.GameData.Type = 3;
                if (type.CompareTo("No Limit") == 0)
                    dispatcher.GameData.Type = 1;
                if (type.CompareTo("Pot Limit") == 0)
                    dispatcher.GameData.Type = 2;
                if (0 >= (long)Convert.ToInt32(this.textBox5.Text)
                    ||
                    0 >= (long)Convert.ToInt32(this.textBox2.Text)
                    ||
                    0 >= (long)Convert.ToInt32(this.textBox6.Text)
                    ||
                    0 >= (long)Convert.ToInt32(this.textBox4.Text)
                    )
                {

                    MessageBox.Show("Invalid Data");
                    return;
                }
                dispatcher.GameData.Ante = (long)Convert.ToInt32(this.textBox3.Text);
                dispatcher.GameData.BigBlind = (long)Convert.ToInt32(this.textBox5.Text);
                dispatcher.GameData.SmallBlind = (long)Convert.ToInt32(this.textBox2.Text);
                dispatcher.GameData.Max = (long)Convert.ToInt32(this.textBox4.Text);
                dispatcher.GameData.Money = (long)Convert.ToInt32(this.textBox6.Text);
                if (dispatcher.GameData.Ante > dispatcher.GameData.SmallBlind ||
                      dispatcher.GameData.BigBlind < dispatcher.GameData.SmallBlind)
                {
                    MessageBox.Show(this, "Ante < Sb < BB ");
                    return;
                }
                if (this.checkBoxIncreaseBlind.Checked)
                {
                    //save time Round
                    if (this.textBoxTimeBLinds.Text != "")
                        dispatcher.GameData.TimeIncrease = 60 * (int)Convert.ToInt64(this.textBoxTimeBLinds.Text);
                    if (this.checkBox2.Checked)
                    {
                        dispatcher.GameData.TimeIncrease = 300 * 3; //15 min

                    }
                    //save structure
                    SaveBlindsStructurs();
                }
                else
                {
                    dispatcher.GameData.TimeIncrease = -1;

                }
                try
                {
                    if (this.textBoxTime2Mind.Text != "")
                        dispatcher.GameData.Time2Mind = (int)Convert.ToInt64(this.textBoxTime2Mind.Text);

                    if (this.checkBox2.Checked)
                    {
                        dispatcher.GameData.Time2Mind = 60; //time in aggr mode

                    }
                }
                catch { }
                this.Close();
                
            }
            catch
            {

                MessageBox.Show("Invalid Data");
                return;
            }

        }

        private void CheckAndChangeBlinds()
        {
            int i;
            for(i=0;i<dataTableBlinds.Rows.Count;i++)
            {


                if (Convert.ToInt64(dataTableBlinds.Rows[i][1].ToString()) > Convert.ToInt64(dataTableBlinds.Rows[i][2].ToString()))
                {

                    dataTableBlinds.Rows[i][1] = Convert.ToInt64(dataTableBlinds.Rows[i][2].ToString()) /2;
                    MessageBox.Show("correction sb\n");
                }
                if (Convert.ToInt64(dataTableBlinds.Rows[i][0].ToString()) > Convert.ToInt64(dataTableBlinds.Rows[i][1].ToString()))
                {

                    dataTableBlinds.Rows[i][0] = 0;
                    MessageBox.Show("correction ante\n");
                }

            }
        }

        private void SaveBlindsStructurs()
        {
            int length = this.dataGridView1.Rows.Count;
            BlindsStructure.RealLengthBlinds = length;
            BlindsStructure.Blinds = new long[length, 3];
            
            for (int i = 0; i < length ; i++)
            {
                long ante = Convert.ToInt64(this.dataGridView1.Rows[i].Cells[0].Value);
                long smallBlind = Convert.ToInt64(this.dataGridView1.Rows[i].Cells[1].Value);
                long bigBlind = Convert.ToInt64(this.dataGridView1.Rows[i].Cells[2].Value);
                if (ante < smallBlind && smallBlind < bigBlind)
                {

                    BlindsStructure.Blinds[i, 0] = ante;
                    BlindsStructure.Blinds[i, 1] = smallBlind;
                    BlindsStructure.Blinds[i, 2] = bigBlind;
                }
                else
                {
                    if (i > 0)
                    {
                        BlindsStructure.Blinds[i, 0] = BlindsStructure.Blinds[i - 1, 0];
                        BlindsStructure.Blinds[i, 1] = BlindsStructure.Blinds[i - 1, 1];
                        BlindsStructure.Blinds[i, 2] = BlindsStructure.Blinds[i - 1, 2];
                    }
                    else
                    {
                        BlindsStructure.Blinds[0, 0] = 0;
                        BlindsStructure.Blinds[0, 1] = 500;
                        BlindsStructure.Blinds[0, 2] = 1000;

                    }


                }
            }


        }
        public GameData Data
        {

            get { return dispatcher.GameData; }
        }

        private Dispatcher dispatcher;

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.comboBox1.SelectedIndex != 2)
                this.groupBox5.Visible = false;
            else
                this.groupBox5.Visible = true;

        }

        private void Properties_Load(object sender, System.EventArgs e)
        {
            if (this.comboBox3.Items.Count > 1)
                this.comboBox3.SelectedIndex = 1;

            this.dataGridView1.DataSource = this.dataTableBlinds;
            LoadBlindsStructure();

            this.checkBox2.Checked = dispatcher.GameData.AggrMode.AggressiveModeBool;
            Translation();
            this.checkBoxIncreaseBlind.Checked = this.dispatcher.GameData.TimeIncrease != -1;
            this.textBoxTime2Mind.Text = this.dispatcher.GameData.Time2Mind.ToString();
            if (this.checkBoxIncreaseBlind.Checked)
            {
                int itme = (int)this.dispatcher.GameData.TimeIncrease / 60;
                this.textBoxTimeBLinds.Text = itme.ToString();
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            Edit edit = new Edit("Create", this);
            edit.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void checkBox2_Enter(object sender, EventArgs e)
        {
            // this.toolTip1.Show("jkjkhh",null,this.checkBox2.Location.X,this.checkBox2.Location.Y);
        }

        private void checkBox1_Enter(object sender, EventArgs e)
        {
            // this.toolTip2.Show("aaaaaaaaaaa",null,this.checkBox1.Location.X,this.checkBox1.Location.Y);
        }
        private delegate void DelegateForm(Control c);

        private bool enable = true;


        private void EnabledMe(Control c)
        {

            c.Enabled = enable;

        }
        private void EnableMeInvok(Control c)
        {
            try
            {
                c.Invoke(new DelegateForm(EnabledMe), new object[] { c });
            }
            catch { }

        }
        private void EnableChangerBinds()
        {
            EnableMeInvok(this.groupBox5);
            EnableMeInvok(this.groupBox7);
            EnableMeInvok(this.groupBox2);
            EnableMeInvok(this.groupBox4);


        }
        private void EnableChangerAggr()
        {
            EnableMeInvok(this.groupBox6);
            EnableMeInvok(this.groupBox11);
            EnableMeInvok(this.groupBox5);
            EnableMeInvok(this.groupBox7);
            EnableMeInvok(this.groupBox2);
            EnableMeInvok(this.groupBox4);
            EnableMeInvok(this.groupBox8);
            EnableMeInvok(this.groupBox3);
            EnableMeInvok(this.groupBoxTime2Mind);
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.checkBox1.Checked = false;

                enable = false;

                // MessageBox.Show("Properties for survival mode are fixed, it's useless to try to change them");
            }
            else
                enable = true;
            EnableChangerAggr();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.checkBox2.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelHardcore_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxTime2Mind_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBoxTimeBLinds_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (Char.IsControl(c) == false)
                if (Char.IsDigit(c) == false)
                    e.Handled = true;
        }
        private void LoadBlindsStructure()
        {

            this.dataSet1.Tables[0].Clear();
            for (int i = 0; i < BlindsStructure.GetLength(); i++)
            {

                DataRow row = this.dataSet1.Tables[0].NewRow();
                row.ItemArray = new object[] { BlindsStructure.Blinds[i, 0], BlindsStructure.Blinds[i, 1], BlindsStructure.Blinds[i, 2] };
                this.dataSet1.Tables[0].Rows.Add(row);
               // this.dataGridView1.Rows.Add(new object[] { BlindsStructure.Blinds[i, 0], BlindsStructure.Blinds[i, 1], BlindsStructure.Blinds[i, 2] });

            }




        }
        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            this.dataSet1.Tables[0].Rows.Add(new object[] { 0, 0, 0 });
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int colum = e.ColumnIndex;

            if (row < 0 || colum < 0)
                return;
            try
            {
               // ulong test = Convert.ToUInt64(this.dataGridView1.Rows[row].Cells[colum].Value);
                ulong test = Convert.ToUInt64(this.dataTableBlinds.Rows[row][colum]);
            
            }

            catch
            {
                //DataGridViewRow row2 = this.dataGridView1.Rows[row];
                this.dataTableBlinds.Rows[row][colum] = 0;


            }
        }

        private void checkBoxIncreaseBlind_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxIncreaseBlind.Checked)
            {
                enable = false;

            }
            else
            {
                enable = true;

            }
            this.EnableChangerBinds();
        }

        private void buttonSaveBlinds_Click(object sender, EventArgs e)
        {
            SaveFileDialog savediag = new SaveFileDialog();
            DialogResult res = savediag.ShowDialog();
            if (res == DialogResult.OK)
            {
                try
                {
                    this.dataSet1.WriteXml(savediag.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                
                }

            }

        }

        private void buttonLoadBlinds_Click(object sender, EventArgs e)
        {
            OpenFileDialog savediag = new OpenFileDialog();
            DialogResult res = savediag.ShowDialog();
            if (res == DialogResult.OK)
            {
                try
                {
                    this.dataSet1.Tables[0].Rows.Clear();
                    this.dataSet1.ReadXml(savediag.FileName);
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
        }

        private void dataTableBlinds_RowChanging(object sender, DataRowChangeEventArgs e)
        {
        
            
      
            try
            {
                // ulong test = Convert.ToUInt64(this.dataGridView1.Rows[row].Cells[colum].Value);
                ulong test = Convert.ToUInt64(e.Row[0]);

            }

            catch
            {
                //DataGridViewRow row2 = this.dataGridView1.Rows[row];
                e.Row[0] = 0;


            }
            try
            {
                // ulong test = Convert.ToUInt64(this.dataGridView1.Rows[row].Cells[colum].Value);
                ulong test = Convert.ToUInt64(e.Row[1]);

            }

            catch
            {
                //DataGridViewRow row2 = this.dataGridView1.Rows[row];
                e.Row[1] = 0;


            }
            try
            {
                // ulong test = Convert.ToUInt64(this.dataGridView1.Rows[row].Cells[colum].Value);
                ulong test = Convert.ToUInt64(e.Row[2]);

            }

            catch
            {
                //DataGridViewRow row2 = this.dataGridView1.Rows[row];
                e.Row[2] = 0;


            }
        }
    }
}
