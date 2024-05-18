﻿namespace SnippetManagerGuiAppWinForms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            GroupBoxFilters = new GroupBox();
            ButtonClearFilters = new Button();
            CheckboxFilterShowMore = new CheckBox();
            GroupBoxFilterHasExtendedDescription = new GroupBox();
            RadioButtonFilterHasExtendedDescriptionAny = new RadioButton();
            RadioButtonFilterHasExtendedDescriptionNo = new RadioButton();
            RadioButtonFilterHasExtendedDescriptionYes = new RadioButton();
            GroupBoxFilterIsRunnable = new GroupBox();
            RadioButtonFilterIsRunnableNo = new RadioButton();
            RadioButtonFilterIsRunnableYes = new RadioButton();
            RadioButtonFilterIsRunnableAny = new RadioButton();
            LabelFilterVerticalLine4 = new Label();
            LabelFiltersHorizontalLine1 = new Label();
            LabelFilterVerticalLine1 = new Label();
            TextboxFilterName = new TextBox();
            LabelFilterName = new Label();
            ComboBoxFilterComplexity = new ComboBox();
            LabelFilterComplexity = new Label();
            LabelFilterVerticalLine3 = new Label();
            ComboBoxFilterType = new ComboBox();
            LabelFilterType = new Label();
            LabelFilterVerticalLine2 = new Label();
            ComboBoxFilterLanguage = new ComboBox();
            LabelFilterLanguage = new Label();
            DataViewSnippetList = new DataGridView();
            ButtonClone = new Button();
            MyToolTip = new ToolTip(components);
            ButtonDelete = new Button();
            ButtonInfo = new Button();
            ButtonAddSnippet = new Button();
            ButtonEditSelectedSnippet = new Button();
            GroupBoxPersistEnvironment = new GroupBox();
            CheckBoxPersistEnvironmentPython = new CheckBox();
            CheckBoxPersistEnvironmentLua = new CheckBox();
            TextBoxCodeViewerEditor = new MyScintillaControl();
            ButtonRunCode = new Button();
            TextBoxRunCodeOutput = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            loadAndAppendToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            GroupBoxFilters.SuspendLayout();
            GroupBoxFilterHasExtendedDescription.SuspendLayout();
            GroupBoxFilterIsRunnable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataViewSnippetList).BeginInit();
            GroupBoxPersistEnvironment.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1215, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, loadAndAppendToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(166, 22);
            newToolStripMenuItem.Text = "New";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(166, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(166, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(166, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(166, 22);
            quitToolStripMenuItem.Text = "Quit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(103, 22);
            undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(103, 22);
            redoToolStripMenuItem.Text = "Redo";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(103, 22);
            cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(103, 22);
            copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(103, 22);
            pasteToolStripMenuItem.Text = "Paste";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // GroupBoxFilters
            // 
            GroupBoxFilters.AutoSize = true;
            GroupBoxFilters.Controls.Add(ButtonClearFilters);
            GroupBoxFilters.Controls.Add(CheckboxFilterShowMore);
            GroupBoxFilters.Controls.Add(GroupBoxFilterHasExtendedDescription);
            GroupBoxFilters.Controls.Add(GroupBoxFilterIsRunnable);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine4);
            GroupBoxFilters.Controls.Add(LabelFiltersHorizontalLine1);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine1);
            GroupBoxFilters.Controls.Add(TextboxFilterName);
            GroupBoxFilters.Controls.Add(LabelFilterName);
            GroupBoxFilters.Controls.Add(ComboBoxFilterComplexity);
            GroupBoxFilters.Controls.Add(LabelFilterComplexity);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine3);
            GroupBoxFilters.Controls.Add(ComboBoxFilterType);
            GroupBoxFilters.Controls.Add(LabelFilterType);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine2);
            GroupBoxFilters.Controls.Add(ComboBoxFilterLanguage);
            GroupBoxFilters.Controls.Add(LabelFilterLanguage);
            GroupBoxFilters.Location = new Point(12, 27);
            GroupBoxFilters.Name = "GroupBoxFilters";
            GroupBoxFilters.Size = new Size(1088, 162);
            GroupBoxFilters.TabIndex = 2;
            GroupBoxFilters.TabStop = false;
            GroupBoxFilters.Text = "Filters";
            // 
            // ButtonClearFilters
            // 
            ButtonClearFilters.Location = new Point(957, 28);
            ButtonClearFilters.Name = "ButtonClearFilters";
            ButtonClearFilters.Size = new Size(92, 23);
            ButtonClearFilters.TabIndex = 22;
            ButtonClearFilters.Text = "Clear filters";
            ButtonClearFilters.UseVisualStyleBackColor = true;
            // 
            // CheckboxFilterShowMore
            // 
            CheckboxFilterShowMore.AutoSize = true;
            CheckboxFilterShowMore.Checked = true;
            CheckboxFilterShowMore.CheckState = CheckState.Checked;
            CheckboxFilterShowMore.Location = new Point(833, 28);
            CheckboxFilterShowMore.Name = "CheckboxFilterShowMore";
            CheckboxFilterShowMore.Size = new Size(118, 19);
            CheckboxFilterShowMore.TabIndex = 21;
            CheckboxFilterShowMore.Text = "Show more filters";
            CheckboxFilterShowMore.UseVisualStyleBackColor = true;
            // 
            // GroupBoxFilterHasExtendedDescription
            // 
            GroupBoxFilterHasExtendedDescription.Controls.Add(RadioButtonFilterHasExtendedDescriptionAny);
            GroupBoxFilterHasExtendedDescription.Controls.Add(RadioButtonFilterHasExtendedDescriptionNo);
            GroupBoxFilterHasExtendedDescription.Controls.Add(RadioButtonFilterHasExtendedDescriptionYes);
            GroupBoxFilterHasExtendedDescription.Location = new Point(232, 88);
            GroupBoxFilterHasExtendedDescription.Name = "GroupBoxFilterHasExtendedDescription";
            GroupBoxFilterHasExtendedDescription.Size = new Size(200, 52);
            GroupBoxFilterHasExtendedDescription.TabIndex = 20;
            GroupBoxFilterHasExtendedDescription.TabStop = false;
            GroupBoxFilterHasExtendedDescription.Text = "Has extended description?";
            // 
            // RadioButtonFilterHasExtendedDescriptionAny
            // 
            RadioButtonFilterHasExtendedDescriptionAny.AutoSize = true;
            RadioButtonFilterHasExtendedDescriptionAny.Checked = true;
            RadioButtonFilterHasExtendedDescriptionAny.Location = new Point(19, 22);
            RadioButtonFilterHasExtendedDescriptionAny.Name = "RadioButtonFilterHasExtendedDescriptionAny";
            RadioButtonFilterHasExtendedDescriptionAny.Size = new Size(46, 19);
            RadioButtonFilterHasExtendedDescriptionAny.TabIndex = 16;
            RadioButtonFilterHasExtendedDescriptionAny.TabStop = true;
            RadioButtonFilterHasExtendedDescriptionAny.Text = "Any";
            RadioButtonFilterHasExtendedDescriptionAny.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterHasExtendedDescriptionNo
            // 
            RadioButtonFilterHasExtendedDescriptionNo.AutoSize = true;
            RadioButtonFilterHasExtendedDescriptionNo.Location = new Point(119, 22);
            RadioButtonFilterHasExtendedDescriptionNo.Name = "RadioButtonFilterHasExtendedDescriptionNo";
            RadioButtonFilterHasExtendedDescriptionNo.Size = new Size(41, 19);
            RadioButtonFilterHasExtendedDescriptionNo.TabIndex = 15;
            RadioButtonFilterHasExtendedDescriptionNo.Text = "No";
            RadioButtonFilterHasExtendedDescriptionNo.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterHasExtendedDescriptionYes
            // 
            RadioButtonFilterHasExtendedDescriptionYes.AutoSize = true;
            RadioButtonFilterHasExtendedDescriptionYes.Location = new Point(71, 22);
            RadioButtonFilterHasExtendedDescriptionYes.Name = "RadioButtonFilterHasExtendedDescriptionYes";
            RadioButtonFilterHasExtendedDescriptionYes.Size = new Size(42, 19);
            RadioButtonFilterHasExtendedDescriptionYes.TabIndex = 14;
            RadioButtonFilterHasExtendedDescriptionYes.Text = "Yes";
            RadioButtonFilterHasExtendedDescriptionYes.UseVisualStyleBackColor = true;
            // 
            // GroupBoxFilterIsRunnable
            // 
            GroupBoxFilterIsRunnable.Controls.Add(RadioButtonFilterIsRunnableNo);
            GroupBoxFilterIsRunnable.Controls.Add(RadioButtonFilterIsRunnableYes);
            GroupBoxFilterIsRunnable.Controls.Add(RadioButtonFilterIsRunnableAny);
            GroupBoxFilterIsRunnable.Location = new Point(15, 88);
            GroupBoxFilterIsRunnable.Name = "GroupBoxFilterIsRunnable";
            GroupBoxFilterIsRunnable.Size = new Size(176, 52);
            GroupBoxFilterIsRunnable.TabIndex = 19;
            GroupBoxFilterIsRunnable.TabStop = false;
            GroupBoxFilterIsRunnable.Text = "Is runnable?";
            // 
            // RadioButtonFilterIsRunnableNo
            // 
            RadioButtonFilterIsRunnableNo.AutoSize = true;
            RadioButtonFilterIsRunnableNo.Location = new Point(122, 22);
            RadioButtonFilterIsRunnableNo.Name = "RadioButtonFilterIsRunnableNo";
            RadioButtonFilterIsRunnableNo.Size = new Size(41, 19);
            RadioButtonFilterIsRunnableNo.TabIndex = 15;
            RadioButtonFilterIsRunnableNo.Text = "No";
            RadioButtonFilterIsRunnableNo.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterIsRunnableYes
            // 
            RadioButtonFilterIsRunnableYes.AutoSize = true;
            RadioButtonFilterIsRunnableYes.Location = new Point(74, 22);
            RadioButtonFilterIsRunnableYes.Name = "RadioButtonFilterIsRunnableYes";
            RadioButtonFilterIsRunnableYes.Size = new Size(42, 19);
            RadioButtonFilterIsRunnableYes.TabIndex = 14;
            RadioButtonFilterIsRunnableYes.Text = "Yes";
            RadioButtonFilterIsRunnableYes.UseVisualStyleBackColor = true;
            // 
            // RadioButtonFilterIsRunnableAny
            // 
            RadioButtonFilterIsRunnableAny.AutoSize = true;
            RadioButtonFilterIsRunnableAny.Checked = true;
            RadioButtonFilterIsRunnableAny.Location = new Point(22, 22);
            RadioButtonFilterIsRunnableAny.Name = "RadioButtonFilterIsRunnableAny";
            RadioButtonFilterIsRunnableAny.Size = new Size(46, 19);
            RadioButtonFilterIsRunnableAny.TabIndex = 13;
            RadioButtonFilterIsRunnableAny.TabStop = true;
            RadioButtonFilterIsRunnableAny.Text = "Any";
            RadioButtonFilterIsRunnableAny.UseVisualStyleBackColor = true;
            // 
            // LabelFilterVerticalLine4
            // 
            LabelFilterVerticalLine4.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine4.Location = new Point(209, 95);
            LabelFilterVerticalLine4.Name = "LabelFilterVerticalLine4";
            LabelFilterVerticalLine4.Size = new Size(2, 45);
            LabelFilterVerticalLine4.TabIndex = 18;
            // 
            // LabelFiltersHorizontalLine1
            // 
            LabelFiltersHorizontalLine1.BorderStyle = BorderStyle.Fixed3D;
            LabelFiltersHorizontalLine1.Location = new Point(15, 78);
            LabelFiltersHorizontalLine1.Name = "LabelFiltersHorizontalLine1";
            LabelFiltersHorizontalLine1.Size = new Size(1060, 2);
            LabelFiltersHorizontalLine1.TabIndex = 17;
            // 
            // LabelFilterVerticalLine1
            // 
            LabelFilterVerticalLine1.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine1.Location = new Point(180, 18);
            LabelFilterVerticalLine1.Name = "LabelFilterVerticalLine1";
            LabelFilterVerticalLine1.Size = new Size(2, 45);
            LabelFilterVerticalLine1.TabIndex = 16;
            // 
            // TextboxFilterName
            // 
            TextboxFilterName.Location = new Point(60, 26);
            TextboxFilterName.Name = "TextboxFilterName";
            TextboxFilterName.Size = new Size(100, 23);
            TextboxFilterName.TabIndex = 11;
            // 
            // LabelFilterName
            // 
            LabelFilterName.AutoSize = true;
            LabelFilterName.Location = new Point(15, 29);
            LabelFilterName.Name = "LabelFilterName";
            LabelFilterName.Size = new Size(39, 15);
            LabelFilterName.TabIndex = 10;
            LabelFilterName.Text = "Name";
            // 
            // ComboBoxFilterComplexity
            // 
            ComboBoxFilterComplexity.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterComplexity.FormattingEnabled = true;
            ComboBoxFilterComplexity.Location = new Point(677, 26);
            ComboBoxFilterComplexity.Name = "ComboBoxFilterComplexity";
            ComboBoxFilterComplexity.Size = new Size(121, 23);
            ComboBoxFilterComplexity.TabIndex = 7;
            // 
            // LabelFilterComplexity
            // 
            LabelFilterComplexity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelFilterComplexity.AutoSize = true;
            LabelFilterComplexity.Location = new Point(603, 29);
            LabelFilterComplexity.Name = "LabelFilterComplexity";
            LabelFilterComplexity.Size = new Size(68, 15);
            LabelFilterComplexity.TabIndex = 6;
            LabelFilterComplexity.Text = "Complexity";
            // 
            // LabelFilterVerticalLine3
            // 
            LabelFilterVerticalLine3.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine3.Location = new Point(591, 18);
            LabelFilterVerticalLine3.Name = "LabelFilterVerticalLine3";
            LabelFilterVerticalLine3.Size = new Size(2, 45);
            LabelFilterVerticalLine3.TabIndex = 5;
            // 
            // ComboBoxFilterType
            // 
            ComboBoxFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterType.FormattingEnabled = true;
            ComboBoxFilterType.Location = new Point(452, 26);
            ComboBoxFilterType.Name = "ComboBoxFilterType";
            ComboBoxFilterType.Size = new Size(121, 23);
            ComboBoxFilterType.TabIndex = 4;
            // 
            // LabelFilterType
            // 
            LabelFilterType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelFilterType.AutoSize = true;
            LabelFilterType.Location = new Point(415, 29);
            LabelFilterType.Name = "LabelFilterType";
            LabelFilterType.Size = new Size(31, 15);
            LabelFilterType.TabIndex = 3;
            LabelFilterType.Text = "Type";
            // 
            // LabelFilterVerticalLine2
            // 
            LabelFilterVerticalLine2.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine2.Location = new Point(403, 18);
            LabelFilterVerticalLine2.Name = "LabelFilterVerticalLine2";
            LabelFilterVerticalLine2.Size = new Size(2, 45);
            LabelFilterVerticalLine2.TabIndex = 2;
            // 
            // ComboBoxFilterLanguage
            // 
            ComboBoxFilterLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterLanguage.FormattingEnabled = true;
            ComboBoxFilterLanguage.Location = new Point(264, 26);
            ComboBoxFilterLanguage.Name = "ComboBoxFilterLanguage";
            ComboBoxFilterLanguage.Size = new Size(121, 23);
            ComboBoxFilterLanguage.TabIndex = 1;
            // 
            // LabelFilterLanguage
            // 
            LabelFilterLanguage.AutoSize = true;
            LabelFilterLanguage.Location = new Point(199, 29);
            LabelFilterLanguage.Name = "LabelFilterLanguage";
            LabelFilterLanguage.Size = new Size(59, 15);
            LabelFilterLanguage.TabIndex = 0;
            LabelFilterLanguage.Text = "Language";
            // 
            // DataViewSnippetList
            // 
            DataViewSnippetList.AllowUserToAddRows = false;
            DataViewSnippetList.AllowUserToDeleteRows = false;
            DataViewSnippetList.AllowUserToResizeRows = false;
            DataViewSnippetList.BackgroundColor = SystemColors.Window;
            DataViewSnippetList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataViewSnippetList.Location = new Point(12, 197);
            DataViewSnippetList.MultiSelect = false;
            DataViewSnippetList.Name = "DataViewSnippetList";
            DataViewSnippetList.RowTemplate.Height = 25;
            DataViewSnippetList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataViewSnippetList.Size = new Size(520, 619);
            DataViewSnippetList.TabIndex = 3;
            // 
            // ButtonClone
            // 
            ButtonClone.Location = new Point(667, 197);
            ButtonClone.Name = "ButtonClone";
            ButtonClone.Size = new Size(129, 23);
            ButtonClone.TabIndex = 4;
            ButtonClone.Text = "Clone";
            MyToolTip.SetToolTip(ButtonClone, "Clones currently selected snippet, so you can change it without affecting original snippet");
            ButtonClone.UseVisualStyleBackColor = true;
            // 
            // ButtonDelete
            // 
            ButtonDelete.ForeColor = Color.Red;
            ButtonDelete.Location = new Point(1078, 197);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(126, 23);
            ButtonDelete.TabIndex = 5;
            ButtonDelete.Text = "Delete";
            MyToolTip.SetToolTip(ButtonDelete, "Deletes currently selected snippet");
            ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // ButtonInfo
            // 
            ButtonInfo.Location = new Point(538, 197);
            ButtonInfo.Name = "ButtonInfo";
            ButtonInfo.Size = new Size(123, 23);
            ButtonInfo.TabIndex = 6;
            ButtonInfo.Text = "More information";
            MyToolTip.SetToolTip(ButtonInfo, "Shows more information about selected snippet, if it is available");
            ButtonInfo.UseVisualStyleBackColor = true;
            // 
            // ButtonAddSnippet
            // 
            ButtonAddSnippet.Location = new Point(802, 197);
            ButtonAddSnippet.Name = "ButtonAddSnippet";
            ButtonAddSnippet.Size = new Size(113, 23);
            ButtonAddSnippet.TabIndex = 7;
            ButtonAddSnippet.Text = "Add snippet";
            MyToolTip.SetToolTip(ButtonAddSnippet, "Opens a new window, allowing you to add new snippet with arbitrary properties");
            ButtonAddSnippet.UseVisualStyleBackColor = true;
            // 
            // ButtonEditSelectedSnippet
            // 
            ButtonEditSelectedSnippet.Location = new Point(921, 197);
            ButtonEditSelectedSnippet.Name = "ButtonEditSelectedSnippet";
            ButtonEditSelectedSnippet.Size = new Size(151, 23);
            ButtonEditSelectedSnippet.TabIndex = 8;
            ButtonEditSelectedSnippet.Text = "Edit selected snippet";
            MyToolTip.SetToolTip(ButtonEditSelectedSnippet, "Opens a new window, where you can change properties like complexity");
            ButtonEditSelectedSnippet.UseVisualStyleBackColor = true;
            // 
            // GroupBoxPersistEnvironment
            // 
            GroupBoxPersistEnvironment.Controls.Add(CheckBoxPersistEnvironmentPython);
            GroupBoxPersistEnvironment.Controls.Add(CheckBoxPersistEnvironmentLua);
            GroupBoxPersistEnvironment.Location = new Point(802, 531);
            GroupBoxPersistEnvironment.Name = "GroupBoxPersistEnvironment";
            GroupBoxPersistEnvironment.Size = new Size(401, 44);
            GroupBoxPersistEnvironment.TabIndex = 12;
            GroupBoxPersistEnvironment.TabStop = false;
            GroupBoxPersistEnvironment.Text = "Persist environment?";
            MyToolTip.SetToolTip(GroupBoxPersistEnvironment, resources.GetString("GroupBoxPersistEnvironment.ToolTip"));
            // 
            // CheckBoxPersistEnvironmentPython
            // 
            CheckBoxPersistEnvironmentPython.AutoSize = true;
            CheckBoxPersistEnvironmentPython.Location = new Point(76, 19);
            CheckBoxPersistEnvironmentPython.Name = "CheckBoxPersistEnvironmentPython";
            CheckBoxPersistEnvironmentPython.Size = new Size(64, 19);
            CheckBoxPersistEnvironmentPython.TabIndex = 1;
            CheckBoxPersistEnvironmentPython.Text = "Python";
            CheckBoxPersistEnvironmentPython.UseVisualStyleBackColor = true;
            // 
            // CheckBoxPersistEnvironmentLua
            // 
            CheckBoxPersistEnvironmentLua.AutoSize = true;
            CheckBoxPersistEnvironmentLua.Location = new Point(6, 19);
            CheckBoxPersistEnvironmentLua.Name = "CheckBoxPersistEnvironmentLua";
            CheckBoxPersistEnvironmentLua.Size = new Size(45, 19);
            CheckBoxPersistEnvironmentLua.TabIndex = 0;
            CheckBoxPersistEnvironmentLua.Text = "Lua";
            CheckBoxPersistEnvironmentLua.UseVisualStyleBackColor = true;
            // 
            // TextBoxCodeViewerEditor
            // 
            TextBoxCodeViewerEditor.AutoCMaxHeight = 9;
            TextBoxCodeViewerEditor.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextBoxCodeViewerEditor.CaretLineVisible = true;
            TextBoxCodeViewerEditor.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxCodeViewerEditor.LexerName = null;
            TextBoxCodeViewerEditor.Location = new Point(538, 226);
            TextBoxCodeViewerEditor.Name = "TextBoxCodeViewerEditor";
            TextBoxCodeViewerEditor.ScrollWidth = 152;
            TextBoxCodeViewerEditor.Size = new Size(665, 299);
            TextBoxCodeViewerEditor.TabIndents = true;
            TextBoxCodeViewerEditor.TabIndex = 9;
            TextBoxCodeViewerEditor.Text = "myScintillaControl1";
            TextBoxCodeViewerEditor.UseRightToLeftReadingLayout = false;
            TextBoxCodeViewerEditor.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // ButtonRunCode
            // 
            ButtonRunCode.Location = new Point(538, 531);
            ButtonRunCode.Name = "ButtonRunCode";
            ButtonRunCode.Size = new Size(219, 44);
            ButtonRunCode.TabIndex = 10;
            ButtonRunCode.Text = "Run this code";
            ButtonRunCode.UseVisualStyleBackColor = true;
            // 
            // TextBoxRunCodeOutput
            // 
            TextBoxRunCodeOutput.Location = new Point(538, 632);
            TextBoxRunCodeOutput.Name = "TextBoxRunCodeOutput";
            TextBoxRunCodeOutput.ReadOnly = true;
            TextBoxRunCodeOutput.Size = new Size(665, 184);
            TextBoxRunCodeOutput.TabIndex = 11;
            TextBoxRunCodeOutput.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(763, 604);
            label1.Name = "label1";
            label1.Size = new Size(200, 15);
            label1.TabIndex = 0;
            label1.Text = "Last run code results for this snippet:";
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Enabled = false;
            label2.Location = new Point(538, 592);
            label2.Name = "label2";
            label2.Size = new Size(665, 3);
            label2.TabIndex = 14;
            // 
            // loadAndAppendToolStripMenuItem
            // 
            loadAndAppendToolStripMenuItem.Name = "loadAndAppendToolStripMenuItem";
            loadAndAppendToolStripMenuItem.Size = new Size(166, 22);
            loadAndAppendToolStripMenuItem.Text = "Load and append";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1215, 826);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GroupBoxPersistEnvironment);
            Controls.Add(TextBoxRunCodeOutput);
            Controls.Add(ButtonRunCode);
            Controls.Add(TextBoxCodeViewerEditor);
            Controls.Add(ButtonEditSelectedSnippet);
            Controls.Add(ButtonAddSnippet);
            Controls.Add(ButtonInfo);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonClone);
            Controls.Add(DataViewSnippetList);
            Controls.Add(GroupBoxFilters);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Snippet Manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            GroupBoxFilters.ResumeLayout(false);
            GroupBoxFilters.PerformLayout();
            GroupBoxFilterHasExtendedDescription.ResumeLayout(false);
            GroupBoxFilterHasExtendedDescription.PerformLayout();
            GroupBoxFilterIsRunnable.ResumeLayout(false);
            GroupBoxFilterIsRunnable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataViewSnippetList).EndInit();
            GroupBoxPersistEnvironment.ResumeLayout(false);
            GroupBoxPersistEnvironment.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Label LabelFilterVerticalLine2;
        private ComboBox ComboBoxFilterLanguage;
        private Label LabelFilterLanguage;
        private ComboBox ComboBoxFilterType;
        private Label LabelFilterType;
        private ComboBox ComboBoxFilterComplexity;
        private Label LabelFilterComplexity;
        private Label LabelFilterVerticalLine3;
        private DataGridView DataViewSnippetList;
        private Button ButtonClone;
        private ToolTip MyToolTip;
        private Button ButtonDelete;
        private Button ButtonInfo;
        private Button ButtonAddSnippet;
        private Button ButtonEditSelectedSnippet;
        private TextBox TextboxFilterName;
        private Label LabelFilterName;
        private RadioButton RadioButtonFilterHasExtendedDescriptionNo;
        private RadioButton RadioButtonFilterHasExtendedDescriptionYes;
        private RadioButton RadioButtonFilterHasExtendedDescriptionAny;
        private Label LabelFilterVerticalLine1;
        private Label LabelFiltersHorizontalLine1;
        private Label LabelFilterVerticalLine4;
        private GroupBox GroupBoxFilterIsRunnable;
        private RadioButton RadioButtonFilterIsRunnableNo;
        private RadioButton RadioButtonFilterIsRunnableYes;
        private RadioButton RadioButtonFilterIsRunnableAny;
        private GroupBox GroupBoxFilterHasExtendedDescription;
        private CheckBox CheckboxFilterShowMore;
        public GroupBox GroupBoxFilters;
        private MyScintillaControl TextBoxCodeViewerEditor;
        private Button ButtonRunCode;
        private RichTextBox TextBoxRunCodeOutput;
        private GroupBox GroupBoxPersistEnvironment;
        private CheckBox CheckBoxPersistEnvironmentLua;
        private CheckBox CheckBoxPersistEnvironmentPython;
        private Button ButtonClearFilters;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem loadAndAppendToolStripMenuItem;
    }
}
