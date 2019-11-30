using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoolMyRide
{
    public class RideGroup
    {
        // TODO: Implement
        private static int ids = 0;
        private List<User> groupMembers;
        public int groupID;

        public RideGroup(String name)
        {
            Name = name;
            groupID = ids++;
        }

        public string Name {get; set;}

        public override string ToString()
        {
            return Name;
        }
    }
}
