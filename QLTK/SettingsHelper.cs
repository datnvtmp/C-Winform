using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QLTK;

/// <summary>
/// Helper để tự động sync giữa AccountSettings và UI controls
/// Quy ước: Property name phải GIỐNG Control name
/// </summary>
public static class SettingsHelper
{
    // ─── Load Settings → UI ────────────────────────────────────────────────────
    /// <summary>
    /// Tự động load giá trị từ AccountSettings lên UI controls
    /// </summary>
    public static void LoadToUI(this AccountSettings settings, Form form)
    {
        if (settings == null || form == null) return;

        var properties = typeof(AccountSettings).GetProperties();

        foreach (var prop in properties)
        {
            var control = FindControl(form, prop.Name);
            if (control == null) continue;

            try
            {
                switch (control)
                {
                    case CheckBox cb:
                        if (prop.PropertyType == typeof(bool))
                            cb.Checked = (bool)prop.GetValue(settings);
                        break;

                    case TextBox tb:
                        tb.Text = prop.GetValue(settings)?.ToString() ?? "";
                        break;

                    case NumericUpDown nud:
                        if (prop.PropertyType == typeof(int))
                            nud.Value = Convert.ToDecimal(prop.GetValue(settings));
                        break;

                    case ComboBox cmb:
                        if (prop.PropertyType == typeof(int))
                            cmb.SelectedIndex = (int)prop.GetValue(settings);
                        break;
                }
            }
            catch { /* Skip if type mismatch */ }
        }
    }
    
    // ─── Save UI → Settings ────────────────────────────────────────────────────
    /// <summary>
    /// Tự động save giá trị từ UI controls vào AccountSettings
    /// </summary>
    public static void SaveFromUI(this AccountSettings settings, Form form)
    {
        if (settings == null || form == null) return;
        
        var properties = typeof(AccountSettings).GetProperties();
        
        foreach (var prop in properties)
        {
            if (!prop.CanWrite) continue;
            
            var control = FindControl(form, prop.Name);
            if (control == null) continue;
            
            try
            {
                switch (control)
                {
                    case CheckBox cb:
                        if (prop.PropertyType == typeof(bool))
                            prop.SetValue(settings, cb.Checked);
                        break;
                        
                    case TextBox tb:
                        if (prop.PropertyType == typeof(string))
                            prop.SetValue(settings, tb.Text);
                        break;
                        
                    case NumericUpDown nud:
                        if (prop.PropertyType == typeof(int))
                            prop.SetValue(settings, Convert.ToInt32(nud.Value));
                        break;
                        
                    case ComboBox cmb:
                        if (prop.PropertyType == typeof(int))
                            prop.SetValue(settings, cmb.SelectedIndex);
                        break;
                }
            }
            catch { /* Skip */ }
        }
    }
    
    // ─── Clone Settings ────────────────────────────────────────────────────────
    /// <summary>
    /// Tự động clone một AccountSettings object
    /// </summary>
    public static AccountSettings Clone(this AccountSettings source)
    {
        if (source == null) return new AccountSettings();
        
        var target = new AccountSettings();
        var properties = typeof(AccountSettings).GetProperties();
        
        foreach (var prop in properties.Where(p => p.CanRead && p.CanWrite))
        {
            try { prop.SetValue(target, prop.GetValue(source)); }
            catch { }
        }
        
        return target;
    }
    
    // ─── Helper: Tìm control đệ quy ────────────────────────────────────────────
    private static Control FindControl(Control parent, string name)
    {
        if (parent == null || string.IsNullOrEmpty(name)) return null;
        
        // Kiểm tra chính control này
        if (parent.Name == name) return parent;
        
        // Tìm trong các control con
        foreach (Control child in parent.Controls)
        {
            var found = FindControl(child, name);
            if (found != null) return found;
        }
        
        return null;
    }
}
