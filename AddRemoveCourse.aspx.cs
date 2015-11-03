using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using Microsoft.AspNet.Membership;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.Security;

public partial class AddRemoveCourse : System.Web.UI.Page
{
    private String userId;

    char[][] transferArray = new char[99][];
    String[] checkedArray;
    List<String> checkedList = new List<String>();
    public List<String> courseList = new List<String>();
    public List<String> neededList = new List<String>();
    List<String> preReqList = new List<String>();

    public static ResultsBuilder rb;


    protected void Page_Load(object sender, EventArgs e)
    {

        //\ gets userName and UserID
        String currentUserName = HttpContext.Current.User.Identity.Name;
        userId = Membership.GetUser(currentUserName).ProviderUserKey.ToString();



        //create connection to database

        using (SqlConnection sqlconn = new SqlConnection("Data Source=C-lomain\\cssqlserver;Initial Catalog=courseHunter540NEW;Integrated Security=True"))
        {
            //create adapter
            SqlDataAdapter sqlda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            SqlCommand cmdGetAll = new SqlCommand();
            cmdGetAll.CommandType = CommandType.StoredProcedure;
            cmdGetAll.CommandText = "getAllCourses";
            cmdGetAll.Connection = sqlconn;

            sqlda.SelectCommand = cmdGetAll;
            sqlda.Fill(ds, "course");

            //fill course List
            foreach (DataRow row in ds.Tables["course"].Rows)
            {
                courseList.Add(row["course_id"].ToString());
                //listboxComplete.Items.Add(row["course_id"].ToString());
            }

            sqlconn.Close();


           





            ns101DropBox.Items.Add("BIOL U101");
            ns102DropBox.Items.Add("BIOL U102");
            ns101DropBox.Items.Add("CHEM U111");
            ns102DropBox.Items.Add("CHEM U112");
            ns101DropBox.Items.Add("PHYS U211");
            ns102DropBox.Items.Add("PHYS U212");
            ns103DropBox.Items.Add("BIOL U101");
            ns103DropBox.Items.Add("CHEM U111");
            ns103DropBox.Items.Add("PHYS U211");

            art101DropBox.Items.Add("AFAM U204");
            art101DropBox.Items.Add("ARTH U101");
            art101DropBox.Items.Add("ARTH U105");
            art101DropBox.Items.Add("ARTH U106");
            art101DropBox.Items.Add("MUSC U110");
            art101DropBox.Items.Add("MUSC U140");
            art101DropBox.Items.Add("THEA U161");
            art101DropBox.Items.Add("THEA U170");

            his101DropBox.Items.Add("HIST U101");
            his101DropBox.Items.Add("HIST U102");
            his101DropBox.Items.Add("HIST U105");
            his101DropBox.Items.Add("HIST U106");

            hum101DropBox.Items.Add("AMST U101");
            hum101DropBox.Items.Add("AMST U102");
            hum101DropBox.Items.Add("ENGL U250");
            hum101DropBox.Items.Add("ENGL U252");
            hum101DropBox.Items.Add("ENGL U275");
            hum101DropBox.Items.Add("ENGL U279");
            hum101DropBox.Items.Add("ENGL U280");
            hum101DropBox.Items.Add("ENGL U283");
            hum101DropBox.Items.Add("ENGL U289");
            hum101DropBox.Items.Add("ENGL U290");
            hum101DropBox.Items.Add("ENGL U291");
            hum101DropBox.Items.Add("FILM U240");
            hum101DropBox.Items.Add("PHIL U102");
            hum101DropBox.Items.Add("PHIL U211");
            hum101DropBox.Items.Add("RELG U103");
            hum101DropBox.Items.Add("AFAM U204");
            hum101DropBox.Items.Add("ARTH U101");
            hum101DropBox.Items.Add("ARTH U105");
            hum101DropBox.Items.Add("ARTH U106");
            hum101DropBox.Items.Add("MUSC U110");
            hum101DropBox.Items.Add("MUSC U140");
            hum101DropBox.Items.Add("THEA U161");
            hum101DropBox.Items.Add("THEA U170");


            for101DropBox.Items.Add("SPAN U101");
            for101DropBox.Items.Add("CHIN U101");
            for101DropBox.Items.Add("FREN U101");
            for101DropBox.Items.Add("GERM U101");
            for101DropBox.Items.Add("ASLG U101");

            soc101DropBox.Items.Add("AFAM U201");
            soc101DropBox.Items.Add("ANTH U102");
            soc101DropBox.Items.Add("ECON U221");
            soc101DropBox.Items.Add("ECON U222");
            soc101DropBox.Items.Add("GEOG U101");
            soc101DropBox.Items.Add("GEOG U103");
            soc101DropBox.Items.Add("POLI U101");
            soc101DropBox.Items.Add("POLI U200");
            soc101DropBox.Items.Add("POLI U320");
            soc101DropBox.Items.Add("PSYC U101");
            soc101DropBox.Items.Add("SOCY U101");
            soc101DropBox.Items.Add("WGST U101");

            soc102DropBox.Items.Add("AFAM U201");
            soc102DropBox.Items.Add("ANTH U102");
            soc102DropBox.Items.Add("ECON U221");
            soc102DropBox.Items.Add("ECON U222");
            soc102DropBox.Items.Add("GEOG U101");
            soc102DropBox.Items.Add("GEOG U103");
            soc102DropBox.Items.Add("POLI U101");
            soc102DropBox.Items.Add("POLI U200");
            soc102DropBox.Items.Add("POLI U320");
            soc102DropBox.Items.Add("PSYC U101");
            soc102DropBox.Items.Add("SOCY U101");
            soc102DropBox.Items.Add("WGST U101");





        }



    }




