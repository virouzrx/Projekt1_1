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
    public partial class AddCarInfo : Form
    {
        public AddCarInfo()
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
                var carInfo  = new CarDocsAndInfo();
                var RegexVIN = new Regex(@"^[A-Z0-9]{17}$");
                var RegexDate = new Regex(@"^[0-3][0-9]\/[0-1][0-9]\/[0-2][0-9]{3}$");
                var RegexCarId = new Regex(@"^[0-9]23/$");
                bool VINcondition = true;
                bool DateCondition = true;
                bool IdCondition = true;

                //vin number
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    label5.Visible = true;
                }
                else if (!RegexVIN.IsMatch(textBox1.Text))
                {
                    label6.Visible = true;
                }
                else
                {
                    carInfo.VinNumber = textBox1.Text;
                    VINcondition = true;
                };

                //car card nr 
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    label7.Visible = true;
                }
                else
                {
                    carInfo.CarCardNumber = textBox2.Text;
                };

                //date
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
                    carInfo.FirstRegistrationDate = DateTime.Parse(textBox3.Text);
                    DateCondition = true;
                }

                int number;
                bool success = Int32.TryParse(textBox1.Text, out number);
                //car id
                if (!success || !RegexCarId.IsMatch(textBox4.Text))
                {
                    label12.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label11.Visible = true;
                }
                else if (RegexCarId.IsMatch(textBox4.Text))
                {
                    carInfo.CarId = number;
                    IdCondition = true;
                }

                if (IdCondition && DateCondition && VINcondition)
                {
                    context.Informacje.Add(carInfo);
                    context.SaveChanges();
                }

            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Back = new ProgramAddData();
            Back.Closed += (s, args) => this.Close();
            Back.Show();
        }
    }
}
