using SnippetManagerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerGuiAppWinForms
{
    public static class GuiHelpers
    {
        // setups combo box which displays enum values and names, so that it shows correct options.
        public static void InitComboBoxData<T>(ComboBox box) where T : Enum
        {
            box.DataSource = new BindingSource(EnumHelpers.GetValuesWithNames<T>(), null);
            box.DisplayMember = "Value";
            box.ValueMember = "Key";
            box.SelectedIndex = 0;
        }

        // retrieves key-value pair from combo box's real data source (a dictionary), to make it possible to directly assign enum value to combo box. Only works if data source is dictionary<T, string>, assigned by for example InitComboBoxData<T>
        public static KeyValuePair<T, string> FindEnumValuePairInComboBoxDictionary<T>(ComboBox box, T value) where T : Enum
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
        // selects an enum option in given ComboBox. Only works if data source is dictionary<T, string>, assigned by for example InitComboBoxData<T>
        public static void SelectComboBoxOption<T>(ComboBox box, T option) where T : Enum
        {
            box.SelectedItem = FindEnumValuePairInComboBoxDictionary(box, option);
        }
    }
}
