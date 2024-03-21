using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace VS2017WindowsService
{
    public partial class VS2017_AMD_Service : ServiceBase
    {
        private int eventId = 1;

        public VS2017_AMD_Service()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("VS2017_AMD_Service"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "VS2017_AMD_Service", "VS2017_AMD_Service_Log");
            }
            eventLog1.Source = "VS2017_AMD_Service";
            eventLog1.Log = "VS2017_AMD_Service_Log";

        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart.");

            // Set up a timer that triggers every minute.
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
        }

        protected override void OnContinue()
        {
            eventLog1.WriteEntry("In OnContinue.");
        }
    }
}
