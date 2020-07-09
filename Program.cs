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
            DateTime dt = DateTime.Now;
            TimeSpan ts = new TimeSpan(23,10, 0); // 10:20pm
            dt = dt.Date + ts; // set date time to same date, but time ahead

            Action doWorkAction = new Action(DoWork);  // call dowork method.
            // doWorkAction(); // print Hi, I am doing work (calls the dowork method
            Console.WriteLine("Hi");
            await ScheduleAction(doWorkAction, dt);
            //Execute(doWorkAction, dt);
            Console.WriteLine("Timer set for {0} now off to do cool things while we wait!", ts);
            for (int i=0;i<10000;i++)
            {
                Console.Write("{0} ",i);
                Thread.Sleep(1000);
            }
            

        }

        public static void DoWork()
        {
            Console.WriteLine("Hi, I am doing work!");

        }
        public static void Execute(Action action, DateTime ExecutionTime) // so it looks like the Action here is the method to call...
        {
            double mathstuff = (int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds;
            Console.WriteLine("mathstuff = MS {0}", mathstuff);

            Task WaitTask = Task.Delay((int)mathstuff).ContinueWith(t => action);
            //Task WaitTask = Task.Delay((int)DateTime.Now.Subtract(ExecutionTime).TotalMilliseconds);
            //WaitTask.ContinueWith(t => action);
            //WaitTask.Start();
        }

        // using await
        public async static Task ScheduleAction(Action action, DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            action();
            
        }

    }
}
