using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "ToDo App";

        }

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "R9pEe3HX2blLhOBmHBSQrfqzApclaLXO2fE09lpy",
            BasePath = "https://database-651ea.firebaseio.com/"
        };


        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FirebaseClient(config);

                export();
            }
            catch
            {
                MessageBox.Show("There was a problem in your internet.");
            }

        }

        private async void export()
        {
            FirebaseResponse response = await client.GetAsync("unfinished_ToDo/");

            Dictionary<string, Data> allData =
                JsonConvert.DeserializeObject<Dictionary<string, Data>>(response.Body.ToString());

            string assigment = "";

            if (allData != null)
            {
                foreach (var item in allData)
                {
                    var date = item.Value.Date;
                    ToDoItem newItem = new ToDoItem(item.Value.Title,
                        item.Key, date.ToString(), true);

                    DateTime thisDay = DateTime.Now;
                    var parsedDate = DateTime.Parse(date);
                    //TimeSpan duration = thisDay - parsedDate;

                    var year = parsedDate.Year;
                    var mounth = parsedDate.Month;
                    var day = parsedDate.Day;

                    if (year == thisDay.Year && mounth == thisDay.Month && day == thisDay.Day)
                    {
                        this.panelToDo.Controls.Add(newItem);
                        assigment += item.Value.Title;
                        assigment += ", ";
                    }
                    else
                    {
                        this.panelExpired.Controls.Add(newItem);
                    }
                }

            }

            response = await client.GetAsync("finished_ToDo/");

            allData = JsonConvert.DeserializeObject<Dictionary<string, Data>>(response.Body.ToString());

            if (allData != null)
            {
                foreach (var item in allData)
                {
                    ToDoItem newItem = new ToDoItem(item.Value.Title,
                        item.Key, item.Value.Date.ToString(), false);

                    this.panelFinished.Controls.Add(newItem);
                }
            }

            if (assigment != "")
            {
                assigment = assigment.Remove(assigment.Length - 2);
                MessageBox.Show("Today's program: " + assigment);
            }

        }

        public void addItem(string Text, string Key, string Date, double dur)
        {
            ToDoItem item = new ToDoItem(Text, Key, Date, true);

            if (dur < 0)
            {
                this.panelToDo.Controls.Add(item);
            }
            else
            {
                this.panelExpired.Controls.Add(item);
            }

            item.Top = pos;
            pos = item.Top + item.Height + 10;

        }

        private async void Add_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != "")
            {
                string key = get_unique_string(18);

                var data = new Data
                {
                    Date = dateTimePicker.Value.ToString(),
                    Key = key,
                    Title = textBox.Text
                };

                SetResponse response = await client.SetAsync("unfinished_ToDo/" + key, data);

                DateTime thisDay = DateTime.Now;
                var parsedDate = DateTime.Parse(data.Date);
                TimeSpan duration = thisDay - parsedDate;

                string date = this.dateTimePicker.Value.ToString();
                addItem(this.textBox.Text, key, date, duration.TotalMinutes);
                textBox.Text = "";
            }
            else
            {
                MessageBox.Show("Incorrect data!");
            }

        }

        private string get_unique_string(int string_length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bit_count = (string_length * 6);
                var byte_count = ((bit_count + 7) / 8); // rounded up
                var bytes = new byte[byte_count];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            this.Text = "ToDo App";
            Form1_Load(sender, e);

        }

        int pos = 10;
        IFirebaseClient client;
    }
}
