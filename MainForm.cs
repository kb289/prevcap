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

using PrevCap.model;
using PrevCap.util;

namespace PrevCap
{
    public partial class MainForm : Form
    {
        GameType targetGame;
        Watcher watcher;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            updateTargetGame();
            updateWatchControl();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
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
            GameDetecter detecter = new GameDetecter();
            if (!detecter.SearchBasePoint(targetGame))
            {
                MessageBox.Show("座標取得失敗", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void previewButton_Click(object sender, EventArgs e)
        {
            PreviewForm previewForm = new PreviewForm();
            previewForm.Image = watcher.CaptureScreenBitmap();
            previewForm.BaseX = targetGame.Base.X;
            previewForm.BaseY = targetGame.Base.Y;
            previewForm.BaseW = targetGame.Size.Width;
            previewForm.BaseH = targetGame.Size.Height;
            previewForm.ShowDialog();
            targetGame.Base = new Point(previewForm.BaseX, previewForm.BaseY);
            updatedBasePosition();
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
            if (kancolleRadio.Checked)
            {
                targetGame = new Kancolle();
            }
            else
            {
                targetGame = new Shiropro();
            }
            initWatcher();
        }

        private void initWatcher()
        {
            watcher = new Watcher();
            watcher.TargetGame = targetGame;
            watcher.SaveDirectory = filePathText.Text;
            watcher.Screen = Screen.PrimaryScreen;
        }

        private void target_CheckedChanged(object sender, EventArgs e)
        {
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
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
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
    }
}
