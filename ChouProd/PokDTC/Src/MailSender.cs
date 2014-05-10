using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace poker
{
    public partial class MailSender : Form
    {
        public MailSender()
        {
            InitializeComponent();
        }
        private string path2xor;
        public MailSender(string path)
        {
            try
            {
                InitializeComponent();
                Translation();
                path2xor = path;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void Translation()
        {

            this.button1.Text = Language.GetSendButton();
            this.richTextBox1.Text = Language.GetSomeComments();

        }

        private void button1_Click(object sender, EventArgs e)
        {
              SpamMe spam = new SpamMe(this.path2xor,this.textBoxFrom.Text,this.textBoxSmtp.Text,this.richTextBox1.Text);
                  bool answer= spam.SendMe();

                  if (answer)
                  {
                      MessageBox.Show(Language.GetMailSent());
                      this.Close();
                  }
                  else
                  {
                      MessageBox.Show(Language.GetMailError(path2xor),"Dohh",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 
                  }
               
        }
    }
}