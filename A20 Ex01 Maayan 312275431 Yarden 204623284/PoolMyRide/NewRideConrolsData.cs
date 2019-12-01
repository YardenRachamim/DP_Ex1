using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    internal class NewRideConrolsData
    {
        private DateTime m_RideDate;

        internal NewRideConrolsData(ePoolMyRidyCityOptions i_CityFrom, ePoolMyRidyCityOptions i_CityTo,
            DateTime i_RideDate,  string i_GroupID, bool i_IsUserDriver)
        {
            CityFrom = i_CityFrom;
            CityTo = i_CityTo;
            RideDate = i_RideDate;
            GroupID = i_GroupID;
            IsUserDriver = i_IsUserDriver;
        }

        internal ePoolMyRidyCityOptions CityFrom { get; private set; }
        internal ePoolMyRidyCityOptions CityTo { get; private set; }
        internal DateTime RideDate {
            get
            {
                return m_RideDate;
            }
            set
            {
                if(m_RideDate <= DateTime.Now)
                {
                    throw new Exception("You must provide a future date");
                }

                m_RideDate = value;
            }
        }
        internal string GroupID { get; private set; }
        internal bool IsUserDriver { get; private set; }
    }
}
