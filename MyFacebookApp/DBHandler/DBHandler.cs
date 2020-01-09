using MyFacebookApp;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyFacebookApp.MyDBHandler
{
    public class DBHandler
    {
        //private static readonly object sr_Padlock = new object();
        private const string k_FileLastFriendsListPath = "./DB_LastCloseFriend.XML";

        // TOOD: for debug
        private static string g1 = Guid.NewGuid().ToString();
        private static string g2 = Guid.NewGuid().ToString();

        private static string e11 = Guid.NewGuid().ToString();
        private static string e12 = Guid.NewGuid().ToString();
        private static string e21 = Guid.NewGuid().ToString();

        private DBHandler()
        {
        }

        public string LastFriendsListPath { get { return k_FileLastFriendsListPath; } }

        public XmlDocument FetchAllUserRideGroupsIDs(string i_UserID)
        {
            // ...
            string[] innerText = { g1, g2 };
            XmlDocument xmlDoc = createXML("RideGroupIDs", "RideGroupID", innerText );

            return xmlDoc;
        }

        public XmlDocument FetchAllGroupRideEvents(string i_RideEventId)
        {
            // ...

            List<string> rideIds = new List<string>();
            XmlDocument xmlDoc;

            if (i_RideEventId == g1)
            {
                string[] inner = { e11, e12 };
                xmlDoc = createXML("RideGroupIDs", "RideGroupID", inner);

            }
            else if(i_RideEventId == g2)
            {
                string[] inner = { e21 };
                xmlDoc = createXML("RideGroupIDs", "RideGroupID", inner);
            }
            else
            {
                string[] inner = { "" };
                xmlDoc = createXML("RideGroupIDs", "RideGroupID", inner);
            }

            return xmlDoc;
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

        private XmlDocument createXML(string i_Root, string i_Child, string[] i_InnerText)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                XmlNode rootNode = xmlDoc.CreateElement(i_Root);
                xmlDoc.AppendChild(rootNode);
                foreach (string text in i_InnerText)
                {
                    XmlNode userNode = xmlDoc.CreateElement(i_Child);
                    userNode.InnerText = text;
                    rootNode.AppendChild(userNode);
                }
            }
            catch (Exception e)
            {
                //DoNothing
            }

            return xmlDoc;
        }

    }
}
