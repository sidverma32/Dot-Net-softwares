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
    public partial class Form1 : Form
    {
        //Initialization of SQL variables
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string sqlstr;
        public Form1()
        {
            InitializeComponent();
        }
        //Registration Portal Code
        private void button1_Click(object sender, EventArgs e)
        {
            

             if (textBox1.Text == "")
            {
                if (textBox2.Text == "")
                {
                    if (textBox3.Text == "")
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("You cannot leave blank");

                        }

                    }
                }
            }
            else
            {
            con.Open();//connection class open
            try
            {
                //sql command to insert data into table
                sqlstr = "insert into register(sid,uname,pwd,mob)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                ExecuteDML();

            }
            catch (Exception)
            {
                MessageBox.Show("ID already exist");

            }
            finally
            {
                con.Close();
            }
                }
        }


        private void ExecuteDML()
        {
            //Dialog box for user confirmation
            DialogResult d = MessageBox.Show("\n\nYou are ready to join A.M.S?", "Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                setstmt();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    MessageBox.Show("You are successfully registered,please login to continue");
            }
            else
                MessageBox.Show("Registration failed");
            con.Close();


        }

        private void setstmt()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
                cmd.CommandText = sqlstr;
                con.Open();

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("user id=sa;pwd=123;database=student");
            cmd = new SqlCommand();
            cmd.Connection = con;

        }

        //Login Portal Code
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                if (textBox6.Text == "")
                {
                    MessageBox.Show("You cannot leave blank");

                }

            }
            else
            {
                con.Open();
                //Code to Login valid user 
                cmd = new SqlCommand("select uname,pwd from register where uname='" + textBox5.Text + "'and pwd='" + textBox6.Text + "'", con);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //redirection from one form to another
                    Form2 f2 = new Form2();
                    f2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("invalid uname or pwd");
                    con.Close();
                }
            }
        }

      

       
    }
}
