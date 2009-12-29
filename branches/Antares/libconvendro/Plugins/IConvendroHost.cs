using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libconvendro.Persistence;

namespace libconvendro.Plugins {
    /// <summary>
    /// Allows the thread to work on the mainform.
    /// </summary>
    public interface IThreadingHost {
        void SetControlsThreading(Boolean var);
        ListView FileListView { get; set; }
        StatusStrip Statusbar { get; set; }
        TextBox LogBox { get; set; }
    }

    /// <summary>
    /// Allows access to the current worklist, including presets.
    /// </summary>
    public interface IConvendroHost {
        /// void GetSelected
        MediaFileList MediaFileList {get; }
        int[] SelectedIndices { get; set; }
        PresetsFile PresetsFile { get; set; }

        ListViewItem GetFileListViewItem(int index);       
    }
}
