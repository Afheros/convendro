using System;
using System.Collections.Generic;
using System.Text;

namespace convendro.Classes.Threading {
    public enum ProcessStage {
        Unknown = 0,
        Starting = 1,
        Processing = 2,
        Error = 3
    }
}
