using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt1_Cepik
{
    public partial class ProgramStart : Form
    {
        public ProgramStart()
        {
            InitializeComponent();
           
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewAddDataForm = new ProgramAddData();
            NewAddDataForm.Closed += (s, args) => this.Close();
            NewAddDataForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NewBrowseDataForm = new ProgramBrowseData();
            NewBrowseDataForm.Closed += (s, args) => this.Close();
            NewBrowseDataForm.Show();
        }
    }
}
