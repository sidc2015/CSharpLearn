using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1.Job
{
    class IntervalJob : JobBase
    {
        protected override void Init()
        {
            this.Interval = 5 * 1000; // 間隔時間
            
        }

        protected override void EventCallBack()
        {
            // Job Content

            System.IO.File.AppendAllText("d:\\service.txt", DateTime.Now.ToString());
        }
    }
}
