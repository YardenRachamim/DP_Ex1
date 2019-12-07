using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public sealed class UserDataManager
    {
        private static UserDataManager s_UserDataManager = null;
        private static readonly object sr_Padlock = new object();

        private UserDataManager()
        {

        }

        public static UserDataManager Instance
        {
            get
            {
                if (s_UserDataManager == null)
                {
                    lock (sr_Padlock)
                    {
                        if (s_UserDataManager == null)
                        {
                            s_UserDataManager = new UserDataManager();
                        }
                    }
                }
                return s_UserDataManager;
            }
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
