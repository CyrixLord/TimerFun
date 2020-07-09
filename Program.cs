using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TimerFun
{
    class Program
    {


        static async Task Main(string[] args)
        {
            await PerformActions();


        }

        public static async Task PerformActions()
        {
        DateTime dt = DateTime.Now;
        TimeSpan ts = new TimeSpan(22, 08, 0); // 10:20pm
        dt = dt.Date + ts; // set date time to same date, but time ahead

            Action doWorkAction = new Action(DoWork);  // call dowork method.
                                                       // doWorkAction(); // print Hi, I am doing work (calls the dowork method
        Console.WriteLine("Hi");
            await ScheduleAction(doWorkAction, dt);  // was awaited
                                                     //Execute(doWorkAction, dt);
        Console.WriteLine("Timer set for {0} now off to do cool things while we wait!", ts);
            for (int i = 0; i< 1000; i++)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(1000);
            }
        }





public static void DoWork()
        {
            Console.WriteLine("Hi, I am doing work!");

        }

        // using await
        public static async Task ScheduleAction(Action action, DateTime ExecutionTime)
        {
             await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            action();
            
            
            
            
        }

    }
}
