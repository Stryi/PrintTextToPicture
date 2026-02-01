using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace PrintTextToPicture.Source
{
    internal static class PictureMaker
    {
        public static bool addText;
        public static bool resizeToFit;
        public static int  maxWidth  = 1920;
        public static int  maxHeight = 1080;
        public static bool overrideDestination = true;
        public static int  pictureQuality = 75;

        internal static void MakePicture(string sourceImagePath, string destinationImagePath, string text)
        {
            if (!overrideDestination)
            {
                if (File.Exists(destinationImagePath))
                {
                    return;
                }
            }

            if ((!PictureMaker.resizeToFit) && (!PictureMaker.addText))
            {
                // Bild nur kopieren, keine Änderung
                File.Copy(sourceImagePath, destinationImagePath, PictureMaker.overrideDestination);
                return;
            }

            Bitmap originalImage = new Bitmap(sourceImagePath);
            Bitmap finalImage = originalImage;

            if (PictureMaker.resizeToFit)
            {
                finalImage = PictureMaker.ReducePictureSize(originalImage, PictureMaker.maxWidth, PictureMaker.maxHeight);
            }

            if ((PictureMaker.addText) && !string.IsNullOrWhiteSpace(text))
            {
                finalImage = PictureMaker.PrintTextToPicture(finalImage, text);
            }

            var jpegEncoder = GetJpegEncoder();

            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, PictureMaker.pictureQuality);


            finalImage.Save(destinationImagePath, jpegEncoder, encoderParams);
        }

        private static ImageCodecInfo GetJpegEncoder()
        {
            return ImageCodecInfo.GetImageEncoders()
                .First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
        }

        internal static Bitmap ReducePictureSize(Bitmap originalImage, int maxWidth, int maxHeight)
        {
            bool resize = false;

            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            var pixelFormat = originalImage.PixelFormat;

            if (originalImage.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)((float)originalImage.Height * ((float)newWidth / (float)originalImage.Width));
                resize = true;
            }

            if (originalImage.Height > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)((float)originalImage.Width * ((float)newHeight / (float)originalImage.Height));
                resize = true;
            }

            if (!resize)
            {
                return originalImage;
            }

            Bitmap newImage = new Bitmap(newWidth, newHeight, pixelFormat);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);

                foreach (var prop in originalImage.PropertyItems)
                {
                    bool setProp = false;
                    if (prop.Id == 0x9003) setProp = true; // DateTimeOriginal
                    if (prop.Id == 0x010F) setProp = true; // Make
                    if (prop.Id == 0x0110) setProp = true; // Model
                    if (prop.Id == 0x829D) setProp = true; // FNumber
                    if (prop.Id == 0x829A) setProp = true; // ExposureTime
                    if (prop.Id == 0x8827) setProp = true; // ISOSpeedRatings
                    if (prop.Id == 0x920A) setProp = true; // FocalLength
                    if (prop.Id == 0x9209) setProp = true; // Flash
                    if (prop.Id == 0x9207) setProp = true; // MeteringMode
                    if (prop.Id == 0xA405) setProp = true; // FocalLengthIn35mmFilm
                    if (prop.Id == 0x0112) setProp = true; // Orientation

                    if (!setProp) continue;

                    newImage.SetPropertyItem(prop);
                }

                originalImage.Dispose();
            }

            return newImage;
        }

        internal static Bitmap PrintTextToPicture(Bitmap originalImage, string pictureText)
        {
            var width  = originalImage.Width;
            var height = originalImage.Height;
            var pixelFormat = originalImage.PixelFormat;

            if (originalImage.PropertyIdList.Contains(0x0112))
            {
                var orientation = originalImage.GetPropertyItem(0x0112);
                if (orientation.Value[0] == 6)
                {
                    // 90 Grad drehen
                    originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    width = originalImage.Width;
                    height = originalImage.Height;
                }
                else if (orientation.Value[0] == 8)
                {
                    // -90 Grad drehen
                    originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    width = originalImage.Width;
                    height = originalImage.Height;
                }
            }

            Bitmap newImage = new Bitmap(width, height, pixelFormat);

            foreach (var prop in originalImage.PropertyItems)
            {
                bool setProp = false;
                if (prop.Id == 0x9003) setProp = true; // DateTimeOriginal
                if (prop.Id == 0x010F) setProp = true; // Make
                if (prop.Id == 0x0110) setProp = true; // Model
                if (prop.Id == 0x829D) setProp = true; // FNumber
                if (prop.Id == 0x829A) setProp = true; // ExposureTime
                if (prop.Id == 0x8827) setProp = true; // ISOSpeedRatings
                if (prop.Id == 0x920A) setProp = true; // FocalLength
                if (prop.Id == 0x9209) setProp = true; // Flash
                if (prop.Id == 0x9207) setProp = true; // MeteringMode
                if (prop.Id == 0xA405) setProp = true; // FocalLengthIn35mmFilm
                //if (prop.Id == 0x0112) setProp = true; // Orientation

                if (!setProp) continue;

                newImage.SetPropertyItem(prop);
            }

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(originalImage, 0, 0, width, height);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                var size = height / 40;

                using (Font font = new Font("Consolas", size, FontStyle.Regular, GraphicsUnit.Pixel))
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;

                    float x = size * 0.25f;
                    float y = height - (int)(size * 1.2);

                    // Schatten
                    g.DrawString(pictureText, font, Brushes.Black, x - 2, y - 2);
                    g.DrawString(pictureText, font, Brushes.Black, x - 2, y + 2);
                    g.DrawString(pictureText, font, Brushes.Black, x + 2, y - 2);
                    g.DrawString(pictureText, font, Brushes.Black, x + 2, y + 2);

                    // Text
                    g.DrawString(pictureText, font, Brushes.White, x, y);
                }

                originalImage.Dispose();

            }

            return newImage;
        }
    }
}
