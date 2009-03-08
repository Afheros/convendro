using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using convendro;
using convendro.Properties;

namespace convendro.Classes {
    public static class Config {
        public static string LocalAppPath = "";

        /// <summary>
        /// Static accessor to the xx.xxx.xxx.xxx.xxx crap.
        /// </summary>
        public static Settings Settings {
            get { return convendro.Properties.Settings.Default; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string generateLocalAppFolder() {
            DirectoryInfo ning = Directory.CreateDirectory(Functions.GetCurrentLocalAppPath());

            return ning.FullName;
        }

        /// <summary>
        /// Initializes and loads settings from the AppConfig file.
        /// </summary>
        /// <param name="aform"></param>
        public static void LoadSettings(frmMain aform) {
            // Generate FFMPEG filepath
            // GenerateFFMpegFilename();
            // GeneratePresetFilename();            

            if (Directory.Exists(Functions.GetCurrentLocalAppPath())) {
                LocalAppPath = Functions.GetCurrentLocalAppPath();
            } else {
                LocalAppPath = generateLocalAppFolder();
            }

            Settings.FFMPEGFilePath = generateSettingsFileName(
                Functions.FILENAME_EXECUTABLE_FFMPEG, 
                Settings.FFMPEGFilePath);

            Settings.LastUsedPresetFile = generateSettingsFileName(
                Functions.FILENAME_PRESETSDATA,
                Settings.LastUsedPresetFile);

            Settings.LastUsedCommandDescriptionFile = generateSettingsFileName(
                Functions.FILENAME_COMMANDLINEDESCRIPTION,
                Settings.LastUsedCommandDescriptionFile);

            GenerateDefaultFolders();

            aform.Location = Settings.mainFormLocation;
            aform.Size = Settings.mainFormSize;
            aform.WindowState = Settings.mainFormState;

            string[] s = Settings.fileListViewColumns.Split(new char[] { '|' });

            if (s.Length >= aform.FileListView.Columns.Count) {
                for (int i = 0; i < aform.FileListView.Columns.Count; i++ ) {
                    int disp = Convert.ToInt32(s[i]);
                    // TODO...
                    aform.FileListView.Columns[i].DisplayIndex = disp;
                }
            }
        }

        /// <summary>
        /// Saves the Form settings to the INI file
        /// </summary>
        /// <param name="aform"></param>
        public static void SaveSettings(frmMain aform) {
            Settings.mainFormLocation = aform.Location;
            Settings.mainFormSize = aform.Size;
            Settings.mainFormState = aform.WindowState ;

            string s = "";
            foreach (ColumnHeader h in aform.FileListView.Columns) {
                s += h.DisplayIndex.ToString() + "|";
            }

            // Remove trailing "|"
            s = s.Trim(new char[] { '|' });
            Settings.fileListViewColumns = s;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private static string tryFindConstantFileLocally(string filename) {
            string res = null;

            res = Path.Combine(Functions.GetCurrentLocalAppPath(), filename);

            if (!File.Exists(res)) {
                res = null;
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="settingfilepath"></param>
        private static string generateSettingsFileName(string filename, string settingfilepath) {
            string res = settingfilepath;

            string localfile = tryFindConstantFileLocally(filename);

            if (String.IsNullOrEmpty(res)) {
                if (!File.Exists(res)) {
                    if (!String.IsNullOrEmpty(localfile)) {
                        res = localfile;                        
                    }
                }
            } else {
                if (!File.Exists(res)) {
                    res = "";
                }
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GenerateDefaultFolders() {
            
            if (String.IsNullOrEmpty(Settings.LastUsedOutputFolder)) {
                Settings.LastUsedOutputFolder = 
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            if (String.IsNullOrEmpty(Settings.LastUsedMediaSetFolder)) {
                Settings.LastUsedMediaSetFolder =
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }
    }
}
