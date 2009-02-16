using System;
using System.Collections.Generic;
using System.Text;
using convendro;
using convendro.Properties;

namespace convendro.Classes {
    public static class Config {
        /// <summary>
        /// 
        /// </summary>
        public static Settings Settings {
            get { return convendro.Properties.Settings.Default; }
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aform"></param>
        public static void LoadFormSettings(frmMain aform) {
            aform.Location = Settings.mainFormLocation;
            aform.Size = Settings.mainFormSize;
            aform.WindowState = Settings.mainFormState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aform"></param>
        public static void SaveFormSettings(frmMain aform) {
            Settings.mainFormLocation = aform.Location;
            Settings.mainFormSize = aform.Size;
            Settings.mainFormState = aform.WindowState;
        }
    }
}
