using DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MyFacebookApp
{
    public static class XMLToListAdapter
    {
        private static DBHandler m_DBHandler = Singleton<DBHandler>.Instance;

        public static List<string> LoadLastFriendsList()
        {
            List<string> list = loadXMLList(m_DBHandler.LastFriendsListPath);
            return list;
        }

        private static List<string> loadXMLList(string i_Path)
        {
            XmlDocument doc = m_DBHandler.LoadXMLFromPath(i_Path);
            List<string> listToReturn = new List<string>();

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string nodeText = node.InnerText;
                listToReturn.Add(nodeText);
            }

            return listToReturn;
        }

        public static void writeLastFriendsList(List<string> i_NamesList)
        {
            string path = m_DBHandler.LastFriendsListPath;
            writeXMLList(i_NamesList, path);
        }
        
        private static void writeXMLList(List<string> i_List, string i_Path)
        {
            m_DBHandler.WritrToXMLLastFreindsList(m_DBHandler.LastFriendsListPath, i_List);
        }
    }
}
