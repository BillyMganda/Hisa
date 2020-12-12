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
using System.Configuration;

namespace Hisa
{
    public partial class Authorize_LPOs : Form
    {
        public Authorize_LPOs()
        {
            InitializeComponent();            
        }
        static string connection=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connection1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //New Authentication method
        public int AuthenticationMethod(String Authorization)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Select * from UserInfo where AuthorizationCode=@AuthorizationCode", conn);
                cmd.Parameters.AddWithValue("@AuthorizationCode", Authorization);                
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    string authorizationsRole = dt.Rows[0]["Role"].ToString();                    
                    if (authorizationsRole.Equals("Manager"))                                                           
                    {
                        MessageBox.Show("LPO Authorised");
                        return 1;
                        //ToLPO tlp = new ToLPO();
                        //tlp.Show();
                        //return 1;
                    }
                    else if (authorizationsRole.Equals("Storekeeper"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("IT Support"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("Purchasing"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("HOD"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("Accounts"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("Requisitions"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                    else if (authorizationsRole.Equals("Statistics"))
                    {
                        MessageBox.Show("You are not allowed to perfom this function");
                        return 1;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               return 0;
        }
        //Login Button
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please input Authorization Code");
            }
            else
            try
            {
                int result = AuthenticationMethod(textBox1.Text);
                if (result == 0)
                {
                    MessageBox.Show("Invalid Authorization Code");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //when enter is hit after password 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }
        //cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //save data to Authorised_LPO when manager hits enter
        void AuthoriseLPO()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
