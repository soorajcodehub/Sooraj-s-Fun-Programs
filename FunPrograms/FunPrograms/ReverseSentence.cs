using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    class ReverseSentence
    {
        String str;

        
        public ReverseSentence(String str)
        {
            this.str = str;
        }

        public String Str()
        {
            return str;
        }

        public void ReverseFullSentence()
        {
            int k = 0;
            int i = 0;
            int j = 0;
            if(String.IsNullOrEmpty(str))
                return;
            else
            {
                str = ReverseString(0,str.Length);
                while(j<str.Length)
                {

                    i = j;
                    while(i < str.Length && !str[i].Equals(' ') )
                    {
                        k++;
                        i++;
                    }
                    str = ReverseString(j,k);
                    j = i + 1;
                    k = k + 1;
                    
                }
            }
                        
        }

        public string ReverseString(int j, int k)
        {
            char temp;
            int counter1, counter2;
            char[] tempstring = str.ToCharArray();
            for (counter1 = j, counter2 = k-1; counter1 < counter2 ; counter1++, counter2--)
            {
                temp = tempstring[counter1];
                 tempstring[counter1]= tempstring[counter2];
                tempstring[counter2] = temp;
            }

            return new String(tempstring);

        }

    }
}
