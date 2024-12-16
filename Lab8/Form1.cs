using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LabNo8_Activity1
{
    public partial class Form1 : Form
    {
        string gender, hobby, status = " ";

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlconnection = "Data Source=AUMC-LAB3-29\\SQLEXPRESS; Initial Catalog=Customer; Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(sqlconnection);
            sqlcon.Open();
            string command = "Select * From CustomerData";
            SqlCommand sqlcommand=new SqlCommand(command, sqlcon);

            DataSet ob1dataset=new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
            adapter.Fill(ob1dataset);
            dataGridView1.DataSource = ob1dataset.Tables[0];
            sqlcon.Close();
        }

        public Form1()
        {

            InitializeComponent();
            comboBox1.Items.Add("Pakistan");
            comboBox1.Items.Add("Turkey");
            comboBox1.Items.Add("America");
            comboBox1.Items.Add("Canada");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }

            if (checkBox1.Checked)
            {
                hobby = checkBox1.Text;
            }
            else if (checkBox2.Checked)
            {
                hobby = checkBox2.Text;
            }

            if (radioButton3.Checked)
            {
                status = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                status = radioButton4.Text;
            }

            ClassValidation cv = new ClassValidation();
            try
            {
                cv.CheckCustomerName(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! {ex.Message}");
            }
            string strConnection = "Data Source=AUMC-LAB3-29\\SQLEXPRESS;Initial Catalog=Customer;"+ "Integrated Security=True";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();
            string strCommand = "insert into CustomerData values('" + textBox1.Text + "', '" + comboBox1.Text + "','" + gender + "', '" + hobby + "','" + status + "' )";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();
            objConnection.Close();
            Form1_Load(sender,e);
            Form2 form = new Form2();
            form.GetData(textBox1.Text, comboBox1.Text, hobby, gender, status);
            form.Show();
        }
    }
}