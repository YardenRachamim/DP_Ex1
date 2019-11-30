using A20_Ex01_Maayan_312275431_Yarden_204623284;
using FacebookWrapper.ObjectModel;
using PoolMyRide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHandler
{
    class DBHandler
    {
        private static DBHandler sm_DBHandler = null;
        private static readonly object srm_Padlock = new object();

        private DBHandler()
        {
        }

        public static DBHandler GetInstance
        {
            get
            {
                if (sm_DBHandler == null)
                {
                    lock (srm_Padlock)
                    {
                        if (sm_DBHandler == null)
                        {
                            sm_DBHandler = new DBHandler();
                        }
                    }
                }

                return sm_DBHandler;
            }
        }

        public List<RideGroup> FetchAllUserRideGroups(User i_User)
        {
            // TODO: implement
            List<RideGroup> userRideGroups = new List<RideGroup>();

            userRideGroups.Add(new RideGroup("IDC Rides"));
            userRideGroups.Add(new RideGroup("Netnya To TelAviv carpool!!"));

            return userRideGroups;
        }

        public List<SingleRide> FetchSingleRideGroupRides(RideGroup selectedRideGroup)
        {
            // TODO: implement
            List<SingleRide> groupRides = new List<SingleRide>();

            groupRides.Add(new SingleRide(ePoolMyRidyCityOptions.Haifa, ePoolMyRidyCityOptions.Netanya,
                DateTime.Now.AddDays(1), true));

            return groupRides;
        }

        public List<RideGroup> FetchAllRideGroups()
        {
            // TODO: implement
            List<RideGroup> userRideGroups = new List<RideGroup>();

            userRideGroups.Add(new RideGroup("IDC Rides"));
            userRideGroups.Add(new RideGroup("Netnya To TelAviv carpool!!"));
            userRideGroups.Add(new RideGroup("TelAviv To Netnya carpool!!"));

            return userRideGroups;
        }

        public void AddUserToRideGroup(User i_User, RideGroup i_RideGroup)
        {
            // TODO: implement
        }

        public void AddSingleRide(SingleRide i_NewRide)
        {
            throw new NotImplementedException();
        }
    }
}
