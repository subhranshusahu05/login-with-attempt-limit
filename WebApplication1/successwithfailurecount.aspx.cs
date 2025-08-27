using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class successwithfailurecount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtname.Text = "";
                txtname.Focus();
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text == "admin@123" && txtpassword.Text == "12345")
                {
                    
                    Response.Redirect("loginwhithfailurecount.aspx?Name=" + txtname.Text);
                }
                else
                {
                    
                    int count = 0;
                    if (ViewState["failurecount"] != null)
                    {
                        count = (int)ViewState["failurecount"];
                    }

                    count++; 

                    if (count >= 3)
                    {
                        Response.Redirect("failurewithfailurecount.aspx?Name=" + txtname.Text);
                    }

                    ViewState["failurecount"] = count;
                    Label1.Text = count + " Attempt(s) Failed. Maximum 3 attempts allowed.";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtpassword.Text = "";
            Label1.Text = "";
            txtname.Focus();
            ViewState["failurecount"] = 0; 
        }





    }
}