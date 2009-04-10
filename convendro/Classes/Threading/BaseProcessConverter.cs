using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Persistence;
using System.Threading;

namespace convendro.Classes.Threading {
    
    // Base class..
    public class BaseProcessConverter : AbstractProcessConverter{
        private string executable;
        private MediaFileList mediafilelist = null;
        private Thread nthread = null;
        private frmMain nform = null;

        /// <summary>
        /// 
        /// </summary>
        public override string Executable {
            get { return this.executable; }
            set { this.executable = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override MediaFileList MediaFileItems {
            get {
                return this.mediafilelist;
            }
            set {
                this.mediafilelist = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public frmMain Form {
            get { return this.nform; }
            set { this.nform = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Thread CurrentThread {
            get { return this.nthread; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void execthread(){
            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool Execute() {
            bool res = false;
            if (executable != "") {
                nthread = new Thread(execthread);
                try {
                    nthread.Start();
                    res = true;
                } catch {
                    res = false;
                }
            }
            return res;            
        }
    }
}
