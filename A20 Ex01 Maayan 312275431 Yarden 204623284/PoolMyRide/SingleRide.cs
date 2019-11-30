using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoolMyRide
{
    public class SingleRide
    {
        private ePoolMyRidyCityOptions m_FromCity;
        private ePoolMyRidyCityOptions m_ToCity;
        private DateTime m_RideDate;

        // TODO: handle corectly
        private RideGroup m_RideGroup;
        private List<User> m_Users;

        public SingleRide(ePoolMyRidyCityOptions i_FromCity, ePoolMyRidyCityOptions i_ToCity,
            DateTime i_RideDate, bool i_IsDriver)
        {
            FromCity = i_FromCity;
            ToCity = i_ToCity;
            RideDate = i_RideDate;
            IsDriver = i_IsDriver;
        }

        public ePoolMyRidyCityOptions FromCity {
            get { return m_FromCity; }

            private set
            {
                if(m_ToCity != ePoolMyRidyCityOptions.None)
                {
                    if(m_ToCity == value)
                    {
                        // TODO: throw the right exception here
                        throw new Exception("City To and City From can't be equal");
                    }
                }

                m_FromCity = value;
            }
        }

        public ePoolMyRidyCityOptions ToCity
        {
            get { return m_ToCity; }

            private set
            {
                if (m_FromCity != ePoolMyRidyCityOptions.None)
                {
                    if (m_FromCity == value)
                    {
                        // TODO: throw the right exception here
                        throw new Exception("City To and City From can't be equal");
                    }
                }

                m_ToCity = value;
            }
        }

        public DateTime RideDate
        {
            get { return m_RideDate; }
            private set
            {
                if(value <= DateTime.Now)
                {
                    // TODO: throw the right exception here
                    throw new Exception("Ride Date must be a future date");
                }

                m_RideDate = value;
            }
        }

        public bool IsDriver { get; private set; }

        public void EditToAndFromCity(ePoolMyRidyCityOptions i_FromCity, ePoolMyRidyCityOptions i_ToCity)
        {
            m_FromCity = ePoolMyRidyCityOptions.None;
            m_ToCity = ePoolMyRidyCityOptions.None;
            FromCity = i_FromCity;
            ToCity = i_ToCity;
        }

        public void EditRideDate(DateTime i_RideDate)
        {
            RideDate = i_RideDate;
        }

        public void EditDriverStatus(bool i_IsDriver)
        {
            IsDriver = i_IsDriver;
        }

        public override string ToString()
        {
            string singleRideString = $"from {FromCity} to {ToCity} at {RideDate}";

            return singleRideString;
        }
    }
}
