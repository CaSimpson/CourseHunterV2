using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    /**********************************************************************
  *                   CREATE YOUR CONNECTION STRINGS BELOW               *
  **********************************************************************/
    private static String coreysDB = WebConfigurationManager.ConnectionStrings["coreydb"].ConnectionString;

    /**********************************************************************
    * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
    **********************************************************************/
    private static String myDatabase = coreysDB;
    SqlConnection con = new SqlConnection(myDatabase);


    String name, userId, userName, major, aboutMe;
    List<String> coursesNeeded, coursesTaken, coursesAll = new List<String>();
    List<int> takenList = new List<int>();
    List<int> allList = new List<int>();
    List<int> needList = new List<int>();



    public Student(String id)
    {
        if(HttpContext.Current.User.Identity.IsAuthenticated)
        {

            userId = id;
            setStudentName();
            setUserName();
            setStudentMajor();
            setAboutMe();
            setCourseLists();





        }//\ END IF AUTHENTICATED
        
    }




    /****************************************************************************************
    *****************************************************************************************
    *********************************  METHODS **********************************************
    *****************************************************************************************
    ****************************************************************************************/


    private void setStudentName()
    {
        SqlCommand cmdName = new SqlCommand("getStudentName", con);
        cmdName.CommandType = CommandType.StoredProcedure;
        cmdName.Parameters.AddWithValue("@studentID", userId);

        con.Open();
        name = Convert.ToString(cmdName.ExecuteScalar());
        con.Close();
    }

    private void setStudentMajor()
    {
        SqlCommand cmdMajor = new SqlCommand("getMajor", con);
        cmdMajor.CommandType = CommandType.StoredProcedure;
        cmdMajor.Parameters.AddWithValue("@studentId", userId);

        con.Open();
        major = Convert.ToString(cmdMajor.ExecuteScalar());
        con.Close();
    }

    private void setAboutMe()
    {
        SqlCommand cmdAboutMe = new SqlCommand("getAboutMe", con);
        cmdAboutMe.CommandType = CommandType.StoredProcedure;
        cmdAboutMe.Parameters.AddWithValue("@studentId", userId);

        con.Open();
        aboutMe = Convert.ToString(cmdAboutMe.ExecuteScalar());
        con.Close();
    }

    private void setUserName()
    {
        SqlCommand cmdUserName = new SqlCommand("getUserName", con);
        cmdUserName.CommandType = CommandType.StoredProcedure;
        cmdUserName.Parameters.AddWithValue("@studentId", userId);

        con.Open();
        userName = Convert.ToString(cmdUserName.ExecuteScalar());
        con.Close();
    }

    private void setCourseLists()
    {
        //\ adds all courses_taken for user to takeList
        using (con)
        {
            SqlCommand cmdGetTaken = new SqlCommand("getCourseTaken", con);
            cmdGetTaken.CommandType = CommandType.StoredProcedure;
            cmdGetTaken.Parameters.AddWithValue("@studentid", userId);
            con.Open();
            using (IDataReader dataReader = cmdGetTaken.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int item = Convert.ToInt32(dataReader["course_id"]);
                    takenList.Add(item);
                }
            }
            con.Close();
        }

        //\ adds all courses to allList
        SqlConnection allCon = new SqlConnection(myDatabase);
        using (allCon)
        {
            SqlCommand cmd = new SqlCommand("getAllCourses", allCon);
            cmd.CommandType = CommandType.StoredProcedure;
            allCon.Open();
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    int item = Convert.ToInt32(dataReader["course_id"]);
                    allList.Add(item);
                }
            }
            allCon.Close();
        }//\ END USING

        needList = allList.Except(takenList).ToList();

        coursesAll = getCourseName(allList);
        coursesTaken = getCourseName(takenList);
        coursesNeeded = getCourseName(needList);




    }

    private List<String> getCourseName(List<int> intList)
    {
        List<String> convertedList = new List<String>();
        String currentCourseName;

        //\ gets course name for possible courses
        SqlConnection conGetName = new SqlConnection(coreysDB);

        SqlCommand cmdGetName = new SqlCommand("getCourseName", conGetName);
        cmdGetName.CommandType = CommandType.StoredProcedure;

        foreach (int c in intList)
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

    public String getName()
    {
        return name;
    }

    public String getUserName()
    {
        return userName;
    }

    public String getAboutMe()
    {
        return aboutMe;
    }

    public List<String> getAllCourses()
    {
        return coursesAll;
    }
    public List<String> getNeededCourses()
    {
        return coursesNeeded;
    }
    public List<String> getTakenCourses()
    {
        return coursesTaken;
    }

}