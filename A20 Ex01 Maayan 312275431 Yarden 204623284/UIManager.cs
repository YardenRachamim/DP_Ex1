using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public sealed class UIManager
    {
        private static User sm_LoggedInUser = null;
        private static readonly object srm_Padlock = new object();

        private UIManager()
        {

        }

        public static User GetLoggedInUser
        {
            get
            {
                if(sm_LoggedInUser == null)
                {
                    // TODO: throw the right exceprion
                    throw new Exception("LoggedInUser must be initialized first! please use LoggedInUser.Init(User) method");
                }

                return sm_LoggedInUser;
            }
        }

        public static void Init(User i_LoggedInUser)
        {
            if (sm_LoggedInUser == null)
            {
                lock (srm_Padlock)
                {
                    if (sm_LoggedInUser == null)
                    {
                        sm_LoggedInUser = i_LoggedInUser;
                    }
                }
            }
        }

        public static void RestartLoggedInUser()
        {
            sm_LoggedInUser = null;
        }
    }
}
