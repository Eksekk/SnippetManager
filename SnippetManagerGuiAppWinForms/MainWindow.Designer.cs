namespace SnippetManagerGuiAppWinForms
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
            TextBoxCodeViewerEditor = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
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
            ComboBoxFilterComplexity = new ComboBox();
            LabelFilterComplexity = new Label();
            LabelFilterVerticalLine2 = new Label();
            ComboBoxFilterType = new ComboBox();
            LabelFilterType = new Label();
            LabelFilterVerticalLine1 = new Label();
            ComboBoxFilterLanguage = new ComboBox();
            LabelFilterLanguage = new Label();
            DataViewSnippetList = new DataGridView();
            ButtonClone = new Button();
            MyToolTip = new ToolTip(components);
            ButtonDelete = new Button();
            ButtonInfo = new Button();
            menuStrip1.SuspendLayout();
            GroupBoxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataViewSnippetList).BeginInit();
            SuspendLayout();
            // 
            // TextBoxCodeViewerEditor
            // 
            TextBoxCodeViewerEditor.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TextBoxCodeViewerEditor.Location = new Point(462, 138);
            TextBoxCodeViewerEditor.Name = "TextBoxCodeViewerEditor";
            TextBoxCodeViewerEditor.Size = new Size(638, 292);
            TextBoxCodeViewerEditor.TabIndex = 0;
            TextBoxCodeViewerEditor.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1139, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(112, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(112, 22);
            loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(112, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(112, 22);
            saveAsToolStripMenuItem.Text = "Save as";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(112, 22);
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
            GroupBoxFilters.Controls.Add(ComboBoxFilterComplexity);
            GroupBoxFilters.Controls.Add(LabelFilterComplexity);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine2);
            GroupBoxFilters.Controls.Add(ComboBoxFilterType);
            GroupBoxFilters.Controls.Add(LabelFilterType);
            GroupBoxFilters.Controls.Add(LabelFilterVerticalLine1);
            GroupBoxFilters.Controls.Add(ComboBoxFilterLanguage);
            GroupBoxFilters.Controls.Add(LabelFilterLanguage);
            GroupBoxFilters.Location = new Point(12, 27);
            GroupBoxFilters.Name = "GroupBoxFilters";
            GroupBoxFilters.Size = new Size(708, 69);
            GroupBoxFilters.TabIndex = 2;
            GroupBoxFilters.TabStop = false;
            GroupBoxFilters.Text = "Filters";
            // 
            // ComboBoxFilterComplexity
            // 
            ComboBoxFilterComplexity.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterComplexity.FormattingEnabled = true;
            ComboBoxFilterComplexity.Location = new Point(494, 27);
            ComboBoxFilterComplexity.Name = "ComboBoxFilterComplexity";
            ComboBoxFilterComplexity.Size = new Size(121, 23);
            ComboBoxFilterComplexity.TabIndex = 7;
            // 
            // LabelFilterComplexity
            // 
            LabelFilterComplexity.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelFilterComplexity.AutoSize = true;
            LabelFilterComplexity.Location = new Point(420, 30);
            LabelFilterComplexity.Name = "LabelFilterComplexity";
            LabelFilterComplexity.Size = new Size(68, 15);
            LabelFilterComplexity.TabIndex = 6;
            LabelFilterComplexity.Text = "Complexity";
            // 
            // LabelFilterVerticalLine2
            // 
            LabelFilterVerticalLine2.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine2.Location = new Point(408, 19);
            LabelFilterVerticalLine2.Name = "LabelFilterVerticalLine2";
            LabelFilterVerticalLine2.Size = new Size(2, 45);
            LabelFilterVerticalLine2.TabIndex = 5;
            // 
            // ComboBoxFilterType
            // 
            ComboBoxFilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterType.FormattingEnabled = true;
            ComboBoxFilterType.Location = new Point(269, 27);
            ComboBoxFilterType.Name = "ComboBoxFilterType";
            ComboBoxFilterType.Size = new Size(121, 23);
            ComboBoxFilterType.TabIndex = 4;
            // 
            // LabelFilterType
            // 
            LabelFilterType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LabelFilterType.AutoSize = true;
            LabelFilterType.Location = new Point(232, 30);
            LabelFilterType.Name = "LabelFilterType";
            LabelFilterType.Size = new Size(31, 15);
            LabelFilterType.TabIndex = 3;
            LabelFilterType.Text = "Type";
            // 
            // LabelFilterVerticalLine1
            // 
            LabelFilterVerticalLine1.BorderStyle = BorderStyle.Fixed3D;
            LabelFilterVerticalLine1.Location = new Point(220, 19);
            LabelFilterVerticalLine1.Name = "LabelFilterVerticalLine1";
            LabelFilterVerticalLine1.Size = new Size(2, 45);
            LabelFilterVerticalLine1.TabIndex = 2;
            // 
            // ComboBoxFilterLanguage
            // 
            ComboBoxFilterLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxFilterLanguage.FormattingEnabled = true;
            ComboBoxFilterLanguage.Location = new Point(81, 27);
            ComboBoxFilterLanguage.Name = "ComboBoxFilterLanguage";
            ComboBoxFilterLanguage.Size = new Size(121, 23);
            ComboBoxFilterLanguage.TabIndex = 1;
            // 
            // LabelFilterLanguage
            // 
            LabelFilterLanguage.AutoSize = true;
            LabelFilterLanguage.Location = new Point(16, 30);
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
            DataViewSnippetList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataViewSnippetList.BackgroundColor = SystemColors.Window;
            DataViewSnippetList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataViewSnippetList.Location = new Point(12, 102);
            DataViewSnippetList.MultiSelect = false;
            DataViewSnippetList.Name = "DataViewSnippetList";
            DataViewSnippetList.RowTemplate.Height = 25;
            DataViewSnippetList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataViewSnippetList.Size = new Size(444, 382);
            DataViewSnippetList.TabIndex = 3;
            // 
            // ButtonClone
            // 
            ButtonClone.Location = new Point(591, 102);
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
            ButtonDelete.Location = new Point(726, 102);
            ButtonDelete.Name = "ButtonDelete";
            ButtonDelete.Size = new Size(126, 23);
            ButtonDelete.TabIndex = 5;
            ButtonDelete.Text = "Delete";
            MyToolTip.SetToolTip(ButtonDelete, "Deletes currently selected snippet");
            ButtonDelete.UseVisualStyleBackColor = true;
            // 
            // ButtonInfo
            // 
            ButtonInfo.Location = new Point(462, 102);
            ButtonInfo.Name = "ButtonInfo";
            ButtonInfo.Size = new Size(123, 23);
            ButtonInfo.TabIndex = 6;
            ButtonInfo.Text = "More information";
            MyToolTip.SetToolTip(ButtonInfo, "Shows more information about selected snippet, if it is available");
            ButtonInfo.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1139, 496);
            Controls.Add(ButtonInfo);
            Controls.Add(ButtonDelete);
            Controls.Add(ButtonClone);
            Controls.Add(DataViewSnippetList);
            Controls.Add(GroupBoxFilters);
            Controls.Add(TextBoxCodeViewerEditor);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainWindow";
            Text = "Snippet Manager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            GroupBoxFilters.ResumeLayout(false);
            GroupBoxFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataViewSnippetList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox TextBoxCodeViewerEditor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
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
        private GroupBox GroupBoxFilters;
        private Label LabelFilterVerticalLine1;
        private ComboBox ComboBoxFilterLanguage;
        private Label LabelFilterLanguage;
        private ComboBox ComboBoxFilterType;
        private Label LabelFilterType;
        private ComboBox ComboBoxFilterComplexity;
        private Label LabelFilterComplexity;
        private Label LabelFilterVerticalLine2;
        private DataGridView DataViewSnippetList;
        private Button ButtonClone;
        private ToolTip MyToolTip;
        private Button ButtonDelete;
        private Button ButtonInfo;
    }
}
