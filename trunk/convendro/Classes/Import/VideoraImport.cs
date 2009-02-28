using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using convendro.Classes.Persistence;

namespace convendro.Classes.Import {

    /// <summary>
    /// 
    /// </summary>
    public static class VideoraImport {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="profiles"></param>
        /// <returns></returns>
        public static bool SerializeVideoraFile(string filename, ProfileList profiles) {
            bool res = false;

            XmlSerializer nser = new XmlSerializer(typeof(ProfileList));
            TextWriter ntext = new StreamWriter(filename);
            try {
                nser.Serialize(ntext, profiles);
                ntext.Flush();
                res = true;
            } catch {
                res = false;
            } finally {
                ntext.Dispose();
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static ProfileList DeserializeVideoraFile(string filename) {
            ProfileList pf = null;

            if (File.Exists(filename)) {
                XmlSerializer nser = new XmlSerializer(typeof(ProfileList));
                TextReader ntext = new StreamReader(filename);
                try {
                    pf = (ProfileList)nser.Deserialize(ntext);
                } finally {
                    ntext.Close();
                    ntext.Dispose();
                }
            }
            return pf;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VideoraFile : BaseImporter {
        private CommandLineOptions createCommandLineOptions(profile i) {
            CommandLineOptions res = null;

            try {
                res = new CommandLineOptions();
                if (i.abitrate != 0) {
                    res.Add("ab", i.abitrate.ToString());
                }

                if (i.achannels != 0) {
                    res.Add("ac", i.achannels.ToString());
                }

            } catch (Exception ex) {
                // do something...
            }

            return res;
        }

        private void processVideoraItems(ProfileList afilelist) {
            foreach (profile i in afilelist) {
                Preset pr = new Preset();
                pr.Name = i.name;
                pr.Category = Path.GetFileNameWithoutExtension(this.file);
                pr.Description = i.encoder;
                pr.Extension = "mp4";                
                
            }
        }

        public override void LoadFile(string filename) {
            base.LoadFile(filename);
            if (File.Exists(filename)) {
                ProfileList newprofile = VideoraImport.DeserializeVideoraFile(filename);

                if (newprofile != null) {
                }
            }
        }
    }
    /// <summary>
    /// Quick and Dirty....
    /// </summary>
    [XmlRoot("ProfileList")]
    public class ProfileList : List<profile> {
        public ProfileList() {
        }
       
    }

    /// <summary>
    /// Quick and Dirty...
    /// </summary>
    public class profile {
        [XmlAttribute()]
        public string name;
        [XmlAttribute()]
        public string encoder;
        [XmlAttribute()]
        public int position;
        [XmlAttribute()]
        public int duration;
        [XmlAttribute()]
        public string vcodec;
        [XmlAttribute()]
        public string vprofile;
        [XmlAttribute()]
        public string vlevel;
        [XmlAttribute()]
        public string vmode;
        [XmlAttribute()]
        public int vbitrate;
        [XmlAttribute()]
        public int vcrf;
        [XmlAttribute()]
        public int vcqp;
        [XmlAttribute()]
        public int vwidth;
        [XmlAttribute()]
        public int vheight;
        [XmlAttribute()]
        public string vaspect;
        [XmlAttribute()]
        public int vframerate;
        [XmlAttribute()]
        public bool varenabled;
        [XmlAttribute()]
        public string varmaxres;
        [XmlAttribute()]
        public bool varmod16;
        [XmlAttribute()]
        public bool vartotal;
        [XmlAttribute()]
        public bool vafenabled;
        [XmlAttribute()]
        public int vcroptop;
        [XmlAttribute()]
        public int vcropbottom;
        [XmlAttribute()]
        public int vcropleft;
        [XmlAttribute()]
        public int vcropright;
        [XmlAttribute()]
        public int vpadtop;
        [XmlAttribute()]
        public int vpadbottom;
        [XmlAttribute()]
        public int vpadleft;
        [XmlAttribute()]
        public int vpadright;
        [XmlAttribute()]
        public string vcli;
        [XmlAttribute()]
        public string vcli1;
        [XmlAttribute()]
        public string vcli2;
        [XmlAttribute()]
        public bool vavsenabled;
        [XmlAttribute()]
        public bool vavsautofps;
        [XmlAttribute()]
        public int vavsmanualfps;
        [XmlAttribute()]
        public bool vavsconvertfps;
        [XmlAttribute()]
        public int vavsaudiodelay;
        [XmlAttribute()]
        public bool vavssubtitles;
        [XmlAttribute()]
        public int vbufsize;
        [XmlAttribute()]
        public int vminrate;
        [XmlAttribute()]
        public int vmaxrate;
        [XmlAttribute()]
        public int vkeyint;
        [XmlAttribute()]
        public bool vdeinterlace;
        [XmlAttribute()]
        public int vthreads;
        [XmlAttribute()]
        public bool vcabac;
        [XmlAttribute()]
        public bool vvgauuid;
        [XmlAttribute()]
        public string acodec;
        [XmlAttribute()]
        public string amode;
        [XmlAttribute()]
        public int abitrate;
        [XmlAttribute()]
        public int achannels;
        [XmlAttribute()]
        public int asamplerate;
        [XmlAttribute()]
        public int avol;
        [XmlAttribute()]
        public string acli;
    }
}
