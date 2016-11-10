using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesis_A.Clase
{
    class Number_To_Image
    {
        public Image DTI2(String currencyCode, Font font, Color textColor, Color backColor, Size minSize)
        {
            SizeF textSize;
            using (Image img = new Bitmap(1, 1))
            {
                using (Graphics drawing = Graphics.FromImage(img))
                {
                    textSize = drawing.MeasureString(currencyCode, font);
                    if (!minSize.IsEmpty)
                    {
                        textSize.Width = textSize.Width > minSize.Width ? textSize.Width : minSize.Width;
                        textSize.Height = textSize.Height > minSize.Height ? textSize.Height : minSize.Height;
                    }
                }
            }

            Image retImg = new Bitmap((int)textSize.Width, (int)textSize.Height);
            using (var drawing = Graphics.FromImage(retImg))
            {
                drawing.Clear(backColor);
            
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    var asd = currencyCode.Length;
                    PointF pf;
                    if (currencyCode.Length == 1)
                    {
                        pf = new PointF(((minSize.Width / 100) * 4), (minSize.Height - font.Size) / 4);

                    }
                    else
                    {
                        pf = new PointF(((minSize.Width / 100) * 8), (minSize.Height - font.Size) / 4);
                    }

                    drawing.DrawString(currencyCode, font, textBrush, pf);
                    drawing.Save();
                }
            }
            return retImg;
        }
    }
}
