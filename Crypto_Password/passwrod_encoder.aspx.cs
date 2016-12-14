using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace AngularJSwithNET
{
    public partial class passwrod_encoder : System.Web.UI.Page
    {



        char[] s1 = new char[10];
        char[] s2 = new char[10];
        char[] s3 = new char[10];
        int[] assinged = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        char[] c = new char[11];

        int[] val = new int[11];
        int topc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {




            if (RadioButtonList1.SelectedIndex == 0)
            {
                s1 = "base".ToCharArray();
                s2 = "ball".ToCharArray();
                s3 = "games".ToCharArray();

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                s1 = "send".ToCharArray();
                s2 = "more".ToCharArray();
                s3 = "money".ToCharArray();
            }
            else if (RadioButtonList1.SelectedIndex == 2)
            {
                s1 = "roads".ToCharArray();
                s2 = "cross".ToCharArray();
                s3 = "danger".ToCharArray();
            }
            int flag = 0;



            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s1[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s1[i];
            }
            for (int i = 0; i < s2.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s2[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s2[i];
            }
            for (int i = 0; i < s3.Length; i++)
            {
                for (int j = 0; j <= topc; j++)
                {
                    if (s3[i] != c[j])
                        flag = 1;
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1)
                    c[topc++] = s3[i];
            }

            if (solve(0, assinged) == 1)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    // label4.Text += "\n" + c[i] + "--->" + val[i].ToString() + "\n";
                    TextBox2.Text += val[i].ToString();
                }
            }
            else { }
            SqlConnection conn = new SqlConnection("user id=sa;pwd=123;database=pwd_enco");
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into enco values('" + TextBox1.Text + "','" + RadioButtonList1.SelectedItem + "','" +  TextBox2.Text+ "')", conn);
                cmd.ExecuteNonQuery();
                TextBox1.Text = null; TextBox2.Text = null; ;
                cmd.Dispose();
                Label1.Text = "<h4>Data received</h4>";
            }
            catch (Exception e1)
            {
                Label1.Text = "<h4> User password already exist</h4>";
            }
            finally
            {
                conn.Close();
            }

        }
        // label4.Text = "Sorry";





        //-------------------end of getdata-----------------




        int solve(int ind, int[] temp1)
        {

            int[] temp2 = new int[10];
            int flag = 0;
            for (int i = 0; i < 10; i++)
            {
                if (temp1[i] == 0)
                {
                    for (int j = 0; j < 10; j++)
                        temp2[j] = temp1[j];
                    temp2[i] = 1;
                    val[ind] = i;
                    if (ind == (topc - 1))
                    {
                        if (verify() == 1)
                        {
                            flag = 1;
                            goto exit;
                        }
                    }
                    else
                    {
                        if (solve(ind + 1, temp2) == 1)
                        {
                            flag = 1;
                            goto exit;
                        }
                    }
                }
            }
        exit:
            if (flag != 0)
                return 1;
            else
                return 0;

        }

        int verify()
        {

            long n1 = 0, n2 = 0, n3 = 0;
            long power = 1;
            char ch;
            int i = s1.Length - 1;
            int in1;
            while (i >= 0)
            {
                ch = s1[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                n1 += power * val[in1];
                power *= 10;
                i--;
            }
            power = 1;
            i = s2.Length - 1;
            while (i >= 0)
            {
                ch = s2[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                n2 += power * val[in1];
                power *= 10;
                i--;
            }
            power = 1;
            i = s3.Length - 1;
            while (i >= 0)
            {
                ch = s3[i];
                in1 = 0;
                while (in1 != topc)
                {
                    if (c[in1] == ch)
                        break;
                    else
                        in1++;
                }
                n3 += power * val[in1];
                power *= 10;
                i--;
            }
            if (n1 + n2 == n3)
                return 1;
            else
                return 0;






           
        }
    }
}