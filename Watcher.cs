using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using PrevCap.model;

namespace PrevCap
{
    // TODO: [何分前まで/何枚まで]を切り替えられるようにする
    // TODO: マルチディスプレイ対応
    public class Watcher
    {
        public bool Watching { get; set; }
        public List<HistoryImageItem> ImageList { get { return imageQueue.ToList(); } }
        public String SaveDirectory { get; set; }
        public GameType TargetGame { get; set; }
        public Screen Screen { get; set; }

        Timer watchTimer;
        Queue<HistoryImageItem> imageQueue = new Queue<HistoryImageItem>();

        public Watcher()
        {
            this.Watching = true;
        }

        public Bitmap CaptureScreenBitmap()
        {
            Bitmap bitmap = new Bitmap(Screen.Bounds.Width, Screen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bitmap.Size);
            return bitmap;
        }

        public Bitmap CaptureBitmap()
        {
            Bitmap bitmap = new Bitmap(TargetGame.Size.Width, TargetGame.Size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
                g.CopyFromScreen(new Point(TargetGame.Base.X, TargetGame.Base.Y), new Point(0, 0), bitmap.Size);
            return bitmap;
        }

        public void SaveHistoryImage(int index)
        {
            if (index < 0 || imageQueue.Count <= index)
                return;
            using (MemoryStream ms = new MemoryStream(ImageList[index].ImageBytes))
            {
                save(new Bitmap(ms));
            }
        }

        public void SaveBitmap()
        {
            save(CaptureBitmap());
        }

        private void save(Bitmap bmp)
        {
            using (bmp)
            {
                // TODO: 画像種別選択
                bmp.Save(string.Format(@"{0}\{1}_{2}.png", SaveDirectory, TargetGame.Identifier,
                    DateTime.Now.ToString("yyMMdd_HHmmss_fff")), ImageFormat.Png);
            }
        }

        private void reduceImageBuffer(int duration)
        {
            DateTime now = DateTime.Now;
            while (imageQueue.Count > 0)
            {
                HistoryImageItem item = imageQueue.Peek();
                if ((now - item.Timestamp).TotalSeconds > duration)
                    imageQueue.Dequeue();
                else
                    break;
            }
        }

        public void UpdateTimer(int intervalSec, int durationMin)
        {
            DisposeTimer();
            watchTimer = new Timer();
            watchTimer.Interval = intervalSec * 1000;
            watchTimer.Tick += (s, e) =>
            {
                if (!Watching)
                    return;
                reduceImageBuffer(durationMin * 60);
                HistoryImageItem item = new HistoryImageItem();
                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = CaptureBitmap())
                    {
                        bmp.Save(ms, ImageFormat.Png);
                        item.ImageBytes = ms.GetBuffer();
                    }
                }
                item.Timestamp = DateTime.Now;
                imageQueue.Enqueue(item);
            };
            watchTimer.Start();
        }

        public void DisposeTimer()
        {
            if (watchTimer != null)
            {
                watchTimer.Stop();
                watchTimer.Dispose();
                watchTimer = null;
            }
        }
    }
}
