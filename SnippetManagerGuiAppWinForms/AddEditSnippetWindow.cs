using SnippetManagerCore;
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
    public partial class AddEditSnippetWindow : Form
    {
        public AddEditSnippetWindow()
        {
            InitializeComponent();
        }

        public CodeSnippet? CodeSnippet { get; set; }
    }
}
