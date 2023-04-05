﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GatePassGenerator
{
    public partial class Form1 : Form
    {
        DatabaseOperations databaseOperations = new DatabaseOperations();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                query = "select * from appUser where username='" + txtUserName.Text+ "' and upass='" + txtPassword.Text + "' and uenabled=1";
                DataSet ds = databaseOperations.getData(query);
                if(ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    String role = ds.Tables[0].Rows[0][3].ToString();
                    Int64 appUserPk = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

                    Dashboard dashboard = new Dashboard(role);
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bad Credentials.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }catch(Exception ex){

                Console.WriteLine("Exception in btnLogin Click: " + ex);
                MessageBox.Show("Something went Wrong: " + ex, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }

      
    }
}
