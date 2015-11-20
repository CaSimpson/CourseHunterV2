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


public partial class Progress : System.Web.UI.Page
{
   

    List<int> completeCoursesInt = new List<int>();
    List<String> completeCourses = new List<String>();
    List<String> formattedList = new List<String>();
    List<String> remainingCourses = new List<String>();
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
            
            //\ Create student object
            Student student = new Student(userId);
            studentName = student.getName(); //\ returns student's name
            lblStudentName.Text = studentName; //\ sets student's name to label
            completeCourses = student.getTakenCourses(); //\ returns a list of completed courses
            remainingCourses = student.getNeededCourses();

            //\ adds taken courses to listbox
            foreach (String s in completeCourses)
            {
                completeListBox.Items.Add(s);
            }
            //\ adds taken courses to listbox
            foreach (String s in remainingCourses)
            {
                remainingListBox.Items.Add(s);
            }




            //************** This calculates percent of courses complete  ********************************************
            /*
                        //\ This calls store procedure to return a count for all courses
                        SqlConnection conCountAll = new SqlConnection(reidsDB);
                        SqlCommand cmdGetCountAll = new SqlCommand("countAll", conCountAll);
                        cmdGetCountAll.CommandType = CommandType.StoredProcedure;

                        conCountAll.Open();
                        totalCourses = Convert.ToInt32(cmdGetCountAll.ExecuteScalar());
                        conCountAll.Close();

                        //\ This calls store procedure to return a count for complete courses
                        SqlConnection conCountComplete = new SqlConnection(reidsDB);

                        SqlCommand cmdGetCountComplete = new SqlCommand("countComplete", conCountComplete);
                        cmdGetCountComplete.CommandType = CommandType.StoredProcedure;
                        cmdGetCountComplete.Parameters.AddWithValue("@studentID", userId);

                        conCountComplete.Open();
                        compCourses = Convert.ToInt32(cmdGetCountComplete.ExecuteScalar());
                        conCountComplete.Close();
                */


            compCourses = student.getCountComplete();
            totalCourses = student.getCountAll();

            myProg = (compCourses * 100) / totalCourses;

            //************* END Calculate Percent Complete ***************************************************

            lblCourseComplete.Text = compCourses.ToString();
            lblCourseRemaining.Text = (totalCourses - compCourses).ToString();
            int allCredits = 120;
            int takenCredits = 0;
            
            foreach(String s in completeCourses)
            {
                System.Diagnostics.Debug.Write("course = " + s);
                Course course = new Course(s);
                takenCredits += course.getCreditValue();
                System.Diagnostics.Debug.Write("takenCredits = " + takenCredits.ToString());
            }
            lblCreditComplete.Text = takenCredits.ToString();
            lblCreditRemaining.Text = (allCredits - takenCredits).ToString();

        }
        else
        {
            Response.Redirect("NotLoggedIn.aspx");
            Server.Transfer("NotLoggedIn.aspx");
        }

    } // END PAGE LOAD




}

