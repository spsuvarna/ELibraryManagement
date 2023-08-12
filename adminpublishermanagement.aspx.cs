using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication3
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        Business b = new Business();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // add publisher
        protected void Button2_Click(object sender, EventArgs e)
        {
           
            if (checkPublisherExists())
            {
                Response.Write("<script>alert('Publisher Already Exist with this ID.');</script>");
            }
            else
            {
                addNewPublisher();
            }
        }
        // update publisher
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                updatePublisherByID();
            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID does not exist');</script>");
            }
        }
        // delete publisher
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkPublisherExists())
            {
                deletePublisherByID();
            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID does not exist');</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            getPublisherByID();
        }




        // user defined functions

        void getPublisherByID()
        {
            try
            {
                Author_Details a = new Author_Details();
                DataTable dt = new DataTable();

                a.publisher_id = TextBox1.Text;
                a.publisher_name = TextBox2.Text;
                a.publisher_dob = TextBox3.Text;
                dt = b.getPublisherData(a);
                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                }

            }
            catch (Exception)
            {

                throw;
            }
            

            
        }

        bool checkPublisherExists()
        {
            try
            {
                Author_Details a = new Author_Details();
                DataTable dt = new DataTable();
                a.publisher_id = TextBox1.Text;
                a.publisher_name = TextBox2.Text;
                a.publisher_dob = TextBox3.Text;
                dt = b.checkExists(a);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
           
          
        }

        void addNewPublisher()
        {
            try
            {
                bool result = false;
                Author_Details a = new Author_Details();
                a.publisher_id = TextBox1.Text;
                a.publisher_name = TextBox2.Text;
                a.publisher_dob = TextBox3.Text;
                result = b.insertpublisherdetails(a);
                Response.Write("<script>alert('Publisher added successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
            
           
        }

        public void updatePublisherByID()
        {
            try
            {
                bool result = false;
                Author_Details a = new Author_Details();
                a.publisher_id = TextBox1.Text;
                a.publisher_name = TextBox2.Text;
                a.publisher_dob = TextBox3.Text;
                result = b.updatepublisherdetails(a);
                Response.Write("<script>alert('Publisher updated successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
           

        }


        public void deletePublisherByID()
        {
            try
            {
                bool result = false;
                Author_Details a = new Author_Details();
                a.publisher_id = TextBox1.Text;
                result = b.deletepublisherdeatails(a);
                Response.Write("<script>alert('Publisher deleted successfully.');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
            
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            
        }


    }
}