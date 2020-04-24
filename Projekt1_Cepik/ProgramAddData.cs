using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_Cepik
{
    public partial class ProgramAddData : Form
    {
        public ProgramAddData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddCarForm = new AddCar();
            NewAddCarForm.Closed += (s, args) => this.Close();
            NewAddCarForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddDriverForm = new AddDriver();
            NewAddDriverForm.Closed += (s, args) => this.Close();
            NewAddDriverForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddTechReviewForm = new AddTechReview();
            NewAddTechReviewForm.Closed += (s, args) => this.Close();
            NewAddTechReviewForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddInsurancePolicyForm = new AddInsurancePolicy();
            NewAddInsurancePolicyForm.Closed += (s, args) => this.Close();
            NewAddInsurancePolicyForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddCarInfoForm = new AddCarInfo();
            NewAddCarInfoForm.Closed += (s, args) => this.Close();
            NewAddCarInfoForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Back = new ProgramStart();
            Back.Closed += (s, args) => this.Close();
            Back.Show();
        }
    }
}
