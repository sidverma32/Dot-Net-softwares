using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic; 
namespace DBOperations
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cb;
        DataSet ds;

        int rno = 0;
        public Form4()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("User Id=Sa;Password=123;Database=employee");
            da = new SqlDataAdapter("Select Eno, Ename, Job, Salary From Employee Order By Eno", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey; 
            ds = new DataSet();
            da.Fill(ds, "Employee");
           // ds.WriteXml("C:\\CSharp11\\Employee.xml");
            //ds.WriteXmlSchema("C:\\CSharp11\\Employee.xsd"); 
            ShowData(); 
        }
        private void ShowData()
        {
            textBox1.Text = ds.Tables[0].Rows[rno][0].ToString();
            textBox2.Text = ds.Tables[0].Rows[rno][1].ToString();
            textBox3.Text = ds.Tables[0].Rows[rno][2].ToString();
            textBox4.Text = ds.Tables[0].Rows[rno][3].ToString();
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            rno = 0;
            ShowData(); 
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (rno > 0)
            {
                rno -= 1;
                if (ds.Tables[0].Rows[rno].RowState == DataRowState.Deleted)
               
                
                
                {
                    MessageBox.Show("Deleted records can't be accessed");
                    return;
                }
                ShowData();
            }
            else
                MessageBox.Show("First record of the table"); 
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rno < ds.Tables[0].Rows.Count - 1)
            {
                rno += 1;
                if (ds.Tables[0].Rows[rno].RowState == DataRowState.Deleted)
                {
                    MessageBox.Show("Deleted records can't be accessed");
                    return;
                }
                ShowData();
            }
            else
                MessageBox.Show("Last record of the table"); 
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            rno = ds.Tables[0].Rows.Count - 1;
            ShowData(); 
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            int index = ds.Tables[0].Rows.Count - 1;
            int eno = Convert.ToInt32(ds.Tables[0].Rows[index][0]) + 1;
            textBox1.Text = eno.ToString();
            textBox2.Focus(); 
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = textBox1.Text; dr[1] = textBox2.Text;
            dr[2] = textBox3.Text; dr[3] = textBox4.Text;
            ds.Tables[0].Rows.Add(dr);
            rno = ds.Tables[0].Rows.Count - 1;
            MessageBox.Show("Record added to the DataTable of DataSet."); 
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[rno][1] = textBox2.Text;
            ds.Tables[0].Rows[rno][2] = textBox3.Text;
            ds.Tables[0].Rows[rno][3] = textBox4.Text;
            MessageBox.Show("DataRow of DataTable updated."); 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows[rno].Delete();
            MessageBox.Show("DataRow of DataTable deleted.");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //da.InsertCommand.CommandText = "Insert Stmt";
            //da.UpdateCommand.CommandText = "Update Stmt";
            //da.DeleteCommand.CommandText = "Delete Stmt";

            cb = new SqlCommandBuilder(da); 
            da.Update(ds, "Employee");
            MessageBox.Show("Data saved to database"); 
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string value = Interaction.InputBox("Enter Employee No to search");
            int eno = int.Parse(value);
            DataRow dr = ds.Tables[0].Rows.Find(eno);
            if (dr != null)
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
            }
            else
                MessageBox.Show("Employee doesn't exists."); 
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
