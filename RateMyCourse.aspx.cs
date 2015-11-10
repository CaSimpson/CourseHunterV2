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



public partial class RateMyCourse : System.Web.UI.Page
{

    /**********************************************************************
    * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
    **********************************************************************/
    String myDatabase = "Data Source=.\\SQLEXPRESS;Initial Catalog=courseHunter540NEW;Integrated Security=True";
    String userId;
    int currentRating = 0;
    List<int> allList = new List<int>();
    String item;
    List<String> formattedList = new List<String>();
    String strCurrentCourse;
    int currentCourse;
   
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
           


            //\ gets userName and UserID
            String currentUserName = HttpContext.Current.User.Identity.Name;
            userId = Membership.GetUser(currentUserName).ProviderUserKey.ToString();


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
                    }
                }
                sqlconn.Close();
            }

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


            //\sets currentcourse to whats selected in dropbox on load

            strCurrentCourse = courseDropBox.SelectedValue;

            SqlConnection conGetCid = new SqlConnection(myDatabase);
            SqlCommand cmdGetCid = new SqlCommand("getID", conGetCid);
            cmdGetCid.CommandType = CommandType.StoredProcedure;

            cmdGetCid.Parameters.AddWithValue("@courseNumber", strCurrentCourse);
            conGetCid.Open();
            currentCourse = (int)cmdGetCid.ExecuteScalar();
            conGetCid.Close();





        }


            if (!IsPostBack)
        {
            BindComment();
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {


            currentRating = Rating1.CurrentRating;

            System.Diagnostics.Debug.WriteLine("course id = " + currentCourse.ToString());


            //string connection = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection con = new SqlConnection(myDatabase);
            SqlDataAdapter da = new SqlDataAdapter("Insert into CommentSystem(UserId,Name,Rating,Comment,course_id) values('" + userId + "','" + txtName.Text + "','" + currentRating + "','" + txtComment.Text + "','" + currentCourse + "')", con);
            con.Open();
            da.SelectCommand.ExecuteNonQuery();
            con.Close();
            lblmessage.Text = "Comment posted successfully.";
            BindComment();
        }
        catch
        {
            lblmessage.Text = "sorry Error while posting comment.";
        }
    }







    private void BindComment()
    {
        //string connection = System.Configuration.ConfigurationManager.ConnectionStrings["con"].ToString();


        SqlConnection con = new SqlConnection(myDatabase);
        SqlDataAdapter da = new SqlDataAdapter("Select * from CommentSystem WHERE course_id = " + currentCourse, con);

        DataTable dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            gdvUserComment.DataSource = dt;
            gdvUserComment.DataBind();
        }


    }








    protected void courseDropBox_SelectedIndexChanged(object sender, EventArgs e)
    {

       



    }

    protected void Button2_Click(object sender, EventArgs e)
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
        
    }

    
}