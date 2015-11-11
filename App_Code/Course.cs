using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
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

    int courseId, credit;
    String  courseName, courseTitle;


    public Course(String cName)
    {
        courseName = cName;
    }

    public int getCreditValue()
    {
        SqlCommand cmdCredit = new SqlCommand("getCredits", con);
        cmdCredit.CommandType = CommandType.StoredProcedure;
        cmdCredit.Parameters.AddWithValue("@courseName", courseName);
        con.Open();
        credit = Convert.ToInt32(cmdCredit.ExecuteScalar());
        con.Close();

        return credit;
    }





}