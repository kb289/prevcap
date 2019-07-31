using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using PrevCap.Model;

namespace PrevCap
{
    public partial class HistoryImageForm : Form
    {
        const int RowHeight = 160;

        private GameWatcher watcher;
        private List<HistoryImageItem> itemList;

        public HistoryImageForm(GameWatcher watcher)
        {;
            this.watcher = watcher;
            this.itemList = watcher.ImageList;
            InitializeComponent();
        }

        private void initWindowSize()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            Size s = watcher.TargetGame.Size;
            double wr = s.Width / (double)s.Height;
            double hr = s.Height / (double)s.Width;
            imageListGrid.Width = (int)(RowHeight * wr);
            ClientSize = new Size((int)((h + imageListGrid.Width * hr) * wr), h);
            Rectangle screenRect = Screen.FromControl(this).Bounds;
            Location = new Point(screenRect.Width / 2 - Size.Width / 2, screenRect.Height / 2 - Size.Height / 2);
        }

        private void initDataGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Image", typeof(byte[])));
            foreach (HistoryImageItem item in itemList)
            {
                DataRow dr = dt.NewRow();
                dr["Image"] = item.ImageBytes;
                dt.Rows.Add(dr);
            }
            imageListGrid.RowTemplate.Height = RowHeight;
            imageListGrid.DataSource = dt;
            imageListGrid.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            (imageListGrid.Columns["Image"] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
            selectRow(imageListGrid.Rows.Count - 1);
            updateRowSelected();
            imageListGrid.SelectionChanged += (s2, e2) =>
            {
                updateRowSelected();
            };
        }

        private void HistoryImageFrom_Load(object sender, EventArgs e)
        {
            initWindowSize();
            initDataGridView();
            if (itemList.Count == 0)
            {
                noImageLabel.Visible = true;
                saveButton.Visible = false;
                timestampLabel.Visible = false;
            }
        }

        private void selectRow(int index)
        {
            if (index == -1)
            {
                imageListGrid.ClearSelection();
            }
            else
            {
                imageListGrid.FirstDisplayedScrollingRowIndex = index;
                imageListGrid[0, index].Selected = true;
            }
        }

        private void updateRowSelected()
        {
            if (imageListGrid.SelectedRows.Count == 0)
            {
                selectedImage.Image = null;
                timestampLabel.Text = "";
                return;
            }
            int index = imageListGrid.SelectedRows[0].Index;
            using (MemoryStream ms = new MemoryStream(itemList[index].ImageBytes))
            {
                selectedImage.Image = new Bitmap(ms);
            }
            timestampLabel.Text = itemList[index].Timestamp.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void imageListGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int newIndex = -1;
            switch (e.KeyCode)
            {
                case Keys.Home:
                    newIndex = 0;
                    break;
                case Keys.End:
                    newIndex = imageListGrid.Rows.Count - 1;
                    break;
            }
            if (newIndex != -1)
            {
                selectRow(newIndex);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(watcher.SaveDirectory))
            {
                MessageBox.Show("保存先ディレクトリが存在しません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (imageListGrid.SelectedRows.Count == 0)
            {
                return;
            }
            int index = imageListGrid.SelectedRows[0].Index;
            watcher.SaveHistoryImage(index);
        }
    }
}
