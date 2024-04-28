using SnippetManagerCore;
using SnippetManagerCore.exceptions;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace SnippetManagerGuiAppWinForms
{
    public partial class MainWindow : Form
    {
        private Dictionary<int, SnippetLanguage> IndexToSnippetLanguageDict = new();
        private Dictionary<int, SnippetType> IndexToSnippetTypeDict = new();
        private Dictionary<int, SnippetComplexity> IndexToSnippetComplexityDict = new();
        private Dictionary<int, CodeSnippet> IndexDataViewRowToSnippet = new();
        private SnippetList Snippets = new();
        readonly int COLUMN_INDEX_TYPES;
        BindingSource BindingSourceSnippetList;
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
print(string.format(""Area of a circle with radius %d is %.2f"", radius, area))"
            });
            InitializeComponent();

            InitializeComboBoxes();
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
            DataViewSnippetList.CellFormatting += (sender, e) =>
            {
                if (e.ColumnIndex == COLUMN_INDEX_TYPES)
                {
                    e.Value = Tools.StringizeSingleParameter(e.Value);
                    e.FormattingApplied = true;
                }
            };

            // update snippet text before selecting another row in table
            DataViewSnippetList.RowLeave += (sender, e) =>
            {
                if (DataViewSnippetList.SelectedRows.Count == 0)
                {
                    return;
                }
                CodeSnippet snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
                snip.Content = TextBoxCodeViewerEditor.Text;
            };

            // update code snippet in editor when new one is selected in table
            DataViewSnippetList.SelectionChanged += (sender, e) =>
            {
                if (DataViewSnippetList.SelectedRows.Count == 0)
                {
                    return;
                }
                CodeSnippet snip = DataViewSnippetList.SelectedRows[0].DataBoundItem as CodeSnippet;
                TextBoxCodeViewerEditor.Text = snip.Content;
                ButtonInfo.Enabled = snip.ExtendedDesc is not null;
            };

            loadToolStripMenuItem.Click += (sender, e) => LoadFromFile();
            saveToolStripMenuItem.Click += (sender, e) => SaveToFile();
            aboutToolStripMenuItem.Click += (sender, e) => About();

            ButtonClone.Click += (sender, e) => CloneSelectedSnippet();
            ButtonDelete.Click += (sender, e) => DeleteSelectedSnippet();
            ButtonInfo.Click += (sender, e) => ViewMoreInfo();
        }

        private void InitializeComboBoxes()
        {
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("All"), SnippetLanguage.All);
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("C#"), SnippetLanguage.Csharp);
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("C++"), SnippetLanguage.Cpp);
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("Lua"), SnippetLanguage.Lua);
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("Python"), SnippetLanguage.Python);
            IndexToSnippetLanguageDict.Add(ComboBoxFilterLanguage.Items.Add("Java"), SnippetLanguage.Java);
            ComboBoxFilterLanguage.SelectedIndex = 0;

            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Any"), SnippetType.Any);
            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Syntax"), SnippetType.Syntax);
            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Standard Library"), SnippetType.StandardLibrary);
            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Language Feature"), SnippetType.LanguageFeature);
            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Algorithm"), SnippetType.Algorithm);
            IndexToSnippetTypeDict.Add(ComboBoxFilterType.Items.Add("Data Structure"), SnippetType.DataStructure);
            ComboBoxFilterType.SelectedIndex = 0;

            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("Any"), SnippetComplexity.Any);
            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("Low"), SnippetComplexity.Low);
            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("Medium Low"), SnippetComplexity.MediumLow);
            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("Medium"), SnippetComplexity.Medium);
            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("Medium High"), SnippetComplexity.MediumHigh);
            IndexToSnippetComplexityDict.Add(ComboBoxFilterComplexity.Items.Add("High"), SnippetComplexity.High);
            ComboBoxFilterComplexity.SelectedIndex = 0;

            ComboBoxFilterLanguage.SelectedIndexChanged += (sender, e) => ApplyFilters();
            ComboBoxFilterType.SelectedIndexChanged += (sender, e) => ApplyFilters();
            ComboBoxFilterComplexity.SelectedIndexChanged += (sender, e) => ApplyFilters();
        }

        private void ApplyFilters()
        {
            // clear items
            var showSnippets = Snippets.FindSnippetsBy(
                                              IndexToSnippetTypeDict[ComboBoxFilterType.SelectedIndex],
                               IndexToSnippetLanguageDict[ComboBoxFilterLanguage.SelectedIndex],
                                                             IndexToSnippetComplexityDict[ComboBoxFilterComplexity.SelectedIndex]
                                                                        );
            HashSet<CodeSnippet> rowsToShow = new(showSnippets);
            foreach (DataGridViewRow row in DataViewSnippetList.Rows)
            {
                // note: when trying to hide currently selected row you'll encounter some cryptic InvalidOperationException about "currency", because it's not allowed to hide selected row
                row.Visible = row.Selected || rowsToShow.Contains(row.DataBoundItem);
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
                        Snippets.LoadFromFile(ofd.FileName);
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

        private void SaveToFile()
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
                var clonedSnip = snip.Clone();
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
                    string desc = snip.ExtendedDesc.Value.Description + "\n\nInformation URLs:\n" + string.Join("\n", snip.ExtendedDesc.Value.Urls);
                    MessageBox.Show(desc, $"Extended Description of snippet '{snip.Name}'", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
