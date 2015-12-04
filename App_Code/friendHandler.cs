﻿using System;
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
using System.Collections;
using System.Web.Configuration;

/// <summary>
/// Summary description for friendHandler
/// </summary>
public class friendHandler
{
    FriendDB friendDB = null;
    private List<String> friendIDList;

    public friendHandler()
    {
        this.friendIDList = new List<String>();
        friendDB = new FriendDB();
    }


    public bool checkIfFriend(string user_id, string friend_id)
    {
        DataTable dt = friendDB.checkIfFriend(user_id, friend_id);


        if (dt.Rows.Count <1)
        {
            //if less than one means there is no row that the as a this user_id and friend_id means they are not fiends
            return false;
        }

        else
        {
            return true;
        }
        

    }


    public void addFriend(string user_id, string friend_id)
    {
        friendDB.addFriend(user_id, friend_id);
    }

    public void removeFriend(string user_id, string friend_id)
    {
        friendDB.removeFriend(user_id, friend_id);
    }

    public List<String> getFriendsList(string user_id)
    {
        
       DataTable friendsTable = friendDB.getFriendsList(user_id);


        if (friendsTable.Rows.Count > 0)
        {
            foreach (DataRow dr in friendsTable.Rows)
            {
                String friendID = dr["friend_id"].ToString();
                this.friendIDList.Add(friendID);
            }
        }

        else
        {
            Console.WriteLine("No rows found.");
        }

        return this.friendIDList;

    }

    /*
    public List<String> mutualFriends(string user_id, string visitedUser_Id)
    {

        DataTable friendsTable = friendDB.mutualFriends(user_id, visitedUser_Id);


        if (friendsTable.Rows.Count > 0)
        {
            foreach (DataRow dr in friendsTable.Rows)
            {
                String friendID = dr["friend_id"].ToString();
                this.friendIDList.Add(friendID);
            }
        }

        else
        {
            Console.WriteLine("No rows found.");
        }

        return this.friendIDList;

    }
    */

}