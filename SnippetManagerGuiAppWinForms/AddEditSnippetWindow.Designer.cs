namespace SnippetManagerGuiAppWinForms
{
    partial class AddEditSnippetWindow
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
            components = new System.ComponentModel.Container();
            LabelName = new Label();
            TextBoxName = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            LabelType = new Label();
            LabelLanguage = new Label();
            LabelComplexity = new Label();
            LabelCode = new Label();
            LabelUrls = new Label();
            ComboBoxType = new ComboBox();
            ComboBoxLanguage = new ComboBox();
            ComboBoxComplexity = new ComboBox();
            ButtonCalculateComplexity = new Button();
            MyToolTip = new ToolTip(components);
            CheckBoxIsRunnable = new CheckBox();
            CheckBoxExtendedDescription = new CheckBox();
            TextBoxDescription = new RichTextBox();
            GridViewUrls = new DataGridView();
            ColumnValue = new DataGridViewTextBoxColumn();
            ButtonOk = new Button();
            ButtonCancel = new Button();
            TextBoxCode = new MyScintillaControl();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridViewUrls).BeginInit();
            SuspendLayout();
            // 
            // LabelName
            // 
            LabelName.Anchor = AnchorStyles.Left;
            LabelName.AutoSize = true;
            LabelName.Location = new Point(12, 15);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(39, 15);
            LabelName.TabIndex = 0;
            LabelName.Text = "Name";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(121, 15);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(358, 23);
            TextBoxName.TabIndex = 1;
            TextBoxName.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Location = new Point(868, 134);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(144, 45);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Location = new Point(39, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(66, 9);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // LabelType
            // 
            LabelType.AutoSize = true;
            LabelType.Location = new Point(12, 60);
            LabelType.Name = "LabelType";
            LabelType.Size = new Size(31, 15);
            LabelType.TabIndex = 3;
            LabelType.Text = "Type";
            // 
            // LabelLanguage
            // 
            LabelLanguage.AutoSize = true;
            LabelLanguage.Location = new Point(13, 100);
            LabelLanguage.Name = "LabelLanguage";
            LabelLanguage.Size = new Size(59, 15);
            LabelLanguage.TabIndex = 4;
            LabelLanguage.Text = "Language";
            // 
            // LabelComplexity
            // 
            LabelComplexity.AutoSize = true;
            LabelComplexity.Location = new Point(13, 141);
            LabelComplexity.Name = "LabelComplexity";
            LabelComplexity.Size = new Size(68, 15);
            LabelComplexity.TabIndex = 5;
            LabelComplexity.Text = "Complexity";
            // 
            // LabelCode
            // 
            LabelCode.AutoSize = true;
            LabelCode.Location = new Point(12, 379);
            LabelCode.Name = "LabelCode";
            LabelCode.Size = new Size(35, 15);
            LabelCode.TabIndex = 6;
            LabelCode.Text = "Code";
            // 
            // LabelUrls
            // 
            LabelUrls.AutoSize = true;
            LabelUrls.Location = new Point(577, 674);
            LabelUrls.Name = "LabelUrls";
            LabelUrls.Size = new Size(27, 15);
            LabelUrls.TabIndex = 7;
            LabelUrls.Text = "Urls";
            // 
            // ComboBoxType
            // 
            ComboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxType.FormattingEnabled = true;
            ComboBoxType.Location = new Point(121, 58);
            ComboBoxType.Name = "ComboBoxType";
            ComboBoxType.Size = new Size(121, 23);
            ComboBoxType.TabIndex = 9;
            // 
            // ComboBoxLanguage
            // 
            ComboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxLanguage.FormattingEnabled = true;
            ComboBoxLanguage.Location = new Point(121, 98);
            ComboBoxLanguage.Name = "ComboBoxLanguage";
            ComboBoxLanguage.Size = new Size(121, 23);
            ComboBoxLanguage.TabIndex = 10;
            // 
            // ComboBoxComplexity
            // 
            ComboBoxComplexity.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxComplexity.FormattingEnabled = true;
            ComboBoxComplexity.Location = new Point(121, 138);
            ComboBoxComplexity.Name = "ComboBoxComplexity";
            ComboBoxComplexity.Size = new Size(121, 23);
            ComboBoxComplexity.TabIndex = 11;
            // 
            // ButtonCalculateComplexity
            // 
            ButtonCalculateComplexity.Location = new Point(269, 138);
            ButtonCalculateComplexity.Name = "ButtonCalculateComplexity";
            ButtonCalculateComplexity.Size = new Size(157, 23);
            ButtonCalculateComplexity.TabIndex = 12;
            ButtonCalculateComplexity.Text = "Calculate from code";
            MyToolTip.SetToolTip(ButtonCalculateComplexity, "Calculates complexity automatically based on amount of lines of code. Not the most reliable indicator.");
            ButtonCalculateComplexity.UseVisualStyleBackColor = true;
            // 
            // CheckBoxIsRunnable
            // 
            CheckBoxIsRunnable.AutoSize = true;
            CheckBoxIsRunnable.Location = new Point(13, 581);
            CheckBoxIsRunnable.Name = "CheckBoxIsRunnable";
            CheckBoxIsRunnable.Size = new Size(84, 19);
            CheckBoxIsRunnable.TabIndex = 20;
            CheckBoxIsRunnable.Text = "Is runnable";
            MyToolTip.SetToolTip(CheckBoxIsRunnable, "Can be run immediately in this application to view results");
            CheckBoxIsRunnable.UseVisualStyleBackColor = true;
            // 
            // CheckBoxExtendedDescription
            // 
            CheckBoxExtendedDescription.AutoSize = true;
            CheckBoxExtendedDescription.Location = new Point(12, 670);
            CheckBoxExtendedDescription.Name = "CheckBoxExtendedDescription";
            CheckBoxExtendedDescription.Size = new Size(137, 19);
            CheckBoxExtendedDescription.TabIndex = 14;
            CheckBoxExtendedDescription.Text = "Extended description";
            CheckBoxExtendedDescription.UseVisualStyleBackColor = true;
            // 
            // TextBoxDescription
            // 
            TextBoxDescription.Location = new Point(155, 618);
            TextBoxDescription.Name = "TextBoxDescription";
            TextBoxDescription.Size = new Size(373, 130);
            TextBoxDescription.TabIndex = 15;
            TextBoxDescription.Text = "";
            // 
            // GridViewUrls
            // 
            GridViewUrls.AllowUserToOrderColumns = true;
            GridViewUrls.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridViewUrls.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewUrls.Columns.AddRange(new DataGridViewColumn[] { ColumnValue });
            GridViewUrls.Location = new Point(620, 608);
            GridViewUrls.Name = "GridViewUrls";
            GridViewUrls.RowTemplate.Height = 25;
            GridViewUrls.Size = new Size(353, 154);
            GridViewUrls.TabIndex = 17;
            // 
            // ColumnValue
            // 
            ColumnValue.HeaderText = "Value";
            ColumnValue.Name = "ColumnValue";
            // 
            // ButtonOk
            // 
            ButtonOk.Location = new Point(453, 810);
            ButtonOk.Name = "ButtonOk";
            ButtonOk.Size = new Size(75, 23);
            ButtonOk.TabIndex = 18;
            ButtonOk.Text = "OK";
            ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(577, 810);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 19;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // TextBoxCode
            // 
            TextBoxCode.AutoCMaxHeight = 9;
            TextBoxCode.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            TextBoxCode.CaretLineVisible = true;
            TextBoxCode.LexerName = null;
            TextBoxCode.Location = new Point(121, 186);
            TextBoxCode.Name = "TextBoxCode";
            TextBoxCode.ScrollWidth = 111;
            TextBoxCode.Size = new Size(597, 387);
            TextBoxCode.TabIndents = true;
            TextBoxCode.TabIndex = 21;
            TextBoxCode.Text = "myScintillaControl1";
            TextBoxCode.UseRightToLeftReadingLayout = false;
            TextBoxCode.WrapMode = ScintillaNET.WrapMode.None;
            // 
            // AddEditSnippetWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1087, 841);
            Controls.Add(TextBoxCode);
            Controls.Add(CheckBoxIsRunnable);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOk);
            Controls.Add(GridViewUrls);
            Controls.Add(TextBoxDescription);
            Controls.Add(CheckBoxExtendedDescription);
            Controls.Add(ButtonCalculateComplexity);
            Controls.Add(ComboBoxComplexity);
            Controls.Add(ComboBoxLanguage);
            Controls.Add(ComboBoxType);
            Controls.Add(LabelUrls);
            Controls.Add(LabelCode);
            Controls.Add(LabelComplexity);
            Controls.Add(LabelLanguage);
            Controls.Add(LabelType);
            Controls.Add(LabelName);
            Controls.Add(TextBoxName);
            Controls.Add(tableLayoutPanel1);
            Name = "AddEditSnippetWindow";
            Text = "AddEditSnippetWindow";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridViewUrls).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RichTextBox TextBoxName;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label LabelName;
        private Label LabelType;
        private Label LabelLanguage;
        private Label LabelComplexity;
        private Label LabelCode;
        private Label LabelUrls;
        private ComboBox ComboBoxType;
        private ComboBox ComboBoxLanguage;
        private ComboBox ComboBoxComplexity;
        private Button ButtonCalculateComplexity;
        private ToolTip MyToolTip;
        private CheckBox CheckBoxExtendedDescription;
        private RichTextBox TextBoxDescription;
        private DataGridView GridViewUrls;
        private DataGridViewTextBoxColumn ColumnValue;
        private Button ButtonOk;
        private Button ButtonCancel;
        private CheckBox CheckBoxIsRunnable;
        private MyScintillaControl TextBoxCode;
    }
}