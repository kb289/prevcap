using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using PrevCap.Model;

namespace PrevCap
{
    // TODO: ゲーム種別自動判別（不要？）
    public class GameDetecter
    {
        // 成功時は左上座標のPointを返す
        public Point? SearchBasePoint(GameType game)
        {
            int baseX = 0;
            int baseY = 0;
            int whiteCount = 0;
            int yClientStart = 0;
            int xClientStart = 0;
            int ySearchStart = 0;
            int xSearchStart = 0;
            bool searchPointFound = false;

            // スクリーンサイズは1920 x 1280で固定
            Bitmap bitmap = new Bitmap(1920, 1280);
            using (Graphics g = Graphics.FromImage(bitmap))
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(1920, 1280));
            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            for (int x = 0; x < 1920; x++)
            {
                for (int y = 0; y < 1280; y++)
                {
                    uint color = (uint)Marshal.ReadInt32(data.Scan0, x * 4 + y * 7680);
                    if (color == 0xffffffff)
                    {
                        if (whiteCount == 0)
                            yClientStart = y;
                        if (++whiteCount == 720)
                            break;
                    }
                    else
                    {
                        whiteCount = 0;
                    }
                }
                if (whiteCount == 720)
                {
                    xClientStart = x;
                    break;
                }
            }
            for (int y = yClientStart; y < 1280; y++)
            {
                for (int x = xClientStart; x < 1920; x++)
                {
                    uint color = (uint)Marshal.ReadInt32(data.Scan0, x * 4 + y * 7680);
                    if (color != 0xffffffff)
                    {
                        if (xSearchStart == 0)
                        {
                            xSearchStart = x;
                        }
                        else
                        {
                            if (x < xSearchStart)
                            {
                                xSearchStart = x;
                                ySearchStart = y;
                                searchPointFound = true;
                            }
                        }
                        break;
                    }
                }
                if (searchPointFound)
                    break;
            }

            // 所持ポイントを確認から右に190pxずらす
            xSearchStart += 190;

            for (int x = xSearchStart; x >= xClientStart; x--)
            {
                whiteCount = 0;
                for (int y = ySearchStart; y < ySearchStart + 10; y++)
                {
                    uint color = (uint)Marshal.ReadInt32(data.Scan0, x * 4 + y * 7680);
                    if (color == 0xffffffff)
                        whiteCount++;
                    else
                        break;
                }
                if (whiteCount == 10)
                {
                    baseX = x + 1;
                    break;
                }
            }
            for (int y = ySearchStart; y >= yClientStart; y--)
            {
                whiteCount = 0;
                for (int x = xSearchStart; x < xSearchStart + 10; x++)
                {
                    uint color = (uint)Marshal.ReadInt32(data.Scan0, x * 4 + y * 7680);
                    if (color == 0xffffffff)
                        whiteCount++;
                    else
                        break;
                }
                if (whiteCount == 10)
                {
                    baseY = y + 1;
                    break;
                }
            }

            // 4辺の外側1pxが白色なら成功
            bool success = false;
            if (baseX != 0 && baseY != 0)
            {
                uint leftCenterColor = (uint)Marshal.ReadInt32(data.Scan0, (baseX - 1) * 4 + (baseY + game.Size.Height / 2) * 7680);
                uint topCenterColor = (uint)Marshal.ReadInt32(data.Scan0, (baseX + game.Size.Width / 2) * 4 + (baseY - 1) * 7680);
                uint rightCenterColor = (uint)Marshal.ReadInt32(data.Scan0, (baseX + game.Size.Width + 1) * 4 + (baseY + game.Size.Height / 2) * 7680);
                uint bottomCenterColor = (uint)Marshal.ReadInt32(data.Scan0, (baseX + game.Size.Width / 2) * 4 + (baseY + game.Size.Height + 1) * 7680);
                if (leftCenterColor == 0xffffffff &&
                    topCenterColor == 0xffffffff &&
                    rightCenterColor == 0xffffffff &&
                    bottomCenterColor == 0xffffffff)
                {
                    game.Base = new Point(baseX, baseY);
                    success = true;
                }
            }

            bitmap.UnlockBits(data);
            bitmap.Dispose();

            return success ? new Point(baseX, baseY) : null as Point?;
        }
    }
}
