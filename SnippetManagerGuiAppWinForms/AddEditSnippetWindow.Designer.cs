﻿namespace SnippetManagerGuiAppWinForms
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
            comboBox3 = new ComboBox();
            ButtonCalculateComplexity = new Button();
            MyToolTip = new ToolTip(components);
            TextBoxCode = new RichTextBox();
            CheckBoxExtendedDescription = new CheckBox();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            ColumnValue = new DataGridViewTextBoxColumn();
            ButtonOk = new Button();
            ButtonCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // LabelName
            // 
            LabelName.Anchor = AnchorStyles.Left;
            LabelName.AutoSize = true;
            LabelName.Location = new Point(12, 27);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(39, 15);
            LabelName.TabIndex = 0;
            LabelName.Text = "Name";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(121, 24);
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
            LabelUrls.Location = new Point(577, 646);
            LabelUrls.Name = "LabelUrls";
            LabelUrls.Size = new Size(27, 15);
            LabelUrls.TabIndex = 7;
            LabelUrls.Text = "Urls";
            // 
            // ComboBoxType
            // 
            ComboBoxType.FormattingEnabled = true;
            ComboBoxType.Location = new Point(121, 58);
            ComboBoxType.Name = "ComboBoxType";
            ComboBoxType.Size = new Size(121, 23);
            ComboBoxType.TabIndex = 9;
            // 
            // ComboBoxLanguage
            // 
            ComboBoxLanguage.FormattingEnabled = true;
            ComboBoxLanguage.Location = new Point(121, 98);
            ComboBoxLanguage.Name = "ComboBoxLanguage";
            ComboBoxLanguage.Size = new Size(121, 23);
            ComboBoxLanguage.TabIndex = 10;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(121, 138);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 11;
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
            // TextBoxCode
            // 
            TextBoxCode.Location = new Point(121, 179);
            TextBoxCode.Name = "TextBoxCode";
            TextBoxCode.Size = new Size(581, 383);
            TextBoxCode.TabIndex = 13;
            TextBoxCode.Text = "";
            // 
            // CheckBoxExtendedDescription
            // 
            CheckBoxExtendedDescription.AutoSize = true;
            CheckBoxExtendedDescription.Location = new Point(12, 642);
            CheckBoxExtendedDescription.Name = "CheckBoxExtendedDescription";
            CheckBoxExtendedDescription.Size = new Size(137, 19);
            CheckBoxExtendedDescription.TabIndex = 14;
            CheckBoxExtendedDescription.Text = "Extended description";
            CheckBoxExtendedDescription.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(155, 590);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(373, 130);
            richTextBox1.TabIndex = 15;
            richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnValue });
            dataGridView1.Location = new Point(623, 590);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 17;
            // 
            // ColumnValue
            // 
            ColumnValue.HeaderText = "Value";
            ColumnValue.Name = "ColumnValue";
            // 
            // ButtonOk
            // 
            ButtonOk.Location = new Point(453, 782);
            ButtonOk.Name = "ButtonOk";
            ButtonOk.Size = new Size(75, 23);
            ButtonOk.TabIndex = 18;
            ButtonOk.Text = "OK";
            ButtonOk.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(577, 782);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 19;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // AddEditSnippetWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 819);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonOk);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(CheckBoxExtendedDescription);
            Controls.Add(TextBoxCode);
            Controls.Add(ButtonCalculateComplexity);
            Controls.Add(comboBox3);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private ComboBox comboBox3;
        private Button ButtonCalculateComplexity;
        private ToolTip MyToolTip;
        private RichTextBox TextBoxCode;
        private CheckBox CheckBoxExtendedDescription;
        private RichTextBox richTextBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnValue;
        private Button ButtonOk;
        private Button ButtonCancel;
    }
}