using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_ForeCast_Improved
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public void SetRow(string date, int ticketsSold, int tvCover, 
                            int sportsVisitors, int fitnessSubscribers, int visitorsAppear, 
                            decimal TotalSales, decimal totalExpenses, decimal totalEarnings)
        {

            this.dataGridView1.Rows.Add(
                date, ticketsSold, tvCover, sportsVisitors, fitnessSubscribers, visitorsAppear, TotalSales, totalExpenses, totalEarnings
            );
        }
    }
}
