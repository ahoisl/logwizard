namespace LogWizard
{
    partial class log_wizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being dimmed.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(log_wizard));
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.logHistory = new System.Windows.Forms.ComboBox();
            this.newFilteredView = new System.Windows.Forms.Button();
            this.delFilteredView = new System.Windows.Forms.Button();
            this.curContextCtrl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addContext = new System.Windows.Forms.Button();
            this.delContext = new System.Windows.Forms.Button();
            this.synchronizedWithFullLog = new System.Windows.Forms.CheckBox();
            this.synchronizeWithExistingLogs = new System.Windows.Forms.CheckBox();
            this.contextFromClipboard = new System.Windows.Forms.Button();
            this.contextToClipboard = new System.Windows.Forms.Button();
            this.toggleTopmost = new System.Windows.Forms.PictureBox();
            this.main = new System.Windows.Forms.SplitContainer();
            this.leftPane = new System.Windows.Forms.TabControl();
            this.filtersTab = new System.Windows.Forms.TabPage();
            this.filtCtrl = new lw_common.ui.filter_ctrl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.categories = new lw_common.ui.categories_ctrl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.notes = new lw_common.ui.note_ctrl();
            this.sourceUp = new System.Windows.Forms.SplitContainer();
            this.editSettings = new System.Windows.Forms.Button();
            this.splitDescription = new System.Windows.Forms.SplitContainer();
            this.filteredLeft = new System.Windows.Forms.SplitContainer();
            this.viewsTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dropHere = new System.Windows.Forms.Label();
            this.description = new lw_common.ui.description_ctrl();
            this.refresh = new System.Windows.Forms.Timer(this.components);
            this.lower = new System.Windows.Forms.Panel();
            this.status = new lw_common.ui.status_ctrl();
            this.saveTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshAddViewButtons = new System.Windows.Forms.Timer(this.components);
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromScratchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneCurrentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLogNotesLogWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNotestxthtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.exportCurrentViewcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCurrentViewtxthtmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleCurrentViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleFullLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleTablerHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleViewTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleFilterPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleNotesPaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSourcePaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.toggleTopmost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main)).BeginInit();
            this.main.Panel1.SuspendLayout();
            this.main.Panel2.SuspendLayout();
            this.main.SuspendLayout();
            this.leftPane.SuspendLayout();
            this.filtersTab.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourceUp)).BeginInit();
            this.sourceUp.Panel1.SuspendLayout();
            this.sourceUp.Panel2.SuspendLayout();
            this.sourceUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDescription)).BeginInit();
            this.splitDescription.Panel1.SuspendLayout();
            this.splitDescription.Panel2.SuspendLayout();
            this.splitDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filteredLeft)).BeginInit();
            this.filteredLeft.Panel1.SuspendLayout();
            this.filteredLeft.SuspendLayout();
            this.viewsTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.lower.SuspendLayout();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 32000;
            this.tip.InitialDelay = 500;
            this.tip.ReshowDelay = 100;
            // 
            // logHistory
            // 
            this.logHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logHistory.FormattingEnabled = true;
            this.logHistory.Location = new System.Drawing.Point(285, 3);
            this.logHistory.Name = "logHistory";
            this.logHistory.Size = new System.Drawing.Size(892, 23);
            this.logHistory.TabIndex = 7;
            this.tip.SetToolTip(this.logHistory, "History - just select any of the previous logs, and they instantly load");
            this.logHistory.Visible = false;
            this.logHistory.DropDown += new System.EventHandler(this.logHistory_DropDown);
            this.logHistory.SelectedIndexChanged += new System.EventHandler(this.logHistory_SelectedIndexChanged);
            this.logHistory.DropDownClosed += new System.EventHandler(this.logHistory_DropDownClosed);
            // 
            // newFilteredView
            // 
            this.newFilteredView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newFilteredView.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFilteredView.Location = new System.Drawing.Point(356, 29);
            this.newFilteredView.Name = "newFilteredView";
            this.newFilteredView.Size = new System.Drawing.Size(18, 20);
            this.newFilteredView.TabIndex = 1;
            this.newFilteredView.Text = "+";
            this.tip.SetToolTip(this.newFilteredView, "New Filtered View of the same Log");
            this.newFilteredView.UseVisualStyleBackColor = true;
            // 
            // delFilteredView
            // 
            this.delFilteredView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delFilteredView.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delFilteredView.Location = new System.Drawing.Point(374, 29);
            this.delFilteredView.Name = "delFilteredView";
            this.delFilteredView.Size = new System.Drawing.Size(18, 20);
            this.delFilteredView.TabIndex = 2;
            this.delFilteredView.Text = "-";
            this.tip.SetToolTip(this.delFilteredView, "Delete this View");
            this.delFilteredView.UseVisualStyleBackColor = true;
            this.delFilteredView.Click += new System.EventHandler(this.delView_Click);
            // 
            // curContextCtrl
            // 
            this.curContextCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.curContextCtrl.FormattingEnabled = true;
            this.curContextCtrl.Location = new System.Drawing.Point(75, 9);
            this.curContextCtrl.Name = "curContextCtrl";
            this.curContextCtrl.Size = new System.Drawing.Size(190, 23);
            this.curContextCtrl.TabIndex = 4;
            this.tip.SetToolTip(this.curContextCtrl, "The template saves the current Filters and the current Views (tabs)");
            this.curContextCtrl.DropDown += new System.EventHandler(this.curContextCtrl_DropDown);
            this.curContextCtrl.SelectedIndexChanged += new System.EventHandler(this.curContextCtrl_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Template";
            this.tip.SetToolTip(this.label5, "\r\n");
            // 
            // addContext
            // 
            this.addContext.Location = new System.Drawing.Point(271, 10);
            this.addContext.Name = "addContext";
            this.addContext.Size = new System.Drawing.Size(23, 22);
            this.addContext.TabIndex = 11;
            this.addContext.Text = "+";
            this.tip.SetToolTip(this.addContext, "Add a template");
            this.addContext.UseVisualStyleBackColor = true;
            this.addContext.Click += new System.EventHandler(this.addContext_Click);
            // 
            // delContext
            // 
            this.delContext.Location = new System.Drawing.Point(292, 10);
            this.delContext.Name = "delContext";
            this.delContext.Size = new System.Drawing.Size(25, 22);
            this.delContext.TabIndex = 12;
            this.delContext.Text = "-";
            this.tip.SetToolTip(this.delContext, "Delete current template");
            this.delContext.UseVisualStyleBackColor = true;
            this.delContext.Click += new System.EventHandler(this.delContext_Click);
            // 
            // synchronizedWithFullLog
            // 
            this.synchronizedWithFullLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.synchronizedWithFullLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.synchronizedWithFullLog.Checked = true;
            this.synchronizedWithFullLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.synchronizedWithFullLog.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.synchronizedWithFullLog.Location = new System.Drawing.Point(248, 29);
            this.synchronizedWithFullLog.Name = "synchronizedWithFullLog";
            this.synchronizedWithFullLog.Size = new System.Drawing.Size(46, 20);
            this.synchronizedWithFullLog.TabIndex = 1;
            this.synchronizedWithFullLog.Text = "<-FL->";
            this.tip.SetToolTip(this.synchronizedWithFullLog, "Synchronized with the Full Log");
            this.synchronizedWithFullLog.UseVisualStyleBackColor = true;
            this.synchronizedWithFullLog.CheckedChanged += new System.EventHandler(this.synchronizedWithFullLog_CheckedChanged);
            // 
            // synchronizeWithExistingLogs
            // 
            this.synchronizeWithExistingLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.synchronizeWithExistingLogs.Appearance = System.Windows.Forms.Appearance.Button;
            this.synchronizeWithExistingLogs.Checked = true;
            this.synchronizeWithExistingLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.synchronizeWithExistingLogs.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.synchronizeWithExistingLogs.Location = new System.Drawing.Point(202, 29);
            this.synchronizeWithExistingLogs.Name = "synchronizeWithExistingLogs";
            this.synchronizeWithExistingLogs.Size = new System.Drawing.Size(46, 20);
            this.synchronizeWithExistingLogs.TabIndex = 3;
            this.synchronizeWithExistingLogs.Text = "<-V->";
            this.tip.SetToolTip(this.synchronizeWithExistingLogs, "Synchronized with the rest of the Views\r\n(when you change the line, the other vie" +
        "ws will \r\ngo to the closest line as you)");
            this.synchronizeWithExistingLogs.UseVisualStyleBackColor = true;
            this.synchronizeWithExistingLogs.CheckedChanged += new System.EventHandler(this.synchronizeWithExistingLogs_CheckedChanged);
            // 
            // contextFromClipboard
            // 
            this.contextFromClipboard.Location = new System.Drawing.Point(362, 11);
            this.contextFromClipboard.Name = "contextFromClipboard";
            this.contextFromClipboard.Size = new System.Drawing.Size(44, 22);
            this.contextFromClipboard.TabIndex = 14;
            this.contextFromClipboard.Text = "Paste";
            this.tip.SetToolTip(this.contextFromClipboard, "Paste from clipboard");
            this.contextFromClipboard.UseVisualStyleBackColor = true;
            this.contextFromClipboard.Click += new System.EventHandler(this.contextFromClipboard_Click);
            // 
            // contextToClipboard
            // 
            this.contextToClipboard.Location = new System.Drawing.Point(318, 11);
            this.contextToClipboard.Name = "contextToClipboard";
            this.contextToClipboard.Size = new System.Drawing.Size(48, 22);
            this.contextToClipboard.TabIndex = 13;
            this.contextToClipboard.Text = "Copy";
            this.tip.SetToolTip(this.contextToClipboard, "Copy to clipboard");
            this.contextToClipboard.UseVisualStyleBackColor = true;
            this.contextToClipboard.Click += new System.EventHandler(this.contextToClipboard_Click);
            // 
            // toggleTopmost
            // 
            this.toggleTopmost.BackColor = System.Drawing.Color.Transparent;
            this.toggleTopmost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleTopmost.Image = global::LogWizard.Properties.Resources.bug;
            this.toggleTopmost.Location = new System.Drawing.Point(0, 0);
            this.toggleTopmost.Name = "toggleTopmost";
            this.toggleTopmost.Size = new System.Drawing.Size(24, 24);
            this.toggleTopmost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toggleTopmost.TabIndex = 17;
            this.toggleTopmost.TabStop = false;
            this.tip.SetToolTip(this.toggleTopmost, "Click it to toggle LogWizard\'s TopMost state\r\nRight-Click to show the Toggles Men" +
        "u");
            this.toggleTopmost.Visible = false;
            this.toggleTopmost.Click += new System.EventHandler(this.toggleTopmost_Click);
            this.toggleTopmost.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toggleTopmost_MouseClick);
            // 
            // main
            // 
            this.main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.main.Location = new System.Drawing.Point(2, 27);
            this.main.Name = "main";
            // 
            // main.Panel1
            // 
            this.main.Panel1.Controls.Add(this.leftPane);
            this.main.Panel1MinSize = 295;
            // 
            // main.Panel2
            // 
            this.main.Panel2.Controls.Add(this.sourceUp);
            this.main.Panel2MinSize = 300;
            this.main.Size = new System.Drawing.Size(1253, 494);
            this.main.SplitterDistance = 295;
            this.main.SplitterWidth = 6;
            this.main.TabIndex = 4;
            this.main.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.main_SplitterMoved);
            // 
            // leftPane
            // 
            this.leftPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftPane.Controls.Add(this.filtersTab);
            this.leftPane.Controls.Add(this.tabPage3);
            this.leftPane.Controls.Add(this.tabPage4);
            this.leftPane.Location = new System.Drawing.Point(-1, 4);
            this.leftPane.MinimumSize = new System.Drawing.Size(275, 0);
            this.leftPane.Name = "leftPane";
            this.leftPane.SelectedIndex = 0;
            this.leftPane.Size = new System.Drawing.Size(299, 487);
            this.leftPane.TabIndex = 13;
            this.leftPane.SizeChanged += new System.EventHandler(this.leftPane_SizeChanged);
            // 
            // filtersTab
            // 
            this.filtersTab.Controls.Add(this.filtCtrl);
            this.filtersTab.Location = new System.Drawing.Point(4, 24);
            this.filtersTab.Name = "filtersTab";
            this.filtersTab.Padding = new System.Windows.Forms.Padding(3);
            this.filtersTab.Size = new System.Drawing.Size(291, 459);
            this.filtersTab.TabIndex = 0;
            this.filtersTab.Text = "Filters";
            this.filtersTab.UseVisualStyleBackColor = true;
            // 
            // filtCtrl
            // 
            this.filtCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filtCtrl.Location = new System.Drawing.Point(3, 2);
            this.filtCtrl.MinimumSize = new System.Drawing.Size(275, 0);
            this.filtCtrl.Name = "filtCtrl";
            this.filtCtrl.settings = null;
            this.filtCtrl.Size = new System.Drawing.Size(285, 459);
            this.filtCtrl.status = null;
            this.filtCtrl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.categories);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(192, 74);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "By Threads / By Context";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // categories
            // 
            this.categories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categories.BackColor = System.Drawing.Color.White;
            this.categories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categories.Location = new System.Drawing.Point(0, 0);
            this.categories.Margin = new System.Windows.Forms.Padding(4);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(192, 78);
            this.categories.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.notes);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(192, 74);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Notes / Bookmarks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // notes
            // 
            this.notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notes.Location = new System.Drawing.Point(4, 3);
            this.notes.Margin = new System.Windows.Forms.Padding(4);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(181, 64);
            this.notes.TabIndex = 1;
            // 
            // sourceUp
            // 
            this.sourceUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceUp.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sourceUp.IsSplitterFixed = true;
            this.sourceUp.Location = new System.Drawing.Point(0, 0);
            this.sourceUp.Name = "sourceUp";
            this.sourceUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sourceUp.Panel1
            // 
            this.sourceUp.Panel1.Controls.Add(this.editSettings);
            this.sourceUp.Panel1.Controls.Add(this.contextFromClipboard);
            this.sourceUp.Panel1.Controls.Add(this.contextToClipboard);
            this.sourceUp.Panel1.Controls.Add(this.delContext);
            this.sourceUp.Panel1.Controls.Add(this.addContext);
            this.sourceUp.Panel1.Controls.Add(this.curContextCtrl);
            this.sourceUp.Panel1.Controls.Add(this.label5);
            // 
            // sourceUp.Panel2
            // 
            this.sourceUp.Panel2.Controls.Add(this.splitDescription);
            this.sourceUp.Size = new System.Drawing.Size(952, 494);
            this.sourceUp.SplitterDistance = 40;
            this.sourceUp.TabIndex = 0;
            // 
            // editSettings
            // 
            this.editSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSettings.Location = new System.Drawing.Point(426, 8);
            this.editSettings.Name = "editSettings";
            this.editSettings.Size = new System.Drawing.Size(125, 25);
            this.editSettings.TabIndex = 17;
            this.editSettings.Text = "Edit Log Settings";
            this.editSettings.UseVisualStyleBackColor = true;
            this.editSettings.Click += new System.EventHandler(this.editSettings_Click);
            // 
            // splitDescription
            // 
            this.splitDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDescription.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitDescription.Location = new System.Drawing.Point(0, 0);
            this.splitDescription.Name = "splitDescription";
            this.splitDescription.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitDescription.Panel1
            // 
            this.splitDescription.Panel1.Controls.Add(this.filteredLeft);
            this.splitDescription.Panel1MinSize = 100;
            // 
            // splitDescription.Panel2
            // 
            this.splitDescription.Panel2.Controls.Add(this.description);
            this.splitDescription.Panel2MinSize = 100;
            this.splitDescription.Size = new System.Drawing.Size(952, 450);
            this.splitDescription.SplitterDistance = 292;
            this.splitDescription.SplitterWidth = 6;
            this.splitDescription.TabIndex = 18;
            this.splitDescription.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitDescription_SplitterMoved);
            // 
            // filteredLeft
            // 
            this.filteredLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filteredLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.filteredLeft.Location = new System.Drawing.Point(0, 0);
            this.filteredLeft.Name = "filteredLeft";
            // 
            // filteredLeft.Panel1
            // 
            this.filteredLeft.Panel1.Controls.Add(this.synchronizeWithExistingLogs);
            this.filteredLeft.Panel1.Controls.Add(this.synchronizedWithFullLog);
            this.filteredLeft.Panel1.Controls.Add(this.delFilteredView);
            this.filteredLeft.Panel1.Controls.Add(this.newFilteredView);
            this.filteredLeft.Panel1.Controls.Add(this.viewsTab);
            this.filteredLeft.Panel1MinSize = 100;
            this.filteredLeft.Panel2MinSize = 100;
            this.filteredLeft.Size = new System.Drawing.Size(952, 292);
            this.filteredLeft.SplitterDistance = 431;
            this.filteredLeft.SplitterWidth = 6;
            this.filteredLeft.TabIndex = 0;
            this.filteredLeft.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.filteredLeft_SplitterMoved);
            // 
            // viewsTab
            // 
            this.viewsTab.AllowDrop = true;
            this.viewsTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewsTab.Controls.Add(this.tabPage1);
            this.viewsTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsTab.Location = new System.Drawing.Point(0, 3);
            this.viewsTab.Name = "viewsTab";
            this.viewsTab.SelectedIndex = 0;
            this.viewsTab.Size = new System.Drawing.Size(426, 290);
            this.viewsTab.TabIndex = 0;
            this.viewsTab.SelectedIndexChanged += new System.EventHandler(this.viewsTab_SelectedIndexChanged);
            this.viewsTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.filteredViews_DragDrop);
            this.viewsTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.filteredViews_DragEnter);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dropHere);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(418, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dropHere
            // 
            this.dropHere.AllowDrop = true;
            this.dropHere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dropHere.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropHere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dropHere.Location = new System.Drawing.Point(5, 3);
            this.dropHere.Name = "dropHere";
            this.dropHere.Size = new System.Drawing.Size(407, 262);
            this.dropHere.TabIndex = 0;
            this.dropHere.Text = "Drop a Log file here\r\n to open";
            this.dropHere.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dropHere.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropHere_DragDrop);
            this.dropHere.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropHere_DragEnter);
            // 
            // description
            // 
            this.description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(0, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(952, 152);
            this.description.TabIndex = 0;
            // 
            // refresh
            // 
            this.refresh.Enabled = true;
            this.refresh.Interval = 500;
            this.refresh.Tick += new System.EventHandler(this.refresh_Tick);
            // 
            // lower
            // 
            this.lower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lower.Controls.Add(this.logHistory);
            this.lower.Controls.Add(this.status);
            this.lower.Location = new System.Drawing.Point(0, 495);
            this.lower.Name = "lower";
            this.lower.Size = new System.Drawing.Size(1261, 27);
            this.lower.TabIndex = 15;
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.status.Location = new System.Drawing.Point(3, 2);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(1132, 24);
            this.status.TabIndex = 18;
            // 
            // saveTimer
            // 
            this.saveTimer.Enabled = true;
            this.saveTimer.Interval = 15000;
            this.saveTimer.Tick += new System.EventHandler(this.saveTimer_Tick);
            // 
            // refreshAddViewButtons
            // 
            this.refreshAddViewButtons.Enabled = true;
            this.refreshAddViewButtons.Interval = 250;
            this.refreshAddViewButtons.Tick += new System.EventHandler(this.refreshAddViewButtons_Tick);
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1255, 24);
            this.menuBar.TabIndex = 18;
            this.menuBar.Text = "menuBar";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.newViewToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openLogToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exportToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem4,
            this.refreshToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newWindowToolStripMenuItem.Text = "New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // newViewToolStripMenuItem
            // 
            this.newViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromScratchToolStripMenuItem,
            this.cloneCurrentToolStripMenuItem});
            this.newViewToolStripMenuItem.Name = "newViewToolStripMenuItem";
            this.newViewToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.newViewToolStripMenuItem.Text = "New View";
            // 
            // fromScratchToolStripMenuItem
            // 
            this.fromScratchToolStripMenuItem.Name = "fromScratchToolStripMenuItem";
            this.fromScratchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fromScratchToolStripMenuItem.Text = "From Scratch";
            this.fromScratchToolStripMenuItem.Click += new System.EventHandler(this.fromScratchToolStripMenuItem_Click);
            // 
            // cloneCurrentToolStripMenuItem
            // 
            this.cloneCurrentToolStripMenuItem.Name = "cloneCurrentToolStripMenuItem";
            this.cloneCurrentToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cloneCurrentToolStripMenuItem.Text = "Clone Current";
            this.cloneCurrentToolStripMenuItem.Click += new System.EventHandler(this.cloneCurrentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportLogNotesLogWizardToolStripMenuItem,
            this.exportNotestxthtmlToolStripMenuItem,
            this.toolStripMenuItem9,
            this.exportCurrentViewcsvToolStripMenuItem,
            this.exportCurrentViewtxthtmlToolStripMenuItem});
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+E";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // exportLogNotesLogWizardToolStripMenuItem
            // 
            this.exportLogNotesLogWizardToolStripMenuItem.Name = "exportLogNotesLogWizardToolStripMenuItem";
            this.exportLogNotesLogWizardToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.exportLogNotesLogWizardToolStripMenuItem.Text = "Export Log + Notes (.LogWizard)";
            this.exportLogNotesLogWizardToolStripMenuItem.Click += new System.EventHandler(this.exportLogNotesLogWizardToolStripMenuItem_Click);
            // 
            // exportNotestxthtmlToolStripMenuItem
            // 
            this.exportNotestxthtmlToolStripMenuItem.Name = "exportNotestxthtmlToolStripMenuItem";
            this.exportNotestxthtmlToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.exportNotestxthtmlToolStripMenuItem.Text = "Export Notes (.txt, .html)";
            this.exportNotestxthtmlToolStripMenuItem.Click += new System.EventHandler(this.exportNotestxthtmlToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(242, 6);
            // 
            // exportCurrentViewcsvToolStripMenuItem
            // 
            this.exportCurrentViewcsvToolStripMenuItem.Name = "exportCurrentViewcsvToolStripMenuItem";
            this.exportCurrentViewcsvToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.exportCurrentViewcsvToolStripMenuItem.Text = "Export Current View (.csv)";
            this.exportCurrentViewcsvToolStripMenuItem.Click += new System.EventHandler(this.exportCurrentViewcsvToolStripMenuItem_Click);
            // 
            // exportCurrentViewtxthtmlToolStripMenuItem
            // 
            this.exportCurrentViewtxthtmlToolStripMenuItem.Name = "exportCurrentViewtxthtmlToolStripMenuItem";
            this.exportCurrentViewtxthtmlToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.exportCurrentViewtxthtmlToolStripMenuItem.Text = "Export Current View (.txt, .html)";
            this.exportCurrentViewtxthtmlToolStripMenuItem.Click += new System.EventHandler(this.exportCurrentViewtxthtmlToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(185, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+P";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(185, 6);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(188, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.copyLineToolStripMenuItem,
            this.toolStripMenuItem5,
            this.findToolStripMenuItem,
            this.toolStripMenuItem6,
            this.goToToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.copyToolStripMenuItem.Text = "Copy Lines";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // copyLineToolStripMenuItem
            // 
            this.copyLineToolStripMenuItem.Name = "copyLineToolStripMenuItem";
            this.copyLineToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyLineToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.copyLineToolStripMenuItem.Text = "Copy Full Lines";
            this.copyLineToolStripMenuItem.Click += new System.EventHandler(this.copyLineToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(203, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(203, 6);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+G";
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.goToToolStripMenuItem.Text = "Go To";
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.goToToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleCurrentViewToolStripMenuItem,
            this.toggleFullLogToolStripMenuItem,
            this.toggleTablerHeaderToolStripMenuItem,
            this.toggleViewTabsToolStripMenuItem,
            this.toggleTitleToolStripMenuItem,
            this.toggleStatusToolStripMenuItem,
            this.toggleFilterPaneToolStripMenuItem,
            this.toggleNotesPaneToolStripMenuItem,
            this.toggleSourcePaneToolStripMenuItem,
            this.toggleDetailsToolStripMenuItem,
            this.toolStripMenuItem10,
            this.topmostToolStripMenuItem,
            this.showAllLinesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeyDisplayString = "Alt+N";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // toggleCurrentViewToolStripMenuItem
            // 
            this.toggleCurrentViewToolStripMenuItem.Name = "toggleCurrentViewToolStripMenuItem";
            this.toggleCurrentViewToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleCurrentViewToolStripMenuItem.Text = "Toggle Current View";
            this.toggleCurrentViewToolStripMenuItem.Click += new System.EventHandler(this.toggleCurrentViewToolStripMenuItem_Click);
            // 
            // toggleFullLogToolStripMenuItem
            // 
            this.toggleFullLogToolStripMenuItem.Name = "toggleFullLogToolStripMenuItem";
            this.toggleFullLogToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleFullLogToolStripMenuItem.Text = "Toggle Full Log";
            this.toggleFullLogToolStripMenuItem.Click += new System.EventHandler(this.toggleFullLogToolStripMenuItem_Click);
            // 
            // toggleTablerHeaderToolStripMenuItem
            // 
            this.toggleTablerHeaderToolStripMenuItem.Name = "toggleTablerHeaderToolStripMenuItem";
            this.toggleTablerHeaderToolStripMenuItem.ShortcutKeyDisplayString = "Alt+H";
            this.toggleTablerHeaderToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleTablerHeaderToolStripMenuItem.Text = "Toggle Table Header";
            this.toggleTablerHeaderToolStripMenuItem.Click += new System.EventHandler(this.toggleTableHeaderToolStripMenuItem_Click);
            // 
            // toggleViewTabsToolStripMenuItem
            // 
            this.toggleViewTabsToolStripMenuItem.Name = "toggleViewTabsToolStripMenuItem";
            this.toggleViewTabsToolStripMenuItem.ShortcutKeyDisplayString = "Alt+V";
            this.toggleViewTabsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleViewTabsToolStripMenuItem.Text = "Toggle View Tabs";
            this.toggleViewTabsToolStripMenuItem.Click += new System.EventHandler(this.toggleViewTabsToolStripMenuItem_Click);
            // 
            // toggleTitleToolStripMenuItem
            // 
            this.toggleTitleToolStripMenuItem.Name = "toggleTitleToolStripMenuItem";
            this.toggleTitleToolStripMenuItem.ShortcutKeyDisplayString = "Alt+T";
            this.toggleTitleToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleTitleToolStripMenuItem.Text = "Toggle Title";
            this.toggleTitleToolStripMenuItem.Click += new System.EventHandler(this.toggleTitleToolStripMenuItem_Click);
            // 
            // toggleStatusToolStripMenuItem
            // 
            this.toggleStatusToolStripMenuItem.Name = "toggleStatusToolStripMenuItem";
            this.toggleStatusToolStripMenuItem.ShortcutKeyDisplayString = "Alt+S";
            this.toggleStatusToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleStatusToolStripMenuItem.Text = "Toggle Status";
            this.toggleStatusToolStripMenuItem.Click += new System.EventHandler(this.toggleStatusToolStripMenuItem_Click);
            // 
            // toggleFilterPaneToolStripMenuItem
            // 
            this.toggleFilterPaneToolStripMenuItem.Name = "toggleFilterPaneToolStripMenuItem";
            this.toggleFilterPaneToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F";
            this.toggleFilterPaneToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleFilterPaneToolStripMenuItem.Text = "Toggle Filter Pane";
            this.toggleFilterPaneToolStripMenuItem.Click += new System.EventHandler(this.toggleFilterPaneToolStripMenuItem_Click);
            // 
            // toggleNotesPaneToolStripMenuItem
            // 
            this.toggleNotesPaneToolStripMenuItem.Name = "toggleNotesPaneToolStripMenuItem";
            this.toggleNotesPaneToolStripMenuItem.ShortcutKeyDisplayString = "Alt+N";
            this.toggleNotesPaneToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleNotesPaneToolStripMenuItem.Text = "Toggle Notes Pane";
            this.toggleNotesPaneToolStripMenuItem.Click += new System.EventHandler(this.toggleNotesPaneToolStripMenuItem_Click);
            // 
            // toggleSourcePaneToolStripMenuItem
            // 
            this.toggleSourcePaneToolStripMenuItem.Name = "toggleSourcePaneToolStripMenuItem";
            this.toggleSourcePaneToolStripMenuItem.ShortcutKeyDisplayString = "Alt+O";
            this.toggleSourcePaneToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleSourcePaneToolStripMenuItem.Text = "Toggle Source Pane";
            this.toggleSourcePaneToolStripMenuItem.Click += new System.EventHandler(this.toggleSourcePaneToolStripMenuItem_Click);
            // 
            // toggleDetailsToolStripMenuItem
            // 
            this.toggleDetailsToolStripMenuItem.Name = "toggleDetailsToolStripMenuItem";
            this.toggleDetailsToolStripMenuItem.ShortcutKeyDisplayString = "Alt+D";
            this.toggleDetailsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.toggleDetailsToolStripMenuItem.Text = "Toggle Details";
            this.toggleDetailsToolStripMenuItem.Click += new System.EventHandler(this.toggleDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(218, 6);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.topmostToolStripMenuItem.Text = "Topmost";
            this.topmostToolStripMenuItem.Click += new System.EventHandler(this.topmostToolStripMenuItem_Click);
            // 
            // showAllLinesToolStripMenuItem
            // 
            this.showAllLinesToolStripMenuItem.Name = "showAllLinesToolStripMenuItem";
            this.showAllLinesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.showAllLinesToolStripMenuItem.Text = "Show All Lines";
            this.showAllLinesToolStripMenuItem.Click += new System.EventHandler(this.showAllLinesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHelpToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // openHelpToolStripMenuItem
            // 
            this.openHelpToolStripMenuItem.Name = "openHelpToolStripMenuItem";
            this.openHelpToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.openHelpToolStripMenuItem.Text = "Open Help";
            this.openHelpToolStripMenuItem.Click += new System.EventHandler(this.openHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem2.Text = "About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem2_Click);
            // 
            // log_wizard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 522);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.toggleTopmost);
            this.Controls.Add(this.main);
            this.Controls.Add(this.lower);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "log_wizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Log Wizard";
            this.Activated += new System.EventHandler(this.log_wizard_Activated);
            this.Deactivate += new System.EventHandler(this.log_wizard_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogWizard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogNinja_FormClosed);
            this.LocationChanged += new System.EventHandler(this.log_wizard_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.log_wizard_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.toggleTopmost)).EndInit();
            this.main.Panel1.ResumeLayout(false);
            this.main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main)).EndInit();
            this.main.ResumeLayout(false);
            this.leftPane.ResumeLayout(false);
            this.filtersTab.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.sourceUp.Panel1.ResumeLayout(false);
            this.sourceUp.Panel1.PerformLayout();
            this.sourceUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourceUp)).EndInit();
            this.sourceUp.ResumeLayout(false);
            this.splitDescription.Panel1.ResumeLayout(false);
            this.splitDescription.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDescription)).EndInit();
            this.splitDescription.ResumeLayout(false);
            this.filteredLeft.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filteredLeft)).EndInit();
            this.filteredLeft.ResumeLayout(false);
            this.viewsTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.lower.ResumeLayout(false);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.SplitContainer main;
        private System.Windows.Forms.SplitContainer sourceUp;
        private System.Windows.Forms.ComboBox curContextCtrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox logHistory;
        private System.Windows.Forms.SplitContainer filteredLeft;
        private System.Windows.Forms.Button newFilteredView;
        private System.Windows.Forms.TabControl viewsTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label dropHere;
        private System.Windows.Forms.Timer refresh;
        private System.Windows.Forms.Button delFilteredView;
        private System.Windows.Forms.Button delContext;
        private System.Windows.Forms.Button addContext;
        private System.Windows.Forms.CheckBox synchronizedWithFullLog;
        private System.Windows.Forms.TabControl leftPane;
        private System.Windows.Forms.TabPage filtersTab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox synchronizeWithExistingLogs;
        private System.Windows.Forms.Button contextFromClipboard;
        private System.Windows.Forms.Button contextToClipboard;
        private System.Windows.Forms.Panel lower;
        private System.Windows.Forms.PictureBox toggleTopmost;
        private System.Windows.Forms.Timer saveTimer;
        private lw_common.ui.filter_ctrl filtCtrl;
        private lw_common.ui.note_ctrl notes;
        private lw_common.ui.status_ctrl status;
        private System.Windows.Forms.Timer refreshAddViewButtons;
        private System.Windows.Forms.Button editSettings;
        private System.Windows.Forms.SplitContainer splitDescription;
        private lw_common.ui.description_ctrl description;
        private lw_common.ui.categories_ctrl categories;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem goToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLogNotesLogWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNotestxthtmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentViewcsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCurrentViewtxthtmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleCurrentViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleFullLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleTablerHeaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleViewTabsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleFilterPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleNotesPaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleSourcePaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem showAllLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem fromScratchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneCurrentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
    }
}

