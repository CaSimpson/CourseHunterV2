using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for friendHandler
/// </summary>
public class friendHandler
{
    FriendDB friendDB = null;
    public friendHandler()
    {
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

}