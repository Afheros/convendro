using System;
using System.Collections.Generic;
using System.Text;

namespace convendro.Classes.Plugins {
    public interface IConvendroHost {
        bool Register(IConvendroPlugin plugin);
    }
}
