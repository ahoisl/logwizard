namespace lw_common.ui {
    partial class filter_ctrl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.viewFromClipboard = new System.Windows.Forms.Button();
            this.viewToClipboard = new System.Windows.Forms.Button();
            this.filterCtrl = new BrightIdeasSoftware.ObjectListView();
            this.enabledCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.filterCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.applyToExistingLines = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.delFilter = new System.Windows.Forms.Button();
            this.filterLabel = new System.Windows.Forms.Label();
            this.addFilter = new System.Windows.Forms.Button();
            this.selectColor = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.selectMatchColor = new System.Windows.Forms.Button();
            this.filterContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBox = new System.Windows.Forms.TextBox();
            this.variableBox = new System.Windows.Forms.ComboBox();
            this.operatorBox = new System.Windows.Forms.ComboBox();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.cancelFilter = new System.Windows.Forms.Button();
            this.caseSensitiveCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.filterCtrl)).BeginInit();
            this.filterContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewFromClipboard
            // 
            this.viewFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewFromClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.viewFromClipboard.Location = new System.Drawing.Point(347, 334);
            this.viewFromClipboard.Name = "viewFromClipboard";
            this.viewFromClipboard.Size = new System.Drawing.Size(50, 22);
            this.viewFromClipboard.TabIndex = 31;
            this.viewFromClipboard.Text = "Paste";
            this.tip.SetToolTip(this.viewFromClipboard, "Paste from clipboard");
            this.viewFromClipboard.UseVisualStyleBackColor = true;
            this.viewFromClipboard.Click += new System.EventHandler(this.viewFromClipboard_Click);
            // 
            // viewToClipboard
            // 
            this.viewToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewToClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.viewToClipboard.Location = new System.Drawing.Point(291, 334);
            this.viewToClipboard.Name = "viewToClipboard";
            this.viewToClipboard.Size = new System.Drawing.Size(50, 22);
            this.viewToClipboard.TabIndex = 30;
            this.viewToClipboard.Text = "Copy";
            this.tip.SetToolTip(this.viewToClipboard, "Copy to clipboard");
            this.viewToClipboard.UseVisualStyleBackColor = true;
            this.viewToClipboard.Click += new System.EventHandler(this.viewToClipboard_Click);
            // 
            // filterCtrl
            // 
            this.filterCtrl.AllColumns.Add(this.enabledCol);
            this.filterCtrl.AllColumns.Add(this.filterCol);
            this.filterCtrl.AllColumns.Add(this.foundCol);
            this.filterCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterCtrl.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.filterCtrl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.enabledCol,
            this.filterCol,
            this.foundCol});
            this.filterCtrl.FullRowSelect = true;
            this.filterCtrl.HeaderWordWrap = true;
            this.filterCtrl.HideSelection = false;
            this.filterCtrl.HighlightBackgroundColor = System.Drawing.Color.Silver;
            this.filterCtrl.Location = new System.Drawing.Point(0, 21);
            this.filterCtrl.Name = "filterCtrl";
            this.filterCtrl.ShowFilterMenuOnRightClick = false;
            this.filterCtrl.ShowGroups = false;
            this.filterCtrl.ShowImagesOnSubItems = true;
            this.filterCtrl.Size = new System.Drawing.Size(397, 310);
            this.filterCtrl.TabIndex = 17;
            this.filterCtrl.UnfocusedHighlightBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.filterCtrl.UseAlternatingBackColors = true;
            this.filterCtrl.UseCellFormatEvents = true;
            this.filterCtrl.UseCompatibleStateImageBehavior = false;
            this.filterCtrl.UseCustomSelectionColors = true;
            this.filterCtrl.UseSubItemCheckBoxes = true;
            this.filterCtrl.View = System.Windows.Forms.View.Details;
            this.filterCtrl.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.filterCtrl_CellEditStarting);
            this.filterCtrl.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.filterCtrl_CellClick);
            this.filterCtrl.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.filterCtrl_FormatRow);
            this.filterCtrl.ItemsChanged += new System.EventHandler<BrightIdeasSoftware.ItemsChangedEventArgs>(this.filterCtrl_ItemsChanged);
            this.filterCtrl.SelectionChanged += new System.EventHandler(this.filterCtrl_SelectionChanged);
            this.filterCtrl.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.filterCtrl_ItemChecked);
            this.filterCtrl.SelectedIndexChanged += new System.EventHandler(this.filterCtrl_SelectedIndexChanged);
            this.filterCtrl.Click += new System.EventHandler(this.filterCtrl_Click);
            this.filterCtrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filterCtrl_KeyPress);
            this.filterCtrl.Leave += new System.EventHandler(this.filterCtrl_Leave);
            this.filterCtrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filterCtrl_MouseDown);
            // 
            // enabledCol
            // 
            this.enabledCol.AspectName = "enabled";
            this.enabledCol.CheckBoxes = true;
            this.enabledCol.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.enabledCol.Text = "Enabled";
            this.enabledCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.enabledCol.ToolTipText = "Enabled";
            this.enabledCol.Width = 38;
            // 
            // filterCol
            // 
            this.filterCol.AspectName = "name";
            this.filterCol.AutoCompleteEditor = false;
            this.filterCol.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.filterCol.FillsFreeSpace = true;
            this.filterCol.Text = "Filter";
            // 
            // foundCol
            // 
            this.foundCol.AspectName = "found_count";
            this.foundCol.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundCol.IsEditable = false;
            this.foundCol.Text = "Found";
            this.foundCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundCol.ToolTipText = "Shows how many log lines this specific filter has found";
            // 
            // applyToExistingLines
            // 
            this.applyToExistingLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyToExistingLines.AutoSize = true;
            this.applyToExistingLines.Location = new System.Drawing.Point(3, 488);
            this.applyToExistingLines.Name = "applyToExistingLines";
            this.applyToExistingLines.Size = new System.Drawing.Size(126, 17);
            this.applyToExistingLines.TabIndex = 33;
            this.applyToExistingLines.TabStop = false;
            this.applyToExistingLines.Text = "Apply to existing lines";
            this.applyToExistingLines.UseVisualStyleBackColor = true;
            this.applyToExistingLines.CheckedChanged += new System.EventHandler(this.applyToExistingLines_CheckedChanged);
            this.applyToExistingLines.Leave += new System.EventHandler(this.applyToExistingLines_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Filters";
            // 
            // delFilter
            // 
            this.delFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delFilter.Enabled = false;
            this.delFilter.Location = new System.Drawing.Point(222, 462);
            this.delFilter.Name = "delFilter";
            this.delFilter.Size = new System.Drawing.Size(60, 22);
            this.delFilter.TabIndex = 24;
            this.delFilter.Text = "Remove";
            this.delFilter.UseVisualStyleBackColor = true;
            this.delFilter.Click += new System.EventHandler(this.delFilter_Click);
            this.delFilter.Leave += new System.EventHandler(this.delFilter_Leave);
            // 
            // filterLabel
            // 
            this.filterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterLabel.AutoSize = true;
            this.filterLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterLabel.Location = new System.Drawing.Point(-4, 337);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(43, 19);
            this.filterLabel.TabIndex = 16;
            this.filterLabel.Text = "Filter";
            // 
            // addFilter
            // 
            this.addFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addFilter.Enabled = false;
            this.addFilter.Location = new System.Drawing.Point(347, 462);
            this.addFilter.Name = "addFilter";
            this.addFilter.Size = new System.Drawing.Size(50, 22);
            this.addFilter.TabIndex = 22;
            this.addFilter.Text = "Apply";
            this.addFilter.UseVisualStyleBackColor = true;
            this.addFilter.Click += new System.EventHandler(this.addFilter_Click);
            this.addFilter.Leave += new System.EventHandler(this.addFilter_Leave);
            // 
            // selectColor
            // 
            this.selectColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectColor.BackgroundImage = global::lw_common.Properties.Resources.eyedropper;
            this.selectColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectColor.Location = new System.Drawing.Point(263, 334);
            this.selectColor.Name = "selectColor";
            this.selectColor.Size = new System.Drawing.Size(22, 22);
            this.selectColor.TabIndex = 36;
            this.tip.SetToolTip(this.selectColor, "Set color");
            this.selectColor.UseVisualStyleBackColor = true;
            this.selectColor.Click += new System.EventHandler(this.selectColor_Click);
            // 
            // selectMatchColor
            // 
            this.selectMatchColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectMatchColor.BackgroundImage = global::lw_common.Properties.Resources.eyedropper;
            this.selectMatchColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.selectMatchColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectMatchColor.Location = new System.Drawing.Point(235, 334);
            this.selectMatchColor.Name = "selectMatchColor";
            this.selectMatchColor.Size = new System.Drawing.Size(22, 22);
            this.selectMatchColor.TabIndex = 25;
            this.tip.SetToolTip(this.selectMatchColor, "Set match color");
            this.selectMatchColor.UseVisualStyleBackColor = true;
            this.selectMatchColor.Click += new System.EventHandler(this.selectMatchColor_Click);
            // 
            // filterContextMenu
            // 
            this.filterContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.moveToTopToolStripMenuItem,
            this.moveToBottomToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.filterContextMenu.Name = "filterContextMenu";
            this.filterContextMenu.Size = new System.Drawing.Size(164, 142);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveToTopToolStripMenuItem
            // 
            this.moveToTopToolStripMenuItem.Name = "moveToTopToolStripMenuItem";
            this.moveToTopToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.moveToTopToolStripMenuItem.Text = "Move To Top";
            this.moveToTopToolStripMenuItem.Click += new System.EventHandler(this.moveToTopToolStripMenuItem_Click);
            // 
            // moveToBottomToolStripMenuItem
            // 
            this.moveToBottomToolStripMenuItem.Name = "moveToBottomToolStripMenuItem";
            this.moveToBottomToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.moveToBottomToolStripMenuItem.Text = "Move To Bottom";
            this.moveToBottomToolStripMenuItem.Click += new System.EventHandler(this.moveToBottomToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.viewToClipboard_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.viewFromClipboard_Click);
            // 
            // filterBox
            // 
            this.filterBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterBox.Location = new System.Drawing.Point(0, 385);
            this.filterBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterBox.Multiline = true;
            this.filterBox.Name = "filterBox";
            this.filterBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.filterBox.Size = new System.Drawing.Size(397, 73);
            this.filterBox.TabIndex = 18;
            this.filterBox.WordWrap = false;
            this.filterBox.TextChanged += new System.EventHandler(this.filterBox_TextChanged);
            this.filterBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterBox_KeyDown);
            this.filterBox.Leave += new System.EventHandler(this.filterBox_Leave);
            this.filterBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.filterBox_PreviewKeyDown);
            // 
            // variableBox
            // 
            this.variableBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.variableBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.variableBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.variableBox.FormattingEnabled = true;
            this.variableBox.Items.AddRange(new object[] {
            "$level",
            "$msg",
            "$file",
            "$func",
            "$class"});
            this.variableBox.Location = new System.Drawing.Point(0, 360);
            this.variableBox.Name = "variableBox";
            this.variableBox.Size = new System.Drawing.Size(57, 21);
            this.variableBox.TabIndex = 19;
            this.variableBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.variableBox_KeyUp);
            // 
            // operatorBox
            // 
            this.operatorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.operatorBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.operatorBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.operatorBox.FormattingEnabled = true;
            this.operatorBox.Items.AddRange(new object[] {
            "=",
            "!=",
            "startswith",
            "!startswith",
            "contains",
            "!contains",
            "any",
            "none",
            "regex"});
            this.operatorBox.Location = new System.Drawing.Point(63, 360);
            this.operatorBox.Name = "operatorBox";
            this.operatorBox.Size = new System.Drawing.Size(66, 21);
            this.operatorBox.TabIndex = 20;
            this.operatorBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.operatorBox_KeyUp);
            // 
            // valueBox
            // 
            this.valueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueBox.Location = new System.Drawing.Point(135, 360);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(262, 20);
            this.valueBox.TabIndex = 21;
            this.valueBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.valueBox_KeyUp);
            // 
            // cancelFilter
            // 
            this.cancelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelFilter.Enabled = false;
            this.cancelFilter.Location = new System.Drawing.Point(288, 462);
            this.cancelFilter.Name = "cancelFilter";
            this.cancelFilter.Size = new System.Drawing.Size(53, 22);
            this.cancelFilter.TabIndex = 23;
            this.cancelFilter.Text = "Cancel";
            this.cancelFilter.UseVisualStyleBackColor = true;
            this.cancelFilter.Click += new System.EventHandler(this.cancelFilter_Click);
            this.cancelFilter.Leave += new System.EventHandler(this.cancelFilter_Leave);
            // 
            // caseSensitiveCheck
            // 
            this.caseSensitiveCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.caseSensitiveCheck.AutoSize = true;
            this.caseSensitiveCheck.Checked = true;
            this.caseSensitiveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseSensitiveCheck.Location = new System.Drawing.Point(3, 466);
            this.caseSensitiveCheck.Name = "caseSensitiveCheck";
            this.caseSensitiveCheck.Size = new System.Drawing.Size(94, 17);
            this.caseSensitiveCheck.TabIndex = 37;
            this.caseSensitiveCheck.TabStop = false;
            this.caseSensitiveCheck.Text = "Case-sensitive";
            this.caseSensitiveCheck.UseVisualStyleBackColor = true;
            this.caseSensitiveCheck.CheckedChanged += new System.EventHandler(this.caseSensitiveCheck_Changed);
            // 
            // filter_ctrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.caseSensitiveCheck);
            this.Controls.Add(this.selectMatchColor);
            this.Controls.Add(this.cancelFilter);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.operatorBox);
            this.Controls.Add(this.variableBox);
            this.Controls.Add(this.selectColor);
            this.Controls.Add(this.viewFromClipboard);
            this.Controls.Add(this.viewToClipboard);
            this.Controls.Add(this.filterCtrl);
            this.Controls.Add(this.applyToExistingLines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterBox);
            this.Controls.Add(this.delFilter);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.addFilter);
            this.MinimumSize = new System.Drawing.Size(290, 0);
            this.Name = "filter_ctrl";
            this.Size = new System.Drawing.Size(397, 505);
            this.Load += new System.EventHandler(this.filter_ctrl_Load);
            this.SizeChanged += new System.EventHandler(this.filter_ctrl_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.filterCtrl)).EndInit();
            this.filterContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewFromClipboard;
        private System.Windows.Forms.Button viewToClipboard;
        private BrightIdeasSoftware.ObjectListView filterCtrl;
        private BrightIdeasSoftware.OLVColumn enabledCol;
        private BrightIdeasSoftware.OLVColumn filterCol;
        private BrightIdeasSoftware.OLVColumn foundCol;
        private System.Windows.Forms.CheckBox applyToExistingLines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delFilter;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.Button addFilter;
        private System.Windows.Forms.Button selectColor;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ContextMenuStrip filterContextMenu;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToBottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.TextBox filterBox;
        private System.Windows.Forms.ComboBox variableBox;
        private System.Windows.Forms.ComboBox operatorBox;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.Button cancelFilter;
        private System.Windows.Forms.Button selectMatchColor;
        private System.Windows.Forms.CheckBox caseSensitiveCheck;
    }
}
