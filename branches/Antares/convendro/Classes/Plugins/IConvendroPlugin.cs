using System;
using System.Collections.Generic;
using System.Text;

namespace convendro.Classes.Plugins {

    public interface IConvendroPlugin {
        string Name { get;}
        Guid Guid { get; }

        /// <summary>
        /// Shows the plugin main dialog (if provided)
        /// </summary>
        bool Execute();

        /// <summary>
        /// 
        /// </summary>
        IConvendroHost Host { get; set; }
    }
}
