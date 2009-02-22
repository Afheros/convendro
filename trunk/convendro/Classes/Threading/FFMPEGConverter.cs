using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using convendro.Classes.Persistence;

namespace convendro.Classes.Threading {
    /// <summary>
    /// 
    /// </summary>
    public class FFMPEGConverter {
        private string executable;
        private Thread nthread;
        private frmMain nform;
        private volatile MediaFileList mediafilelist;
        private bool showdoswindow;
        private float fileduration = 0.00F;
        private DateTime currentdate;
        private volatile bool stoprequested = false;
        private ManualResetEvent stopThread;
        private ManualResetEvent threadHasStopped;

        /// <summary>
        /// 
        /// </summary>
        private void init() {
            nthread = null;
            nform = null;
            mediafilelist = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            mediafilelist.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public FFMPEGConverter() {
            init();
        }

        public FFMPEGConverter(ManualResetEvent stopthread, ManualResetEvent signalthreadstopped) {
            init();
            stopThread = stopthread;
            threadHasStopped = signalthreadstopped;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Executable {
            get { return executable; }
            set { executable = value; }
        }

        public bool StopRequested {
            get { return stoprequested; }
            set { stoprequested = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ShowWindow {
            get { return this.showdoswindow; }
            set { this.showdoswindow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmMain Form {
            get { return nform; }
            set { nform = value; }
        }

        public Thread CurrentThread {
            get { return this.nthread; }
        }

        public MediaFileList MediaFileItems {
            get { return this.mediafilelist; }
            set { this.mediafilelist = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void execthread() {
            foreach (MediaFile m in this.mediafilelist.Items) {
                if (stopThread.WaitOne(0, true)) {
                    threadHasStopped.Set();
                    this.synchUpdateControls();
                    return;
                }

                Process nprocess = new Process();
                try {
                    float current = 0.00F;
                    this.fileduration = 0.00F;
                    currentdate = DateTime.Now;

                    m.DateStarted = currentdate;

                    nprocess.StartInfo.FileName = this.executable;
                    nprocess.StartInfo.Arguments = m.BuildCommandLine();

                    nprocess.EnableRaisingEvents = false;
                    nprocess.StartInfo.UseShellExecute = false;
                    nprocess.StartInfo.CreateNoWindow = true;
                    nprocess.StartInfo.RedirectStandardOutput = true;
                    nprocess.StartInfo.RedirectStandardError = true;
                    nprocess.Start();
                    StreamReader d = nprocess.StandardError;
                    do {
                        string s = d.ReadLine();
                        if (s.Contains("Duration: ")) {
                            string stime = Functions.ExtractDuration(s);
                            fileduration = Functions.TotalStringToSeconds(stime);
                            synchTotalFloat();

                        } else {
                            if (s.Contains("frame=")) {
                                string currents = Functions.ExtractTime(s);
                                current = Functions.CurrentStringToSeconds(currents);
                                synchCurrentFloat(current);
                            }
                        }

                        if (stopThread.WaitOne(0, true)) {
                            nprocess.Kill();
                            threadHasStopped.Set();
                            this.synchUpdateControls();
                            return;
                        }

                    } while (!d.EndOfStream);
                    nprocess.WaitForExit();
                } finally {
                    nprocess.Close();
                }

                m.DateFinished = DateTime.Now;
                this.synchListViewItem(m);
            } // End Foreach

            /// update controls
            threadHasStopped.Set();
            this.synchUpdateControls();
        }

        /// <summary>
        /// 
        /// </summary>
        private void synchUpdateControls() {
            if (nform.InvokeRequired) {
                nform.Invoke(new MethodInvoker(synchUpdateControls));
            } else {
                nform.SetControlsThreading(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amediafile"></param>
        /// <param name="atimespan"></param>
        private void synchListViewItem(MediaFile amediafile) {
            if (nform.FileListView.InvokeRequired) {
                nform.FileListView.Invoke(new MediaFileInvoker(synchListViewItem), new object[] { amediafile });
            } else {
                if (amediafile != null) {                   
                    TimeSpan atimespan = amediafile.DateFinished.Subtract(amediafile.DateStarted);
                    nform.FileListView.Items[amediafile.Order].SubItems[frmMain.SUBCOL_DURATION].Text =
                        String.Format(Functions.TIMEFORMAT_HHMMSS,
                        atimespan.Hours, atimespan.Minutes, atimespan.Seconds);
                    nform.FileListView.Items[amediafile.Order].SubItems[frmMain.SUBCOL_STARTED].Text =
                        String.Format(Functions.TIMEFORMAT_HHMMSS,
                        amediafile.DateStarted.Hour, amediafile.DateStarted.Minute, amediafile.DateStarted.Second);
                    nform.FileListView.Items[amediafile.Order].SubItems[frmMain.SUBCOL_FINISHED].Text =
                        String.Format(Functions.TIMEFORMAT_HHMMSS,
                        amediafile.DateFinished.Hour, amediafile.DateFinished.Minute, amediafile.DateFinished.Second);
                        
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private void synchTextStatusBar(string text) {
            if (nform.Statusbar.InvokeRequired) {
                nform.Statusbar.Invoke(new StringInvoker(synchTextStatusBar), new object[] { text });
            } else {
                if (!nform.Statusbar.IsDisposed) {
                    if (nform.Statusbar.Items[2] != null) {
                        (nform.Statusbar.Items[2] as ToolStripLabel).Text = text;
                    }
                }
            }
        }

        private void synchTextOutput(string text) {
            if (nform.LogBox.InvokeRequired) {
                nform.LogBox.Invoke(new StringInvoker(synchTextOutput), new object[] { text });
            } else {
                nform.LogBox.Text = text;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="floating"></param>
        private void synchTotalFloat() {
            if (nform.Statusbar.InvokeRequired) {
                nform.Statusbar.Invoke(new MethodInvoker(synchTotalFloat));
            } else {
                (nform.Statusbar.Items[1] as ToolStripProgressBar).Minimum = 0;
                (nform.Statusbar.Items[1] as ToolStripProgressBar).Maximum = 100;
                (nform.Statusbar.Items[1] as ToolStripProgressBar).Value = 0;
            }
        }

        /// <summary>
        /// Sets the status...
        /// </summary>
        /// <param name="avalue"></param>
        private void synchCurrentFloat(float avalue) {
            if (nform.Statusbar.InvokeRequired) {
                nform.Statusbar.Invoke(new FloatInvoker(synchCurrentFloat),
                    new object[] { avalue });
            } else {
                int v = (nform.Statusbar.Items[1] as ToolStripProgressBar).Value;

                float vv = (avalue / this.fileduration);

                int stat = (int)(vv * 100F);

                if (stat > 100) {
                    stat = 100;
                }

                TimeSpan pdelta = DateTime.Now.Subtract(currentdate);

                Double seconds = (pdelta.TotalSeconds * fileduration) / avalue;

                TimeSpan pdelta2 = new TimeSpan(0, 0, (int)seconds);
                DateTime finishtime = currentdate.Add(pdelta2);

                (nform.Statusbar.Items[1] as ToolStripProgressBar).Value = stat;
                (nform.Statusbar.Items[2] as ToolStripLabel).Text = String.Format(
                    "Started: {0}," + "Est. finish: {1}" + ", Duration: {2}",
                    currentdate.ToShortTimeString(),
                    finishtime.ToShortTimeString(),
                    String.Format("{0}h {1}m {2}s", pdelta2.Hours, pdelta2.Minutes, pdelta2.Seconds)
                    );
            }
        }

        public bool Execute() {
            bool res = false;
            if (executable != "") {
                nthread = new Thread(execthread);
                nthread.Start();
            }
            return res;
        }
    }
}
