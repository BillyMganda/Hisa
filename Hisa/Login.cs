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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        static string connection=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connection1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //new method
        public int Loginmethod (String Username,String Password)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand("Select * from UserInfo where UserName=@Username and Password=@Password", conn);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["Role"].ToString();
                    //HOD Role
                    if (role.Equals("HOD"))
                    {
                        this.Hide();
                        HOD_Module hod = new HOD_Module(dt.Rows[0]["FullNames"].ToString());
                        hod.Show();                       
                        return 1;
                    }
                    //Requisitions Role
                    else if (role.Equals("Requisitions"))
                    {
                        this.Hide();
                        Requisitions rqs = new Requisitions(dt.Rows[0]["FullNames"].ToString());
                        rqs.Show();                        
                        return 1;
                    }
                    //Accounts Role
                    else if (role.Equals("Accounts"))
                    {
                        this.Hide();
                        Accounts_Module am = new Accounts_Module(dt.Rows[0]["FullNames"].ToString());
                        am.Show();                        
                        return 1;
                    }
                    //IT Support Role
                    else if (role.Equals("IT Support"))
                    {
                        this.Hide();
                        IT_Support its = new IT_Support(dt.Rows[0]["FullNames"].ToString());
                        its.Show();                        
                        return 1;
                    }
                    //Manager Role
                    else if (role.Equals("Manager"))
                    {
                        this.Hide();
                        Managers_Module mm = new Managers_Module(dt.Rows[0]["FullNames"].ToString());
                        mm.Show();                        
                        return 1;
                    }
                    //Purchasing Role
                    else if (role.Equals("Purchasing"))
                    {
                        this.Hide();
                        Purchasing p = new Purchasing(dt.Rows[0]["FullNames"].ToString());
                        p.Show();                        
                        return 1;
                    }
                    //Statistics Role
                    else if (role.Equals("Statistics"))
                    {
                        this.Hide();
                        Statistics st = new Statistics(dt.Rows[0]["FullNames"].ToString());
                        st.Show();                        
                        return 1;
                    }
                    //Storekeeper Role
                    else if (role.Equals("Storekeeper"))
                    {
                        this.Hide();
                        Storekeeper sk = new Storekeeper(dt.Rows[0]["FullNames"].ToString());
                        sk.Show();                        
                        return 1;
                    }
                }
               
                return 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //login button
        private void btnLogin_Click(object sender, EventArgs e)
        {                  
           
                try
                {
                int result = Loginmethod(txtUserName.Text, txtPassword.Text);
                if (result == 0)
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }
        //when enter is hit after password 
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }

      
    }

