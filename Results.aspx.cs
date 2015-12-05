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

public partial class Results : System.Web.UI.Page
{
    /**********************************************************************
   *                   CREATE YOUR CONNECTION STRINGS BELOW               *
   **********************************************************************/
    private static String defaultDatabase = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


    /**********************************************************************
   * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
   **********************************************************************/
    String myDatabase = defaultDatabase;


    List<int> takenList = new List<int>();
    List<int> allList = new List<int>();
    List<int> possibleList = new List<int>();
    List<int> needList = new List<int>();
    List<String> strTakenList = new List<String>();
    List<String> strAllList = new List<String>();
    List<String> strPossibleList = new List<String>();
    List<String> strNeedList = new List<String>();
    int[] recIntList = new int[5];
    String[] recList = new String[5];
    List<String> formattedList = new List<String>();
    Student student;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(HttpContext.Current.User.Identity.IsAuthenticated))
        {

            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("~/Default");
        }

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {



            //\ gets userName and UserID
            String userName = HttpContext.Current.User.Identity.Name;
            String userId = Membership.GetUser(userName).ProviderUserKey.ToString();

            student = new Student(userId);

            strTakenList = student.getTakenCourses();
            takenList = student.getTakenInt();
            strAllList = student.getAllCourses();
            allList = student.getCourseName(strAllList);


           
            //\ creates need list and Creates resultbuilder object
            needList = student.getNeededInt();
            ResultsBuilder rs = new ResultsBuilder(needList, takenList);
            //\ finds possible courses and inits possible list
            rs.findPossible();
            possibleList = rs.getPossible();
            rs.findRecommended();
            //recIntList = rs.getRecommended();
            int[][] recArray =   rs.getRecommended();


            String currentCourseName;

            //\ gets course name for possible courses
            SqlConnection conGetName = new SqlConnection(myDatabase);

            SqlCommand cmdGetName = new SqlCommand("getCourseName", conGetName);
            cmdGetName.CommandType = CommandType.StoredProcedure;

            foreach (int c in possibleList)
            {

                cmdGetName.Parameters.AddWithValue("@courseID", c);
                conGetName.Open();
                currentCourseName = Convert.ToString(cmdGetName.ExecuteScalar());
                formattedList.Add(currentCourseName);
                cmdGetName.Parameters.Clear();
                conGetName.Close();
            }


            //\ gets course name for recommended courses
            SqlConnection conGetRec = new SqlConnection(myDatabase);

            SqlCommand cmdGetRec = new SqlCommand("getCourseName", conGetRec);
            cmdGetRec.CommandType = CommandType.StoredProcedure;

            for (int i = 0; i < 5; i++)
            {

                cmdGetRec.Parameters.AddWithValue("@courseID", recArray[i][0]);
                conGetRec.Open();
                currentCourseName = Convert.ToString(cmdGetRec.ExecuteScalar());
                recList[i] = currentCourseName;
                cmdGetRec.Parameters.Clear();
                conGetRec.Close();
            }


            rec1.Text = " 1.  " + recList[0];
            rec2.Text = " 2.  " + recList[1];
            rec3.Text = " 3.  " + recList[2];
            rec4.Text = " 4.  " + recList[3];
            rec5.Text = " 5.  " + recList[4];

           

            formattedList.Sort();
            
            foreach (String i in formattedList)
            {
               allPosListBox.Items.Add(i.ToString());
            }

            foreach (String i in formattedList)
            {
                //allPosListBox.Items.Add(i);
            }

            
        }
        else
        {
            Response.Redirect("NotLoggedIn.aspx");
            Server.Transfer("NotLoggedIn.aspx");
        }
    }
}
















/*
 ▄████▄   ▒█████   ██▀███  ▓█████ ▓██   ██▓     ██████  ██▓ ███▄ ▄███▓ ██▓███    ██████  ▒█████   ███▄    █ 
▒██▀ ▀█  ▒██▒  ██▒▓██ ▒ ██▒▓█   ▀  ▒██  ██▒   ▒██    ▒ ▓██▒▓██▒▀█▀ ██▒▓██░  ██▒▒██    ▒ ▒██▒  ██▒ ██ ▀█   █ 
▒▓█    ▄ ▒██░  ██▒▓██ ░▄█ ▒▒███     ▒██ ██░   ░ ▓██▄   ▒██▒▓██    ▓██░▓██░ ██▓▒░ ▓██▄   ▒██░  ██▒▓██  ▀█ ██▒
▒▓▓▄ ▄██▒▒██   ██░▒██▀▀█▄  ▒▓█  ▄   ░ ▐██▓░     ▒   ██▒░██░▒██    ▒██ ▒██▄█▓▒ ▒  ▒   ██▒▒██   ██░▓██▒  ▐▌██▒
▒ ▓███▀ ░░ ████▓▒░░██▓ ▒██▒░▒████▒  ░ ██▒▓░   ▒██████▒▒░██░▒██▒   ░██▒▒██▒ ░  ░▒██████▒▒░ ████▓▒░▒██░   ▓██░
░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒▓ ░▒▓░░░ ▒░ ░   ██▒▒▒    ▒ ▒▓▒ ▒ ░░▓  ░ ▒░   ░  ░▒▓▒░ ░  ░▒ ▒▓▒ ▒ ░░ ▒░▒░▒░ ░ ▒░   ▒ ▒ 
  ░  ▒     ░ ▒ ▒░   ░▒ ░ ▒░ ░ ░  ░ ▓██ ░▒░    ░ ░▒  ░ ░ ▒ ░░  ░      ░░▒ ░     ░ ░▒  ░ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░
░        ░ ░ ░ ▒    ░░   ░    ░    ▒ ▒ ░░     ░  ░  ░   ▒ ░░      ░   ░░       ░  ░  ░  ░ ░ ░ ▒     ░   ░ ░ 
░ ░          ░ ░     ░        ░  ░ ░ ░              ░   ░         ░                  ░      ░ ░           ░ 
░ 
*/
