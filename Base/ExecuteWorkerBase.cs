using PrintTextToPicture.Source;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Tools
{
    internal class ExecuteWorkerBase
    {
        protected int maxCount = 10;
        protected int count    = 0;

        internal string Result {get;set;}
        
        public BackgroundWorker BackgroundWorker;

        internal void Reset()
        {
            this.maxCount = 10;
            this.count = 0;
            this.Result = string.Empty;
        }

        protected void ReportError(Exception error)
        {
            this.ReportProgress(error.Message);
        }

        protected void ReportError(string error)
        {
            this.ReportProgress(error);
        }

        public virtual bool Execute()
        {
            return true;
        }

        protected bool IsCanceled()
        {
            if (this.BackgroundWorker == null)
                return false;

            if (this.BackgroundWorker.CancellationPending)
                return true;

            return false;
        }

        protected void ReportProgress(string message)
        {
            if (this.BackgroundWorker == null)
                return;

            int percent = (this.count * 100) / this.maxCount;
            var info = new ProgressInformation();
            info.Max      = this.maxCount;
            info.Current  = this.count;
            info.Message  = message;

            this.BackgroundWorker.ReportProgress(percent, info);
        }

        internal class ProgressInformation
        {
            public int Max;
            public int Current;
            public string Message;
        }
    }
}
