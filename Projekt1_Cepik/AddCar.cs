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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
            
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
        }

        private void AddCar_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CepikDB())
            {
                var cars = new Cars();
                var RegexCarID = new Regex(@"^[0-9]{1,6}$");
                var RegexCarName = new Regex(@"^([A-Z][a-z]*( [A-Z][a-z]*)?)$");
                var RegexLicensePlate = new Regex(@"^[A-Z]{3}[A-Z0-9]{4,5}$");
                var RegexModelName = new Regex(@"^([A-Z][a-z]*( [A-Z][a-z]*( [A-Za-z0-9]*))?)$");
                bool CarIdCondition = false; ;
                bool DriverIdCondition = false;
                bool CarModelCondition = false;
                bool CarCompanyCondition = false;
                bool LicensePlateCondition = false;

                int number;
                bool success = Int32.TryParse(textBox1.Text, out number);
                //car id
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    //button1.Enabled = false;
                    label6.Visible = true;
                }
                else if (!success || !RegexCarID.IsMatch(textBox1.Text))
                {
                    //button1.Enabled = false;
                    label7.Visible = true;
                }
                else
                {
                    cars.CarId = number;
                    CarIdCondition = true;
                };
                bool success2 = Int32.TryParse(textBox2.Text, out number);
                //driver id 
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    //button1.Enabled = false;
                    label6.Visible = true;
                }
                else if (!success2 || !RegexCarID.IsMatch(textBox2.Text))
                {
                    //button1.Enabled = false;
                    label7.Visible = true;
                }
                else
                {
                    cars.DriverId = number;
                    DriverIdCondition = true;
                };
                //car model
                if (!RegexModelName.IsMatch(textBox3.Text))
                {
                    label14.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    label14.Visible = true;
                }
                else if (RegexModelName.IsMatch(textBox3.Text))
                {
                    cars.CarModel = textBox3.Text;
                    CarModelCondition = true;
                }
                //car company name 
                if (!RegexCarName.IsMatch(textBox4.Text))
                {
                    label9.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label10.Visible = true;
                }
                else if (RegexCarName.IsMatch(textBox4.Text))
                {
                    cars.CarCompany = textBox4.Text;
                    CarCompanyCondition = true;
                }
                //license plate 
                if (!RegexLicensePlate.IsMatch(textBox5.Text))
                {
                    label13.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox5.Text))
                {
                    label12.Visible = true;
                }
                else if (RegexLicensePlate.IsMatch(textBox5.Text))
                {
                    cars.LicensePlateNumber = textBox5.Text;
                    LicensePlateCondition = true;
                }
                if (CarIdCondition && CarModelCondition && DriverIdCondition && CarCompanyCondition && LicensePlateCondition)
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
                context.Pojazdy.Add(cars);
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
    }
}
