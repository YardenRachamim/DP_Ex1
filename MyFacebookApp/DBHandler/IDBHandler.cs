using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyFacebookApp.MyDBHandler
{
    public interface IDBHandler
    {
        XmlDocument FetchAllUserRideGroupsIDs(string i_UserID);

        XmlDocument FetchAllGroupRideEvents(string i_RideEventId);

        void SaveEventToGroupRide(string i_RideGroupId, string i_RideEventId);

        XmlDocument LoadXMLFromPath(string i_FilePath);

        void WritrToXMLLastFreindsList(string i_FilePath, List<string> i_Items);
    }
} 
