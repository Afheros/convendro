using System;
using System.Collections.Generic;
using System.Text;
using convendro.Classes.Persistence;

namespace convendro.Classes.Comparers {
    public abstract class BasePresetsSorter : IComparer<Preset> {
        private bool reverse = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Reverse {
            get { return reverse; }
            set { reverse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract int Compare(Preset x, Preset y);
    }
}
