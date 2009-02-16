using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Comparers;

namespace convendro.Classes.Persistence {
    /// <summary>
    /// A list of Presets, which is used to store presets 
    /// persistently to drive.
    /// </summary>
    public class PresetsFile {
        private List<Preset> presetslist = new List<Preset>();

        public PresetsFile() { }

        public List<Preset> Presets {
            get { return this.presetslist; }
            set { this.presetslist = value; }
        }

        public int AddPreset(Preset apreset) {
            int res = -1;
            try {
                presetslist.Add(apreset);
            } catch {
                res = -1;
            }
            return res;
        }

        public void RemovePreset(int anindex) {
            this.presetslist.RemoveAt(anindex);
        }

        public void RemovePreset(Preset apreset) {
            this.presetslist.Remove(apreset);
        }


        public Preset FindPreset(string name) {
            return this.presetslist.Find(delegate(Preset p) { return p.Name == name; });
        }

        public int FindPresetIndex(Preset apreset) {
            int res = -1;

            for (int i = 0; i < this.presetslist.Count; i++) {
                if (this.presetslist[i].Name == apreset.Name) {
                    res = i;
                    break;
                }
            }
            return res;
        }

        public int FindPresetIndex(string aname) {
            int res = -1;

            for (int i = 0; i < this.presetslist.Count; i++) {
                if (this.presetslist[i].Name == aname) {
                    res = i;
                    break;
                }
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Sort() {
            this.presetslist.Sort(new PresetsNameSorter());
        }

        /// <summary>
        /// 
        /// </summary>
        public void Sort(bool reverse) {
            this.presetslist.Sort(new PresetsNameSorter(reverse));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<Preset> comparer) {
            this.presetslist.Sort(comparer);
        }
    }

}
