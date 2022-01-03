using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using System.Drawing;

namespace WinFormsApp
{
    public partial class ToDoItem : UserControl
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "R9pEe3HX2blLhOBmHBSQrfqzApclaLXO2fE09lpy",
            BasePath = "https://database-651ea.firebaseio.com/"
        };


        public ToDoItem()
        {
            InitializeComponent();
        }

        public ToDoItem(string title, string Key, string Date, bool ok)
        {
            InitializeComponent();

            this.textBox.Visible = false;

            if (!ok)
            {
                this.pipe.Visible = false;
                this.pencil.Visible = false;
            }
            else
            {
                this.minus.Visible = false;
            }

            key = Key;
            value = title;
            myDate = Date;

            this.title.Text = title;
            this.date.Text = Date;

            try
            {
                client = new FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("There was a problem in your internet.");
            }

        }

        private async void trash_Click(object sender, EventArgs e)
        {
            FirebaseResponse response1 = await client.DeleteAsync("unfinished_ToDo/" + key);
            FirebaseResponse response2 = await client.DeleteAsync("finished_ToDo/" + key);

            this.BackColor = Color.Tomato;
            title.Text = "Deleted";
            date.Text = "";
            this.pencil.Visible = false;
            this.trash.Visible = false;
            this.minus.Visible = false;
            this.pipe.Visible = false;
        }

        private async void pipe_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Date = myDate,
                Key = key,
                Title = value
            };

            SetResponse response1 = await client.SetAsync("finished_ToDo/" + key, data);
            FirebaseResponse response2 = await client.DeleteAsync("unfinished_ToDo/" + key);

            this.pipe.Visible = !this.pipe.Visible;
            this.minus.Visible = !this.minus.Visible;

        }

        private async void minus_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Date = myDate,
                Key = key,
                Title = value
            };

            FirebaseResponse response1 = await client.DeleteAsync("finished_ToDo/" + key);
            SetResponse response2 = await client.SetAsync("unfinished_ToDo/" + key, data);

            this.pipe.Visible = !this.pipe.Visible;
            this.minus.Visible = !this.minus.Visible;

        }

        private async void pencil_Click(object sender, EventArgs e)
        {
            this.title.Visible = !this.title.Visible;
            this.textBox.Visible = !this.textBox.Visible;

            if (this.title.Visible == true && this.textBox.Text != "")
            {
                string newText = textBox.Text;
                var data = new Data
                {
                    Date = myDate,
                    Key = key,
                    Title = newText
                };

                FirebaseResponse response = await client.UpdateAsync("unfinished_ToDo/" + key, data);

                this.title.Text = newText;
            }

            this.textBox.Text = "";
        }

        public string key = null;
        public string value = null;
        public string myDate = null;
        IFirebaseClient client;

    }
}
