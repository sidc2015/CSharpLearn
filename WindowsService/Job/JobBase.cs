using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1.Job
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class JobBase : Timer
    {
        public JobBase()
        {
            this.AutoReset = true;            
            this.Elapsed += new ElapsedEventHandler(DoIt);
        }

        public void DoIt(object source, ElapsedEventArgs e)
        {
            try
            {
                EventCallBack();
            }
            catch (Exception ex)
            {

            }
        }

        public void Stop()
        {
            this.Enabled = false;
        }

        public void Start()
        {
            this.Enabled = true;

            try
            {
                Init();
            }
            catch (Exception ex)
            {

            }
        }
        protected abstract void Init();

        protected abstract void EventCallBack();
    }
}
