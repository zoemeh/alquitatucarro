using AlquitaTuCarro_UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquitaTuCarro.UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserBox.Text;
            string password = PasswordBox.Text;
            if (username != null && password != null)
            {
                var client = new HttpClient();
                var user = new Dictionary<string, string>()
                {
                    {"username", username },
                    {"password", password}
                };
                string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("https://localhost:7163/Users/authenticate", content);
                var result = response.Result;
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var s = result.Content.ReadAsStringAsync().Result;
                    dynamic j = JObject.Parse(s);
                    string token = j.token;
                    TokenStore.Token = token;
                    Program.mainForm.CurrentForm = Program.mainForm.FuelTypesForm;
                } else
                {
                    MessageBox.Show("Wrong User");
                }
           
            }
        }
    }
}
