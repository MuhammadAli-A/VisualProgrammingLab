using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabNo8_Activity1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }
        public void GetData(string name, string contry, string gender, string hobby, string status)
        {
            label1.Text = $"Customer Name: {name}";
            label2.Text= $"Country: {contry}";
            label3.Text = $"Gender: {gender}";
            label4.Text = $"Hobby: {hobby}";
            label5.Text= $"Status: {status}";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
