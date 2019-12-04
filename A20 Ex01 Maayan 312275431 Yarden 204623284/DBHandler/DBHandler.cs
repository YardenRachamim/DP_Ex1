using A20_Ex01_Maayan_312275431_Yarden_204623284;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        internal void SaveEventToGroupRides(string i_GroupID, string i_EventID)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        internal List<string> FetchAllGroupRides(string groupID)
        {
            // TODO: implement
            List<string> rideEventsIDs = new List<string>();

            rideEventsIDs.Add("0");
            rideEventsIDs.Add("1");

            return rideEventsIDs;
        }
    }
}
