using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //create an event args class
    public class WorkPerformedEventArgs : System.EventArgs
    {
        public WorkPerformedEventArgs(int hours, WorkType wt)
        {
            this.Hours = hours;
            this.WorkType = wt;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }

    //delegate below is used for events
    public delegate int WorkPerformHandler(object sender, WorkPerformedEventArgs e);
    public class Worker 
    {
        //the events below have to have a delegate type
        public event WorkPerformHandler WorkPerformed;
        public event EventHandler WorkCompleted; //this is built in

        //say this function is called..a developer can hook into these events and do something with them when they fire
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //raise event
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
            //raise event
        }

        protected virtual void OnWorkPerformed(int hours, WorkType wt) //protected virtual so that it can be inherited and overrided
        {
            var del = WorkPerformed as WorkPerformHandler; //cast it to its delegate type
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, wt));
            }
        }
        protected virtual void OnWorkCompleted()
        {
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}