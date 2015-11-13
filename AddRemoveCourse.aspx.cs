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
using System.Web.Configuration;

public partial class AddRemoveCourse : System.Web.UI.Page
{
    private String userId;

    char[][] transferArray = new char[99][];
    String[] checkedArray;
    List<String> checkedList = new List<String>();
    public List<String> courseList = new List<String>();
    public List<String> neededList = new List<String>();
    List<String> preReqList = new List<String>();
    Student student;

    public static ResultsBuilder rb;

    /**********************************************************************
   *                   CREATE YOUR CONNECTION STRINGS BELOW               *
   **********************************************************************/
    private static String coreysDB = WebConfigurationManager.ConnectionStrings["coreydb"].ConnectionString;



    /**********************************************************************
    * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
    **********************************************************************/
    String myDatabase = coreysDB;


    protected void Page_Load(object sender, EventArgs e)
    {



        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {

            //\ gets userName and UserID
            String currentUserName = HttpContext.Current.User.Identity.Name;
            userId = Membership.GetUser(currentUserName).ProviderUserKey.ToString();

            student = new Student(userId);

            /*          LEAVE THIS FOR NOW
            //create connection to database

            using (SqlConnection sqlconn = new SqlConnection(myDatabase))
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

        */
            setTakenCourses();



            //\ adds optional courses to dropbox
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
        else { }

    }



    //\ add button
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {


            //\ gets a string list of checked items
            List<String> strChecked = new List<String>();
            strChecked = getChecked();
            //\ gets a int list of checked items
            List<int> intChecked = new List<int>();
            intChecked = getCourseId(strChecked);
            //\ adds all selected to courses_taken table
            student.addCoursesTaken(intChecked);


            // I think i can delete this, testing 
            //gets the difference of completed courses and all courses
            IEnumerable<String> allNeeded = courseList.Except(strChecked);
            // This uses build in method Exept to find the differece of all courses and completed
            // This list will be the courses needed to complete degree
            List<String> needcourses = courseList.Except(strChecked).ToList();



            foreach (String s in needcourses)
            {
                // listboxRecommend.Items.Add(s);
            }



            //|||||||| TESTING PURPOSES ONLY
            foreach (String s in checkedList)
            {
            }
            foreach (int s in intChecked)
            {
            }
            foreach (String s in courseList)
            {
            }


            Response.Redirect("Progress.aspx");
            Server.Transfer("Progress.aspx");



            //\\\\\\\\\\\\\\\ END TESTING CODE
        }

        setTakenCourses();
    }



    //\ Remove selected courses

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            //\ gets list of checked checkboxes
            List<String> removeChecked = new List<String>();
            removeChecked = getChecked();
            //\ converts strings to int
            List<int> removeInt = new List<int>();
            removeInt = getCourseId(removeChecked);

