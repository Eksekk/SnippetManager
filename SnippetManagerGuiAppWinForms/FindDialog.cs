using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManagerGuiAppWinForms
{
    public record FindUserOptions(string Text, bool MatchCase, bool WholeWord, bool UseRegex);
    // a dialog, which will be used to find text in scintilla code view
    public partial class FindDialog : Form
    {
        public FindDialog()
        {
            InitializeComponent();
        }
    }
}
