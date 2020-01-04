using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp
{
     class Cls
    {
        private string m_Str = "";
        private int m_Int = 0;

        Cls() { }

        public string p_Str
        {
            get;
            set;
        }

        public int p_Int
        {
            get;
            set;
        }

        public int testc()
        {
            Func<int> func = new Func<int>(() => p_Int);

            return func();
        }
    };
}
