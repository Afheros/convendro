﻿using System;
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
using convendro.Classes.Import;

namespace convendro {
    public partial class frmMain : Form {
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
        public const int SUBCOL_STARTED = 5;
        public const int SUBCOL_FINISHED = 6;

        public frmMain() {
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

        /// <summary>
        /// Verify if thread is running or not...
        /// </summary>
        /// <returns></returns>
        public bool IsThreadRunning() {
            bool ret = false;

            // Check if thread is active..
            if (this.ffmpegconverter != null) {
                if (this.ffmpegconverter.CurrentThread.IsAlive) {
                    ret = true;
                }
            }

            return ret;
        }

        private void listViewFiles_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent("FileDrop")) {
                // check if thread is still running...
                e.Effect = (!IsThreadRunning() ? DragDropEffects.Copy : DragDropEffects.None);
            }
        }

        private void listViewFiles_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData("FileDrop");
            for (int x = 0; x < files.Length; x++) {
                if (File.Exists(files[x])) {
                    AddFile(files[x]);
                }
            }
            SetControlsThreading(true);
            updateStatusBar1();
        }

        /// <summary>
        /// Adds a file to the filelistview...
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
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
            int con = mediafilesPresetsToolStripMenuItem.DropDownItems.IndexOf(
                mediafileSelectPresetListToolStripMenuItem);

            // context menu...
            int con1 = presetToolStripMenuItem.DropDownItems.IndexOf(
                selectPresetToolStripMenuItem);

            if (con != 0) {
                // delete everything
                int count = mediafileSelectPresetListToolStripMenuItem.DropDownItems.Count;

                while (count > 1) {
                    mediafilesPresetsToolStripMenuItem.DropDownItems.RemoveAt(0);
                    count = mediafilesPresetsToolStripMenuItem.DropDownItems.Count;
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
                mediafilesPresetsToolStripMenuItem.DropDownItems.Insert(0, new ToolStripSeparator());
                presetToolStripMenuItem.DropDownItems.Insert(0, new ToolStripSeparator());
                // sort the data...
                PresetsUsedCountSorter p = new PresetsUsedCountSorter();
                try {
                    p.Reverse = true;
                    this.presetdata.Sort(p);
                    int x = 0;

                    while (x < 5 && x < this.presetdata.Presets.Count) {
                        Preset npreset = this.presetdata.Presets[x];
                        ToolStripMenuItem menuitem = new ToolStripMenuItem();

                        menuitem.Text = npreset.Name;
                        menuitem.ToolTipText = npreset.Description;
                        menuitem.Click += new EventHandler(dynamicPresetMenuItem_Click);
                        menuitem.ShortcutKeys = (Keys.Control | Keys.Alt |
                            ((Keys)Enum.Parse(typeof(Keys), "D" + x.ToString())));
                        mediafilesPresetsToolStripMenuItem.DropDownItems.Insert(0, menuitem);

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
            Config.LoadSettings(this);

            // Prepare PresetFile
            if (String.IsNullOrEmpty(Config.Settings.LastUsedPresetFile)) {
                this.presetdata = null;
                Config.Settings.LastUsedPresetFile = Path.Combine(Application.StartupPath,
                    Functions.FILENAME_PRESETSDATA);
            } else {
                this.presetdata = Functions.DeserializePresetsData(
                    Config.Settings.LastUsedPresetFile);
            }

            //
            if (String.IsNullOrEmpty(Config.Settings.LastUsedCommandDescriptionFile)) {
                Config.Settings.LastUsedCommandDescriptionFile =
                    Path.Combine(Application.StartupPath, Functions.FILENAME_COMMANDLINEDESCRIPTION);
            }

            // Create the file automatically...
            if (this.presetdata == null) {
                this.presetdata = new PresetsFile();
            }

            refreshPresetMenu();
            setUpToolbars();
            SetControlsThreading(true);

            // If FFMEPG doesn't exist, we should probably show a dialog...
            if (String.IsNullOrEmpty(Config.Settings.FFMPEGFilePath)) {
                MessageBox.Show("FFMPeg was not found. You may wish to set this in the settings", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolsPresetsEditorToolStripMenuItem_Click(object sender, EventArgs e) {
            frmPresetsEditor nform = new frmPresetsEditor(this.presetdata);

            nform.StartPosition = FormStartPosition.CenterParent;

            DialogResult res = nform.ShowDialog();
            try {
                if (res == DialogResult.OK) {
                    // Save Presetfile.
                    Functions.SerializePresetsData(
                        Config.Settings.LastUsedPresetFile,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileExitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesStartConversionToolStripMenuItem_Click(object sender, EventArgs e) {
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
            } catch {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesStopConversionToolStripMenuItem_Click(object sender, EventArgs e) {
            stopThread();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesClearListToolStripMenuItem_Click(object sender, EventArgs e) {
            listViewFiles.Items.Clear();
            this.SetControlsThreading(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesAddListToolStripMenuItem_Click(object sender, EventArgs e) {
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
                this.SetControlsThreading(true);
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
        private void mediafilesDeleteListToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (ListViewItem n in listViewFiles.SelectedItems) {
                n.Remove();
            }
            this.SetControlsThreading(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesSelectPresetListToolStripMenuItem_Click(object sender, EventArgs e) {
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
                        Functions.SerializePresetsData(Config.Settings.LastUsedPresetFile, this.presetdata);
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
        private void mediafilesPropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
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
        private void mediafilesMoveUpToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count == 1) {
                if (listViewFiles.SelectedItems[0].Index > 0) {
                    ListViewItem i1 = listViewFiles.SelectedItems[0];
                    int ind = i1.Index;
                    listViewFiles.Items.RemoveAt(ind);
                    listViewFiles.Items.Insert(ind - 1, i1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mediafilesMoveDownToolStripMenuItem_Click(object sender, EventArgs e) {
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

            // ProgressBar
            progressBarMain.Visible = !threadfinished;

            // Play...
            mediafilesPlaytoolStripButton.Enabled = threadfinished
                && !String.IsNullOrEmpty(Config.Settings.FFMPEGFilePath)
                && listViewFiles.Items.Count > 0;
            conversionStartToolStripMenuItem.Enabled =
                mediafilesPlaytoolStripButton.Enabled;

            // Stop
            mediafilesStopToolStripButton.Enabled = !threadfinished;
            conversionStopToolStripMenuItem.Enabled = !threadfinished;

            // TestRun
            mediafilesTestRunToolStripMenuItem.Enabled =
                (listViewFiles.Items.Count > 0);
            mediafilesTestRunToolStripButton.Enabled =
                mediafilesTestRunToolStripMenuItem.Enabled;

            mediafilesClearListToolStripMenuItem.Enabled = threadfinished;
            mediafilesClearListToolStripButton.Enabled = threadfinished;

            mediafilesAddListToolStripMenuItem.Enabled = threadfinished;
            mediafilesAddListToolStripButton.Enabled = threadfinished;

            mediafilesDeleteListToolStripMenuItem.Enabled = threadfinished;
            mediafilesDeleteListToolStripButton.Enabled = threadfinished;

            mediafilesMoveDownToolStripButton.Enabled = threadfinished;
            mediafilesMoveDownToolStripMenuItem.Enabled = threadfinished;

            mediafilesMoveUpToolStripButton.Enabled = threadfinished;
            mediafilesMoveUpToolStripMenuIte.Enabled = threadfinished;


            progressBarMain.Value = 0;

            if (threadfinished) {
                lblStatusBarMain.Text = "";
            }

        }

        /// <summary>
        /// Loads a pre-existing mediafile/queue into the mediafile object.
        /// </summary>
        /// <param name="afilename"></param>
        public void LoadMediaFileList(string afilename) {
            if (File.Exists(afilename)) {
                try {
                    this.mediafilelist = Functions.DeserializeMediaFileList(afilename);

                    // Add new presets, where necessary...
                    if (mediafilelist != null) {
                        foreach (MediaFile f in mediafilelist.Items) {
                            Preset internalpreset = f.Preset;

                            if (this.presetdata.FindPresetIndex(internalpreset) == -1) {
                                this.presetdata.AddPreset(internalpreset);
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Saves the current mediafile to file.
        /// </summary>
        /// <param name="afilename"></param>
        public void SaveMediaFileList(string afilename) {
            try {
                Functions.SerializeMediaFileList(afilename, this.mediafilelist);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            stopThread();
            Config.SaveSettings(this);

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


        private void ctxListView_Opening(object sender, CancelEventArgs e) {
            testRunToolStripMenuItem.Enabled =
                (listViewFiles.Items.Count > 0) &&
                (listViewFiles.SelectedItems.Count == 1) &&
                (listViewFiles.SelectedItems[0].SubItems[SUBCOL_PRESETNAME].Text != "");
        }

        private void mediafilesTestRunToolStripMenuItem_Click(object sender, EventArgs e) {
            MediaFileList newlist = new MediaFileList();

            foreach (ListViewItem n in listViewFiles.SelectedItems) {
                string filename = Path.Combine(n.SubItems[SUBCOL_PATH].Text, n.SubItems[SUBCOL_FILENAME].Text);
                Preset preset = presetdata.FindPreset(n.SubItems[SUBCOL_PRESETNAME].Text);

                if (preset != null) {
                    newlist.AddMediaFile(filename, preset, n.Index);
                }
            }

            frmTerminal nterm = new frmTerminal(newlist,
                Config.Settings.FFMPEGFilePath);
            nterm.Show();
            nterm.StartProcessing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exploreFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            if (listViewFiles.SelectedItems.Count > 0) {
                foreach (ListViewItem i in listViewFiles.SelectedItems) {
                    Functions.ShowFolderExplorer(i.SubItems[SUBCOL_PATH].Text);
                }
            }
        }

        /// <summary>
        /// Generic import method.
        /// </summary>
        /// <param name="animporter"></param>
        private void importPresets(string caption, IImporter animporter) {
            OpenFileDialog nfile = new OpenFileDialog();
            nfile.Filter = String.Format("{0}|{1}",
                Functions.MEDIAFILES_FILTER_XML, Functions.MEDIAFILES_FILTER_ALL);
            nfile.Title = caption;
            try {
                if (nfile.ShowDialog() == DialogResult.OK) {
                    // Make a backup of the file...
                    if (Config.Settings.MakeBackupsXMLFiles) {
                        Functions.CreateBackupFile(Config.Settings.LastUsedPresetFile);
                    }

                    animporter.LoadFile(nfile.FileName);

                    if (animporter.Presets.Count > 0) {
                        int oldcount = this.presetdata.Presets.Count;
                        this.presetdata.AddPresets(animporter.Presets);
                        if (this.presetdata.Presets.Count > oldcount) {
                            MessageBox.Show(String.Format("{0} files were imported...",
                                (this.presetdata.Presets.Count - oldcount)));
                        }
                    }
                }
            } finally {
                nfile.Dispose();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileImportWinFFToolStripMenuItem_Click(object sender, EventArgs e) {
            this.importPresets("Import WinFF file", new WinFFFile());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fileImportVideoraToolStripMenuItem_Click(object sender, EventArgs e) {
            this.importPresets("Import Videora file", new VideoraFile());
        }
    }
}