            //\ call removeCourseTaken from student object
            student.removeCoursesTaken(removeInt);
            Response.Redirect("Progress.aspx");
            Server.Transfer("Progress.aspx");
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
            case "ns101": curID = ns101DropBox.SelectedValue.ToString();
                break;
            case "ns102": curID = ns102DropBox.SelectedValue.ToString();
                break;
            case "ns103": curID = ns103DropBox.SelectedValue.ToString();
                break;
            case "art101": curID = art101DropBox.SelectedValue.ToString();
                break;
            case "his101": curID = his101DropBox.SelectedValue.ToString();
                break;
            case "hum101": curID = hum101DropBox.SelectedValue.ToString();
                break;
            case "for101": curID = for101DropBox.SelectedValue.ToString();
                break;
            case "soc101": curID = soc101DropBox.SelectedValue.ToString();
                break;
            case "soc102": curID = soc102DropBox.SelectedValue.ToString();
                break;
        }
        return curID;
    }//\ END getID




    //\ Returns a formatted List<String> of all courses checked
    private List<String> getChecked()
    {
        List<String> returnList = new List<String>();
        /*
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
                */

        foreach (Control c in addPanel.Controls)
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
            }
        }





        return returnList;
    }






    private List<int> getCourseId(List<String> inputList)
    {

        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {


            List<int> intChecked = new List<int>();

            SqlConnection conGetID = new SqlConnection(myDatabase);
            SqlCommand cmdGetID = new SqlCommand();

            int idValue;

            foreach (String s in inputList)
            {
                cmdGetID.CommandText = "getID";
                cmdGetID.CommandType = CommandType.StoredProcedure;
                cmdGetID.Connection = conGetID;
                cmdGetID.Parameters.AddWithValue("@courseNumber", s);
                conGetID.Open();
                idValue = Convert.ToInt32(cmdGetID.ExecuteScalar());
                cmdGetID.Parameters.Clear();
                intChecked.Add(idValue);
                conGetID.Close();
            }


            return intChecked;
        }
        else
        {
            List<int> returnList = new List<int>();
            return returnList;
        }
    }

    private void setTakenCourses()
    {
        // List<int> intAllCourses = new List<int>();
        //intAllCourses = student.getAllCourses();
        //List<String> strAllCourses = new List<String>();
        // strAllCourses = student.getAllCourses();

        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();
        List<String> strCoursesTaken = new List<String>();

        foreach (String s in strCoursesTakenRAW)
        {

            String formattedID = s;
            formattedID = formattedID.Remove(4, 1);

            strCoursesTaken.Add(formattedID);
        }



        foreach (WebControl c in addPanel.Controls.OfType<CheckBox>())
        {
            if (strCoursesTaken.Contains(c.ID))
            {

                ((CheckBox)c).BackColor = System.Drawing.Color.Red;

            }//end if
            else
            {
                ((CheckBox)c).BackColor = System.Drawing.Color.Green;
            }
        }//end foreach


    }






    protected void his101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = his101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            his101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            his101.BackColor = System.Drawing.Color.Green;
        }
        */
        dropBoxAltered();

    }







    protected void ns101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = ns101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            ns101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            ns101.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void ns102DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = ns102DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            ns102.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            ns102.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void art101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = art101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            art101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            art101.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void hum101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = hum101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            hum101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            hum101.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void for101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = for101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            for101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            for101.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void soc101DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = soc101DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            soc101.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            soc101.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void soc102DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {/*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = soc102DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            soc102.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            soc102.BackColor = System.Drawing.Color.Green;
        }*/
        dropBoxAltered();

    }

    protected void ns103DropBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropBoxAltered();
        /*
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        String curVal = ns103DropBox.SelectedValue.ToString();

        if (strCoursesTakenRAW.Contains(curVal))
        {
            ns103.BackColor = System.Drawing.Color.Red;
        }
        else
        {
            ns103.BackColor = System.Drawing.Color.Green;
        }
        */
    }

    private void dropBoxAltered()
    {
        List<String> strCoursesTakenRAW = new List<String>();
        strCoursesTakenRAW = student.getTakenCourses();

        foreach (WebControl d in addPanel.Controls.OfType<DropDownList>())
        {
            String curVal = ((DropDownList)d).SelectedValue.ToString();
            ListBox1.Items.Add(curVal);

            if (strCoursesTakenRAW.Contains(curVal))
            {
                switch (d.ID)
                {
                    case "ns101DropBox":
                        ns101.BackColor = System.Drawing.Color.Red;
                        break;
                    case "ns102DropBox":
                        ns102.BackColor = System.Drawing.Color.Red; break;
                    case "ns103DropBox":
                        ns103.BackColor = System.Drawing.Color.Red; break;
                    case "art101DropBox":
                        art101.BackColor = System.Drawing.Color.Red; break;
                    case "his101DropBox":
                        his101.BackColor = System.Drawing.Color.Red; break;
                    case "hum101DropBox":
                        hum101.BackColor = System.Drawing.Color.Red; break;
                    case "for101DropBox":
                        for101.BackColor = System.Drawing.Color.Red; break;
                    case "soc101DropBox":
                        soc101.BackColor = System.Drawing.Color.Red; break;
                    case "soc102DropBox":
                        soc102.BackColor = System.Drawing.Color.Red; break;
                }


            }//end if
            else
            {
                switch (d.ID)
                {
                    case "ns101DropBox":
                        ns101.BackColor = System.Drawing.Color.Green;
                        break;
                    case "ns102DropBox":
                        ns102.BackColor = System.Drawing.Color.Green; break;
                    case "ns103DropBox":
                        ns103.BackColor = System.Drawing.Color.Green; break;
                    case "art101DropBox":
                        art101.BackColor = System.Drawing.Color.Green; break;
                    case "his101DropBox":
                        his101.BackColor = System.Drawing.Color.Green; break;
                    case "hum101DropBox":
                        hum101.BackColor = System.Drawing.Color.Green; break;
                    case "for101DropBox":
                        for101.BackColor = System.Drawing.Color.Green; break;
                    case "soc101DropBox":
                        soc101.BackColor = System.Drawing.Color.Green; break;
                    case "soc102DropBox":
                        soc102.BackColor = System.Drawing.Color.Green; break;
                }
            }
        }//end foreach
    }




}