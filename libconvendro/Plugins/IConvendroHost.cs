using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace libconvendro.Plugins {
    public interface IConvendroHost {
        bool Register(IConvendroPlugin plugin);
        void SetControlsThreading(Boolean var);
        ListView FileListView { get; set; }
        StatusStrip Statusbar { get; set; }
        TextBox LogBox { get; set; }
    }
}
