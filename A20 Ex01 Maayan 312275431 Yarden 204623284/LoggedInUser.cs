using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public sealed class LoggedInUser
    {
        private static LoggedInUser sm_LoggedInUser = null;
        private static readonly object srm_Padlock = new object();

        private LoggedInUser()
        {
        }

        public static LoggedInUser GetLoggedInUser
        {
            get
            {
                if (sm_LoggedInUser == null)
                {
                    lock (srm_Padlock)
                    {
                        if (sm_LoggedInUser == null)
                        {
                            sm_LoggedInUser = new LoggedInUser();
                        }

                    }
                }

                return sm_LoggedInUser;
            }
        }
    }
}
