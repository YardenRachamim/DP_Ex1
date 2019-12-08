using A20_Ex01_Maayan_312275431_Yarden_204623284;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DataHandler
{
    public class DBHandler
    {
        private static DBHandler s_DBHandler = null;
        private static readonly object sr_Padlock = new object();

        // TOOD: debug
        private static string g1 = Guid.NewGuid().ToString();
        private static string g2 = Guid.NewGuid().ToString();

        private static string e11 = Guid.NewGuid().ToString();
        private static string e12 = Guid.NewGuid().ToString();
        private static string e21 = Guid.NewGuid().ToString();

        private DBHandler()
        {
        }

        public static DBHandler GetInstance
        {
            get
            {
                if (s_DBHandler == null)
                {
                    lock (sr_Padlock)
                    {
                        if (s_DBHandler == null)
                        {
                            s_DBHandler = new DBHandler();
                        }
                    }
                }

                return s_DBHandler;
            }
        }

        public List<string> FetchAllUserRideGroupsIDs(string i_UserID)
        {
            // TODO: implement
            List<string> rideGroupIds = new List<string>();

            rideGroupIds.Add(g1);
            rideGroupIds.Add(g2);

            return rideGroupIds;
        }

        public List<string> FetchAllGroupRideEvents(string i_RideEventId)
        {
            // TODO: implement

            List<string> rideIds = new List<string>();

            if(i_RideEventId == g1)
            {
                rideIds.Add(e11);
                rideIds.Add(e12);

            }
            else if(i_RideEventId == g2)
            {
                rideIds.Add(e21);
            }

            return rideIds;
        }

        public void SaveEventToGroupRide(string i_RideGroupId, string i_RideEventId)
        {
            throw new NotImplementedException();
        }

        public XmlDocument LoadXMLFromPath(string i_FilePath)
        {
            XmlDocument doc = new XmlDocument();

            createFileIfNotExist(i_FilePath);
            doc.Load(i_FilePath);

            return doc;
        }

        private void createFileIfNotExist(string i_FilePath)
        {
            if (!File.Exists(i_FilePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(i_FilePath))
                {
                    sw.WriteLine("<lastFriendsList>");
                    sw.WriteLine("</lastFriendsList>");
                }
            }
        }

        public void WritrToXMLLastFreindsList(string i_FilePath, List<string> i_Items)
        {
            createFileIfNotExist(i_FilePath);
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("lastFriendsList");
                xmlDoc.AppendChild(rootNode);


                foreach (string friendName in i_Items)
                {

                    XmlNode userNode = xmlDoc.CreateElement("friend");

                    userNode.InnerText = friendName;
                    rootNode.AppendChild(userNode);
                }

                xmlDoc.Save(i_FilePath);
            }
            catch (Exception e)
            {
                //DoNothing
            }
        }
    }
}