    protected void btnSubmit_Click(object sender, EventArgs e)
    {


        //scans web controls and adds all "checked" checkboxes to checkedList
        foreach (Control c in uiPlaceholder.Controls.OfType<CheckBox>())
        {
            if (c is CheckBox && ((CheckBox)c).Checked)
            {
                String formattedID = c.ID; //holds value of formatted ID
                //\ if id < 7 than it contains a checkbox, and we call getID method to return it
                if (c.ID.Length < 7)
                {
                    formattedID = getID(c.ID);
                }
                //\ if not grab the id of the checkbox and add a space(because of id formatting)
                else
                {
                    formattedID = formattedID.Insert(4, " ");
                }
                //\ this adds each courseID (formatted properly) that was "checked" to a list
                checkedList.Add(formattedID);
            }//end if
        }//end foreach


        List<int> intChecked = new List<int>();


        //conC.Open();

        SqlConnection conGetID = new SqlConnection("Data Source=C-lomain\\cssqlserver;Initial Catalog=courseHunter540NEW;Integrated Security=True");
        SqlCommand cmdGetID = new SqlCommand();

        int idValue;

        foreach (String s in checkedList)
        {
            cmdGetID.CommandText = "getID";
            cmdGetID.CommandType = CommandType.StoredProcedure;
            cmdGetID.Connection = conGetID;
            cmdGetID.Parameters.AddWithValue("@courseNumber", s);
            conGetID.Open();
            idValue = (int)cmdGetID.ExecuteScalar();
            cmdGetID.Parameters.Clear();
            intChecked.Add(idValue);
            conGetID.Close();
        }


        //gets the difference of completed courses and all courses
        IEnumerable<String> allNeeded = courseList.Except(checkedList);

        // This uses build in method Exept to find the differece of all courses and completed
        // This list will be the courses needed to complete degree
        List<String> needcourses = courseList.Except(checkedList).ToList();

        //\ Create ResultsBuilder Object, which needs a list of completed and needed courses
        //rb = new ResultsBuilder(checkedList, needcourses);











        // older code
        //\ This will create a new table to save the user's list of needed courses
        // String createTbl = "CREATE TABLE "+ id +"(courseIdAndNumber text);";

        // SqlConnection cont = new SqlConnection("Data Source=c-lomain\\cssqlserver;Initial Catalog=test1;Integrated Security=True");
        //cont.Open();
        //SqlCommand cmdt = new SqlCommand(createTbl, cont);
        // SqlDataReader reader = cmdt.ExecuteReader();
        //cont.Close();


        //\ This creates connection to database and stores completed courses for the user.
        //\ by using stored procedure that takes student id and course id as parameters
        SqlConnection conC = new SqlConnection("Data Source=C-lomain\\cssqlserver;Initial Catalog=courseHunter540NEW;Integrated Security=True");
        //conC.Open();

        foreach (int i in intChecked)
        {
            using (SqlCommand cmd = new SqlCommand("addTaken", conC))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentid", userId);
                cmd.Parameters.AddWithValue("@courseid", i);
                conC.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {

                }
            }

            conC.Close();
        }

