using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
class threprog
{
    public static void Main()
    {
        program pg = new program();
        Thread t1 = new Thread(new ThreadStart(pg.WorkThreadFunction));
        t1.Start();
        t1.Join();

        while (true)
        {          
            if (!t1.IsAlive)
            {
                Console.WriteLine("Alarm-tråd termineret");
                break;
            }
        }
    }
}

class program
{
    public void WorkThreadFunction()
    {
        Random rng = new Random();
        int warningCount = 0;
        for (; ; )
        {
            int temp = rng.Next(-20, 120);
            Console.WriteLine("Temperaturen er " + temp);
            if (temp < 0 || temp > 100)
            {
                warningCount++;
            }
            if (warningCount == 3)
            {
                break;
            }
            Thread.Sleep(2000);
        }
    }
}