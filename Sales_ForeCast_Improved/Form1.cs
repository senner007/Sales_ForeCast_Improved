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
        List<int> ValidateTextboxes (params object[] list)
        {
            var returnList = new List<int>();
            foreach (string tbTag in list)
            {
                int validated = Validate(this.Controls.OfType<TextBox>().FirstOrDefault(t => (string)t.Tag == tbTag).Text);
                if (validated == -1)
                {
                    ToggleErrorLabel(tbTag, true);              
                }   
                else
                {
                    ToggleErrorLabel(tbTag, false);
                    returnList.Add(validated);
                }
            }
            return returnList.Count() == list.Count() ? returnList : new List<int>();
        }

        void ToggleErrorLabel (string s, bool onOff) => this.Controls.OfType<Label>().FirstOrDefault(w => (string)w.Tag == "error" + s).Visible = onOff;
     //  void ClearErrorLabels() => this.Controls.OfType<Label>().Where(l => l.Tag.ToString().StartsWith("error")).ToList().ForEach(l => l.Visible = false);

        private void button1_Click(object sender, EventArgs e)
        {

            var validated = ValidateTextboxes(
                   this.ticketsSold.Tag,
                   this.tvCover.Tag,
                   this.sportsVisitors.Tag
                );

            if (validated.Count() != 0)
            {
              //  Console.WriteLine(Convert.ToDateTime(dateTimePicker1.Value));
                // dateTimePicker skal valideres først
                SalesForecastPlural.list.Add(
                    Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + " " + DateTime.Now.ToString("hh.mm.ss.ff"), 
                    new SalesForecast(validated[0], validated[1], validated[2] )
                    );

                Console.WriteLine(string.Join("", SalesForecastPlural
                    .list.Select(x => "\n - Date: " + x.Key +
                    " \n - Forecast: " +
                    " Tickets Sold: " + x.Value.TicketsSold +
                    ", TV Cover: " + x.Value.TVCover +
                    ", Sports Visitors: " + x.Value.SportsVisitors).ToArray())
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
        public SalesForecast(int ticketsSold, int tvCover, int sportsVisitors)
        {
            TicketsSold = ticketsSold;
            TVCover = tvCover;
            SportsVisitors = sportsVisitors;
        }
    }
    static class SalesForecastPlural
    {
        public static Dictionary<string, SalesForecast> list = new Dictionary<string, SalesForecast>();
    }

}


