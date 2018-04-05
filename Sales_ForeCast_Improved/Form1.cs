using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sales_ForeCast_Improved
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        int Validate(string s)
        {
            return Int32.TryParse(s, out int parsed) && parsed > -1 || s == "" ? parsed : -1;
        }
        string FindTextBoxByTag(object Tag)
        {
            return this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Tag == Tag).Text;
        }
        List<int> UserTextToInt (List<Object> list)
        {
            return list.Select(l => Validate(FindTextBoxByTag(l))).ToList();
        }
        void ShowErrorLabels(List<Object> list)
        {
            list.ForEach(l => ToggleErrorLabel( l.ToString(), Validate(FindTextBoxByTag(l)) == -1 ));
        }

        void ToggleErrorLabel (string s, bool onOff) => this.Controls.OfType<Label>().FirstOrDefault(w => (string)w.Tag == "error_" + s).Visible = onOff;
     //  void ClearErrorLabels() => this.Controls.OfType<Label>().Where(l => l.Tag.ToString().StartsWith("error")).ToList().ForEach(l => l.Visible = false);

        private void button1_Click(object sender, EventArgs e)
        {

            List<Object> userInput = new List<object>()
            {
                   this.ticketsSold.Tag,
                   this.tvCover.Tag,
                   this.sportsVisitors.Tag,
                   this.fitnessSubscribers.Tag,
                   this.visitorsAppear.Tag
            };

            var userTextToInt = UserTextToInt(userInput);

            ShowErrorLabels(userInput);

            if (userTextToInt.IndexOf(-1) == -1)
            {
                SalesForecastPlural.list.Add(
                    Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + " " + DateTime.Now.ToString("hh.mm.ss.ff"), 
                    new SalesForecast(userTextToInt)
                    );

                Console.WriteLine(string.Join("", SalesForecastPlural
                    .list.Select(x => "\n - Date: " + x.Key +
                    " \n - Forecast: " +
                    " Tickets Sold: " + x.Value.TicketsSold +
                    ", TV Cover: " + x.Value.TVCover +
                    ", Sports Visitors: " + x.Value.SportsVisitors +
                    ", Fitness Subsribers: " + x.Value.FitnessSubscribers +
                    ", Visitors appear: " + x.Value.VisitorsAppear
                    ).ToArray())
                 );
                   

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();
        }
    }
    class SalesForecast
    {
        public int TicketsSold { get; private set; }
        public int TVCover { get; private set; }
        public int SportsVisitors { get; private set; }
        public int FitnessSubscribers { get; private set; }
        public int VisitorsAppear { get; private set; }
        public SalesForecast(List<int> validatedInput)
        {
            TicketsSold = validatedInput[0];
            TVCover = validatedInput[1];
            SportsVisitors = validatedInput[2];
            FitnessSubscribers = validatedInput[3];
            VisitorsAppear = validatedInput[4];
        }
    }
    static class SalesForecastPlural
    {
        public static Dictionary<string, SalesForecast> list = new Dictionary<string, SalesForecast>();
    }

}


