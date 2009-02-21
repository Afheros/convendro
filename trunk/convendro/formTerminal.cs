using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using convendro.Classes.Threading;
using System.Threading;
using convendro.Classes.Persistence;

namespace convendro {
    public partial class frmTerminal : Form {
        private TestConverter convertthread = null;
        private string executable;
        private MediaFileList mediafilelist = null;
        private ManualResetEvent stopthreadevent = new ManualResetEvent(false);
        private ManualResetEvent threadhasstoppedevent = new ManualResetEvent(false);       

        public frmTerminal() {
            InitializeComponent();
        }

        public frmTerminal(MediaFileList afilelist, string anexecutable) : this() {
            this.executable = anexecutable;
            if (afilelist != null) {
                mediafilelist = afilelist;
            }
        }

        private void formTerminal_Load(object sender, EventArgs e) {
            this.edTerminalLog.Text = "";
            this.convertthread = new TestConverter(stopthreadevent, threadhasstoppedevent);
            this.convertthread.Executable = this.executable;
            this.convertthread.MediaFileItems = this.mediafilelist;
            this.convertthread.Form = this;
            this.convertthread.Execute();
        }
       
        public RichTextBox Terminal {
            get { return edTerminalLog; }
            set { edTerminalLog = value; }
        }

        public void StartProcessing() {
            stopthreadevent.Reset();
            threadhasstoppedevent.Reset();
        }

        public void StopProcessing() {
            if (convertthread != null) {
                if (convertthread.CurrentThread != null && convertthread.CurrentThread.IsAlive) {
                    stopthreadevent.Set();

                    while (convertthread.CurrentThread.IsAlive) {
                        if (WaitHandle.WaitAll(new ManualResetEvent[] { threadhasstoppedevent }, 100, true)) {
                            break;
                        }
                        Application.DoEvents();
                    }
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void formTerminal_FormClosing(object sender, FormClosingEventArgs e) {
            StopProcessing();
            e.Cancel = false;
        }

        private void frmTerminal_FormClosed(object sender, FormClosedEventArgs e) {
            this.Dispose();
        }
    }
}
