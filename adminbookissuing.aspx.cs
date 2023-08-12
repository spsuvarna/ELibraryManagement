using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication3
{
    
    public partial class adminbookissuing : System.Web.UI.Page
    {
        Business b = new Business();
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                //SqlDataSource1.SelectParameters.Clear();

                //SqlDataSource1.SelectCommand = "SELECT * FROM book_issue_tbl";
                //SqlDataSource1.DataBind();
                //GridView1.DataBind();
            }

        // issue book
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    Response.Write("<script>alert('This Member already has this book');</script>");
                }
                else
                {
                    issueBook();
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }
        // return book
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This Entry does not exist');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        // go button click event
        protected void Button1_Click(object sender, EventArgs e)
        {

             getNames();
            getMember();
            
        }




        // user defined function

        void returnBook()
        {
            bool result = false;
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            result = b.returnBook(a);
            Response.Write("<script>alert('Book Returned Successfully');</script>");
            clearForm();

            GridView1.DataBind();
        }

        void issueBook()
        {
            bool result = false;
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            a.member_name = TextBox3.Text;
            a.book_name = TextBox4.Text;
            a.issue_date = TextBox5.Text;
            a.due_date = TextBox6.Text;
            result = b.insertbookissue(a);
            Response.Write("<script>alert('Book Issued Successfully');</script>");
            clearForm();

            GridView1.DataBind();
        }

        bool checkIfBookExist()
        {
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;

            DataTable dt = new DataTable();
            dt = b.getBookExists(a);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool checkIfMemberExist()
        {
            Author_Details a = new Author_Details();
            a.member_id = TextBox2.Text;

            DataTable dt = new DataTable();
            dt = b.getMemberExists(a);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool checkIfIssueEntryExist()
        {
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            DataTable dt = new DataTable();
            dt = b.checkIfIssueEntryExist(a);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        void getNames()
        {

            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            DataTable dt = new DataTable();
            dt = b.getNames(a);
            if (dt.Rows.Count >= 1)
            {
                TextBox4.Text = dt.Rows[0]["book_name"].ToString();


            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID');</script>");
            }
        }
        void getMember()
        {
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            //a.member_name = TextBox3.Text;
            //a.book_name = TextBox4.Text;
            //a.issue_date = TextBox5.Text;
            //a.due_date = TextBox6.Text;
            DataTable dt = new DataTable();
            dt = b.getmemberId(a);
            if (dt.Rows.Count >= 1)
            {
                TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                TextBox5.Text = dt.Rows[1]["issue_date"].ToString();
                TextBox6.Text = dt.Rows[2]["due_date"].ToString();
            }
            else
            {
                Response.Write("<script>alert('');</script>");
            }
           
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            //TextBox7.Text = "";
           

        }
        public void updateBook()
        {
            try
            {
                bool result = false;
                Author_Details a = new Author_Details();
                a.book_id = TextBox1.Text;
                a.member_id = TextBox2.Text;
                a.member_name = TextBox3.Text;
                a.book_name = TextBox4.Text;
                a.issue_date = TextBox5.Text;
                a.due_date = TextBox6.Text;

                result = b.updateAdminBookIssue(a);
                Response.Write("<script>alert('updated successfully.');</script>");
                clearForm();
                //GridView1.DataBind();

            }
            catch (Exception)
            {

                throw;
            }


        }



        protected void Button3_Click1(object sender, EventArgs e)
        {
            if (checkIfBookExist() && checkIfMemberExist())
            {

                if (checkIfIssueEntryExist())
                {
                    updateBook();
                }
                

            }
            else
            {
                Response.Write("<script>alert('Wrong Book ID or Member ID');</script>");
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            TextBox TextBox1 = (TextBox)gvr.FindControl("TextBox1");
            TextBox TextBox2 = (TextBox)gvr.FindControl("TextBox2");
            TextBox TextBox3 = (TextBox)gvr.FindControl("TextBox3");
            TextBox TextBox4 = (TextBox)gvr.FindControl("TextBox4");
            TextBox TextBox5 = (TextBox)gvr.FindControl("TextBox5");
            TextBox TextBox6 = (TextBox)gvr.FindControl("TextBox6");
            bool result = false;
            Author_Details a = new Author_Details();
            a.book_id = TextBox1.Text;
            a.member_id = TextBox2.Text;
            a.member_name = TextBox3.Text;
            a.book_name = TextBox4.Text;
            a.issue_date = TextBox5.Text;
            a.due_date = TextBox6.Text;

            result = b.updateAdminBookIssue(a);
            if (result == true)

            {
                GridView1.EditIndex = -1;

                GridView1.DataBind();
                string CloseWindow = "alert('Successfully updated book details')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
                return;
            }
            else
            {
                string CloseWindow = "alert('Failed to update book details')";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", CloseWindow, true);
                return;
            }
            

           

        }

        protected void GridViewBookTitledetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                GridViewRow rowSelect = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int rowindex = rowSelect.RowIndex;
                Label hiddenField1 = (Label)GridView1.Rows[rowindex].FindControl("book_id");
                int bookid = Convert.ToInt32(hiddenField1.Text);


                SqlDataSource1.SelectParameters.Clear();
                SqlDataSource1.SelectCommand = "SELECT member_id,member_name,book_id,book_name,issue_date,due_date from book_issue_tbl";
                SqlDataSource1.SelectCommandType = SqlDataSourceCommandType.Text;

                SqlDataSource1.DataBind();
                GridView1.DataBind();
                //GridViewBookTitledetails.DataBind();

               

                

            }

        }

        protected void GridViewBookTitledetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

        }

        protected void GridViewBookTitledetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();

        }

        protected void GridViewBookTitledetails_DataBound(object sender, EventArgs e)
        {
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                TextBox member_id = gvRow.FindControl("TextBox2") as TextBox;
                TextBox book_id = gvRow.FindControl("TextBox1") as TextBox;
                TextBox member_name = gvRow.FindControl("TextBox3") as TextBox;
                TextBox book_name = gvRow.FindControl("TextBox4") as TextBox;
                TextBox issue_date = gvRow.FindControl("TextBox5") as TextBox;
                TextBox due_date = gvRow.FindControl("TextBox6") as TextBox;




            }
        }
    }
}