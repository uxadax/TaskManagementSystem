using System;
using System.Windows.Forms;
using System.Drawing;

namespace TaskManagementSystem
{
    public class PlaceholderTextBox : TextBox
    {
        private string _placeholderText;
        public string PlaceholderText
        {
            get { return _placeholderText; }
            set
            {
                _placeholderText = value;
                SetPlaceholder();
            }
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(PlaceholderText))
            {
                this.Text = PlaceholderText;
                this.ForeColor = Color.Gray;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.Text == PlaceholderText)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SetPlaceholder();
        }

        public PlaceholderTextBox()
        {
            this.GotFocus += RemovePlaceholder;
            this.LostFocus += ShowPlaceholder;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (Text == PlaceholderText)
            {
                Text = "";
                ForeColor = Color.Black;
            }
        }

        private void ShowPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Text))
            {
                Text = PlaceholderText;
                ForeColor = Color.Gray;
            }
        }
    }
}
