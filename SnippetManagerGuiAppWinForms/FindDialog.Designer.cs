namespace SnippetManagerGuiAppWinForms
{
    partial class FindDialog
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
            LabelFindText = new Label();
            TextBoxFindText = new TextBox();
            CheckBoxMatchCase = new CheckBox();
            ButtonSearch = new Button();
            ButtonCancel = new Button();
            CheckBoxWholeWord = new CheckBox();
            CheckBoxUseRegex = new CheckBox();
            SuspendLayout();
            // 
            // LabelFindText
            // 
            LabelFindText.AutoSize = true;
            LabelFindText.Location = new Point(12, 20);
            LabelFindText.Name = "LabelFindText";
            LabelFindText.Size = new Size(56, 15);
            LabelFindText.TabIndex = 0;
            LabelFindText.Text = "Find text:";
            // 
            // TextBoxFindText
            // 
            TextBoxFindText.Location = new Point(74, 17);
            TextBoxFindText.Name = "TextBoxFindText";
            TextBoxFindText.Size = new Size(231, 23);
            TextBoxFindText.TabIndex = 1;
            // 
            // CheckBoxMatchCase
            // 
            CheckBoxMatchCase.AutoSize = true;
            CheckBoxMatchCase.Location = new Point(12, 63);
            CheckBoxMatchCase.Name = "CheckBoxMatchCase";
            CheckBoxMatchCase.Size = new Size(86, 19);
            CheckBoxMatchCase.TabIndex = 2;
            CheckBoxMatchCase.Text = "Match case";
            CheckBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // ButtonSearch
            // 
            ButtonSearch.Location = new Point(74, 177);
            ButtonSearch.Name = "ButtonSearch";
            ButtonSearch.Size = new Size(75, 23);
            ButtonSearch.TabIndex = 3;
            ButtonSearch.Text = "Search";
            ButtonSearch.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(188, 177);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 4;
            ButtonCancel.Text = "Cancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // CheckBoxWholeWord
            // 
            CheckBoxWholeWord.AutoSize = true;
            CheckBoxWholeWord.Location = new Point(12, 99);
            CheckBoxWholeWord.Name = "CheckBoxWholeWord";
            CheckBoxWholeWord.Size = new Size(90, 19);
            CheckBoxWholeWord.TabIndex = 5;
            CheckBoxWholeWord.Text = "Whole word";
            CheckBoxWholeWord.UseVisualStyleBackColor = true;
            // 
            // CheckBoxUseRegex
            // 
            CheckBoxUseRegex.AutoSize = true;
            CheckBoxUseRegex.Location = new Point(12, 136);
            CheckBoxUseRegex.Name = "CheckBoxUseRegex";
            CheckBoxUseRegex.Size = new Size(77, 19);
            CheckBoxUseRegex.TabIndex = 6;
            CheckBoxUseRegex.Text = "Use regex";
            CheckBoxUseRegex.UseVisualStyleBackColor = true;
            // 
            // FindDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 212);
            Controls.Add(CheckBoxUseRegex);
            Controls.Add(CheckBoxWholeWord);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonSearch);
            Controls.Add(CheckBoxMatchCase);
            Controls.Add(TextBoxFindText);
            Controls.Add(LabelFindText);
            Name = "FindDialog";
            Text = "FindDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelFindText;
        private TextBox TextBoxFindText;
        private CheckBox CheckBoxMatchCase;
        private Button ButtonSearch;
        private Button ButtonCancel;
        private CheckBox CheckBoxWholeWord;
        private CheckBox CheckBoxUseRegex;
    }
}