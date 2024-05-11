using SnippetManagerCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManagerGuiAppWinForms
{
    public partial class AddEditSnippetWindow : Form
    {
        private BindingSource BindingSourceSnippetComplexity;
        // setups combo box which displays enum values and names, so that it shows correct options
        private void InitComboBoxData<T>(ComboBox box) where T : Enum
        {
            box.DataSource = new BindingSource(EnumHelpers.GetValuesWithNames<T>(), null);
            box.DisplayMember = "Value";
            box.ValueMember = "Key";
        }

        // retrieves key-value pair from combo box's real data source (a dictionary), to make it possible to directly assign enum value to combo box
        private static KeyValuePair<T, string> FindEnumValuePairInComboBoxDictionary<T>(ComboBox box, T value) where T : Enum
        {
            var bs = box.DataSource as BindingSource;
            if (bs.DataSource is Dictionary<T, string> dict)
            {
                return dict.First(entry => Equals(entry.Key, value));
            }
            else
            {
                throw new InvalidOperationException("ComboBox data source is not a dictionary");
            }
        }
        public AddEditSnippetWindow()
        {
            InitializeComponent();
            InitComboBoxData<SnippetComplexity>(ComboBoxComplexity);
            ComboBoxComplexity.SelectedItem = SnippetLanguage.All;
            BindingSourceSnippetComplexity = ComboBoxComplexity.DataSource as BindingSource;
            InitComboBoxData<SnippetLanguage>(ComboBoxLanguage);
            ComboBoxLanguage.SelectedItem = SnippetType.Any;
            InitComboBoxData<SnippetType>(ComboBoxType);
            ComboBoxType.SelectedItem = SnippetComplexity.Any;

            // dynamically enable/disable "is runnable" checkbox depending on the language chosen
            ComboBoxLanguage.SelectedIndexChanged += (sender, e) =>
            {
                CheckBoxIsRunnable.Enabled = CodeSnippet.IsLanguageRunnable(ComboBoxSelectedItem<SnippetLanguage>(ComboBoxLanguage));
            };
            ButtonOk.Click += (sender, e) => this.DialogResult = DialogResult.OK;

            ButtonCancel.Click += (sender, e) => this.DialogResult = DialogResult.Cancel;
            ButtonCalculateComplexity.Click += (sender, e) => CalculateAndAssignComplexity();
            // commented out, because "X" already gives "cancelled" result, while closing via ok button still triggers that event and overwrites value of "ok"
            //this.FormClosed += (sender, e) => this.DialogResult = DialogResult.Cancel;

            CheckBoxIsRunnable.CheckedChanged += (sender, e) =>
            {
                var lang = ComboBoxSelectedItem<SnippetLanguage>(ComboBoxLanguage);
                if (CheckBoxIsRunnable.Checked && !CodeSnippet.IsLanguageRunnable(lang))
                {
                    MessageBox.Show($"The language {EnumHelpers.GetValueName(lang)} is never runnable, so you can't set this snippet as runnable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CheckBoxIsRunnable.Checked = false;
                }
            };

            CheckBoxExtendedDescription.CheckedChanged += (sender, e) => OnExtendedDescriptionCheck();

            ComboBoxLanguage.SelectedIndexChanged += (sender, e) =>
            {
                TextBoxCode.ChangeLanguage(ComboBoxSelectedItem<SnippetLanguage>(ComboBoxLanguage));
            };
        }

        public CodeSnippet? CodeSnippet { get; set; }

        // constructor used for editing existing snippet
        public AddEditSnippetWindow(CodeSnippet s) : this()
        {
            CodeSnippet = s;
        }

        public static void SelectComboBoxOption<T>(ComboBox box, T option) where T : Enum
        {
            box.SelectedItem = FindEnumValuePairInComboBoxDictionary(box, option);
        }

        private void UpdateControlsFromSnippet(CodeSnippet s)
        {
            // fill the form with the snippet data
            SelectComboBoxOption(ComboBoxLanguage, s.Lang);
            SelectComboBoxOption(ComboBoxComplexity, s.Complexity);
            SelectComboBoxOption(ComboBoxType, s.Types[0]);
            TextBoxCode.Text = s.Content;
            if (s.ExtendedDesc is not null)
            {
                CheckBoxExtendedDescription.Checked = true;
                TextBoxDescription.Text = s.ExtendedDesc.Value.Description;
                GridViewUrls.Rows.Clear();
                foreach (string url in s.ExtendedDesc.Value.Urls)
                {
                    GridViewUrls.Rows.Add(url);
                }
            }
            else
            {
                CheckBoxExtendedDescription.Checked = false;
                TextBoxDescription.Text = "";
                GridViewUrls.Rows.Clear();
            }
            OnExtendedDescriptionCheck(); // it's not called when property is changed in code???
            CheckBoxIsRunnable.Checked = s.IsRunnable;
        }

        private static T ComboBoxSelectedItem<T>(ComboBox box)
        {
            return ((KeyValuePair<T, string>)box.SelectedItem).Key;
        }

        private void UpdateSnippetFromControls()
        {
            // first validate is runnable checkbox, to prevent user from setting it to true for languages that are never runnable
            // this should be first check that runs, because I use message box, and not want for any changes to happen when this method wouldn't succeed anyways
            if (!CodeSnippet!.ValidateIsRunnableByLanguage())
            {
                MessageBox.Show($"The language {EnumHelpers.GetValueName(CodeSnippet.Lang)} is never runnable, so you can't set this snippet as runnable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CheckBoxIsRunnable.Checked = false;
                return;
            }

            // check for three enum values having value of "any" or "all", which is obviously invalid in most cases
            // TODO: just remove them from combo box somehow?
            if (ComboBoxSelectedItem<SnippetComplexity>(ComboBoxComplexity) == SnippetComplexity.Any)
            {
                MessageBox.Show("Snippet complexity of 'any' is invalid", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ComboBoxSelectedItem<SnippetType>(ComboBoxType) == SnippetType.Any)
            {
                MessageBox.Show("Snippet type of 'any' is invalid", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ComboBoxSelectedItem<SnippetLanguage>(ComboBoxLanguage) == SnippetLanguage.All)
            {
                MessageBox.Show("Snippet language of 'all' is invalid", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CodeSnippet.Lang = ComboBoxSelectedItem<SnippetLanguage>(ComboBoxLanguage);
            CodeSnippet.Complexity = ComboBoxSelectedItem<SnippetComplexity>(ComboBoxComplexity);
            CodeSnippet.Types = new() { ComboBoxSelectedItem<SnippetType>(ComboBoxType) };
            CodeSnippet.Content = TextBoxCode.Text;
            if (CheckBoxExtendedDescription.Checked)
            {
                CodeSnippet.ExtendedDesc = new()
                {
                    Description = TextBoxDescription.Text,
                    Urls = GridViewUrls.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[0].Value?.ToString()!).Where(s => !string.IsNullOrWhiteSpace(s)).ToList()
                };
            }
            else
            {
                CodeSnippet.ExtendedDesc = null;
            }
        }

        public DialogResult ShowEditDialog()
        {
            Debug.Assert(CodeSnippet is not null, "You need to provide snippet to edit when showing dialog in edit mode");
            // making a copy to restore later if user cancels the edit (need this, because I modify the passed snippet instantly when most controls' state is changed)
            // I believe this is called "memento pattern"
            CodeSnippet copied = CodeSnippet.Clone() as CodeSnippet;
            UpdateControlsFromSnippet(CodeSnippet);
            var r = base.ShowDialog();
            if (r == DialogResult.OK)
            {
                UpdateSnippetFromControls();
            }
            else
            {
                // restore old version of snippet
                CodeSnippet.AssignPropertiesOf(copied);
            }
            return r;
        }

        public DialogResult ShowAddDialog()
        {
            CodeSnippet = new();
            UpdateControlsFromSnippet(CodeSnippet);
            var r = base.ShowDialog();
            if (r == DialogResult.OK)
            {
                UpdateSnippetFromControls();
            }
            return r;
        }

        public void CalculateAndAssignComplexity()
        {
            CodeSnippet.Content = TextBoxCode.Text; // update this here, so that below method call uses the latest code
            CodeSnippet.Complexity = CodeSnippet.NaiveCalculateComplexity();
            SelectComboBoxOption(ComboBoxComplexity, CodeSnippet.Complexity);
        }

        public void OnExtendedDescriptionCheck()
        {
            var check = CheckBoxExtendedDescription.Checked;
            TextBoxDescription.Enabled = check;
            LabelUrls.Enabled = check;
            GridViewUrls.Enabled = check;
        }
    }
}
