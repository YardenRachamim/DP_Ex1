﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace MyFacebookApp
{
    public class CommonPages : IEnumerable<KeyValuePair<Page, int>>
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

        private List<KeyValuePair<Page, int>> orderList()
        {
            List<KeyValuePair<Page, int>> pageList = m_PageDictionary.ToList();
            pageList = pageList.OrderByDescending(i => i.Value).ToList();
            
            return pageList;
        }

        public IEnumerator<KeyValuePair<Page, int>> GetEnumerator()
        {
            //List<KeyValuePair<Page, int>> pageList = m_PageDictionary.ToList();
            //pageList = pageList.OrderByDescending(i => i.Value).ToList();
            return m_PageDictionary.OrderByDescending(i => i.Value).GetEnumerator();
            //return ((IEnumerable<KeyValuePair<Page, int>>)pageList).GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
