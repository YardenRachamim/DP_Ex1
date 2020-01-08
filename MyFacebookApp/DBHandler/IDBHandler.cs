using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyFacebookApp.MyDBHandler
{
    public interface IDBHandler
    {
        List<string> FetchAllUserRideGroupsIDs(string i_UserID);

        List<string> FetchAllGroupRideEvents(string i_RideEventId);

        void SaveEventToGroupRide(string i_RideGroupId, string i_RideEventId);

        List<string> LoadLastFriendsList();

        void WriteLastFriendsList(List<string> i_NamesList);
    }
} 
