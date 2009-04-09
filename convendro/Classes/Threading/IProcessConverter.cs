using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Persistence;
using System.Threading;

namespace convendro.Classes.Threading {

    /// <summary>
    /// Generalized ProcessConverter
    /// </summary>
    public interface IProcessConverter {
        public string Executable { get; set; }
        public MediaFileList MediaFileItems { get; set; }
        public Thread CurrentThread { get; set; }
        public bool Execute();
    }
}
