using System;
using System.Windows.Forms;

namespace LegaiaText
{
    public partial class SearchDialog : Form
    {
        public event EventHandler<SearchEventArgs> OnTextEntered;

        public SearchDialog()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void SearchDialog_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return: OK(); break;
                case Keys.Escape: Close(); break;
            }
        }

        private void OK()
        {
            OnTextEntered(this, new SearchEventArgs(TextSearch.Text));

            Close();
        }
    }

    public class SearchEventArgs : EventArgs
    {
        public string Text;

        public SearchEventArgs(string Text)
        {
            this.Text = Text;
        }
    }
}
