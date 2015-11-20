using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.AspNet.Membership;
using System.Web.Security;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Configuration;



public partial class RateMyCourse : System.Web.UI.Page
{
    /**********************************************************************
    *                   CREATE YOUR CONNECTION STRINGS BELOW               *
    **********************************************************************/
    private static String defaultDatabase = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


    /**********************************************************************
   * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
   **********************************************************************/



    //store connection string for my Database in a string 
    String myDatabase = defaultDatabase;
    String userId;
    int currentRating = 0;
    List<int> allList = new List<int>();
    String item;
    List<String> formattedList = new List<String>();
    List<String> allCourses = new List<String>();
    String strCurrentCourse;
    int currentCourse;
    Student student;
    Comment comment;
   
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
           


            //\ gets userName and UserID
            String currentUserName = HttpContext.Current.User.Identity.Name;
            userId = Membership.GetUser(currentUserName).ProviderUserKey.ToString();

            student = new Student(userId);
            comment = new Comment(userId);

            /*

            //\ adds all courses to allList
            using (SqlConnection sqlconn = new SqlConnection(myDatabase))
            {
                SqlCommand cmd = new SqlCommand("getAllCourses", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlconn.Open();
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int item = Convert.ToInt32(dataReader["course_id"]);
                        allList.Add(item);
                        //System.Diagnostics.Debug.Print("course id = " + item);
                    }
                }
                sqlconn.Close();
            }
            */
            allCourses = student.getAllCourses(); 

            foreach(String s in allCourses)
            {
                courseDropBox.Items.Add(s);
            }

            /*
            String currentCourseName;

            //\ gets course name for all courses and adds to dropbox
            SqlConnection conGetName = new SqlConnection(myDatabase);

            SqlCommand cmdGetName = new SqlCommand("getCourseName", conGetName);
            cmdGetName.CommandType = CommandType.StoredProcedure;

            foreach (int c in allList)
            {

                cmdGetName.Parameters.AddWithValue("@courseID", c);
                conGetName.Open();
                currentCourseName = Convert.ToString(cmdGetName.ExecuteScalar());
                courseDropBox.Items.Add(currentCourseName);
                cmdGetName.Parameters.Clear();
                conGetName.Close();
            }
        */

            //\sets currentcourse to whats selected in dropbox on load

            strCurrentCourse = courseDropBox.SelectedValue;
            currentCourse = student.getCourseName(strCurrentCourse);


            /*

            SqlConnection conGetCid = new SqlConnection(myDatabase);
            SqlCommand cmdGetCid = new SqlCommand("getID", conGetCid);
            cmdGetCid.CommandType = CommandType.StoredProcedure;

            cmdGetCid.Parameters.AddWithValue("@courseNumber", strCurrentCourse);
            conGetCid.Open();
            currentCourse = (int)cmdGetCid.ExecuteScalar();
            conGetCid.Close();



            checkComment();
            */
        }
        else
        {
            Response.Redirect("NotLoggedIn.aspx");
            Server.Transfer("NotLoggedIn.aspx");
        }


            if (!IsPostBack)
        {
            BindComment();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        

            currentRating = Rating1.CurrentRating;


            System.Diagnostics.Debug.WriteLine("course id = " + currentCourse.ToString());
            
            bool success = comment.addComment(txtName.Text, currentRating, txtComment.Text, currentCourse);

          


            if (success == true)
            {
                lblmessage.Text = "Comment posted successfully.";
                BindComment();
            }
        else { lblmessage.Text = "sorry Error while posting comment."; }
        
            
        
        clearLabels();

    }







    private void BindComment()
    {


        SqlConnection con = new SqlConnection(myDatabase);
        SqlCommand cmdBindComment = new SqlCommand("bindComment", con);
        cmdBindComment.CommandType = CommandType.StoredProcedure;
        cmdBindComment.Parameters.AddWithValue("@courseid", currentCourse);
        SqlDataAdapter da = new SqlDataAdapter(cmdBindComment);

        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            gdvUserComment.Visible = true;
            gdvUserComment.DataSource = dt;
            gdvUserComment.DataBind();


            

        }
        else
        {
            gdvUserComment.Visible = false;
        }
        checkComment();
        
    }




    private void checkComment()
    {
        SqlConnection con = new SqlConnection(myDatabase);
        SqlCommand cmdCheckComment = new SqlCommand("checkComment", con);
        cmdCheckComment.CommandType = CommandType.StoredProcedure;
        cmdCheckComment.Parameters.AddWithValue("@userid", userId);
        cmdCheckComment.Parameters.AddWithValue("@courseid", currentCourse);
        con.Open();
        int hasComment = Convert.ToInt32(cmdCheckComment.ExecuteScalar());
        con.Close();
        if(hasComment > 0)
        {
            btnRemove.Visible = true;
        }
        else
        {
            btnRemove.Visible = false;
        }

    }



    protected void courseDropBox_SelectedIndexChanged(object sender, EventArgs e)
    {


        //\sets currentcourse to whats selected in dropbox on load

        strCurrentCourse = courseDropBox.SelectedItem.Text;

        SqlConnection conGetCid = new SqlConnection(myDatabase);
        SqlCommand cmdGetCid = new SqlCommand("getID", conGetCid);
        cmdGetCid.CommandType = CommandType.StoredProcedure;

        cmdGetCid.Parameters.AddWithValue("@courseNumber", strCurrentCourse);
        conGetCid.Open();
        currentCourse = (int)cmdGetCid.ExecuteScalar();
        conGetCid.Close();
        //System.Diagnostics.Debug.WriteLine("course id = " + currentCourse.ToString());

        BindComment();
        clearLabels();


    }

    





    protected void btnRemove_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(myDatabase);
        
            using (SqlCommand cmdRemoveTaken = new SqlCommand("removeComment", con))
            {
                cmdRemoveTaken.CommandType = CommandType.StoredProcedure;
                cmdRemoveTaken.Parameters.AddWithValue("@userid", userId);
                cmdRemoveTaken.Parameters.AddWithValue("@courseid", currentCourse);
                con.Open();
                try
                {
                    cmdRemoveTaken.ExecuteNonQuery();
                }
                catch (SqlException)
                {

                }
            }
            con.Close();
        BindComment();
        clearLabels();
        
    }

    private void clearLabels()
    {
        txtName.Text = "";
        txtComment.Text = "";
        Rating1.CurrentRating = 0;
    }

}