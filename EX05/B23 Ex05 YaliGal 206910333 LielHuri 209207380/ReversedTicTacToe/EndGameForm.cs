using System;
using System.Windows.Forms;

namespace ReversedTicTacToe
{
    public partial class EndGameForm : Form
    {
        public string Message
        {
            get { return resultLabel.Text; }
            set { resultLabel.Text = value; }
        }

        public EndGameForm()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
