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
        public void SetRow(string date, List<int> list, decimal totalSales, decimal totalExpenses, decimal totalEarnings)
        {
            this.dataGridView1.Rows.Add( date, list[0], list[1], list[2], list[3], list[4], totalSales, totalExpenses, totalEarnings);
        }
    }
}
