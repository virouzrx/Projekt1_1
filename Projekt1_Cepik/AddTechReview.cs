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
    public partial class AddTechReview : Form
    {
        public AddTechReview()
        {
            InitializeComponent();
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Back = new ProgramAddData();
            Back.Closed += (s, args) => this.Close();
            Back.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
            }
            else if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
            }
            else if (checkBox2.Checked == false)
            {
                checkBox1.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CepikDB())
            {
                var techReview = new TechnicalReview();
                var RegexId = new Regex(@"^[0-9]{1,6}$");
                var RegexDate = new Regex(@"^[0-3][0-9]\/[0-1][0-9]\/[0-2][0-9]{3}$");
                bool Idcondition = true;
                bool DateCondition = true;

                //tr id
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
                    techReview.TechnicalReviewID = number;
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
                    techReview.CarId = number;
                    Idcondition = true;
                };

                //date1
                if (!RegexDate.IsMatch(textBox3.Text))
                {
                    label9.Visible = true;
                    DateCondition = false;
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    label10.Visible = true;
                    DateCondition = false;
                }
                else if (RegexDate.IsMatch(textBox3.Text))
                {
                    techReview.TechnicalReviewDate = DateTime.Parse(textBox3.Text);
                    DateCondition = true;
                }

                //date2
                if (!RegexDate.IsMatch(textBox4.Text))
                {
                    label15.Visible = true;
                    DateCondition = false;
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label14.Visible = true;
                    DateCondition = false;
                }
                else if (RegexDate.IsMatch(textBox4.Text))
                {
                    techReview.TechnicalReviewExpiryDate = DateTime.Parse(textBox4.Text);
                    DateCondition = true;
                }

                //tr state
                if (checkBox1.Checked == true)
                {
                    techReview.TechnicalReviewStatus = true;
                }
                else if (checkBox2.Checked == true)
                {
                    techReview.TechnicalReviewStatus = false;
                }
                else
                {
                    label11.Visible = true;
                }

                if (Idcondition == true && DateCondition == true && checkBox2.Checked == true || checkBox1.Checked == true) //czemu to nie dziala?
                {
                    context.BadanieTechniczne.Add(techReview);
                    context.SaveChanges();
                }
                else label13.Visible = true;
                //context.SaveChanges();
            }
                
        }

    }
}
