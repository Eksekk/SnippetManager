using ScintillaNET;
using SnippetManagerCore;
using SnippetManagerCore.exceptions;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace SnippetManagerGuiAppWinForms
{

    public partial class MainWindow : Form
    {
        private SnippetList Snippets = new();
        readonly int COLUMN_INDEX_TYPES;
        readonly BindingSource BindingSourceSnippetList;
        private string LastSavedFilePath;

        private void InitializeMenu()
        {

            newToolStripMenuItem.Click += (sender, e) => AddSnippet();
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            loadToolStripMenuItem.Click += (sender, e) => LoadFromFile();
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.Click += (sender, e) => SaveToFile(false);
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveAsToolStripMenuItem.Click += (sender, e) => SaveToFile(true);
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.Shift | Keys.S;
            aboutToolStripMenuItem.Click += (sender, e) => About();
        }

        private void InitializeFilters()
        {
            InitializeComboBoxes();
            RadioButtonFilterHasExtendedDescriptionAny.CheckedChanged += (sender, e) => ApplyFilters();
            RadioButtonFilterHasExtendedDescriptionYes.CheckedChanged += (sender, e) => ApplyFilters();
            RadioButtonFilterHasExtendedDescriptionNo.CheckedChanged += (sender, e) => ApplyFilters();
            RadioButtonFilterIsRunnableAny.CheckedChanged += (sender, e) => ApplyFilters();
            RadioButtonFilterIsRunnableYes.CheckedChanged += (sender, e) => ApplyFilters();
            RadioButtonFilterIsRunnableNo.CheckedChanged += (sender, e) => ApplyFilters();

            TextboxFilterName.TextChanged += (sender, e) => ApplyFilters();

            ShowMoreFiltersCheckStateChanged();
            CheckboxFilterShowMore.CheckedChanged += (sender, e) => ShowMoreFiltersCheckStateChanged();
        }
        public MainWindow()
        {
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Csharp,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "Console.WriteLine(\"Hello, World!\");"
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Cpp,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "std::cout << \"Hello, World!\" << std::endl;"
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Python,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "print(\"Hello, World!\")"
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Java,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "System.out.println(\"Hello, World!\");",
                ExtendedDesc = new SnippetExtendedDescription()
                {
                    Description = "This is a simple snippet to print 'Hello, World!' to the console",
                    Urls = new() { "https://en.wikipedia.org/wiki/%22Hello,_World!%22_program" }
                }
            });
            Snippets.Add(new()
            {
                Name = "Hello World",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.Low,
                Types = new[] { SnippetType.Syntax }.ToList(),
                Content = "print(\"Hello, World!\")"
            });
            Snippets.Add(new()
            {
                Name = "Calculations",
                Lang = SnippetLanguage.Lua,
                Complexity = SnippetComplexity.MediumLow,
                Types = new[] { SnippetType.StandardLibrary }.ToList(),
                Content = @"-- calculate the area of a circle
local pi = math.pi
local radius = 12
local area = pi * radius * radius
print(string.format(""Area of a circle with radius %d is %.2f"", radius, area))
local t = setmetatable({}, {
    __index = function(tab)
        print(""Indexing a table"")
    end
})"
            });
            InitializeComponent();

            BindingSourceSnippetList = new() { DataSource = Snippets };
            DataViewSnippetList.AutoGenerateColumns = false; // by default all object properties are shown, and I want only some, so have to add columns manually
            DataViewSnippetList.DataSource = BindingSourceSnippetList;
            DataViewSnippetList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
            });
            DataViewSnippetList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Lang",
                HeaderText = "Language",
            });
            DataViewSnippetList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Complexity",
                HeaderText = "Complexity",
            });
            COLUMN_INDEX_TYPES = DataViewSnippetList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Types",
                HeaderText = "Type",
            });

            // setup handler to show collection's elements instead of "(Collection)" text
            DataViewSnippetList.CellFormatting += CellFormatting;

            // update snippet text before selecting another row in table
            DataViewSnippetList.RowLeave += (sender, e) => UpdateSnippetContentFromTextbox();

            // update code snippet in editor when new one is selected in table
            DataViewSnippetList.SelectionChanged += SnippetTableSelectionChanged;

            // allow user to sort by columns
            foreach (DataGridViewColumn col in DataViewSnippetList.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            InitializeMenu();


            ButtonClone.Click += (sender, e) => CloneSelectedSnippet();
            ButtonDelete.Click += (sender, e) => DeleteSelectedSnippet();
            ButtonInfo.Click += (sender, e) => ViewMoreInfo();

            ButtonAddSnippet.Click += (sender, e) => AddSnippet();
            ButtonEditSelectedSnippet.Click += (sender, e) => EditSnippet();

            InitializeFilters();


            this.KeyPreview = true;
            this.KeyDown += KeyPressed;
        }

        private void InitializeComboBoxes()
        {
            Dictionary<SnippetLanguage, string> langValues = EnumHelpers.GetValuesWithNames<SnippetLanguage>();
            ComboBoxFilterLanguage.DataSource = new BindingSource(langValues, null);
            ComboBoxFilterLanguage.DisplayMember = "Value";
            ComboBoxFilterLanguage.ValueMember = "Key";
            ComboBoxFilterLanguage.SelectedIndex = 0;

            Dictionary<SnippetType, string> typeValues = EnumHelpers.GetValuesWithNames<SnippetType>();
            ComboBoxFilterType.DataSource = new BindingSource(typeValues, null);
            ComboBoxFilterType.DisplayMember = "Value";
            ComboBoxFilterType.ValueMember = "Key";
            ComboBoxFilterType.SelectedIndex = 0;

            Dictionary<SnippetComplexity, string> complexityValues = EnumHelpers.GetValuesWithNames<SnippetComplexity>();
            ComboBoxFilterComplexity.DataSource = new BindingSource(complexityValues, null);
            ComboBoxFilterComplexity.DisplayMember = "Value";
            ComboBoxFilterComplexity.ValueMember = "Key";
            ComboBoxFilterComplexity.SelectedIndex = 0;

            ComboBoxFilterLanguage.SelectedIndexChanged += (sender, e) => ApplyFilters();
            ComboBoxFilterType.SelectedIndexChanged += (sender, e) => ApplyFilters();
            ComboBoxFilterComplexity.SelectedIndexChanged += (sender, e) => ApplyFilters();
        }

        private void ApplyFilters()
        {
            Func<RadioButton, RadioButton, ThreeValueEnum> ThreeRadioGroupToEnum = (yes, no) =>
            {
                if (yes.Checked)
                {
                    return ThreeValueEnum.Yes;
                }
                if (no.Checked)
                {
                    return ThreeValueEnum.No;
                }
                return ThreeValueEnum.Any;
            };
            // clear items
            var showSnippets = Snippets.FindSnippetsBy(new()
            {
                Name = TextboxFilterName.Text,
                Type = ((KeyValuePair<SnippetType, string>)ComboBoxFilterType.SelectedItem).Key,
                Lang = ((KeyValuePair<SnippetLanguage, string>)ComboBoxFilterLanguage.SelectedItem).Key,
                Complexity = ((KeyValuePair<SnippetComplexity, string>)ComboBoxFilterComplexity.SelectedItem).Key,
                IsRunnable = ThreeRadioGroupToEnum(RadioButtonFilterIsRunnableYes, RadioButtonFilterIsRunnableNo),
                HasExtendedDescription = ThreeRadioGroupToEnum(RadioButtonFilterHasExtendedDescriptionYes, RadioButtonFilterHasExtendedDescriptionNo)
            });
            HashSet<CodeSnippet> rowsToShow = new(showSnippets);

            // since selection will be changed, update current snippet before selecting another programmatically
            // (it doesn't send events?)
            UpdateSnippetContentFromTextbox();
            DataViewSnippetList.CurrentCell = null;
            foreach (DataGridViewRow row in DataViewSnippetList.Rows)
            {
                // note: when trying to hide currently selected row you'll encounter some cryptic InvalidOperationException about "currency manager", because it's not allowed to hide selected row
                if (row.Selected)
                {
                    row.Selected = false;
                }
                row.Visible = rowsToShow.Contains(row.DataBoundItem);
            }

            // select first visible row in control
            foreach (DataGridViewRow row in DataViewSnippetList.Rows)
            {
                if (row.Visible)
                {
                    row.Selected = true;
                    DataViewSnippetList.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        private void LoadFromFile()
        {
            // show dialog to select file, call required method, handle exceptions (showing message box), then update snippets list
            using (OpenFileDialog ofd = new()
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Select a file with snippets to load",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    int selectedIndex = DataViewSnippetList.SelectedRows.Count > 0 ? DataViewSnippetList.SelectedRows[0].Index : -1;
                    try
                    {
                        if (selectedIndex != -1)
                        {
                            DataViewSnippetList.Rows[selectedIndex].Selected = false;
                        }
                        Snippets.Clear();
                        Snippets.LoadFromFile(ofd.FileName);
                        BindingSourceSnippetList.ResetBindings(false);
                        ApplyFilters();
                    }
                    catch (SnippetLoadingException e)
                    {
                        if (selectedIndex != -1)
                        {
                            DataViewSnippetList.Rows[selectedIndex].Selected = true;
                        }
                        MessageBox.Show($"Error while loading snippets from file: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void About()
        {
            MessageBox.Show("Snippet Manager\n\nA simple application to manage code snippets\n\nAuthor: Jan Solich", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveToFile(bool saveAs)
        {
            if (saveAs || LastSavedFilePath == null)
            {
                using SaveFileDialog sfd = new()
                {
                    Title = "Save snippets to file",
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    CheckPathExists = true,
                    OverwritePrompt = true,

                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Snippets.SaveToFile(sfd.FileName);
                        LastSavedFilePath = sfd.FileName;
                    }
                    catch (SnippetSavingException e)
                    {
                        MessageBox.Show($"Error while saving snippets to file: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    Snippets.SaveToFile(LastSavedFilePath);
                }
                catch (SnippetSavingException e)
                {
                    MessageBox.Show($"Error while saving snippets to file: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CloneSelectedSnippet()
        {
            if (DataViewSnippetList.SelectedRows.Count > 0)
            {
                var snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
                DataViewSnippetList.SelectedRows[0].Selected = false;
                var clonedSnip = snip.Clone() as CodeSnippet;
                Snippets.Add(clonedSnip);
                BindingSourceSnippetList.ResetBindings(false); // this will update the control (DataGridView) with new data (cloned snippet)

                foreach (DataGridViewRow r in DataViewSnippetList.Rows)
                {
                    if (object.ReferenceEquals(r.DataBoundItem, clonedSnip))
                    {
                        r.Selected = true;
                        DataViewSnippetList.FirstDisplayedScrollingRowIndex = r.Index;
                        return;
                    }
                }
                Debug.Fail("No matching row found after cloning snippet and updating the control");
            }
        }

        private void DeleteSelectedSnippet()
        {
            if (DataViewSnippetList.SelectedRows.Count > 0)
            {
                var snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
                Snippets.Remove(snip);
                DataViewSnippetList.SelectedRows[0].Selected = false; // need to deselect manually to not cause exception when deleting last row
                BindingSourceSnippetList.ResetBindings(false);
            }
        }

        private void ViewMoreInfo()
        {
            if (DataViewSnippetList.SelectedRows.Count > 0)
            {
                var snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
                if (snip.ExtendedDesc is not null)
                {
                    string desc = snip.ExtendedDesc.Value.Description + (snip.ExtendedDesc.Value.Urls.Count > 0 ? "\n\nInformation URLs:\n" + string.Join("\n", snip.ExtendedDesc.Value.Urls) : "");
                    MessageBox.Show(desc, $"Extended Description of snippet '{snip.Name}'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == COLUMN_INDEX_TYPES)
            {
                e.Value = Tools.StringizeSingleParameter(e.Value);
                e.FormattingApplied = true;
            }
        }

        private void UpdateSnippetContentFromTextbox()
        {
            if (DataViewSnippetList.SelectedRows.Count == 0)
            {
                return;
            }
            CodeSnippet snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
            snip.Content = TextBoxCodeViewerEditor.Text;
        }

        private void SnippetTableSelectionChanged(object? sender, EventArgs e)
        {
            if (DataViewSnippetList.SelectedRows.Count == 0)
            {
                return;
            }
            CodeSnippet snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
            TextBoxCodeViewerEditor.ChangeLanguage(snip.Lang);
            TextBoxCodeViewerEditor.Text = snip.Content;
            //Clipboard.SetText(TextBoxCodeViewerEditor.DescribeKeywordSets());


            ButtonInfo.Enabled = snip.ExtendedDesc is not null;
        }

        private void ShowMoreFiltersCheckStateChanged()
        {
            bool show = CheckboxFilterShowMore.Checked;
            LabelFiltersHorizontalLine1.Visible = show;
            LabelFilterVerticalLine4.Visible = show;
            GroupBoxFilterHasExtendedDescription.Visible = show;
            GroupBoxFilterIsRunnable.Visible = show;
        }

        private void AddSnippet()
        {
            AddEditSnippetWindow w = new();
            var result = w.ShowAddDialog();
            if (result == DialogResult.OK)
            {
                Snippets.Add(w.CodeSnippet!);
                BindingSourceSnippetList.ResetBindings(false);
                // select newly added
                foreach (DataGridViewRow r in DataViewSnippetList.Rows)
                {
                    // this deselects any (should be at most one) currently selected row, then selects the newly added one if it's found
                    if (object.ReferenceEquals(r.DataBoundItem, w.CodeSnippet))
                    {
                        r.Selected = true;
                        DataViewSnippetList.FirstDisplayedScrollingRowIndex = r.Index;
                    }
                    else
                    {
                        r.Selected = false;
                    }
                }
            }
        }

        private void EditSnippet()
        {
            if (DataViewSnippetList.SelectedRows.Count == 0)
            {
                return;
            }
            CodeSnippet snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
            AddEditSnippetWindow w = new(snip);
            var result = w.ShowEditDialog();
            if (result == DialogResult.OK)
            {
                BindingSourceSnippetList.ResetBindings(false);
            }
        }

        private void KeyPressed(object? sender, KeyEventArgs e)
        {
            // we don't want to override default behavior of text box
            if (TextBoxCodeViewerEditor.Focused)
            {
                return;
            }

            // note: menu item keystrokes are handled in constructor, here we add only the ones that are not in menu

            if (e.Control && e.KeyCode == Keys.N)
            {
                AddSnippet();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                EditSnippet();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedSnippet();
                e.SuppressKeyPress = true;
            }
        }
    }
}
