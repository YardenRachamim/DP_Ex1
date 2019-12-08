using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoolMyRide
{
    public class RideGroup
    {
        private readonly Group r_RideGroupFacebookGroup;
        private bool m_IsValidGroupFacebookId = false;
        private readonly FacebookObjectCollection<Event> r_GroupEvents = new FacebookObjectCollection<Event>();

        public RideGroup(string i_GroupName)
        {
            defaultInit(i_GroupName);
            Id = Guid.NewGuid().ToString();
            m_IsValidGroupFacebookId = false;
            GroupMembers = new FriendList();
        }

        public RideGroup(string i_GroupId, string i_GroupName)
        {
            try
            {
                defaultInit(i_GroupName);
                r_RideGroupFacebookGroup = FacebookWrapper.FacebookService.GetObject(i_GroupId);
                m_IsValidGroupFacebookId = true;
            }
            catch(Exception ex)
            {
            }
        }

        private void defaultInit(string i_GroupName)
        {
            Name = i_GroupName;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
        public FriendList GroupMembers { get; private set; }
        public bool IsValidGroupFacebookId {
            get
            {
                return m_IsValidGroupFacebookId;
            }
        }
        public Group Group
        {
            get
            {
                Group group = null;

                if (IsValidGroupFacebookId)
                {
                    group = FacebookWrapper.FacebookService.GetObject(Id);
                }

                throw new Exception("This group can't be accessed");
            }
        }
        public FacebookObjectCollection<Event> Events
        {
            get
            {
                return r_GroupEvents;
            }
        }

        public void AddEvent(Event i_EventToAdd)
        {
            r_GroupEvents.Add(i_EventToAdd);
        }

        public void AddEvents(FacebookObjectCollection<Event> i_EventsToAdd)
        {
            foreach(Event e in i_EventsToAdd)
            {
                AddEvent(e);
            }
        }

        public string AddMember(User i_UserToAdd, out bool o_NeedToJoinmAunually)
        {
            List<User> userToAdd = new List<User>();

            o_NeedToJoinmAunually = false;
            userToAdd.Add(i_UserToAdd);

            if (IsValidGroupFacebookId)
            {
                o_NeedToJoinmAunually = true;
            }
            else
            {
                GroupMembers.AddMemeber(userToAdd);
            }

            return Id;
        }

        public Event CreateEvent(User i_EventOwner, string i_EventName, DateTime i_RideDate, string i_Description)
        {
            Event eventRide = null;
            FacebookObjectCollection<User> members = null;

            if (m_IsValidGroupFacebookId)
            {
                eventRide = Group.CreateEvent_DeprecatedSinceV2(i_EventName,
                    i_RideDate,
                    i_Description: i_Description);
                members = Group.Members;
            }
            else
            {
                eventRide = i_EventOwner.CreateEvent_DeprecatedSinceV2(i_EventName,
                    i_RideDate,
                    i_Description: i_Description);
                members = GroupMembers.Members;
            }

            if (eventRide != null && members != null)
            {
                eventRide.InviteUsers(members);
                r_GroupEvents.Add(eventRide);
            }
            else
            {
                if (eventRide == null)
                {
                    throw new Exception("Problem in event creation");
                }
                else
                {
                    throw new Exception("There are no group members to invite");
                }
            }

            return eventRide;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
