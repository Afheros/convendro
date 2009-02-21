﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using convendro.Classes.Persistence;

namespace convendro.Classes.Threading {
    public enum ProcessStage {
        Unknown = 0,
        Starting = 1,
        Processing = 2,
        Error = 3
    }

    /// <summary>
    /// Test converter class to test stuff and that.
    /// </summary>
    public class TestConverter {
        private Form nform;
        private Thread nthread;
        private string executable;
        private MediaFileList mediafiles;
        private ManualResetEvent mnstopevent, mnhasstoppedevent;
        private ProcessStage processstage = ProcessStage.Unknown;

        public TestConverter(ManualResetEvent stopevent, ManualResetEvent hasstoppedevent) {
            this.mnstopevent = stopevent;
            this.mnhasstoppedevent = hasstoppedevent;

        }

        public Form Form {
            get { return nform; }
            set { nform = value; }
        }

        public Thread CurrentThread {
            get { return this.nthread; }
        }

        public string Executable {
            get { return this.executable; }
            set { this.executable = value; }
        }

        public MediaFileList MediaFileItems {
            get { return this.mediafiles; }
            set { this.mediafiles = value; }
        }

        protected virtual void execthread() {
            foreach (MediaFile i in mediafiles.Items) {
                if (mnstopevent.WaitOne(0, true)) {                    
                    mnhasstoppedevent.Set();
                    return;
                }

                Process nprocess = new Process();
                try {
                    nprocess.StartInfo.FileName = this.executable;
                    nprocess.StartInfo.Arguments = i.BuildCommandLine();
                    nprocess.EnableRaisingEvents = false;
                    nprocess.StartInfo.UseShellExecute = false;
                    nprocess.StartInfo.CreateNoWindow = true;
                    nprocess.StartInfo.RedirectStandardOutput = true;
                    nprocess.StartInfo.RedirectStandardError = true;
                    nprocess.Start();
                    StreamReader d = nprocess.StandardError;
                    do {
                        string s = d.ReadLine();
                        SynchOutputwindow(s);
                        if (s.Contains("Duration: ")) {
                            processstage = ProcessStage.Starting;
                        } else {
                            if (s.Contains("frame=")) {
                                processstage = ProcessStage.Processing;
                            } else {
                                processstage = ProcessStage.Error;
                            }
                        }

                        if (mnstopevent.WaitOne(0, true)) {
                            nprocess.Kill();
                            mnhasstoppedevent.Set();
                            return;
                        }

                    } while (!d.EndOfStream);
                    nprocess.WaitForExit();
                } finally {
                    nprocess.Close();
                }
            }
        }

        public void Execute() {
            if (executable != "") {
                nthread = new Thread(execthread);
                nthread.Start();
            }
        }

        protected virtual void SynchOutputwindow(string s) {
            if ((nform as frmTerminal).Terminal.InvokeRequired) {
                (nform as frmTerminal).Terminal.Invoke(new StringInvoker(SynchOutputwindow), new object[] { s });
            } else {
                (nform as frmTerminal).Terminal.Text += s + Environment.NewLine;
                (nform as frmTerminal).Terminal.SelectionStart =
                    (nform as frmTerminal).Terminal.Text.Length - 1;
                (nform as frmTerminal).Terminal.ScrollToCaret();
            }
        }

    }
}
