using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using convendro.Classes;
using convendro.Classes.Threading;
using convendro.Classes.Persistence;
using convendro.Classes.Comparers;

namespace convendro
{
    public partial class frmMain : Form
    {
        private PresetsFile presetdata = null;
        private MediaFileList mediafilelist = new MediaFileList();
        private FFMPEGConverter ffmpegconverter = null;
        private ManualResetEvent stopThreadEvent = new ManualResetEvent(false);
        private ManualResetEvent threadHasStoppedEvent = new ManualResetEvent(false);

        public const int SUBCOL_FILENAME = 0;
        public const int SUBCOL_PATH = 1;
        public const int SUBCOL_SIZE = 2;
        public const int SUBCOL_PRESETNAME = 3;
        public const int SUBCOL_DURATION = 4;

        public frmMain()
        {
            InitializeComponent();            
        }

        public TextBox LogBox {
            get { return this.textLogger; }
            set { this.textLogger = value; }
        }

        public Label TotalTime {
            get { return this.labelTotal; }
            set { this.labelTotal = value; }
        }

        public Label CurrentTime {
            get { return this.labelCurrent; }
            set { this.labelCurrent = value; }
        }

        public StatusStrip Statusbar {
            get { return this.mainStatusStrip; }
            set { this.mainStatusStrip = value; }
        }

        public ToolStripProgressBar FileProgress {
            get { return this.progressBarMain; }
            set { this.progressBarMain = value; }
        }

        public ListView FileListView {
            get { return this.listViewFiles; }
            set { this.listViewFiles = value; }
        }

        public PresetsFile PresetsFile {
            get { return this.presetdata; }
            set { this.presetdata = value; }
        }

        private void button1_Click(object sender, EventArgs e) {
            FFMPEGConverter nmpeg = new FFMPEGConverter();
            nmpeg.Form = this;
            nmpeg.Execute();
            
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent("FileDrop")) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData("FileDrop");
            for (int x = 0; x < files.Length; x++) {
                if (File.Exists(files[x])) {
                    AddFile(files[x]);
                }
            }
            updateStatusBar1();
        }

        private long AddFile(string p) {
            FileInfo n = new FileInfo(p);
            long ftotal = 0;
            if (n != null) {
                ListViewItem nitem = new ListViewItem();
                nitem.Text = n.Name;
                nitem.SubItems.Add(Path.GetDirectoryName(n.FullName));
                ftotal = n.Length;
                string s = Functions.ConvertFileSizeToString(n.Length);
                nitem.SubItems.Add(s);
                nitem.SubItems.Add("");
                nitem.SubItems.Add("");
                listViewFiles.Items.Add(nitem);
            }
            return ftotal;
        }

        /// <summary>
        /// 
        /// </summary>
        private void updateStatusBar1() {
            lblFilesBarMain.Text = String.Format("Files: {0}", 
                listViewFiles.Items.Count);
        }

