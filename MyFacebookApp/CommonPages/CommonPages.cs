using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace MyFacebookApp
{
    public class CommonPages
    {
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

        public List<KeyValuePair<Page, int>> GetSortedPagesByCommonLikesAsPairs()
        {
            List<KeyValuePair<Page, int>> pageList = m_PageDictionary.ToList();
            pageList = pageList.OrderByDescending(i => i.Value).ToList();

            return pageList;
        }
    }
}
