using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Persistence;

namespace convendro.Classes.Comparers {
    public class PresetsNameSorter : BasePresetsSorter {
        /// <summary>
        /// 
        /// </summary>
        public PresetsNameSorter() {
            this.Reverse = false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="reverseorder"></param>
        public PresetsNameSorter(bool reverseorder)
            : this() {
            this.Reverse = reverseorder;
        }

        public override int Compare(Preset x, Preset y) {
            int i = 0;

            if (x != null && y != null) {
                if (!this.Reverse) {
                    i = x.Name.CompareTo(y.Name);
                } else {
                    i = y.Name.CompareTo(x.Name);
                }
            }

            return i;
        }
    }
}
