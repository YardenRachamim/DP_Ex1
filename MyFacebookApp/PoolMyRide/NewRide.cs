using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoolMyRide
{
    public class NewRide
    {
        private DateTime m_RideDate;

        public NewRide(ePoolMyRidyCityOptions i_CityFrom, ePoolMyRidyCityOptions i_CityTo,
            DateTime i_RideDate,  string i_GroupID, bool i_IsUserDriver)
        {
            CityFrom = i_CityFrom;
            CityTo = i_CityTo;
            RideDate = i_RideDate;
            GroupID = i_GroupID;
            IsUserDriver = i_IsUserDriver;
        }

        public ePoolMyRidyCityOptions CityFrom { get; private set; }
        public ePoolMyRidyCityOptions CityTo { get; private set; }
        public DateTime RideDate {
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
        public string GroupID { get; private set; }
        public bool IsUserDriver { get; private set; }
    }
}
