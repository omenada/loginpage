using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        string ConnectionString = "Server=apartment.mssql.somee.com;Database=apartment;User Id=daniomena_SQLLogin_1;Password=x8qc4bjh5f";
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConnectionString;
           
           
            try
            {
                //open the connection
                myConnection.Open();
                //Perform the command
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = String.Format(
                   "SELECT * FROM Login WHERE UserId= '{0}' AND Password= '{1}'",
                   txtusername.Text.Trim().Replace("\"", ",").Replace(";", ""),
                   txtpassword.Text.Trim().Replace("\"", ",").Replace(";", ""));

                myCommand.Connection = myConnection;

                SqlDataReader myDataReader = myCommand.ExecuteReader();
                if (myDataReader.Read())
                {
                    //MessageBox.Show("Logged in!");

                    myInfo infoFromLogin = new myInfo();
                    infoFromLogin.loginMessage = "Welcome!! You are " + txtusername.Text;

                    //pass it on 
                    Main newForm = new Main(infoFromLogin);
                    newForm.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Not Found!");

                }


                //perform the command
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            finally
            {
                //always close

                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();

                }

            }
        }
    }
}
