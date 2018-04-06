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
        int _Validate(string inputText) => Int32.TryParse(inputText, out int parsed) && parsed > -1 || inputText == "" ? parsed : -1;
        string _FindTextBoxByTag(object Tag) => this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Tag == Tag).Text;
        List<int> UserTextToInt(List<Object> tbTags) => tbTags.Select(l => _Validate(_FindTextBoxByTag(l))).ToList();
        void _ToggleErrorLabel(Object tag, bool onOff)
        {
            // TODO : brug defaultifempty
            try
            {
                this.Controls.OfType<Label>().First(l => l.Tag.ToString() == "error_" + tag).Visible = onOff;
            }
            catch { }
        }
        void ToggleLabels(List<Object> tbTags, List<int> validatedInts)
        {
            int counter = 0;
            tbTags.ForEach(t => _ToggleErrorLabel(t, validatedInts[counter++] < 0));
        }
             
        void Clear(Control ctrl)
        {
            ctrl.Controls.OfType<TextBox>().ToList().ForEach(t => { t.Text = ""; _ToggleErrorLabel(t.Tag, false); });
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
        private void calculateButton_Click(object sender, EventArgs e)
        {
            var inputTags = GetInputTags();
            var userTextToInt = UserTextToInt(inputTags);

            ToggleLabels(inputTags, userTextToInt);

            if (userTextToInt.IndexOf(-1) == -1)
            {
                SalesForecast salesForecast = new SalesForecast(userTextToInt);
                Console.WriteLine(salesForecast.FitnessSubscribers);
                showCalculationsButton.Enabled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => this.textBox1.Text = Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString();
        private void resetButton_Click(object sender, EventArgs e) => Clear(this);

        private void OnTextChanged(object sender, EventArgs e)
        {
            this.showCalculationsButton.Enabled = false;
        }

        private void showCalculationsButton_Click(object sender, EventArgs e)
        {

            var userTextToInt = UserTextToInt(GetInputTags());

            SalesForecastPlural.list.Add(
                Convert.ToDateTime(dateTimePicker1.Value).ToShortDateString() + " " + DateTime.Now.ToString("hh.mm.ss.ff"),
                new SalesForecast(userTextToInt)
            );

            //MessageBox.Show(
            //string.Join("", SalesForecastPlural // TODO: messagebox
            //    .list.Select(x => "\n - Date: " + x.Key +
            //    " \n - Forecast: " +
            //    " Tickets Sold: " + x.Value.TicketsSold +
            //    ", TV Cover: " + x.Value.TVCover +
            //    ", Sports Visitors: " + x.Value.SportsVisitors +
            //    ", Fitness Subsribers: " + x.Value.FitnessSubscribers +
            //    ", Visitors appear: " + x.Value.VisitorsAppear +
            //    ", \n - Total Income: " + x.Value.TotalIncome +
            //    ", \n - Total Expenses: " + x.Value.TotalExpenses +
            //    ", \n - Total Earnings: " + x.Value.TotalEarnings
            //    ).ToArray())
            //);

            // TableLayoutPanel Initialization
            //TableLayoutPanel panel = new TableLayoutPanel();
            //panel.ColumnCount = 3;
            //panel.RowCount = 1;
            //panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            //panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            //panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            //panel.Controls.Add(new Label() { Text = "Address" }, 1, 0);
            //panel.Controls.Add(new Label() { Text = "Contact No" }, 2, 0);
            //panel.Controls.Add(new Label() { Text = "Email ID" }, 3, 0);

            //var form = new Form();
            //form.Controls.Add(panel);
            //form.Width = 900;
            //form.Height = 900;
            ////form.Text = string.Join("", SalesForecastPlural // TODO: messagebox
            ////    .list.Select(x => "\n - Date: " + x.Key +
            ////    " \n - Forecast: " +
            ////    " Tickets Sold: " + x.Value.TicketsSold +
            ////    ", TV Cover: " + x.Value.TVCover +
            ////    ", Sports Visitors: " + x.Value.SportsVisitors +
            ////    ", Fitness Subsribers: " + x.Value.FitnessSubscribers +
            ////    ", Visitors appear: " + x.Value.VisitorsAppear +
            ////    ", \n - Total Income: " + x.Value.TotalIncome +
            ////    ", \n - Total Expenses: " + x.Value.TotalExpenses +
            ////    ", \n - Total Earnings: " + x.Value.TotalEarnings
            ////    ).ToArray());
            //form.Show();

            showCalculationsButton.Enabled = false;
        }
    }
    delegate decimal Calculate(params decimal[] vals);
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

            CalculateIncome();
            CalculateExpenses();
            CalculateEarnings();

        }
        public decimal TotalIncome { get; private set; }
        public decimal TotalEarnings { get; private set; }
        public decimal TotalExpenses { get; private set; }
        private void CalculateIncome ()
        {
            TotalIncome = SumUp(
                  Mult(Constants.BILLET_PRIS_GENNEMSNIT, TicketsSold),
                  Mult(Constants. TV_RETTIGHEDER_PR_KANAL, TVCover),
                  Mult(SportsVisitors, Constants.SALG_SPORTS_VARE_GENNEMSNIT, Constants.SALG_FRA_BUTIK_BESOEG_PCT),
                  Mult(Constants.ABONNEMENT_PRIS_6_MAANEDER, FitnessSubscribers),
                  Mult(Constants.SALG_DRIKKEVARE_GENNEMSNIT, TicketsSold, (Convert.ToDecimal(VisitorsAppear) / 100))
             );
        }
        private void CalculateEarnings()
        {
            TotalEarnings = TotalIncome - TotalExpenses;
        }
        private void CalculateExpenses()
        {
            TotalExpenses = TotalIncome * Constants.TOTAL_OMK_I_PCT;
        }
        Calculate Mult = vals => vals.Aggregate((a, b) => a * b);
        Calculate SumUp = vals => vals.Sum();
    }
    static class SalesForecastPlural
    {
        public static Dictionary<string, SalesForecast> list = new Dictionary<string, SalesForecast>();
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
