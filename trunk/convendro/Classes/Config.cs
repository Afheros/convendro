using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
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
        public static void LoadSettings(frmMain aform) {
            // Generate FFMPEG filepath
            GenerateFFMpegFilename();
            aform.Location = Settings.mainFormLocation;
            aform.Size = Settings.mainFormSize;
            aform.WindowState = Settings.mainFormState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aform"></param>
        public static void SaveSettings(frmMain aform) {
            Settings.mainFormLocation = aform.Location;
            Settings.mainFormSize = aform.Size;
            Settings.mainFormState = aform.WindowState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string TryFindFFMpegLocally() {
            string res = null;

            res = Path.Combine(Application.StartupPath, Functions.EXECUTABLE_FFMPEG);

            if (!File.Exists(res)) {
                res = null;
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static void GenerateFFMpegFilename() {
            string localfile = TryFindFFMpegLocally();

            if (String.IsNullOrEmpty(Settings.FFMPEGFilePath)) {
                if (!File.Exists(Settings.FFMPEGFilePath)) {
                    if (!String.IsNullOrEmpty(localfile)) {
                        Settings.FFMPEGFilePath = localfile;
                    }
                }
            } else {
                // We should probably check if the file stored in the settings 
                // is actually valid
                if (!File.Exists(Settings.FFMPEGFilePath)) {
                    Settings.FFMPEGFilePath = "";
                }
            }
        }
    }
}
