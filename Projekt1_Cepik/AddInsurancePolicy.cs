using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_Cepik
{
    public partial class AddInsurancePolicy : Form
    {
        public AddInsurancePolicy()
        {
            InitializeComponent();
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CepikDB())
            {
                var insurancePolicy = new InsurancePolicy();
                var RegexId = new Regex(@"^[0-9]{1,6}$");
                var RegexDate = new Regex(@"^[0-3][0-9]\/[0-1][0-9]\/[0-2][0-9]{3}$");
                bool Idcondition = true;
                bool DateCondition = true;

                //policy id
                int number;
                bool success = Int32.TryParse(textBox1.Text, out number);
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    label5.Visible = true;
                    Idcondition = false;
                }
                else if (!success || !RegexId.IsMatch(textBox1.Text))
                {
                    label6.Visible = true;
                    Idcondition = false;
                }
                else
                {
                    insurancePolicy.InsuranceId = number;
                    Idcondition = true;
                };

                //car id
                bool success2 = Int32.TryParse(textBox1.Text, out number);
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    label7.Visible = true;
                    Idcondition = false;
                }
                else if (!success2 || !RegexId.IsMatch(textBox2.Text))
                {
                    label8.Visible = true;
                    Idcondition = false;
                }
                else
                {
                    insurancePolicy.CarId = number;
                    Idcondition = true;
                };

                //date1
                if (!RegexDate.IsMatch(textBox3.Text))
                {
                    label10.Visible = true;
                    DateCondition = false;
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    label9.Visible = true;
                    DateCondition = false;
                }
                else if (RegexDate.IsMatch(textBox3.Text))
                {
                    insurancePolicy.PolicyStartDay = DateTime.Parse(textBox3.Text);
                    DateCondition = true;
                }

                //date2
                if (!RegexDate.IsMatch(textBox4.Text))
                {
                    label12.Visible = true;
                    DateCondition = false;
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label11.Visible = true;
                    DateCondition = false;
                }
                else if (RegexDate.IsMatch(textBox4.Text))
                {
                    insurancePolicy.PolicyExpiryDate = DateTime.Parse(textBox4.Text);
                    DateCondition = true;
                }

                if (Idcondition == true && DateCondition == true) //czemu to nie dziala?
                {
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Back = new ProgramAddData();
            Back.Closed += (s, args) => this.Close();
            Back.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