        /*
                List<String> testList = new List<String>();

                using (SqlConnection sqlconn = new SqlConnection("Data Source=c-lomain\\cssqlserver;Initial Catalog=coursehunterdb;Integrated Security=True"))
                {
                    //\ This will check each course you need and see if you meet prereqs
                    //  foreach(String s in neededCourses)
                    //  {
                    //\ This cmd will give a list of all prereq for current course
                    SqlCommand cmd = new SqlCommand(";WITH CTE AS ( " +
                                                        "SELECT DISTINCT M1.course_id group_id, M1.course_id FROM " +
                                                        "Prerequisites M1 LEFT JOIN Prerequisites M2 ON M1.course_id = M2.prereq_id " +
                                                        " UNION ALL SELECT C.group_id, M.prereq_id " +
                                                        "FROM CTE C JOIN Prerequisites M ON C.course_id = M.course_id) " +
                                                        "SELECT * FROM CTE ORDER BY course_id", sqlconn);

                    sqlconn.Open();

                    //\ adds all prereqs for current couses to list
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            String groupID = Convert.ToString(dataReader["group_id"]);
                            String courseID = Convert.ToString(dataReader["course_id"]);
                            testList.Add(groupID);
                            //prereqTemp[0] = groupID;
                            //prereqTemp[1] = courseID;
                            //possibleCourses.Add(groupID);
                            //prereqList.Add(prereqTemp); //\ a list of current prereqs for current course 's'
                        }
                    }
                }



                */


        // ResultsBuilder r = new ResultsBuilder(checkedList, needcourses);
        //List<String> testPossible = r.getPossible();

        //foreach(String s in testList)
        // {
        //listboxComplete.Items.Add(s);
        // }
        foreach (String s in needcourses)
        {
            // listboxRecommend.Items.Add(s);
        }

        /* OLD CODE
        //\ this populates the newly created table
            String insertStmt = "INSERT INTO " + id +"(courseIdAndNumber) " + "VALUES(@courseId)";

        using (SqlConnection con = new SqlConnection("Data Source=c-lomain\\cssqlserver;Initial Catalog=test1;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand(insertStmt, con))
        {
            cmd.Parameters.Add("@courseId", SqlDbType.Text);

            con.Open();

            foreach (String s in needcourses)
            {
                cmd.Parameters["@courseId"].Value = s;
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        
    */
        //SqlCommand sqlCmd = new SqlCommand("CREATE TABLE " + id + " (takencourses varchar(9))",con);
        //SqlCommand sqlCmd2;
        //foreach (String s in needcourses)
        //{
        //char[] tempValue = s.ToCharArray();
        //SqlCommand sqlCmd2 = new SqlCommand("INSERT INTO testid (courseIdAndNumber) VALUES ("+        +")", con);
        //sqlCmd2.ExecuteNonQuery();
        // }

        //con.Close();
        //SqlCommand sqlCmd2 = new SqlCommand("INSERT INTO testid (courseIdAndNumber) VALUES (@VarChar)", con);

        //sqlCmd2.Parameters.Add("@VarChar", SqlDbType.VarChar, 9);
        //sqlCmd2.Parameters["@VarChar"].Value = ms.GetBuffer();
        // sqlCmd2.ExecuteNonQuery();






