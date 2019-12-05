using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public sealed class UserDataManager
    {
        private static UserDataManager s_UIManager = null;
        private static readonly object sr_Padlock = new object();

        private UserDataManager()
        {

        }

        public static UserDataManager Instance
        {
            get
            {
                if (s_UIManager == null)
                {
                    lock (sr_Padlock)
                    {
                        if (s_UIManager == null)
                        {
                            s_UIManager = new UserDataManager();
                        }
                    }
                }
                return s_UIManager;
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
            s_UIManager = null;
        }
    }
}
