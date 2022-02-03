using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200140034_UTS_PAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            string endpoint = "http://api.aladhan.com/v1/calendarByCity";
            string parameters = "?country=Indonesia&city=Yogyakarta";
            string uri = endpoint + parameters;
            HttpResponseMessage responeMessage = httpClient.GetAsync(uri).Result;
            string response = responeMessage.Content.ReadAsStringAsync().Result;
            dynamic resultObject = JsonConvert.DeserializeObject(response);

            WaktuINI.Text = DateTime.Now.ToString();

            SubuhLabel.Text = resultObject.data[0].timings.Fajr;
            DuhurLabel.Text = resultObject.data[0].timings.Dhuhr;
            AsarLabel.Text = resultObject.data[0].timings.Asr;
            MaghribLabel.Text = resultObject.data[0].timings.Maghrib;
            IsyaLabel.Text = resultObject.data[0].timings.Isha;

        }
    }
}
