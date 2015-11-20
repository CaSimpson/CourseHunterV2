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
using System.Web.Configuration;



public partial class profile : System.Web.UI.Page
{
    /**********************************************************************
   *                   CREATE YOUR CONNECTION STRINGS BELOW               *
   **********************************************************************/
    private static String reidsDB = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


    /**********************************************************************
   * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
   **********************************************************************/



    //store connection string for my Database in a string 
    String myDatabase = reidsDB;
    String userId;
    String username;
    String studentName;
    String majorName;
    String AboutYourselve;


    protected void Page_Load(object sender, EventArgs e)
    {
        //if user is logged in
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            //get the username 
            username = HttpContext.Current.User.Identity.Name;
            //get the userId from membership table 
            userId = Membership.GetUser(username).ProviderUserKey.ToString();


            //connect to the database
            SqlConnection sqlConnection1 = new SqlConnection(myDatabase);

            //getStudentName is the name of the stored procedure 
            SqlCommand cmd1 = new SqlCommand("getStudentName", sqlConnection1);

            //StoredProcedure is command type 
            cmd1.CommandType = CommandType.StoredProcedure;

            cmd1.Connection = sqlConnection1;

            //StoredProcedure has param 
            cmd1.Parameters.AddWithValue("@studentID", userId);

            sqlConnection1.Open();

            studentName = Convert.ToString(cmd1.ExecuteScalar());

            sqlConnection1.Close();

            //the lable studentName to be = to the name in student table
            //studentName.Text = name;

            //*************** END get Student Name ******************************************************

            //boxEnterName.Text = ""; //this is where the user will enter their new name so we make it empty  //\ this is give name value of ""



            //get all major names in the major table and add them to the drop down menu called majorsDropDown
            using (SqlConnection sqlConnection2 = new SqlConnection(myDatabase))
            {
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "getAllMajors";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Connection = sqlConnection2;

                sqlConnection2.Open();

                SqlDataReader reader = cmd2.ExecuteReader();

                if (reader.HasRows)
                {
                    majorsDropDown.Items.Clear();
                    majorsDropDown.Items.Insert(0, new ListItem("Select", ""));
                    while (reader.Read())
                    {
                        String major = Convert.ToString(reader["major_name"]);
                        majorsDropDown.Items.Add(major);
                    }
                }

                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();

                sqlConnection2.Close();
            }

            //this is just a test
            selValue.Text = majorsDropDown.SelectedValue;



            using (SqlConnection sqlConnection = new SqlConnection(myDatabase))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getNameMajorUserNameText";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@student_id", userId);

                cmd.Connection = sqlConnection;

                sqlConnection.Open();

                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
             //           String username;
            //            String studentName;
             //           String majorName;
            //            String AboutYourselve;

                        ///username = usernameLabel.Text = Convert.ToString(dataReader["UserName"]);
                        studentName = studentNameLabel.Text = Convert.ToString(dataReader["name"]);
                        majorName = majorNameLabel.Text = Convert.ToString(dataReader["major_name"]);
                        AboutYourselve = boxAboutYourselve.Text = Convert.ToString(dataReader["text"]);



                    }
                }

                sqlConnection.Close();
            }

        }


       // Button1.Click += new EventHandler(this.Update_Click);
    }


    public void Update_Click(object sender, EventArgs e)
    {

        String newUsername = "hello";
        String newName = "hello";
        String selectedMajor = "hello";
        String aboutMe = "hello";
 

        newUsername = boxEnterUsername.Text; 
        if (newUsername.Equals(""))
            newUsername = username;

        newName = txtName.Text;
        System.Diagnostics.Debug.WriteLine("newName = " + newName);
        if (newName.Equals(""))
            newName = studentName;

        selectedMajor = majorsDropDown.SelectedValue.ToString();
        if (selectedMajor.Equals(""))
            selectedMajor = "Computer Science"; //\  If major box is empty we need to get current major, if they leave this blank sqlexception becuase procedure requires @major_name value

        aboutMe = boxAboutYourselve.Text;
        

        using (SqlConnection sqlConnection4 = new SqlConnection(myDatabase))
        {
            SqlCommand cmd4 = new SqlCommand();
            cmd4.CommandText = "updateStudentInfo";
            cmd4.CommandType = CommandType.StoredProcedure;

            cmd4.Parameters.AddWithValue("@student_id", userId);
            cmd4.Parameters.AddWithValue("@UserName", newUsername);
            cmd4.Parameters.AddWithValue("@name", newName);
            cmd4.Parameters.AddWithValue("@major_name", selectedMajor);
            cmd4.Parameters.AddWithValue("@text", aboutMe);
            System.Diagnostics.Debug.WriteLine("studentID = " + userId);

            cmd4.Connection = sqlConnection4;

            sqlConnection4.Open();
            try
            {
                //execute the stored procedure 

                cmd4.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("query executed" + newName);
            }
           catch (SqlException)
            {

            }
            sqlConnection4.Close();
        }


    }

}