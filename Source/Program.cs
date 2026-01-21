using PrintTextToPicture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using Tools;

internal class Program : ExecuteWorkerBase
{
    internal string PictureRootPath;
    internal bool   ProcessSubFolder;

    [STAThread]
    static void Main()
    {
        Configuration.ReadConfig();

        var mainForm = new MainForm();
        Application.Run(mainForm);

        //// Test auf einer einzigen JPG Datei.
        //var sourcePath      = @"C:\Users\StryiC\Pictures\Bilderrahmen\Original.jpg";
        //var destinationPath = @"C:\Users\StryiC\Pictures\Bilderrahmen\Convert.jpg";

        //File.Copy(sourcePath, destinationPath, true);

        ////AddTextToImage(destinationPath, "Das ist ein Test.");

        //ReducePictureSize (destinationPath, 1920, 1080);
        //PrintTextToPicture(destinationPath, "Das ist ein Test.");

    }


    public override bool Execute(string command)
    {
        var sourceDirList = Directory.GetDirectories(this.PictureRootPath);

        this.count = 0;
        this.maxCount = this.GetPictureCount(this.PictureRootPath);

        foreach (var sourceDir in sourceDirList)
        {
            this.ProcessFolder(sourceDir, command);
        }

        return true;
    }

    private int GetPictureCount(string pictureRootPath)
    {
        int count = 0;
        
        var sourceFileList = Directory.GetFiles(pictureRootPath, "*.jpg");
        count = sourceFileList.Length;

        var sourceDirList = Directory.GetDirectories(pictureRootPath);
        foreach (var sourceDir in sourceDirList)
        {
            count = count + this.GetPictureCount(sourceDir);
        }

        return count;
    }

    internal void ProcessFolder(string sourceDir, string command)
    {
        string pictureText = sourceDir.Replace(this.PictureRootPath, string.Empty);
        pictureText = pictureText.Trim('\\');

        var sourceFileList = new List<string>(Directory.GetFiles(sourceDir, "*.jpg"));

        int fileCount = 0;

        foreach (var sourcePicturePath in sourceFileList)
        {
            fileCount++;
            var fileCountText = string.Format("{0} von {1}", fileCount, sourceFileList.Count);

            string fileName = Path.GetFileName(sourcePicturePath);

            this.ReportProgress(string.Format("{0}\\{1} ({2})", pictureText , fileName, fileCountText));

            //Thread.Sleep(100);  
            
            this.count++;

            var pictureExists = File.Exists(sourcePicturePath);

            if (command == "MAKE")
            {
                PrintTextToPicture(sourcePicturePath, pictureText);
            }

            if (command == "COMPRESS")
            {
                // Full HD
                ReducePictureSize(sourcePicturePath, 1920, 1080);
            }

        }

        if (this.ProcessSubFolder)
        {
            var subfolderList = Directory.GetDirectories(sourceDir);

            foreach (var subfolder in subfolderList )
            {
            
                this.ProcessFolder(subfolder, command);
            }
        }
    }

    internal static void PrintTextToPicture(string picturePath, string pictureText)
    {
        Bitmap originalImage = new Bitmap(picturePath);
        var width       = originalImage.Width;
        var height      = originalImage.Height;
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

        using (Bitmap newImage = new Bitmap(width, height, pixelFormat))
        {
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
                    sf.Alignment     = StringAlignment.Near;
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

                newImage.Save(picturePath, ImageFormat.Jpeg);
            }
        }
    }

    internal static void AddTextToImage(string picturePath, string pictureText)
    {
        Bitmap imageNew;

        using (var fs = new FileStream(picturePath, FileMode.Open, FileAccess.Read))
        using (var originalImage = Image.FromStream(fs))
        using (var image = new Bitmap(originalImage))
        using (var graphics = Graphics.FromImage(image))
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            using (Font font = new Font("Consolas", 20, FontStyle.Regular))
            {
                float margin = 10f;

                SizeF textSize = graphics.MeasureString(pictureText, font);
                float x = margin;
                float y = image.Height - textSize.Height - margin;

                // Schatten
                graphics.DrawString(pictureText, font, Brushes.Black, x + 1, y + 1);
                graphics.DrawString(pictureText, font, Brushes.Black, x - 1, y - 1);

                // Text
                graphics.DrawString(pictureText, font, Brushes.White, x, y);
            }

            imageNew = image.Clone() as Bitmap;

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

                imageNew.SetPropertyItem(prop);
            }
        }


        imageNew.Save(picturePath, ImageFormat.Jpeg);
    }

    internal static void ReducePictureSize(string image, int maxWidth, int maxHeight)
    {
        bool resize = false;
        int newWidth;
        int newHeight;
        Bitmap originalImage;
        PixelFormat pixelFormat;

        try
        {
            originalImage = new Bitmap(image);
            newWidth    = originalImage.Width;
            newHeight   = originalImage.Height;
            pixelFormat = originalImage.PixelFormat;

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
                originalImage.Dispose();
                return;
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Fehler '{ex.Message}' beim Lesen des Bildes: {image}");
        }

        try
        {
            using (Bitmap newImage = new Bitmap(newWidth, newHeight, pixelFormat))
            {
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(originalImage, 0, 0, newWidth, newHeight);

                    foreach(var prop in originalImage.PropertyItems)
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

                    newImage.Save(image, ImageFormat.Jpeg);
                }
            }
        }
        catch (Exception ex)
        {
            originalImage.Dispose();
            Trace.WriteLine($"Fehler '{ex.Message}' beim Speichern des Bildes: {image}");
            //throw new Exception($"Fehler '{ex.Message}' beim Speichern des Bildes: {image}");
        }
    }
}
