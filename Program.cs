using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] x = new char[16, 10];
            bool once = false;
            while (true)
            {
                Random rand = new Random();


                //initialized
                if (!once) {
                    for (int i = 0; i < x.GetLength(0); i++)
                    {
                        for (int j = 0; j < x.GetLength(1); j++)
                        {
                            x[i, j] = (rand.Next() % 2 == 0) ? '-' : 'O';
                            Console.Write(x[i, j].ToString() + " ");
                        }
                        Console.Write("\n");
                    }
                }

                Console.Write("\n");
                //time for some fun
                bool dead_question_mark;
                char[,] y = new char[16, 10];

                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int j = 0; j < x.GetLength(1); j++)
                    {
                        dead_question_mark = (x[i, j] == 1) ? true : false;
                        int count = 0;

                        for (int a = -1; a < 2; a++)
                        {
                            for (int b = -1; b < 2; b++)
                            {
                                if (a == 0 && b == 0) continue;
                                try
                                {
                                    if (x[i + a, j + b] == 'O') count++;

                                }
                                catch (IndexOutOfRangeException)
                                {

                                    continue;
                                }
                            }
                        }

                        y[i, j] = AliveOrDead(count, dead_question_mark);
                    }
                }

               Console.ReadLine();
                x = y;
                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int j = 0; j < x.GetLength(1); j++)
                    {
                        Console.Write(x[i, j].ToString() + " ");
                    }
                    Console.Write("\n");
                }

               Console.ReadLine();
            }
        }
        static char AliveOrDead(int count, bool dead_question_mark)
        {
            if (dead_question_mark)
            {
                if (count == 3) return 'O';

            }
            else if (!dead_question_mark)
            {
                if (count == 3 || count == 2)  return 'O';
                else return '-';

            }
            return '-';
            
        }
    }
}