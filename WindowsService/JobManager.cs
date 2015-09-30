using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowsService1.Job;

namespace WindowsService1
{
    public class JobManager
    {
        private static JobManager _instance;
        private static object DaemonLock = new object();
        private static bool IsRun = false;
        private static JobBase[] JobList;
        public static JobManager GetInstance()
        {
            lock (DaemonLock)
            {
                if (_instance == null)
                {
                    _instance = new JobManager();
                    // http://stackoverflow.com/questions/949246/how-to-get-all-classes-within-namespace
                    var tmp = new List<JobBase>();
                    foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, "WindowsService1.Job", StringComparison.Ordinal)))
                    {
                        var name = type.Name;
                        if (name.Substring(name.Length - 3) != "Job")
                        {
                            continue;
                        }
                        ConstructorInfo ctor = type.GetConstructor(new Type[] { });
                        var job = (JobBase)ctor.Invoke(new object[] { });
                        tmp.Add(job);
                        //job.Run();
                        //MethodInfo method = type.GetMethod("Run");
                        //method.Invoke();
                    }
                    JobList = tmp.ToArray();
                }
            }
            return _instance;
        }

        public void Stop()
        {
            if (!IsRun)
            {
                return;
            }

            foreach (var job in JobList)
            {
                job.Stop();
            }

            IsRun = false;
        }

        public void Start()
        {
            if (IsRun)
            {
                return;
            }

            foreach(var job in JobList)
            {
                job.Start();
            }

            IsRun = true;
        }
    }
}
