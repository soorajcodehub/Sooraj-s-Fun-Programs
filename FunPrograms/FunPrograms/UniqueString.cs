using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class UniqueString
    {
        String str;
        public UniqueString(String str)
        {
            this.str = str;
        }

        public bool hasUniqueChracters()
        {
            HashSet<char> hashSet = new HashSet<char>();
            int i;
            if (String.IsNullOrEmpty(str))
            {
                return false;
            }
            else
            {
                for (i = 0; i < str.Length; i++)
                {
                    if (!hashSet.Contains(str[i]))
                    {
                        hashSet.Add(str[i]);
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
