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
         
        List<int> UserTextToInt(List<Object> tbTags)
        {
            int Validate(string inputText) => Int32.TryParse(inputText, out int parsed) && parsed > -1 || inputText == "" ? parsed : -1;         
            string FindTextBoxByTag(object Tag) =>this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Tag == Tag).Text;          
            return tbTags.Select(l => Validate(FindTextBoxByTag(l))).ToList();
        }
        void ToggleErrorLabel(Object tag, bool onOff)
        {
            // TODO : hvordan bruges defaultifempty?!
            try
            {
                this.Controls.OfType<Label>().First(l => l.Tag.ToString() == "error_" + tag).Visible = onOff;
            }
            catch { }
        }
        void ToggleLabels(List<Object> tbTags, List<int> validatedInts, Action<Object, bool> TEL)
        {
            int counter = 0;
            tbTags.ForEach(t => TEL(t, validatedInts[counter++] < 0));
        }
             
        void Clear(Control ctrl, Action<Object, bool> TEL)
        {
            ctrl.Controls.OfType<TextBox>().ToList().ForEach(t => { t.Text = ""; TEL(t.Tag, false); });
        }
        List<Object> GetInputTags()
        {
            return new List<object>()
            {
                   this.ticketsSold.Tag,
                   this.tvCover.Tag,
                   this.sportsVisitors.Tag,
                   this.fitnessSubscribers.Tag,
                   this.visitorsAppear.Tag
            };

        }
        /*
         *  
         *  Events
         *  
         */

        private void calculateButton_Click(object sender, EventArgs e)
        {
            var inputTags = GetInputTags();
            var userTextToInt = UserTextToInt(inputTags);

            ToggleLabels(inputTags, userTextToInt, ToggleErrorLabel);

            if (userTextToInt.IndexOf(-1) == -1)
            {
                SalesForecast salesForecast = new SalesForecast(userTextToInt);
                Console.WriteLine(salesForecast.FitnessSubscribers);
                showCalculationsButton.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            Clear(this, ToggleErrorLabel);
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            this.showCalculationsButton.Enabled = false;
        }
        private void showCalculationsButton_Click(object sender, EventArgs e)
        {
         
            SalesForecastPlural.AddToDict(
             Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + " " + DateTime.Now.ToString("hh.mm.ss.ff"),
             new SalesForecast(UserTextToInt(GetInputTags()))
            );

            Form2 f2 = new Form2();
            SalesForecastPlural.GetDict().ToList().ForEach(l =>

                f2.SetRow(
                    l.Key,
                    l.Value.TicketsSold,
                    l.Value.TVCover,
                    l.Value.SportsVisitors,
                    l.Value.FitnessSubscribers,
                    l.Value.VisitorsAppear,
                    l.Value.TotalSales,
                    l.Value.TotalExpenses,
                    l.Value.TotalEarnings
                )
            );
            f2.Show();

            showCalculationsButton.Enabled = false;
        }
    }
 
    static class SalesForecastPlural
    {      
        private static Dictionary<string, SalesForecast> dict = new Dictionary<string, SalesForecast>();
        public static void AddToDict (string key, SalesForecast value)
        {
            dict.Add(key, value);
        }
        public static Dictionary<string, SalesForecast> GetDict() => dict;
    }
    public static class Constants
    {
        public const decimal SALG_FRA_BUTIK_BESOEG_PCT = 0.2M; // 20 %
        public const uint BILLET_PRIS_GENNEMSNIT = 175; // 175 kr
        public const uint SALG_DRIKKEVARE_GENNEMSNIT = 70; // 70 kr
        public const uint SALG_SPORTS_VARE_GENNEMSNIT = 245; // 245kr
        public const uint ABONNEMENT_PRIS_6_MAANEDER = 999; // 999kr
        public const uint TV_RETTIGHEDER_PR_KANAL = 1000000; // 1 mill kr
        public const decimal TOTAL_OMK_I_PCT = 0.64M; // 64 %    
    }
}
