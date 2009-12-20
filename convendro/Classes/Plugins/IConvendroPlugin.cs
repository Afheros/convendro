using System;
using System.Collections.Generic;
using System.Text;

namespace convendro.Classes.Plugins {

    public interface IConvendroPlugin {
        string Name { get;}
        Guid Guid { get; }

        /// <summary>
        /// Activates a plugin in the host;
        /// </summary>
        void Activate();

        /// <summary>
        /// Deactivates a plugin in the host;
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Shows the plugin main dialog (if provided)
        /// </summary>
        bool Execute();

        /// <summary>
        /// 
        /// </summary>
        IConvendroHost Host { get; set; }

        /// <summary>
        /// Sets up the plugin
        /// </summary>
        void Initialize();

        /// <summary>
        /// Destroy the plugin;
        /// </summary>
        void Uninitialize();
    }
}
