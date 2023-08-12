using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using System.Text;




namespace WebApplication3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["role"].Equals(" "))
                {

                    LinkButton2.Visible = true; // sign up link button

                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button


                    LinkButton5.Visible = true; // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button


                }
                else if (Session["role"].Equals("user"))
                {

                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    LinkButton5.Visible = true; // admin login link button
                    LinkButton11.Visible = false; // author management link button
                    LinkButton12.Visible = false; // publisher management link button
                    LinkButton8.Visible = false; // book inventory link button
                    LinkButton9.Visible = false; // book issuing link button
                }
                else if (Session["role"].Equals("admin"))
                {

                    LinkButton2.Visible = false; // sign up link button

                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                    LinkButton5.Visible = false; // admin login link button
                    LinkButton11.Visible = true; // author management link button
                    LinkButton12.Visible = true; // publisher management link button
                    LinkButton8.Visible = true; // book inventory link button
                    LinkButton9.Visible = true; // book issuing link button
                }

            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");

        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {


        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {


        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
          

            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";




            LinkButton2.Visible = true; // sign up link button

            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button


            LinkButton5.Visible = true; // admin login link button
            LinkButton11.Visible = false; // author management link button
            LinkButton12.Visible = false; // publisher management link button
            LinkButton8.Visible = false; // book inventory link button
            LinkButton9.Visible = false; // book issuing link button
            if (IsPostBack)
            {
                // Check if the page is loaded from cache (Back/Forward button was clicked)
                if (Request.Headers["Cache-Control"] == "max-age=0" || Request.Headers["Cache-Control"] == "no-cache")
                {
                    Session.Clear();
                    // Redirect to the login page
                    Response.Redirect("/homepage.aspx");
                }
                else
                {
                    // Check if the user is already logged in and redirect to the homepage
                    if (Session["role"].Equals(" "))
                    {
                        Session.Clear();
                        Response.Redirect("/homepage.aspx");
                    }
                }
            }



            




        }
        

        // view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton12_Click1(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");

        }

        protected void LinkButton2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");

        }
      

    }
}