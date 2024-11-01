using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1
{
    public partial class Assignment : System.Windows.Forms.Form
    {
        public Assignment()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                string[] names = { "Tamil Nadu", "Kerala", "Telugana", "Andhara", "Delhi" };
                foreach (string name in names)
                {
                    comboBox1.Items.Add(name);
                }
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello World!");

            // MessageBox.Show("Hello World!" , "Call");

            // MessageBox.Show("Hello World!", "Call",MessageBoxButtons.OKCancel);

            MessageBox.Show("Hello World!", "Call", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label.Text = "This is a label.";
        }

        private void Textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Label2.Text = "Enter the Name :";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Textbox.Text, "Title", MessageBoxButtons.OKCancel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Font oldfont;
            Font newfont;
            oldfont = this.richTextBox1.SelectionFont;
            if (oldfont.Bold)
            {
                newfont = new Font(oldfont, oldfont.Style & ~FontStyle.Bold);
            }
            else
            {
                newfont = new Font(oldfont, oldfont.Style | FontStyle.Bold);
            }
            this.richTextBox1.SelectionFont = newfont;
            this.richTextBox1.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "RichTextBox";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void ButtonBuy_Click(object sender, EventArgs e)
        {
            string items = string.Empty;
            if (cp.Checked)
                items += "\n Pencil";
            if (cs.Checked)
                items += "\n Sharpener";
            if (cpp.Checked)
                items += "\n Pen";
            MessageBox.Show("You have bought: " + items, "Cart", MessageBoxButtons.OKCancel);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            {
                string gender;
                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                MessageBox.Show(gender, "Gender", MessageBoxButtons.OKCancel);
            }

            //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
            //{
            //    string items = string.Empty;
            //    if (checkbox.Checked)
            //        items += "\n Pencil";
            //    if (checkbox.Checked)
            //        items += "\n Sharpener";
            //    if (checkbox.Checked)
            //        items += "\n Pen";
            //    MessageBox.Show("You have bought: " + items);
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BuyButton_Click(object sender, EventArgs e)
        {

            string items = string.Empty;
            if (cp.Checked)
                items += "\n Pencil";
            if (cs.Checked)
                items += "\n Sharpener";
            if (cpp.Checked)
                items += "\n Pen";
            MessageBox.Show("You have bought: " + items, "Cart", MessageBoxButtons.OKCancel);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedItem.ToString() == "Tamil Nadu")
                {
                    comboBox2.Items.Add("Chennai");
                    comboBox2.Items.Add("Trichy");
                    comboBox2.Items.Add("Pondi");
                    comboBox2.Items.Add("Madurai");
                    comboBox2.Items.Add("Kanchipuram");
                }
                if (comboBox1.SelectedItem.ToString() == "Kerala")
                {
                    comboBox2.Items.Add("Kolam");
                    comboBox2.Items.Add("Cochin");
                    comboBox2.Items.Add("Thiruvandhapuram");
                }






            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                decimal price = nump1.Value;
                int quantity = (int)nump2.Value;
                decimal total; total = price * quantity;
                //MessageBox.Show(String.Format("The total price is {0:C}", total , "Price"));
                MessageBox.Show(String.Format("The total price is {0:C}", total), "Price",MessageBoxButtons.OKCancel);

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            lm.Text = "Month Calender Date : " + monthCalendar1.SelectionStart.ToLongDateString();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            labelyear.Text = "DateTimePicker Date: " + ly.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Muhammad Ali\source\repos\Picture.jpg");
        }
    }
}

