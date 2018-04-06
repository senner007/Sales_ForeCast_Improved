namespace Sales_ForeCast_Improved
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ticketsSold = new System.Windows.Forms.TextBox();
            this.tvCover = new System.Windows.Forms.TextBox();
            this.sportsVisitors = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fitnessSubscribers = new System.Windows.Forms.TextBox();
            this.visitorsAppear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.showCalculationsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ticketsSold
            // 
            this.ticketsSold.Location = new System.Drawing.Point(182, 65);
            this.ticketsSold.Name = "ticketsSold";
            this.ticketsSold.Size = new System.Drawing.Size(100, 20);
            this.ticketsSold.TabIndex = 0;
            this.ticketsSold.Tag = "ticketsSold";
            this.ticketsSold.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // tvCover
            // 
            this.tvCover.Location = new System.Drawing.Point(182, 103);
            this.tvCover.Name = "tvCover";
            this.tvCover.Size = new System.Drawing.Size(100, 20);
            this.tvCover.TabIndex = 1;
            this.tvCover.Tag = "tvCover";
            this.tvCover.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // sportsVisitors
            // 
            this.sportsVisitors.Location = new System.Drawing.Point(182, 138);
            this.sportsVisitors.Name = "sportsVisitors";
            this.sportsVisitors.Size = new System.Drawing.Size(100, 20);
            this.sportsVisitors.TabIndex = 2;
            this.sportsVisitors.Tag = "sportsVisitors";
            this.sportsVisitors.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Tag = "error_ticketsSold";
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Tag = "error_tvCover";
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Tag = "error_sportsVisitors";
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(28, 496);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 6;
            this.calculateButton.Text = "Beregn";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(553, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(553, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Tag = "calender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Tag = "ticketsSold";
            this.label4.Text = "Billetter solgt:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 10;
            this.label5.Tag = "tvCover";
            this.label5.Text = "TV kanaler dækning";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 11;
            this.label6.Tag = "sportsVisitors";
            this.label6.Text = "Besøger sportsbutik";
            // 
            // fitnessSubscribers
            // 
            this.fitnessSubscribers.Location = new System.Drawing.Point(182, 174);
            this.fitnessSubscribers.Name = "fitnessSubscribers";
            this.fitnessSubscribers.Size = new System.Drawing.Size(100, 20);
            this.fitnessSubscribers.TabIndex = 12;
            this.fitnessSubscribers.Tag = "fitnessSubscribers";
            this.fitnessSubscribers.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // visitorsAppear
            // 
            this.visitorsAppear.Location = new System.Drawing.Point(182, 209);
            this.visitorsAppear.Name = "visitorsAppear";
            this.visitorsAppear.Size = new System.Drawing.Size(100, 20);
            this.visitorsAppear.TabIndex = 13;
            this.visitorsAppear.Tag = "visitorsAppear";
            this.visitorsAppear.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 14;
            this.label7.Tag = "fitnessSubscribers";
            this.label7.Text = "Motionscenter Abonnement";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 15;
            this.label8.Tag = "visitorsAppear";
            this.label8.Text = "Tilskuere mødt op i %";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Tag = "error_fitnessSubscribers";
            this.label9.Text = "label9";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(328, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 17;
            this.label10.Tag = "error_visitorsAppear";
            this.label10.Text = "label10";
            this.label10.Visible = false;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(121, 496);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 18;
            this.resetButton.Text = "Nulstil";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // showCalculationsButton
            // 
            this.showCalculationsButton.Enabled = false;
            this.showCalculationsButton.Location = new System.Drawing.Point(553, 131);
            this.showCalculationsButton.Name = "showCalculationsButton";
            this.showCalculationsButton.Size = new System.Drawing.Size(200, 23);
            this.showCalculationsButton.TabIndex = 19;
            this.showCalculationsButton.Text = "Afslut beregninger og vis";
            this.showCalculationsButton.UseVisualStyleBackColor = true;
            this.showCalculationsButton.Click += new System.EventHandler(this.showCalculationsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.showCalculationsButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.visitorsAppear);
            this.Controls.Add(this.fitnessSubscribers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sportsVisitors);
            this.Controls.Add(this.tvCover);
            this.Controls.Add(this.ticketsSold);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ticketsSold;
        private System.Windows.Forms.TextBox tvCover;
        private System.Windows.Forms.TextBox sportsVisitors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fitnessSubscribers;
        private System.Windows.Forms.TextBox visitorsAppear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button showCalculationsButton;
    }
}

