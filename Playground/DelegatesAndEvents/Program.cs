using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public enum WorkType
    {
        GoToMeetings,
        Golf, 
        GenerateReports
    }
    //create delegate
    class Program
    {
        static void Main(string[] args)
        {
            //instantiate and pass in the constructor a method with the same "Signature"
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);


            ////invoke it by passing it to a function that accepts a WorkPerformedHandler (this is great for testing!)
            //DoWork(del1, 50, WorkType.GenerateReports);
            //DoWork(del2, 20, WorkType.Golf);

            ////invocation list. Good for executing multiple functions in one call
            //del1 = del1 + del2; //or del1 += del2
            //DoWork(del1, 60, WorkType.Golf);

            //del1(50, WorkType.GenerateReports);
            //del2(510, WorkType.GenerateReports);

            Worker work = new Worker();
            //work.WorkPerformed += work_WorkPerformed; //if i did it this way, i would need to create a method with the same signature
            work.WorkPerformed += (x, y) =>
            {
                Console.WriteLine("Work processing..." + y.Hours.ToString());
                return 1;
            };
            work.WorkCompleted += (x, y) =>
            {
                Console.WriteLine("Work Completed!!!!");
            };


            work.DoWork(10, WorkType.Golf);
            Console.Read();
        }

        ////make it dynamic. Basically an interface!
        //static void DoWork(WorkPerformedHandler handler, int hours, WorkType wt)
        //{
        //    handler(hours, wt);
        //}

        static void WorkPerformed1(int hours, WorkType wt)
        {
            Console.WriteLine("WorkPerformed 1 Called - " + hours.ToString());
        }

        static void WorkPerformed2(int hours, WorkType wt)
        {
            Console.WriteLine("WorkPerformed 2 Called - " + hours.ToString());
        }
    }
}