        /// <summary>
        /// refreshes the preset menu...
        /// </summary>
        private void refreshPresetMenu() {
            // reset the menus...
            int con = filePresetsToolStripMenuItem.DropDownItems.IndexOf(
                fileSelectPresetListToolStripMenuItem);

            // context menu...
            int con1 = presetToolStripMenuItem.DropDownItems.IndexOf(
                selectPresetToolStripMenuItem);

            if (con != 0) {
                // delete everything
                int count = fileSelectPresetListToolStripMenuItem.DropDownItems.Count;

                while (count > 1) {
                    filePresetsToolStripMenuItem.DropDownItems.RemoveAt(0);
                    count = filePresetsToolStripMenuItem.DropDownItems.Count;
                }
            }

            // remove contexmenuitems...
            if (con != 0) {
                int count = presetToolStripMenuItem.DropDownItems.Count;
                while (count > 1) {
                    presetToolStripMenuItem.DropDownItems.RemoveAt(0);
                    count = presetToolStripMenuItem.DropDownItems.Count;
                }
            }

            //
            if (presetdata.Presets.Count > 0) {
                filePresetsToolStripMenuItem.DropDownItems.Insert(0, new ToolStripSeparator());
                presetToolStripMenuItem.DropDownItems.Insert(0, new ToolStripSeparator());
                // sort the data...
                PresetsUsedCountSorter p = new PresetsUsedCountSorter();
                try {
                    p.Reverse = false;
                    this.presetdata.Sort(p);
                    int x = 0;

                    while (x < 5 && x < this.presetdata.Presets.Count) {
                        Preset npreset = this.presetdata.Presets[x];
                        ToolStripMenuItem menuitem = new ToolStripMenuItem();

                        menuitem.Text = npreset.Name;
                        menuitem.ToolTipText = npreset.Description;
                        menuitem.Click += new EventHandler(dynamicPresetMenuItem_Click);                        
                        menuitem.ShortcutKeys = (Keys.Control | Keys.Alt | 
                            ((Keys) Enum.Parse(typeof(Keys), "D" + x.ToString())));
                        filePresetsToolStripMenuItem.DropDownItems.Insert(0, menuitem);

                        // contextmenu
                        ToolStripMenuItem contextmenuitem = new ToolStripMenuItem();
                        contextmenuitem.Text = npreset.Name;
                        contextmenuitem.ToolTipText = npreset.Description;
                        contextmenuitem.Click += new EventHandler(dynamicPresetMenuItem_Click);
                        contextmenuitem.ShortcutKeys = (Keys.Control | Keys.Alt |
                            ((Keys)Enum.Parse(typeof(Keys), "D" + x.ToString())));
                        presetToolStripMenuItem.DropDownItems.Insert(0, contextmenuitem);

                        x++;
                    }
                } finally {
                    this.presetdata.Sort();
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dynamicPresetMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem n = (sender as ToolStripMenuItem);

            if (n != null) {
                if (this.listViewFiles.SelectedItems.Count > 0) {
                    Preset npreset = this.presetdata.FindPreset(n.Text);

                    if (npreset != null) {
                        foreach (ListViewItem it in listViewFiles.SelectedItems) {
                            it.SubItems[SUBCOL_PRESETNAME].Text = npreset.Name;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void setUpToolbars() {
            toolStripContainer1.TopToolStripPanel.Join(toolsToolStrip);
            toolStripContainer1.TopToolStripPanel.Join(conversionToolStrip);
            toolStripContainer1.TopToolStripPanel.Join(fileToolStrip);
            toolStripContainer1.TopToolStripPanel.Join(mainMenuStrip);
        }

        /// <summary>
        /// Main Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e) {

            Config.LoadFormSettings(this);

            this.presetdata = Functions.DeserializePresetsData(Application.StartupPath + "\\" +
                Functions.FILENAME_PRESETSDATA);

            if (this.presetdata == null) {
                // create the object regardless...
                this.presetdata = new PresetsFile();
            }

            refreshPresetMenu();
            setUpToolbars();
            SetControlsThreading(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void presetsEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            frmPresetsEditor nform = new frmPresetsEditor(this.presetdata);

            nform.StartPosition = FormStartPosition.CenterParent;
            
            DialogResult res = nform.ShowDialog();
            try {
                if (res == DialogResult.OK) {
                    // Save Presetfile.
                    Functions.SerializePresetsData(
                        Functions.CombineCurrentFilePath(Functions.FILENAME_PRESETSDATA),
                        this.presetdata);
                }
            } finally {
                // Save commandline descriptions...
                nform.SaveDescriptionSettings(
                    Functions.CombineCurrentFilePath(
                    Functions.FILENAME_COMMANDLINEDESCRIPTION));
                nform.Dispose();
            }
        }

        /// <summary>
        /// Shows the about dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            frmAbout nabout = new frmAbout();
            try {
                nabout.ShowDialog();
            } finally {
                nabout.Dispose();
            }
        }

        private void fileExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }


        private void buildMediaFileList() {
            this.mediafilelist.Clear();
            foreach (ListViewItem n in listViewFiles.Items) {
                string filename = Path.Combine(n.SubItems[SUBCOL_PATH].Text, n.SubItems[SUBCOL_FILENAME].Text);
                Preset preset = presetdata.FindPreset(n.SubItems[SUBCOL_PRESETNAME].Text);

                if (preset != null) {
                    this.mediafilelist.AddMediaFile(filename, preset, n.Index);
                }

                Application.DoEvents();
            }
        }

        private void startConversionToolStripMenuItem_Click(object sender, EventArgs e) {
            buildMediaFileList();
            threadHasStoppedEvent.Reset();
            stopThreadEvent.Reset();
            SetControlsThreading(false);
            ffmpegconverter = new FFMPEGConverter(stopThreadEvent, 
                threadHasStoppedEvent);
            try {
                ffmpegconverter.Form = this;
                ffmpegconverter.MediaFileItems = this.mediafilelist;
                ffmpegconverter.Executable = Path.Combine(Application.StartupPath, "ffmpeg.exe");
                ffmpegconverter.Execute();
            } catch (Exception ex) {

            }
        }

        private void stopConversionToolStripMenuItem_Click(object sender, EventArgs e) {
            stopThread();
        }

        private void fileClearListToolStripMenuItem_Click(object sender, EventArgs e) {
            // ToDo check threading...
            listViewFiles.Items.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileAddListToolStripMenuItem_Click(object sender, EventArgs e) {
            // ToDo check threading...
            
            string filedir = (String.IsNullOrEmpty(
                        Config.Settings.LastUsedInputFolder) ?
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) :
                        Config.Settings.LastUsedInputFolder);
            

            OpenFileDialog openerdlg = new OpenFileDialog();
            try {
                openerdlg.Title = "Add file(s)";
                openerdlg.Filter = Functions.MEDIAFILES_FILTER;
                openerdlg.FilterIndex = Config.Settings.LastUsedMediaIndex;
                openerdlg.InitialDirectory = filedir;
                openerdlg.Multiselect = true;    

                DialogResult res = openerdlg.ShowDialog();


                if (res == DialogResult.OK) {
                    long total = 0;
                    foreach (String s in openerdlg.FileNames) {
                        filedir = Path.GetFullPath(s);
                        total += AddFile(s);
                    }

                }
            } finally {
                updateStatusBar1();
                Config.Settings.LastUsedMediaIndex = openerdlg.FilterIndex;
                Config.Settings.LastUsedInputFolder = filedir;                   
                openerdlg.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileDeleteListToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (ListViewItem n in listViewFiles.SelectedItems) {
                n.Remove();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileSelectPresetListToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count > 0) {
                frmPresetsEditor nform = new frmPresetsEditor(this.presetdata);

                nform.StartPosition = FormStartPosition.CenterParent;

                DialogResult res = nform.ShowDialog();
                try {
                    if (res == DialogResult.OK) {
                        if (nform.CurrentPreset != null) {
                            this.listViewFiles.SelectedItems[0].SubItems[SUBCOL_PRESETNAME].Text = nform.CurrentPreset.Name;
                            nform.CurrentPreset.LastUsed = DateTime.Now;
                            nform.CurrentPreset.UsedCount += 1;
                        }

                        // Save Presetfile.
                        Functions.SerializePresetsData(
                            Functions.CombineCurrentFilePath(Functions.FILENAME_PRESETSDATA),
                            this.presetdata);
                    }
                } finally {
                    // Save commandline descriptions...
                    nform.SaveDescriptionSettings(
                        Functions.CombineCurrentFilePath(
                        Functions.FILENAME_COMMANDLINEDESCRIPTION));
                    nform.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count > 0) {
                Functions.ShowPropertiesWindow(
                    Path.Combine(listViewFiles.SelectedItems[0].SubItems[SUBCOL_PATH].Text,
                    listViewFiles.SelectedItems[0].SubItems[SUBCOL_FILENAME].Text));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileMoveUpToolStripMenuIte_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count == 1) {
                if (listViewFiles.SelectedItems[0].Index > 0) {                   
                    ListViewItem i1 = listViewFiles.SelectedItems[0];
                    int ind = i1.Index;
                    listViewFiles.Items.RemoveAt(ind);
                    listViewFiles.Items.Insert(ind -1, i1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileMoveDownToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count == 1) {
                if (listViewFiles.SelectedItems[0].Index < listViewFiles.Items.Count - 1) {
                    ListViewItem i1 = listViewFiles.SelectedItems[0];
                    int ind = i1.Index;
                    listViewFiles.Items.RemoveAt(ind);
                    listViewFiles.Items.Insert(ind + 1, i1);
                }
            }
        }

        /// <summary>
        /// stops the thread...
        /// </summary>
        private void stopThread() {
            if (ffmpegconverter != null) {
                if (ffmpegconverter.CurrentThread != null && ffmpegconverter.CurrentThread.IsAlive) {                    
                    stopThreadEvent.Set();

                    while (ffmpegconverter.CurrentThread.IsAlive) {
                        if (WaitHandle.WaitAll(new ManualResetEvent[] { threadHasStoppedEvent }, 100, true)) {
                            break;
                        }
                        Application.DoEvents();
                    }
                }
            }

            SetControlsThreading(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadfinished"></param>
        public void SetControlsThreading(bool threadfinished) {
            conversionPlaytoolStripButton.Enabled = threadfinished;
            conversionStartToolStripMenuItem.Enabled = threadfinished;

            conversionStopToolStripButton.Enabled = !threadfinished;
            conversionStopToolStripMenuItem.Enabled = !threadfinished;

            progressBarMain.Value = 0;
            if (threadfinished) {
                lblStatusBarMain.Text = "";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            stopThread();
            // Save settings...
            Config.SaveFormSettings(this);

            Config.Settings.Save();
            e.Cancel = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editSelectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (ListViewItem i in listViewFiles.Items) {
                i.Selected = true;
                Application.DoEvents();
            }
        }
    }
}
