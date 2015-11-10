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


public partial class Progress : System.Web.UI.Page
{
    /**********************************************************************
   * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
   **********************************************************************/
    String myDatabase = "Data Source=.\\SQLEXPRESS;Initial Catalog=courseHunter540NEW;Integrated Security=True";

    List<int> completeCoursesInt = new List<int>();
    List<String> completeCourses = new List<String>();
    List<String> formattedList = new List<String>();
    String studentName;
    int totalCourses;
    int compCourses;

    public int myProg;
    int id = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {





            //\ gets userName and UserID
            String userName = HttpContext.Current.User.Identity.Name;
            String userId = Membership.GetUser(userName).ProviderUserKey.ToString();
            //String actualName;


            // ******************* This gets student's name from database and adds to lblStudentName *********************************

            //\ gets student name from student id
            SqlConnection con = new SqlConnection(myDatabase);
            SqlCommand cmdGetName = new SqlCommand("getStudentName", con);
            cmdGetName.CommandType = CommandType.StoredProcedure;
            cmdGetName.Parameters.AddWithValue("@studentId", userId);

            con.Open();
            studentName = Convert.ToString(cmdGetName.ExecuteScalar());
            con.Close();

            lblStudentName.Text = studentName;
            //*************** END set Student Name ******************************************************




            // ******************* This gets a list of all completed courses and adds to listbox *********************************

            //\ adds all courses_taken for user to completeCoursesInt array
            using (SqlConnection sqlconn = new SqlConnection(myDatabase))
            {
                SqlCommand cmd = new SqlCommand("getCourseTaken", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentid", userId);
                sqlconn.Open();
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int item = Convert.ToInt32(dataReader["course_id"]);
                        completeCoursesInt.Add(item);
                    }
                }
                sqlconn.Close();
            }

            //\ called getCourseName Method, which converts course_id to course_name
            completeCourses = getCourseName(completeCoursesInt);

            //\ adds all complete courses to Compete Courses List Box
            foreach (String s in completeCourses)
            {
                completeListBox.Items.Add(s);
            }
            //*************** END get complete courses list ******************************************************



            //************** This calculates percent of courses complete  ********************************************

            //\ This calls store procedure to return a count for all courses
            SqlConnection conCountAll = new SqlConnection(myDatabase);
            SqlCommand cmdGetCountAll = new SqlCommand("countAll", conCountAll);
            cmdGetCountAll.CommandType = CommandType.StoredProcedure;

            conCountAll.Open();
            totalCourses = Convert.ToInt32(cmdGetCountAll.ExecuteScalar());
            conCountAll.Close();

            //\ This calls store procedure to return a count for complete courses
            SqlConnection conCountComplete = new SqlConnection(myDatabase);

            SqlCommand cmdGetCountComplete = new SqlCommand("countComplete", conCountComplete);
            cmdGetCountComplete.CommandType = CommandType.StoredProcedure;
            cmdGetCountComplete.Parameters.AddWithValue("@studentID", userId);

            conCountComplete.Open();
            compCourses = Convert.ToInt32(cmdGetCountComplete.ExecuteScalar());
            conCountComplete.Close();

            myProg = (compCourses * 100) / totalCourses;

            //************* END Calculate Percent Complete ***************************************************




        }
        else
        {
            // then user is not logged in   redirect maybe???
        }

    } // END PAGE LOAD





    // method will convert list of course_id to list of course_names
    private List<String> getCourseName(List<int> intList)
    {
        List<String> convertedList = new List<String>();
        String currentCourseName;

        //\ gets course name for possible courses
        SqlConnection conGetName = new SqlConnection(myDatabase);

        SqlCommand cmdGetName = new SqlCommand("getCourseName", conGetName);
        cmdGetName.CommandType = CommandType.StoredProcedure;

        foreach (int c in completeCoursesInt)
        {

            cmdGetName.Parameters.AddWithValue("@courseID", c);
            conGetName.Open();
            currentCourseName = Convert.ToString(cmdGetName.ExecuteScalar());
            convertedList.Add(currentCourseName);
            cmdGetName.Parameters.Clear();
            conGetName.Close();
        }

        return convertedList;
    } // end getCourseName

    //Method CURRENTLY EMPTY
    public static int getProgress()
    {
        return 0;
    }



}