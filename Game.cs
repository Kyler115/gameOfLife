using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife 
{
    public class Game 
    {
        int[] living;
        int[] dead;
        int[] life;
        public Game(int[] list)
        {
            living = list;
            int i = 0;
            int j = 0;
            while (i < 1024)
            {
                if (living.Contains(i))
                {
                    i++;
                }
                else
                {
                    dead[j] = i;
                    i++;
                }
                j++;
            }
            i = 0;
            j = 0;

            int k = 0;
            while (living.Length >= 3)
            {
                foreach (int c in dead)
                {
                    if (living.Contains(c - 31))
                    {
                        i++;
                    }
                    if (living.Contains(c - 32))
                    {
                        i++;
                    }
                    if (living.Contains(c - 33))
                    {
                        i++;
                    }
                    if (living.Contains(c + 1))
                    {
                        i++;
                    }
                    if (living.Contains(c - 1))
                    {
                        i++;
                    }
                    if (living.Contains(c + 31))
                    {
                        i++;
                    }
                    if (living.Contains(c + 32))
                    {
                        i++;
                    }
                    if (living.Contains(c + 33))
                    {
                        i++;
                    }
                    if (i <= 2 || i >= 4)
                    {
                    }
                    else
                    {
                        life[k] = c;
                        dead[k] = 0;
                    }
                    k++;
                }


            }
            
        }


    }
}