        //|||||||| TESTING PURPOSES ONLY
        foreach (String s in checkedList)
        {
            //listboxComplete.Items.Add(s);
        }

        foreach (int s in intChecked)
        {
            //if (!checkedList.Contains(s))
            //{
            // listboxRecommend.Items.Add(s.ToString());
            //}
        }



        foreach (String s in courseList)
        {

        }


        Response.Redirect("Results.aspx");
        Server.Transfer("Results.asps");



        //\\\\\\\\\\\\\\\ END TESTING CODE
    }



    //\ Remove selected courses

    protected void btnRemove_Click(object sender, EventArgs e)
    {

        List<String> removeChecked = new List<String>();

        removeChecked = getChecked();

        List<int> removeInt = new List<int>();

        removeInt = getCourseId(removeChecked);




        SqlConnection conR = new SqlConnection("Data Source=c-lomain\\cssqlserver;Initial Catalog=courseHunter540;Integrated Security=True");
        //conC.Open();

        foreach (int i in removeInt)
        {
            using (SqlCommand cmd = new SqlCommand("removeTaken", conR))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentid", userId);
                cmd.Parameters.AddWithValue("@courseid", i);
                conR.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {

                }
            }

            conR.Close();
        }

    }





    /********************************************************************************************************************
    **************************************************************************************   METHODS   ******************
    ********************************************************************************************************************/


    //\ private method that gets selected value from a droplistbox 
    //\ parameters: curID is the id of the checkbox
    private String getID(String curID)
    {
        //\ this tells us which droplistbox we need to get a value from
        switch (curID)
        {
            case "ns101": curID = ns101DropBox.SelectedValue;
                break;
            case "ns102": curID = ns102DropBox.SelectedValue;
                break;
            case "art101": curID = art101DropBox.SelectedValue;
                break;
            case "his101": curID = his101DropBox.SelectedValue;
                break;
            case "hum101": curID = hum101DropBox.SelectedValue;
                break;
            case "for101": curID = for101DropBox.SelectedValue;
                break;
            case "soc101": curID = soc101DropBox.SelectedValue;
                break;
            case "soc102": curID = soc102DropBox.SelectedValue;
                break;
        }
        return curID;
    }//\ END getID




    //\ Returns a formatted List<String> of all courses checked
    private List<String> getChecked()
    {
        List<String> returnList = new List<String>();

        foreach (Control c in uiPlaceholder.Controls.OfType<CheckBox>())
        {
            if (c is CheckBox && ((CheckBox)c).Checked)
            {
                String formattedID = c.ID; //holds value of formatted ID
                //\ if id < 7 than it is in dropbox and is formatted, so we call getID method to return it
                if (c.ID.Length < 7)
                {
                    formattedID = getID(c.ID); //\ calls getID method
                }
                //\ if not grab the id of the checkbox and add a space(because of id formatting)
                else
                {
                    formattedID = formattedID.Insert(4, " ");
                }
                //\ this adds each courseID (formatted properly) that was "checked" to a list
                returnList.Add(formattedID);
            }//end if
        }//end foreach

        return returnList;
    }


   



private List<int> getCourseId(List<String> inputList)
    {
        List<int> intChecked = new List<int>();

        SqlConnection conGetID = new SqlConnection("Data Source=C-lomain\\cssqlserver;Initial Catalog=courseHunter540NEW;Integrated Security=True");
        SqlCommand cmdGetID = new SqlCommand();

        int idValue;

        foreach (String s in inputList)
        {
            cmdGetID.CommandText = "getID";
            cmdGetID.CommandType = CommandType.StoredProcedure;
            cmdGetID.Connection = conGetID;
            cmdGetID.Parameters.AddWithValue("@courseNumber", s);
            conGetID.Open();
            idValue = (int)cmdGetID.ExecuteScalar();
            cmdGetID.Parameters.Clear();
            intChecked.Add(idValue);
            conGetID.Close();
        }


        return intChecked;
    }




    }