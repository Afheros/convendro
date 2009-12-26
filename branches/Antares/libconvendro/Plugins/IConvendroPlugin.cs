using System;
using System.Collections.Generic;
using System.Text;

namespace libconvendro.Plugins {

    public interface IConvendroPlugin {
        string Name { get;}

        string Description { get; }

        string Author { get;}

        string CopyrightInformation { get;}

        Version Version { get; }

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
