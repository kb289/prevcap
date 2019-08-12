using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics;

using PrevCap.Model;
using PrevCap.Util;

namespace PrevCap
{
    public partial class MainForm : Form
    {
        GameType targetGame;
        GameWatcher watcher;
        CustomGame custom;

        public MainForm()
        {
            custom = CustomGame.Default;
            InitializeComponent();
        }

        private void loadCustomData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["customUseSize"] != null)
            {
                int width = int.Parse(config.AppSettings.Settings["customWidth"].Value);
                int height = int.Parse(config.AppSettings.Settings["customHeight"].Value);
                custom = new CustomGame(
                    config.AppSettings.Settings["customDisplayName"].Value,
                    config.AppSettings.Settings["customIdentifier"].Value,
                    new Size(width, height),
                    new Point(0, 0),
                    bool.Parse(config.AppSettings.Settings["customUseSize"].Value),
                    0,
                    bool.Parse(config.AppSettings.Settings["customUseClientArea"].Value)
                    );
            }
        }

        private void saveCustomData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            bool add = config.AppSettings.Settings["customUseSize"] == null;
            Dictionary<string, string> customDic = new Dictionary<string, string>()
            {
                { "customDisplayName", custom.DisplayName },
                { "customIdentifier", custom.Identifier },
                { "customWidth", custom.FixedSize.Width.ToString() },
                { "customHeight", custom.FixedSize.Height.ToString() },
                { "customUseSize", custom.UseSize.ToString() },
                { "customUseClientArea", custom.UseClientArea.ToString() },
            };
            foreach (KeyValuePair<string, string> kvp in customDic)
            {
                if (add)
                    config.AppSettings.Settings.Add(kvp.Key, kvp.Value);
                else
                    config.AppSettings.Settings[kvp.Key].Value = kvp.Value;
            }
            config.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            loadCustomData();
            updateTargetGame();
            updateWatchControl();
            int baseX = int.Parse(config.AppSettings.Settings["baseX"].Value);
            int baseY = int.Parse(config.AppSettings.Settings["baseY"].Value);
            targetGame.Base = new Point(baseX, baseY);
            updatedBasePosition();
            watcher.SaveDirectory = config.AppSettings.Settings["path"].Value;
            filePathText.Text = folderBrowserDialog1.SelectedPath = watcher.SaveDirectory;
            Left = int.Parse(config.AppSettings.Settings["x"].Value);
            Top = int.Parse(config.AppSettings.Settings["y"].Value);
        }

        private void getPositionButton_Click(object sender, EventArgs e)
        {
            Point? basePoint = new GameDetecter().SearchBasePoint(targetGame);
            if (!basePoint.HasValue)
            {
                MessageBox.Show("座標取得失敗", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            targetGame.Base = basePoint.Value;
            successGettingPositionMark.Visible = true;
            OnceTimer timer = new OnceTimer(1500, () => successGettingPositionMark.Visible = false);
            updatedBasePosition();
        }

        private void updatedBasePosition()
        {
            positionText.Text = string.Format("x={0}, y={1}", targetGame.Base.X, targetGame.Base.Y);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["baseX"].Value = targetGame.Base.X.ToString();
            config.AppSettings.Settings["baseY"].Value = targetGame.Base.Y.ToString();
            config.Save();
        }

        private void adjustBasePosition()
        {
            int overX = targetGame.Base.X + targetGame.Size.Width - watcher.Screen.Bounds.Width;
            if (overX > 0)
                targetGame.Base = new Point(Math.Max(0, targetGame.Base.X - overX), targetGame.Base.Y);
            int overY = targetGame.Base.Y + targetGame.Size.Height - watcher.Screen.Bounds.Height;
            if (overY > 0)
                targetGame.Base = new Point(targetGame.Base.X, Math.Max(0, targetGame.Base.Y - overY));
            if (overX > 0 || overY > 0)
                updatedBasePosition();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            PreviewForm previewForm = new PreviewForm();
            previewForm.Image = watcher.CaptureScreenBitmap();
            previewForm.BaseX = targetGame.Base.X;
            previewForm.BaseY = targetGame.Base.Y;
            previewForm.BaseW = targetGame.Size.Width;
            previewForm.BaseH = targetGame.Size.Height;
            previewForm.ShowDialog(this);
            targetGame.Base = new Point(previewForm.BaseX, previewForm.BaseY);
            updatedBasePosition();
            adjustBasePosition();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(watcher.SaveDirectory))
            {
                MessageBox.Show("保存先ディレクトリが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["path"].Value = watcher.SaveDirectory;
            config.Save();
            watcher.SaveBitmap();
        }

        private void updateWatchControl()
        {
            watchIntervalSpinner.Enabled = watchCheck.Checked;
            watchDurationSpinner.Enabled = watchCheck.Checked;
        }

        private void watchCheck_CheckedChanged(object sender, EventArgs e)
        {
            updateWatchControl();
            if (watchCheck.Checked)
                watcher.UpdateTimer((int)watchIntervalSpinner.Value, (int)watchDurationSpinner.Value);
            else
                watcher.DisposeTimer();
        }

        private void updateTargetGame()
        {
            Point? basePoint = targetGame?.Base;
            if (kancolleRadio.Checked)
            {
                targetGame = new Kancolle();
            }
            else if (shiroproRadio.Checked)
            {
                targetGame = new Shiropro();
            }
            else
            {
                targetGame = custom;
            }
            if (basePoint.HasValue)
                targetGame.Base = basePoint.Value;
            initWatcher();
            getPositionButton.Enabled = !customRadio.Checked;
            positionText.Enabled = !(customRadio.Checked && !custom.UseSize);
            customButton.Enabled = customRadio.Checked;
            adjustBasePosition();
        }

        private void initWatcher()
        {
            watcher = new GameWatcher();
            watcher.TargetGame = targetGame;
            watcher.SaveDirectory = filePathText.Text;
            watcher.Screen = Screen.PrimaryScreen;
        }

        private void target_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked)
                return;
            updateTargetGame();
        }

        private void showHistoryImageButton_Click(object sender, EventArgs e)
        {
            watcher.Watching = false;
            HistoryImageForm form = new HistoryImageForm(watcher);
            form.ShowDialog(this);
            watcher.Watching = true;
        }

        private void filePathText_TextChanged(object sender, EventArgs e)
        {
            watcher.SaveDirectory = filePathText.Text;
        }

        private void showFBDButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                watcher.SaveDirectory = filePathText.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["x"].Value = Left.ToString();
            config.AppSettings.Settings["y"].Value = Top.ToString();
            config.Save();
        }

        private void watchIntervalSpinner_ValueChanged(object sender, EventArgs e)
        {
            watcher.UpdateTimer((int)watchIntervalSpinner.Value, (int)watchDurationSpinner.Value);
        }

        private void watchDurationSpinner_ValueChanged(object sender, EventArgs e)
        {
            watcher.UpdateTimer((int)watchIntervalSpinner.Value, (int)watchDurationSpinner.Value);
        }

        private void customButton_Click(object sender, EventArgs e)
        {
            watcher.Watching = false;
            CustomGameForm form = new CustomGameForm(custom);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                custom = form.Custom;
                saveCustomData();
                updateTargetGame();
            }
            watcher.Watching = true;
        }

        private void openSaveDirButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(filePathText.Text))
                return;
            Process.Start(filePathText.Text);
        }
    }
}
