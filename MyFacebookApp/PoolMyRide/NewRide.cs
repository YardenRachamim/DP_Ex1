using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyFacebookApp;
using Utils;

namespace PoolMyRide
{
    public class NewRide
    {
        private DateTime m_RideDate;
        public event Action m_RideNotification;
        private DateTime m_NotificationTime;

        public NewRide(ePoolMyRidyCityOptions i_CityFrom, ePoolMyRidyCityOptions i_CityTo,
            DateTime i_RideDate, string i_GroupID, bool i_IsUserDriver)
        {
            CityFrom = i_CityFrom;
            CityTo = i_CityTo;
            RideDate = i_RideDate;
            GroupID = i_GroupID;
            IsUserDriver = i_IsUserDriver;
        }

        public NewRide(ePoolMyRidyCityOptions i_CityFrom, ePoolMyRidyCityOptions i_CityTo,
            DateTime i_RideDate, string i_GroupID, bool i_IsUserDriver,
            int i_MinutesBeforeRideToNotify,
            Action i_ToNotify) : this(i_CityFrom, i_CityTo, i_RideDate, i_GroupID, i_IsUserDriver)

        {
            m_NotificationTime = RideDate.AddMinutes(-i_MinutesBeforeRideToNotify);
            m_RideNotification = i_ToNotify;
            CurrentTimeNotifier.Notifier += IsNotificationTime;
        }

        public void IsNotificationTime(DateTime i_Compare)
        {
            bool isTimeInRange = false;

            isTimeInRange = RideDate.Ticks >= i_Compare.Ticks 
                && m_NotificationTime.Ticks <= i_Compare.Ticks;

            if (isTimeInRange)
            {
                m_RideNotification.Invoke();
                CurrentTimeNotifier.Notifier -= IsNotificationTime;
            }
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
