using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLotto
{
    class Lotto
    {
        public static int[] ArvoSuomiLotto(int drawns)
        {
            int[] numbers = new int[7];
            Random rnd = new Random();

            for(int i = 0; i < drawns; i++) {
                for (int j = 0; j < 7; j++)
                {
                    int number = rnd.Next(1, 39);
                    
                    // Check if number exists in array
                    if (!numbers.Contains(number))
                    {
                        numbers[j] = number;
                    }
                    else
                    {
                        j--;
                    }
                }
            }
            return numbers;
        }
    }
}
