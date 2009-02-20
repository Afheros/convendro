namespace convendro
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textLogger = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colPath = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colPresetName = new System.Windows.Forms.ColumnHeader();
            this.colDuration = new System.Windows.Forms.ColumnHeader();
            this.colStarted = new System.Windows.Forms.ColumnHeader();
            this.colFinished = new System.Windows.Forms.ColumnHeader();
            this.ctxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportWinFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileImportVideoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.editInvertSelectionToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesClearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesAddListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesDeleteListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mediafilesMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesMoveUpToolStripMenuIte = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesMoveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafilesPresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediafileSelectPresetListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.conversionStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionStopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsPresetsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.fileExitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileClearListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileAddListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileDeleteListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.fileMoveUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.fileMoveDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fileSelectPresetListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.conversionToolStrip = new System.Windows.Forms.ToolStrip();
            this.conversionPlaytoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.conversionStopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolsEditPresetsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblFilesBarMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarMain = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusBarMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.ctxListView.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.fileToolStrip.SuspendLayout();
            this.conversionToolStrip.SuspendLayout();
            this.toolsToolStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLogger
            // 
            this.textLogger.Location = new System.Drawing.Point(150, 12);
            this.textLogger.Multiline = true;
            this.textLogger.Name = "textLogger";
            this.textLogger.Size = new System.Drawing.Size(534, 207);
            this.textLogger.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(552, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(56, 190);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(35, 13);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "label1";
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(138, 178);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(35, 13);
            this.labelCurrent.TabIndex = 3;
            this.labelCurrent.Text = "label2";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listViewFiles);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(690, 323);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(690, 416);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.fileToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.conversionToolStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolsToolStrip);
            // 
            // listViewFiles
            // 
            this.listViewFiles.AllowColumnReorder = true;
            this.listViewFiles.AllowDrop = true;
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colPath,
            this.colSize,
            this.colPresetName,
            this.colDuration,
            this.colStarted,
            this.colFinished});
            this.listViewFiles.ContextMenuStrip = this.ctxListView;
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.GridLines = true;
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(0, 0);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(690, 323);
            this.listViewFiles.TabIndex = 0;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragDrop);
            this.listViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewFiles_DragEnter);
            // 
            // colFileName
            // 
            this.colFileName.Text = "File";
            this.colFileName.Width = 123;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 134;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.Width = 80;
            // 
            // colPresetName
            // 
            this.colPresetName.Text = "Preset";
            this.colPresetName.Width = 85;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration";
            // 
            // colStarted
            // 
            this.colStarted.Text = "StartTime";
            // 
            // colFinished
            // 
            this.colFinished.Text = "Finished";
            // 
            // ctxListView
            // 
            this.ctxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem,
            this.deleteFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.presetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.propertiesToolStripMenuItem});
            this.ctxListView.Name = "ctxListView";
            this.ctxListView.Size = new System.Drawing.Size(137, 104);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFileToolStripMenuItem.Image")));
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.addFileToolStripMenuItem.Text = "Add File...";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.mediafilesAddListToolStripMenuItem_Click);
            // 
            // deleteFileToolStripMenuItem
            // 
            this.deleteFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFileToolStripMenuItem.Image")));
            this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
            this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteFileToolStripMenuItem.Text = "Delete";
            this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.mediafilesDeleteListToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectPresetToolStripMenuItem});
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.presetToolStripMenuItem.Text = "Preset";
            // 
            // selectPresetToolStripMenuItem
            // 
            this.selectPresetToolStripMenuItem.Image = global::convendro.Properties.Resources.application_form_magnify;
            this.selectPresetToolStripMenuItem.Name = "selectPresetToolStripMenuItem";
            this.selectPresetToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.selectPresetToolStripMenuItem.Text = "Select...";
            this.selectPresetToolStripMenuItem.Click += new System.EventHandler(this.mediafilesSelectPresetListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.propertiesToolStripMenuItem.Text = "Properties...";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.mediaFilesToolStripMenuItem,
            this.toolsToolsStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(690, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileImportToolStripMenuItem,
            this.toolStripSeparator5,
            this.fileExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileImportToolStripMenuItem
            // 
            this.fileImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileImportWinFFToolStripMenuItem,
            this.fileImportVideoraToolStripMenuItem});
            this.fileImportToolStripMenuItem.Name = "fileImportToolStripMenuItem";
            this.fileImportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.fileImportToolStripMenuItem.Text = "Import";
            // 
            // fileImportWinFFToolStripMenuItem
            // 
            this.fileImportWinFFToolStripMenuItem.Name = "fileImportWinFFToolStripMenuItem";
            this.fileImportWinFFToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fileImportWinFFToolStripMenuItem.Text = "WinFF...";
            this.fileImportWinFFToolStripMenuItem.Click += new System.EventHandler(this.fileImportWinFFToolStripMenuItem_Click);
            // 
            // fileImportVideoraToolStripMenuItem
            // 
            this.fileImportVideoraToolStripMenuItem.Name = "fileImportVideoraToolStripMenuItem";
            this.fileImportVideoraToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.fileImportVideoraToolStripMenuItem.Text = "Videora...";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(107, 6);
            // 
            // fileExitToolStripMenuItem
            // 
            this.fileExitToolStripMenuItem.Image = global::convendro.Properties.Resources.cancel;
            this.fileExitToolStripMenuItem.Name = "fileExitToolStripMenuItem";
            this.fileExitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.fileExitToolStripMenuItem.Text = "Exit";
            this.fileExitToolStripMenuItem.Click += new System.EventHandler(this.fileExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCopyToolStripMenuItem,
            this.toolStripSeparator8,
            this.editInvertSelectionToolStripItem,
            this.editSelectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // editCopyToolStripMenuItem
            // 
            this.editCopyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editCopyToolStripMenuItem.Image")));
            this.editCopyToolStripMenuItem.Name = "editCopyToolStripMenuItem";
            this.editCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.editCopyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editCopyToolStripMenuItem.Text = "Copy";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(161, 6);
            // 
            // editInvertSelectionToolStripItem
            // 
            this.editInvertSelectionToolStripItem.Name = "editInvertSelectionToolStripItem";
            this.editInvertSelectionToolStripItem.Size = new System.Drawing.Size(164, 22);
            this.editInvertSelectionToolStripItem.Text = "Invert Selection";
            // 
            // editSelectAllToolStripMenuItem
            // 
            this.editSelectAllToolStripMenuItem.Name = "editSelectAllToolStripMenuItem";
            this.editSelectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.editSelectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editSelectAllToolStripMenuItem.Text = "Select All";
            this.editSelectAllToolStripMenuItem.Click += new System.EventHandler(this.editSelectAllToolStripMenuItem_Click);
            // 
            // mediaFilesToolStripMenuItem
            // 
            this.mediaFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediafilesClearListToolStripMenuItem,
            this.mediafilesAddListToolStripMenuItem,
            this.mediafilesDeleteListToolStripMenuItem,
            this.toolStripSeparator7,
            this.mediafilesMoveToolStripMenuItem,
            this.mediafilesPresetsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.conversionStartToolStripMenuItem,
            this.conversionStopToolStripMenuItem});
            this.mediaFilesToolStripMenuItem.Name = "mediaFilesToolStripMenuItem";
            this.mediaFilesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.mediaFilesToolStripMenuItem.Text = "MediaFiles";
            // 
            // mediafilesClearListToolStripMenuItem
            // 
            this.mediafilesClearListToolStripMenuItem.Image = global::convendro.Properties.Resources.page_white;
            this.mediafilesClearListToolStripMenuItem.Name = "mediafilesClearListToolStripMenuItem";
            this.mediafilesClearListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediafilesClearListToolStripMenuItem.Text = "Clear";
            this.mediafilesClearListToolStripMenuItem.Click += new System.EventHandler(this.mediafilesClearListToolStripMenuItem_Click);
            // 
            // mediafilesAddListToolStripMenuItem
            // 
            this.mediafilesAddListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mediafilesAddListToolStripMenuItem.Image")));
            this.mediafilesAddListToolStripMenuItem.Name = "mediafilesAddListToolStripMenuItem";
            this.mediafilesAddListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediafilesAddListToolStripMenuItem.Text = "Add...";
            this.mediafilesAddListToolStripMenuItem.Click += new System.EventHandler(this.mediafilesAddListToolStripMenuItem_Click);
            // 
            // mediafilesDeleteListToolStripMenuItem
            // 
            this.mediafilesDeleteListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mediafilesDeleteListToolStripMenuItem.Image")));
            this.mediafilesDeleteListToolStripMenuItem.Name = "mediafilesDeleteListToolStripMenuItem";
            this.mediafilesDeleteListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediafilesDeleteListToolStripMenuItem.Text = "Delete";
            this.mediafilesDeleteListToolStripMenuItem.Click += new System.EventHandler(this.mediafilesDeleteListToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(149, 6);
            // 
            // mediafilesMoveToolStripMenuItem
            // 
            this.mediafilesMoveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediafilesMoveUpToolStripMenuIte,
            this.mediafilesMoveDownToolStripMenuItem});
            this.mediafilesMoveToolStripMenuItem.Name = "mediafilesMoveToolStripMenuItem";
            this.mediafilesMoveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediafilesMoveToolStripMenuItem.Text = "Move";
            // 
            // mediafilesMoveUpToolStripMenuIte
            // 
            this.mediafilesMoveUpToolStripMenuIte.Image = global::convendro.Properties.Resources.arrow_up;
            this.mediafilesMoveUpToolStripMenuIte.Name = "mediafilesMoveUpToolStripMenuIte";
            this.mediafilesMoveUpToolStripMenuIte.Size = new System.Drawing.Size(105, 22);
            this.mediafilesMoveUpToolStripMenuIte.Text = "Up";
            this.mediafilesMoveUpToolStripMenuIte.Click += new System.EventHandler(this.mediafilesMoveUpToolStripMenuItem_Click);
            // 
            // mediafilesMoveDownToolStripMenuItem
            // 
            this.mediafilesMoveDownToolStripMenuItem.Image = global::convendro.Properties.Resources.arrow_down;
            this.mediafilesMoveDownToolStripMenuItem.Name = "mediafilesMoveDownToolStripMenuItem";
            this.mediafilesMoveDownToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.mediafilesMoveDownToolStripMenuItem.Text = "Down";
            this.mediafilesMoveDownToolStripMenuItem.Click += new System.EventHandler(this.mediafilesMoveDownToolStripMenuItem_Click);
            // 
            // mediafilesPresetsToolStripMenuItem
            // 
            this.mediafilesPresetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediafileSelectPresetListToolStripMenuItem});
            this.mediafilesPresetsToolStripMenuItem.Name = "mediafilesPresetsToolStripMenuItem";
            this.mediafilesPresetsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mediafilesPresetsToolStripMenuItem.Text = "Presets";
            // 
            // mediafileSelectPresetListToolStripMenuItem
            // 
            this.mediafileSelectPresetListToolStripMenuItem.Image = global::convendro.Properties.Resources.application_form_magnify;
            this.mediafileSelectPresetListToolStripMenuItem.Name = "mediafileSelectPresetListToolStripMenuItem";
            this.mediafileSelectPresetListToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.mediafileSelectPresetListToolStripMenuItem.Text = "Select...";
            this.mediafileSelectPresetListToolStripMenuItem.Click += new System.EventHandler(this.mediafilesSelectPresetListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // conversionStartToolStripMenuItem
            // 
            this.conversionStartToolStripMenuItem.Image = global::convendro.Properties.Resources.control_play_blue;
            this.conversionStartToolStripMenuItem.Name = "conversionStartToolStripMenuItem";
            this.conversionStartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.conversionStartToolStripMenuItem.Text = "Start";
            this.conversionStartToolStripMenuItem.Click += new System.EventHandler(this.mediafilesStartConversionToolStripMenuItem_Click);
            // 
            // conversionStopToolStripMenuItem
            // 
            this.conversionStopToolStripMenuItem.Image = global::convendro.Properties.Resources.control_stop_blue;
            this.conversionStopToolStripMenuItem.Name = "conversionStopToolStripMenuItem";
            this.conversionStopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.conversionStopToolStripMenuItem.Text = "Stop";
            this.conversionStopToolStripMenuItem.Click += new System.EventHandler(this.mediafilesStopConversionToolStripMenuItem_Click);
            // 
            // toolsToolsStripMenuItem
            // 
            this.toolsToolsStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsPresetsEditorToolStripMenuItem,
            this.toolsSettingsToolStripMenuItem});
            this.toolsToolsStripMenuItem.Name = "toolsToolsStripMenuItem";
            this.toolsToolsStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolsStripMenuItem.Text = "Tools";
            // 
            // toolsPresetsEditorToolStripMenuItem
            // 
            this.toolsPresetsEditorToolStripMenuItem.Image = global::convendro.Properties.Resources.application_form_edit;
            this.toolsPresetsEditorToolStripMenuItem.Name = "toolsPresetsEditorToolStripMenuItem";
            this.toolsPresetsEditorToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.toolsPresetsEditorToolStripMenuItem.Text = "Presets Editor...";
            this.toolsPresetsEditorToolStripMenuItem.Click += new System.EventHandler(this.toolsPresetsEditorToolStripMenuItem_Click);
            // 
            // toolsSettingsToolStripMenuItem
            // 
            this.toolsSettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("toolsSettingsToolStripMenuItem.Image")));
            this.toolsSettingsToolStripMenuItem.Name = "toolsSettingsToolStripMenuItem";
            this.toolsSettingsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.toolsSettingsToolStripMenuItem.Text = "Settings...";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileExitToolStripButton,
            this.toolStripSeparator2,
            this.fileClearListToolStripButton,
            this.fileAddListToolStripButton,
            this.fileDeleteListToolStripButton,
            this.toolStripSeparator4,
            this.fileMoveUpToolStripButton,
            this.fileMoveDownToolStripButton,
            this.toolStripSeparator3,
            this.fileSelectPresetListToolStripButton});
            this.fileToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.fileToolStrip.Location = new System.Drawing.Point(3, 24);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(180, 23);
            this.fileToolStrip.TabIndex = 1;
            // 
            // fileExitToolStripButton
            // 
            this.fileExitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileExitToolStripButton.Image = global::convendro.Properties.Resources.cancel;
            this.fileExitToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.fileExitToolStripButton.Name = "fileExitToolStripButton";
            this.fileExitToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileExitToolStripButton.Text = "Exit";
            this.fileExitToolStripButton.Click += new System.EventHandler(this.fileExitToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // fileClearListToolStripButton
            // 
            this.fileClearListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileClearListToolStripButton.Image = global::convendro.Properties.Resources.page_white1;
            this.fileClearListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileClearListToolStripButton.Name = "fileClearListToolStripButton";
            this.fileClearListToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileClearListToolStripButton.Text = "Clear Screen";
            this.fileClearListToolStripButton.Click += new System.EventHandler(this.mediafilesClearListToolStripMenuItem_Click);
            // 
            // fileAddListToolStripButton
            // 
            this.fileAddListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileAddListToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fileAddListToolStripButton.Image")));
            this.fileAddListToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.fileAddListToolStripButton.Name = "fileAddListToolStripButton";
            this.fileAddListToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileAddListToolStripButton.Text = "Add Media file";
            this.fileAddListToolStripButton.Click += new System.EventHandler(this.mediafilesAddListToolStripMenuItem_Click);
            // 
            // fileDeleteListToolStripButton
            // 
            this.fileDeleteListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileDeleteListToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("fileDeleteListToolStripButton.Image")));
            this.fileDeleteListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDeleteListToolStripButton.Name = "fileDeleteListToolStripButton";
            this.fileDeleteListToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileDeleteListToolStripButton.Text = "Delete Media file";
            this.fileDeleteListToolStripButton.Click += new System.EventHandler(this.mediafilesDeleteListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // fileMoveUpToolStripButton
            // 
            this.fileMoveUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileMoveUpToolStripButton.Image = global::convendro.Properties.Resources.arrow_up;
            this.fileMoveUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMoveUpToolStripButton.Name = "fileMoveUpToolStripButton";
            this.fileMoveUpToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileMoveUpToolStripButton.Text = "Move Up";
            this.fileMoveUpToolStripButton.Click += new System.EventHandler(this.mediafilesMoveUpToolStripMenuItem_Click);
            // 
            // fileMoveDownToolStripButton
            // 
            this.fileMoveDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileMoveDownToolStripButton.Image = global::convendro.Properties.Resources.arrow_down;
            this.fileMoveDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileMoveDownToolStripButton.Name = "fileMoveDownToolStripButton";
            this.fileMoveDownToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileMoveDownToolStripButton.Text = "Move Down";
            this.fileMoveDownToolStripButton.Click += new System.EventHandler(this.mediafilesMoveDownToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // fileSelectPresetListToolStripButton
            // 
            this.fileSelectPresetListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fileSelectPresetListToolStripButton.Image = global::convendro.Properties.Resources.application_form_magnify;
            this.fileSelectPresetListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileSelectPresetListToolStripButton.Name = "fileSelectPresetListToolStripButton";
            this.fileSelectPresetListToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.fileSelectPresetListToolStripButton.Text = "Select Preset";
            // 
            // conversionToolStrip
            // 
            this.conversionToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.conversionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conversionPlaytoolStripButton,
            this.conversionStopToolStripButton});
            this.conversionToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.conversionToolStrip.Location = new System.Drawing.Point(103, 47);
            this.conversionToolStrip.Name = "conversionToolStrip";
            this.conversionToolStrip.Size = new System.Drawing.Size(47, 23);
            this.conversionToolStrip.TabIndex = 2;
            // 
            // conversionPlaytoolStripButton
            // 
            this.conversionPlaytoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.conversionPlaytoolStripButton.Image = global::convendro.Properties.Resources.control_play_blue;
            this.conversionPlaytoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.conversionPlaytoolStripButton.Name = "conversionPlaytoolStripButton";
            this.conversionPlaytoolStripButton.Size = new System.Drawing.Size(23, 20);
            this.conversionPlaytoolStripButton.Text = "Start Conversion";
            this.conversionPlaytoolStripButton.Click += new System.EventHandler(this.mediafilesStartConversionToolStripMenuItem_Click);
            // 
            // conversionStopToolStripButton
            // 
            this.conversionStopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.conversionStopToolStripButton.Image = global::convendro.Properties.Resources.control_stop_blue;
            this.conversionStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.conversionStopToolStripButton.Name = "conversionStopToolStripButton";
            this.conversionStopToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.conversionStopToolStripButton.Text = "Stop Conversion";
            this.conversionStopToolStripButton.Click += new System.EventHandler(this.mediafilesStopConversionToolStripMenuItem_Click);
            // 
            // toolsToolStrip
            // 
            this.toolsToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsEditPresetsToolStripButton});
            this.toolsToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolsToolStrip.Location = new System.Drawing.Point(126, 70);
            this.toolsToolStrip.Name = "toolsToolStrip";
            this.toolsToolStrip.Size = new System.Drawing.Size(24, 23);
            this.toolsToolStrip.TabIndex = 3;
            // 
            // toolsEditPresetsToolStripButton
            // 
            this.toolsEditPresetsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolsEditPresetsToolStripButton.Image = global::convendro.Properties.Resources.application_form_edit;
            this.toolsEditPresetsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsEditPresetsToolStripButton.Name = "toolsEditPresetsToolStripButton";
            this.toolsEditPresetsToolStripButton.Size = new System.Drawing.Size(23, 20);
            this.toolsEditPresetsToolStripButton.Text = "Edit Presets...";
            this.toolsEditPresetsToolStripButton.Click += new System.EventHandler(this.toolsPresetsEditorToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFilesBarMain,
            this.progressBarMain,
            this.lblStatusBarMain});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 394);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(690, 22);
            this.mainStatusStrip.TabIndex = 5;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // lblFilesBarMain
            // 
            this.lblFilesBarMain.AutoSize = false;
            this.lblFilesBarMain.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblFilesBarMain.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblFilesBarMain.Name = "lblFilesBarMain";
            this.lblFilesBarMain.Size = new System.Drawing.Size(109, 17);
            this.lblFilesBarMain.Text = "0 files";
            // 
            // progressBarMain
            // 
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(120, 16);
            this.progressBarMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarMain.ToolTipText = "Progress of current file";
            // 
            // lblStatusBarMain
            // 
            this.lblStatusBarMain.Name = "lblStatusBarMain";
            this.lblStatusBarMain.Size = new System.Drawing.Size(444, 17);
            this.lblStatusBarMain.Spring = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 416);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.labelCurrent);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textLogger);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Convendro";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ctxListView.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.conversionToolStrip.ResumeLayout(false);
            this.conversionToolStrip.PerformLayout();
            this.toolsToolStrip.ResumeLayout(false);
            this.toolsToolStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textLogger;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblFilesBarMain;
        private System.Windows.Forms.ToolStripProgressBar progressBarMain;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colPresetName;
        private System.Windows.Forms.ToolStripMenuItem toolsToolsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsPresetsEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxListView;
        private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectPresetToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fileExitToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton fileAddListToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fileDeleteListToolStripButton;
        private System.Windows.Forms.ToolStripButton fileClearListToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton fileMoveUpToolStripButton;
        private System.Windows.Forms.ToolStripButton fileMoveDownToolStripButton;
        private System.Windows.Forms.ToolStrip conversionToolStrip;
        private System.Windows.Forms.ToolStripButton conversionPlaytoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton fileSelectPresetListToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBarMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolsToolStrip;
        private System.Windows.Forms.ToolStripButton toolsEditPresetsToolStripButton;
        private System.Windows.Forms.ToolStripButton conversionStopToolStripButton;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ToolStripMenuItem toolsSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem editInvertSelectionToolStripItem;
        private System.Windows.Forms.ColumnHeader colStarted;
        private System.Windows.Forms.ColumnHeader colFinished;
        private System.Windows.Forms.ToolStripMenuItem fileImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileImportWinFFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileImportVideoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafilesClearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafilesAddListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafilesDeleteListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mediafilesMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafilesMoveUpToolStripMenuIte;
        private System.Windows.Forms.ToolStripMenuItem mediafilesMoveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafilesPresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediafileSelectPresetListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem conversionStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversionStopToolStripMenuItem;
    }
}

