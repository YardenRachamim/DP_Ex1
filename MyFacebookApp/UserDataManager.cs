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

        #region Fields
        private FacebookObjectCollection<User> m_Friends;
        public FacebookObjectCollection<User> Friends
        {
            get
            {
                Func<FacebookObjectCollection<User>> lazyProperty = new Func<FacebookObjectCollection<User>>(() => LoggedInUser.Friends);
                commonGetProcess(lazyProperty, ref m_Friends);

                return m_Friends;
            }
        }

        private FacebookObjectCollection<Album> m_Albums;
        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                Func<FacebookObjectCollection<Album>> lazyProperty = new Func<FacebookObjectCollection<Album>>(() => LoggedInUser.Albums);
                commonGetProcess(lazyProperty, ref m_Albums);

                return m_Albums;
            }
        }

        private FacebookObjectCollection<Post> m_Posts;
        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                Func<FacebookObjectCollection<Post>> lazyProperty = new Func<FacebookObjectCollection<Post>>(() => LoggedInUser.Posts);
                commonGetProcess(lazyProperty, ref m_Posts);

                return m_Posts;
            }
        }

        private FacebookObjectCollection<Page> m_LikedPages;
        public FacebookObjectCollection<Page> LikedPages
        {
            get
            {
                Func<FacebookObjectCollection<Page>> lazyProperty = new Func<FacebookObjectCollection<Page>>(() => LoggedInUser.LikedPages);
                commonGetProcess(lazyProperty, ref m_LikedPages);

                return m_LikedPages;
            }
        }

        private City m_Hometown;
        public City Hometown
        {
            get
            {
                Func<City> lazyProperty = new Func<City>(() => LoggedInUser.Hometown);
                commonGetProcess(lazyProperty, ref m_Hometown);

                return m_Hometown;
            }
        }

        private User.eRelationshipStatus? m_RelationshipStatus;
        public User.eRelationshipStatus? RelationshipStatus
        {
            get
            {
                Func<User.eRelationshipStatus?> lazyProperty = new Func<User.eRelationshipStatus?>(() => LoggedInUser.RelationshipStatus);
                commonGetProcess(lazyProperty, ref m_RelationshipStatus);

                return m_RelationshipStatus;
            }
        }

        private string m_PictureNormalURL;
        public string PictureNormalURL
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.PictureNormalURL);
                commonGetProcess(lazyProperty, ref m_PictureNormalURL);

                return m_PictureNormalURL;
            }
        }

        private string m_FirstName;
        public string FirstName
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.FirstName);
                commonGetProcess(lazyProperty, ref m_FirstName);

                return m_FirstName;
            }
        }

        private string m_LastName;
        public string LastName
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.LastName);
                commonGetProcess(lazyProperty, ref m_LastName);

                return m_LastName;
            }
        }

        private string m_Birthday;
        public string Birthday
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.Birthday);
                commonGetProcess(lazyProperty, ref m_Birthday);

                return m_Birthday;
            }
        }

        private string m_Religion;
        public string Religion
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.Religion);
                commonGetProcess(lazyProperty, ref m_Religion);

                return m_Religion;
            }
        }

        private double? m_TimeZone;
        public double? TimeZone
        {
            get
            {
                Func<double?> lazyProperty = new Func<double?>(() => LoggedInUser.TimeZone);
                commonGetProcess(lazyProperty, ref m_TimeZone);

                return m_TimeZone;
            }
        }

        private string m_Id;
        public string Id
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.Id);
                commonGetProcess(lazyProperty, ref m_Id);

                return m_Id;
            }
        }

        private string m_Name;
        public string Name
        {
            get
            {
                Func<string> lazyProperty = new Func<string>(() => LoggedInUser.Name);
                commonGetProcess(lazyProperty, ref m_Name);

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
        #endregion Fields

        private void commonGetProcess<T>(Func<T> i_LazyProperty, ref T io_ClassMember)
        {
            if (io_ClassMember == null)
            {
                lock (sr_Padlock)
                {
                    if (io_ClassMember == null)
                    {
                        io_ClassMember = i_LazyProperty();
                    }
                }
            }
        }

        public void RestartLoggedInUser()
        {
            FieldInfo[] userDataManagerFieldInfo = typeof(UserDataManager).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo fieldInfo in userDataManagerFieldInfo)
            {
                fieldInfo.SetValue(this, null);
            }
        }
    }
}
