using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNet.Membership;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Security;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class searchUsers : System.Web.UI.Page
{
    String usernameInSearchBox="";
    String userId = "";
    protected List<student22> studentList;
    protected static string tempUserID="";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(HttpContext.Current.User.Identity.IsAuthenticated))
        {

            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/Default");
        }

        studentList = new List<student22>();
        seachAllUSers.Visible = false;
        userFoundLabel.Visible = false;
        usernameInSearchBox = searchBox.Text;
        
        storedProcedure myProcReader = new storedProcedure("getAllUsernames");
        DataTable dt = myProcReader.executeReader();


            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    String username = dr["UserName"].ToString();
                    student22 stud = new student22(username);
                    this.studentList.Add(stud);
                }
            }
        
        else
        {
            Console.WriteLine("No rows found.");
        }

        createTable();


    }//end of searchUsers class

    void btn_Click(object sender, EventArgs e)
    {

        string name= ((sender) as Button).ID;
        //send this username to the viewProfile page 
       // string name = usernameInSearchBox;
        Session["name"] = name;
        Response.Redirect("viewProfile.aspx");
    }

    private void createTable()
    {
        HtmlTable myTable = new HtmlTable();
        myTable.Attributes["class"] = "table";
        foreach (var student in studentList)
         {
            HtmlTableRow row = new HtmlTableRow();
            row.Attributes["class"] = "panel panel-success";

            HtmlTableCell cell1 = new HtmlTableCell();
             cell1.Attributes["class"] = "";

            var userNameLabel = new Label();
            userNameLabel.Text = student.getUsername();
            cell1.Controls.Add(userNameLabel);
            //cell1.InnerText = student.getUsername();
            row.Controls.Add(cell1);

            HtmlTableCell cell2 = new HtmlTableCell();
            Image img = new Image();
             img.Attributes["class"] = "thumbnail";
            img.Height = 150;
            img.Width = 150;
            img.AlternateText = "No image on file";
            img.ImageUrl = "ImageHandler.ashx?UserId=" + student.getStudent_id();
            //add the btn to cell3
            cell2.Controls.Add(img);
            //add cell3 to the row
            row.Controls.Add(cell2);

            HtmlTableCell cell3 = new HtmlTableCell();
            //create button
            Button btn = new Button();
            btn.Text = "view User Profile";
            btn.ID= student.getUsername(); 
            //event hadler for button
            btn.Click += new EventHandler(btn_Click);
            //add the btn to cell3
            cell3.Controls.Add(btn);
            //add cell3 to the row
            row.Controls.Add(cell3);

            //add all rows to table
            myTable.Controls.Add(row);


        }
        PlaceHolder1.Controls.Add(myTable);
    }

    public void search_Click(object sender, EventArgs e)
    {
        //if the user enters anything in the search  box
        if (!(String.IsNullOrEmpty(usernameInSearchBox)))
        {
            //check the entered text to see if it exist in the users table
            storedProcedure myProc = new storedProcedure("checkUserName");
            paramter param1 = new paramter("@theUsername", usernameInSearchBox);
            myProc.addParam(param1);
            //if that username exist the userID will be returned
            userId = myProc.executeScalarParam();

            //if the userId is not null or empty means the user was found
            if (!(String.IsNullOrEmpty(userId)))
            {
                userFoundLabel.Text = "user " + usernameInSearchBox + " found";
                userFoundLabel.Visible = true;

                //send this username to the viewProfile page 
                string name = usernameInSearchBox;
                Session["name"] = name;
                Response.Redirect("viewProfile.aspx");
            }
            else
            {
                userFoundLabel.Text = "" + usernameInSearchBox + " is not a valid username";
                userFoundLabel.Visible = true;
            }

        }
        else
        {
            userFoundLabel.Text ="Enter a username";
            userFoundLabel.Visible = true;
           
        }


    }//end of search_Click

    public void allUSers_Click(object sender, EventArgs e)
    {
        seachAllUSers.Visible = true;
    }

}