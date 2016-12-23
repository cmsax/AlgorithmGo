using AlgorithmGo.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGo.Test
{
    class AlgorithmTest
    {
        SequenceList<int> sl = new SequenceList<int>(20);
        
        void test()
        {
            Random rd = new Random();
            for (int i = 0; i < sl.GetLength(); i++)
            {
                try
                {
                    sl.Append(rd.Next(100));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
            for(int i = 0; i < sl.GetLength(); i++)
            {
                Console.Write("{0}, ", sl[i]);
            }
            
        }

    }
}
