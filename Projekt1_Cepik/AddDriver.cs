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
    public partial class AddDriver : Form
    {
        public AddDriver()
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
            //label14.Visible = false;
            //label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CepikDB())
            {
                var drivers = new Drivers();
                var RegexID = new Regex(@"^[0-9]{1,6}$");
                var RegexName = new Regex(@"^[A-Z][a-z]*$");
                var RegexAddressCity = new Regex(@"^([A-Z][a-z]*(-[A-Z][a-z]*)?)$");
                var RegexAddress = new Regex(@"^([A-Z][a-z]*(\s[0-9]{1,5})?)$");
                var RegexLastName = new Regex(@"^([A-Z][a-z]*(-[A-Z][a-z]*)?)$");
                var RegexPESEL = new Regex(@"^[0-9]{11}$");
                bool DriverIdCondition = true; 
                bool AddressCityCondition = true;
                bool AddressCondition = true;
                bool PeselCondition = true;
                bool NameCondition = true;

                int number;
                bool success = Int32.TryParse(textBox1.Text, out number);
                //driver id
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    //button1.Enabled = false;
                    label7.Visible = true;
                }
                else if (!success || !RegexID.IsMatch(textBox1.Text))
                {
                    //button1.Enabled = false;
                    label6.Visible = true;
                }
                else
                {
                    drivers.DriverId = number;
                    DriverIdCondition = true;
                };
    
                //name 
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    //button1.Enabled = false;
                    label8.Visible = true;
                    NameCondition = false;
                }
                else if (!RegexName.IsMatch(textBox2.Text))
                {
                    //button1.Enabled = false;
                    label12.Visible = true;
                    NameCondition = false;
                }
                else
                {
                    drivers.FirstName = textBox2.Text;
                    NameCondition = true;
                };

                //last name
                if (!RegexName.IsMatch(textBox3.Text))
                {
                    label11.Visible = true;
                    NameCondition = false; 
                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    label9.Visible = true;
                    NameCondition = false;
                }
                else if (RegexName.IsMatch(textBox3.Text))
                {
                    drivers.LastName = textBox3.Text;
                    NameCondition = true;
                }

                //address
                if (!RegexAddress.IsMatch(textBox4.Text))
                {
                    label13.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox4.Text))
                {
                    label10.Visible = true;
                }
                else if (RegexAddress.IsMatch(textBox4.Text))
                {
                    drivers.Address = textBox4.Text;
                    AddressCondition = true;
                }

                //region 
                drivers.Region = textBox5.Text;

                //city
                if (!RegexAddressCity.IsMatch(textBox6.Text))
                {
                    label16.Visible = true;
                }
                else if (string.IsNullOrEmpty(textBox6.Text))
                {
                    label17.Visible = true;
                }
                else if (RegexAddress.IsMatch(textBox6.Text))
                {
                    drivers.Address = textBox6.Text;
                    AddressCityCondition = true;
                }



                if (DriverIdCondition && NameCondition && AddressCondition && PeselCondition && AddressCityCondition)
                {
                    button1.Enabled = true;
                }
                else button1.Enabled = false;
                context.Kierowcy.Add(drivers);
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
