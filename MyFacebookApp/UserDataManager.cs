using FacebookWrapper.ObjectModel;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp
{
    public sealed class UserDataManager
    {
        //private static UserDataManager s_UserDataManager = null;
        private static readonly object sr_Padlock = new object();
        private UserDataManager()
        {
        }

        private FacebookObjectCollection<User> m_Friends;
        public FacebookObjectCollection<User> Friends
        {
            get
            {
                if (m_Friends == null)
                {
                    m_Friends = LoggedInUser.Friends;
                }

                return m_Friends;
            }
        }

        private FacebookObjectCollection<Album> m_Albums;
        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                if (m_Albums == null)
                {
                    m_Albums = LoggedInUser.Albums;
                }

                return m_Albums;
            }
        }

        private FacebookObjectCollection<Post> m_Posts;
        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                if (m_Posts == null)
                {
                    m_Posts = LoggedInUser.Posts;
                }

                return m_Posts;
            }
        }

        private FacebookObjectCollection<Page> m_LikedPages;
        public FacebookObjectCollection<Page> LikedPages
        {
            get
            {
                if (m_LikedPages == null)
                {
                    m_LikedPages = LoggedInUser.LikedPages;
                }

                return m_LikedPages;
            }
        }

        private City m_Hometown;
        public City Hometown
        {
            get
            {
                if (m_Hometown == null)
                {
                    m_Hometown = LoggedInUser.Hometown;
                }

                return m_Hometown;
            }
        }

        private User.eRelationshipStatus? m_RelationshipStatus;
        public User.eRelationshipStatus? RelationshipStatus
        {
            get
            {
                if (m_RelationshipStatus == null)
                {
                    m_RelationshipStatus = LoggedInUser.RelationshipStatus;
                }

                return m_RelationshipStatus;
            }
        }

        private string m_PictureNormalURL;
        public string PictureNormalURL
        {
            get
            {
                if (m_PictureNormalURL == null)
                {
                    m_PictureNormalURL = LoggedInUser.PictureNormalURL;
                }

                return m_PictureNormalURL;
            }
        }

        private string m_FirstName;
        public string FirstName
        {
            get
            {
                if (m_FirstName == null)
                {
                    m_FirstName = LoggedInUser.FirstName;
                }

                return m_FirstName;
            }
        }

        private string m_LastName;
        public string LastName
        {
            get
            {
                if (m_LastName == null)
                {
                    m_LastName = LoggedInUser.LastName;
                }

                return m_LastName;
            }
        }

        private string m_Birthday;
        public string Birthday
        {
            get
            {
                if (m_Birthday == null)
                {
                    m_Birthday = LoggedInUser.Birthday;
                }

                return m_Birthday;
            }
        }

        private string m_Religion;
        public string Religion
        {
            get
            {
                if (m_Religion == null)
                {
                    m_Religion = LoggedInUser.Religion;
                }

                return m_Religion;
            }
        }

        private double? m_TimeZone;
        public double? TimeZone
        {
            get
            {
                if (m_TimeZone == null)
                {
                    m_TimeZone = LoggedInUser.TimeZone;
                }

                return m_TimeZone;
            }
        }

        private string m_Id;
        public string Id
        {
            get
            {
                if(m_Id == null)
                {
                    m_Id = LoggedInUser.Id;
                }

                return m_Id;
            }
        }

        private string m_Name;
        public string Name
        {
            get
            {
                if(m_Name == null)
                {
                    m_Name = LoggedInUser.Name;
                }

                return m_Name;
            }
        }

        private User m_LoggedInUser;
        public User LoggedInUser
        {
            get
            {
                if(m_LoggedInUser == null)
                {
                    throw new InvalidOperationException("you must set LoggedInUser first!");
                }

                return m_LoggedInUser;
            }
            set
            {
                m_LoggedInUser = value;
            }
        }

        public void RestartLoggedInUser()
        {
            foreach (FieldInfo fieldInfo in typeof(UserDataManager).GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var fieldName = fieldInfo.Name;
                fieldInfo.SetValue(this, null);
            }
        }
    }
}
