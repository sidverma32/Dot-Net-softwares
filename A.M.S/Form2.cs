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
namespace A.M.S
{
    public partial class Form2 : Form
    {
        //Initialization of variables
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Connection class
            con = new SqlConnection("user id=sa;pwd=123;database=student");
            cmd = new SqlCommand();
            cmd.Connection = con;
            panel1.Visible = false;
          panel2.Visible = false;


        }

      
        //fetch valid data of user from db
        private void button1_Click(object sender, EventArgs e)
        {//command to fetch data of profile tab
            con.Open();

            cmd = new SqlCommand("select * from register where sid='" + textBox1.Text + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                panel2.Visible = true;
                textBox5.Text = textBox1.Text;
                textBox7.Text = dr.GetString(1);
                textBox8.Text = dr.GetString(2);
               
                textBox10.Text = Convert.ToString(dr.GetValue(3));
                cmd.Dispose();
                con.Close();
            }
            else
            {
                MessageBox.Show("Invalid student id");
                con.Close();
            }

            con.Open();
            //commmand to retrieve a particular data from db
            cmd = new SqlCommand("select * from record where sid='" + textBox1.Text + "'", con);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                //if data match put hte content at appropriate place
                panel1.Visible = true;
                textBox2.Text = dr.GetString(1);
                textBox4.Text = Convert.ToString(dr.GetValue(2));
                cmd.Dispose();
                con.Close();
            }
            else
            {
                MessageBox.Show("Invalid student id");
                con.Close();
            }

        }
        //Mark your current day attendance
        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            try
            {
                cmd = new SqlCommand("Insert into daily values('" + textBox1.Text + "','" + radioButton1.Checked + "','" + DateTime.Now + "','" + textBox11.Text + "')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Your attendance is marked");
                textBox11.Text = null;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
                catch(Exception)
            {
                MessageBox.Show("Something went wrong,please try after sometime");
            }
            finally
            {
                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //redirection code from one form to another
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
           con.Open();
            try
            {
                cmd = new SqlCommand("update register set uname='" + textBox7.Text + "',pwd='" + textBox8.Text + "',mob='" +textBox10.Text.ToString() + "' where sid='" + textBox5.Text + "'",con);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("YOur profile updated");
               textBox5.Text= textBox7.Text = textBox8.Text =textBox10.Text = null;
                con.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Something went wrong");
                con.Close();
            }
           
           
      
        }

       
    }
}
