using MyFacebookApp.MyDBHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyFacebookApp
{
    public class DBHandlerAdapter
    {
        private readonly DBHandler r_DBHandler = Singleton<DBHandler>.Instance;

        public List<string> LoadLastFriendsList()
        {
            List<string> list = loadXMLList(r_DBHandler.LastFriendsListPath);
            return list;
        }

        public void writeLastFriendsList(List<string> i_NamesList)
        {
            string path = r_DBHandler.LastFriendsListPath;
            writeXMLList(i_NamesList, path);
        }
        
        public List<string> FetchAllUserRideGroupsIDs(string i_UserID)
        {
            XmlDocument doc = r_DBHandler.FetchAllUserRideGroupsIDs(i_UserID);
            List<string> rideGroupList = loadXMLFromDocToList(doc);

            return rideGroupList;
        }

        public List<string> FetchAllGroupRideEvents(string i_RideEventId)
        {
            XmlDocument doc = r_DBHandler.FetchAllGroupRideEvents(i_RideEventId);
            List<string> groupRideEventsList = loadXMLFromDocToList(doc);

            return groupRideEventsList;
        }

        public void SaveEventToGroupRide(string i_RideGroupId, string i_RideEventId)
        {
            r_DBHandler.SaveEventToGroupRide(i_RideGroupId, i_RideEventId);
        }

        private void writeXMLList(List<string> i_List, string i_Path)
        {
            r_DBHandler.WritrToXMLLastFreindsList(r_DBHandler.LastFriendsListPath, i_List);
        }

        private List<string> loadXMLList(string i_Path)
        {
            XmlDocument doc = r_DBHandler.LoadXMLFromPath(i_Path);
            List<string> listToReturn = loadXMLFromDocToList(doc);

            return listToReturn;
        }

        private List<string> loadXMLFromDocToList(XmlDocument i_XML)
        {
            List<string> listToReturn = new List<string>();

            foreach (XmlNode node in i_XML.DocumentElement.ChildNodes)
            {
                string nodeText = node.InnerText;
                listToReturn.Add(nodeText);
            }
            return listToReturn;
        }
    }
}
