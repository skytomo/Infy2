using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infy2
{
    class DrawLifeGame
    {
        Bitmap canvas;

        int cellsize = 10, gridsize = 1;
        float x = 0.0F, y = 0.0F, zoom = 1.0F;

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                if (zoom < 0.125F)
                {
                    zoom = 0.125F;
                }
                else if (zoom > 32.0F)
                {
                    zoom = 32.0F;
                }
                else
                {
                    zoom = value;
                }
            }
        }

        public Bitmap Draw(List<CellOfLifeGame> list, int width, int height)
        {
            if (width <= 0) width = 1;
            if (height <= 0) height = 1;
            //過去に使ったcanvasがあった場合は、ここで解放してから新しくnewする。
            if (canvas != null) canvas.Dispose();
            canvas = new Bitmap(width, height);
            Brush brush;
            brush = Brushes.Lime;
            Graphics g = Graphics.FromImage(canvas);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            foreach (var item in list)
            {
                if ((x <= ((item.X * (cellsize + gridsize)) + cellsize) * zoom) || ((item.X * (cellsize + gridsize) * zoom) <= x + width) || (y <= ((item.Y * (cellsize + gridsize)) + cellsize) * zoom) || ((item.Y * (cellsize + gridsize) * zoom) <= y + height))
                {
                    g.FillRectangle(brush, (cellsize + gridsize) * zoom * (item.X - x), (cellsize + gridsize) * zoom * (item.Y - y), cellsize * zoom, cellsize * zoom);
                }
            }
            g.Dispose();
            return canvas;
        }
    }
}