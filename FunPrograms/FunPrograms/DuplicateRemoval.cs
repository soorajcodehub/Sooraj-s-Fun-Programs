using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    class DuplicateRemoval
    {
        string str;
        public DuplicateRemoval(string str)
        {
            this.str = str;
        }

        public string RemoveDuplicates()
        {
            HashSet<char> hs = new HashSet<char>();
            char[] tempstring = str.ToCharArray();
            int length = tempstring.Length;
            int tail, begin =0;
            while(begin < length)
            {
                if (!hs.Contains(tempstring[begin]))
                {
                    hs.Add(tempstring[begin]);
                    begin++;
                    
                }
                else
                {
                    tail = begin;
                    while (hs.Contains(tempstring[tail]))
                    {
                         tail++;
                         length--;
                         if (tail == tempstring.Length)
                         {
                             tail = tail - 1;
                             begin = begin - 1;
                             break;
                         }
                    }
                    tempstring[begin] = tempstring[tail];
                }


            }

            return new String(tempstring, 0,begin+1);
        }
            


    }
}
