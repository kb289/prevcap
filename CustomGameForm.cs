using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using PrevCap.Model;

namespace PrevCap
{
    public partial class CustomGameForm : Form
    {
        public CustomGame Custom { get; private set; }

        public CustomGameForm(CustomGame custom)
        {
            this.Custom = custom;
            InitializeComponent();
        }

        private void initWindowCombo()
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (String.IsNullOrEmpty(p.MainWindowTitle) || p.MainWindowHandle.ToInt32() == 0 ||
                    p.Id == Process.GetCurrentProcess().Id)
                    continue;
                var item = new WindowListItem();
                item.Process = p;
                windowCombo.Items.Add(item);
            }
            if (windowCombo.Items.Count > 0)
            {
                windowCombo.SelectedIndex = 0;
                foreach (var item in windowCombo.Items)
                {
                    if ((item as WindowListItem).Process.Id == Custom.ProcessId)
                    {
                        windowCombo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void CustomGameForm_Load(object sender, EventArgs e)
        {
            initWindowCombo();
            identifierText.Text = Custom.Identifier;
            (Custom.UseSize ? sizeRadio : windowRadio).Checked = true;
            widthText.Text = Custom.FixedSize.Width.ToString();
            heightText.Text = Custom.FixedSize.Height.ToString();
            (Custom.UseClientArea ? clientAreaRadio : windowAreaRadio).Checked = true;
            updateTargetAreControl();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CustomGame orgCustom = Custom;
            int hwnd = windowRadio.Checked ? (windowCombo.SelectedItem as WindowListItem).Process.Id : 0;
            bool useSize = sizeRadio.Checked;
            Custom = new CustomGame(orgCustom.DisplayName, identifierText.Text, getSize(),
                orgCustom.Base, sizeRadio.Checked, hwnd, clientAreaRadio.Checked);
        }

        private Size getSize()
        {
            int width = 1, height = 1;
            int.TryParse(widthText.Text, out width);
            int.TryParse(heightText.Text, out height);
            Rectangle screenRect = Screen.PrimaryScreen.Bounds;
            return new Size(Math.Min(width, screenRect.Width), Math.Min(height, screenRect.Height));
        }

        private class WindowListItem
        {
            public Process Process { get; set; }
            public override string ToString()
            {
                return Process.MainWindowTitle;
            }
        }

        private void updateTargetAreControl()
        {
            widthText.Enabled = sizeRadio.Checked;
            heightText.Enabled = sizeRadio.Checked;
            windowCombo.Enabled = !sizeRadio.Checked;
            areaTypePanel.Enabled = !sizeRadio.Checked;
        }

        private void sizeRadio_CheckedChanged(object sender, EventArgs e)
        {
            updateTargetAreControl();
        }
    }
}
