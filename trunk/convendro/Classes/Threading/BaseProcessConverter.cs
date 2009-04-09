using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Persistence;
using System.Threading;

namespace convendro.Classes.Threading {
    
    // Base class..
    public class BaseProcessConverter : AbstractProcessConverter{
        private string executable;
        private MediaFileList mediafilelist;
        private Thread nthread;
        private frmMain nform;



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

        public override bool Execute() {
            return true;
        }
    }
}
