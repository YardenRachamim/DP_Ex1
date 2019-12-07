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

            rideGroupIds.Add("0");
            rideGroupIds.Add("1");

            return rideGroupIds;
        }


        internal XmlDocument LoadXMLFromPath(string i_FilePath)
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

        internal void WritrToXMLLastFreindsList(string i_FilePath, List<string> i_Items)
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
