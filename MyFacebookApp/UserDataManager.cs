using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp
{
    public sealed class UserDataManager
    {
        private static UserDataManager s_UserDataManager = null;
        private static readonly object sr_Padlock = new object();

        private UserDataManager()
        {

        }

        public FacebookObjectCollection<User> Friends { get; set; }
        public FacebookObjectCollection<Album> Albums { get; set; }
        public FacebookObjectCollection<Post> Posts { get; set; }
        
        public User LoggedInUser
        {
            get; set;
        }

        public void RestartLoggedInUser()
        {
            s_UserDataManager = null;
        }
    }
}
