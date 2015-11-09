using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_privleges_AddCourse : System.Web.UI.Page
{
    /**********************************************************************
   * REPLACE THIS STRING WITH CONNECTIONSTRING FROM YOUR LOCAL DATABASE  *
   **********************************************************************/
    String myDatabase = "Data Source=USER-VAIO\\SQLEXPRESS;Initial Catalog=courseHunter540NEW;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

   
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection insertCon = new SqlConnection(myDatabase))
        { 
            insertCon.Open();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "insertCourses";
            cmdInsert.Connection= insertCon;
            
            insertCon.Close();
        }
    }
}