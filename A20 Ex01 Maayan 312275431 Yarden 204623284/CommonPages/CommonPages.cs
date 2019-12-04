using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace A20_Ex01_Maayan_312275431_Yarden_204623284
{
    public class CommonPages
    {

        //TODO: change to singletone Maayan :(
        private Dictionary<Page,int> m_PageDictionary = new Dictionary<Page, int>();

        public void Add(Page i_Page)
        {
            if (m_PageDictionary.ContainsKey(i_Page))
            {
                m_PageDictionary[i_Page]++;
            }
            else
            {
                m_PageDictionary.Add(i_Page, 1);
            }
        }

        public FacebookObjectCollection<Page> GetSortedPagesByCommonLikes()
        {
            List<KeyValuePair<Page,int>> pageList =  m_PageDictionary.ToList();
            pageList = pageList.OrderByDescending(i => i.Value).ToList();
            FacebookObjectCollection<Page> orderListToReturn = new FacebookObjectCollection<Page>();

            foreach (KeyValuePair<Page, int> pair in pageList)
            {
                orderListToReturn.Add(pair.Key);
            }
            return orderListToReturn;
        }

        public List<KeyValuePair<Page, int>> GetSortedPagesByCommonLikesAsPairs()
        {
            List<KeyValuePair<Page, int>> pageList = m_PageDictionary.ToList();
            pageList = pageList.OrderByDescending(i => i.Value).ToList();

            return pageList;
        }
    }
}
