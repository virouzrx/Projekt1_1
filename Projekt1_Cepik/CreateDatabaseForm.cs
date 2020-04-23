using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projekt1_Cepik
{
    public partial class CreateDatabaseForm : Form
    {
        
        public CreateDatabaseForm()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 5;
            label2.Visible = false;
            using (var database = new CepikDB())
             {
                 if (!database.Database.Exists())
                 {
                     button2.Enabled = false; 

                 }
                 else button1.Enabled = false; 
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            progressBar1.Visible = true; 
            label2.Visible = true;
            button2.Enabled = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewProgramStartForm = new ProgramStart();
            NewProgramStartForm.Closed += (s, args) => this.Close();
            NewProgramStartForm.Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var database = new CepikDB())
            {
                if (!database.Database.Exists())
                {
                    Database.SetInitializer(new CreateDatabaseIfNotExists<CepikDB>());
                    var context = new CepikDB();
                    context.Database.Create();
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            var NewProgramStartForm = new ProgramStart();
            NewProgramStartForm.Closed += (s, args) => this.Close();
            NewProgramStartForm.Show();
        }
    }
}
