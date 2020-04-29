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
using System.Data.Entity;
using System.Data.SqlClient;

namespace Projekt1_Cepik
{
    public partial class BrowseData : Form
    {
        public BrowseData()
        {
            InitializeComponent();
            textBox3.ReadOnly = true;
            //textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CepikDB())
            {
                /*  SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Projekt1_Cepik.CepikDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                  connection.Open();
                  string sqlCommand = "SELECT CarId[ID pojazdu], LicensePlateNumber[Nr tablicy rejestracyjnej]," +
                                                              "CarModel [Model pojazdu], CarCompany [Marka], DriverId [Wlasciciel] " +
                                                      "FROM Cars WHERE CarId = @ID";
                  SqlCommand command = new SqlCommand(sqlCommand, connection);
                  command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                  SqlDataReader da = command.ExecuteReader();
                  while (da.Read())
                  {
                      textBox3.Text = da.GetValue(0).ToString();
                      textBox3.Text = da.GetValue(1).ToString();
                      textBox3.Text = da.GetValue(2).ToString();
                      textBox3.Text = da.GetValue(3).ToString();
                      textBox3.Text = da.GetValue(4).ToString();
                  }
                  connection.Close(); */ // <^ - to nie działa nie wiem czemu
            
            }
         
        }
    }
}
