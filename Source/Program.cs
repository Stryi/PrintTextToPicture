using PrintTextToPicture;
using PrintTextToPicture.Source;
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
    public static string SourceImageDirectory { get; set; }
    public static string DestinationImageDirectory { get; set; }

    public static bool Abort { get; set; }

    [STAThread]
    static void Main()
    {
        Configuration.ReadConfig();

        var mainForm = new MainForm();
        Application.Run(mainForm);


        //PictureMaker.overrideDestination = true;
        //PictureMaker.addText = true;
        //PictureMaker.resizeToFit = true;
        //PictureMaker.maxWidth  = 1920;
        //PictureMaker.maxHeight = 1080;
        //Program.SourceImageDirectory      = @"C:\Users\StryiC\Pictures\Bilderrahmen\Bilderrahmen 2022\2022.05.21 Südtirol\";
        //Program.DestinationImageDirectory = @"C:\Users\StryiC\Pictures\Bilderrahmen\Bilderrahmen 2022 FullHD\2022.05.21 Südtirol\";

        //// Startzeitpunkt merken
        //var startTime = DateTime.Now;

        //var program = new Program();
        //program.Execute();

        //// Dauer ausgeben
        //var endTime = DateTime.Now;
        //var duration = endTime - startTime;
        //Console.WriteLine("Dauer: " + duration.ToString());

        // --------------------------------------------------------------------------------
        // Test auf einer einzigen JPG Datei.
        // --------------------------------------------------------------------------------

        //var sourcePath      = @"C:\Users\StryiC\Pictures\Bilderrahmen\Original.jpg";
        //var destinationPath = @"C:\Users\StryiC\Pictures\Bilderrahmen\Convert.jpg";

        //var pictureMaker = new PictureMaker();
        //pictureMaker.addText = true;
        //pictureMaker.resizeToFit = true;
        //pictureMaker.overrideDestination = true;
        //pictureMaker.MakePicture(sourcePath, destinationPath, "Das ist ein Täscht.");
    }


    public override bool Execute()
    {
        this.count = 0;
        this.maxCount = this.GetPictureCount(Program.SourceImageDirectory);

        this.ProcessFolder(Program.SourceImageDirectory);

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

    internal void ProcessFolder(string sourceDir)
    {
        var folderName = sourceDir.Replace(Program.SourceImageDirectory, string.Empty);
        folderName = folderName.Trim('\\');

        var destinationFolderName = Path.Combine(Program.DestinationImageDirectory, folderName);
        if (!Directory.Exists(destinationFolderName))
        {
            Directory.CreateDirectory(destinationFolderName);
        }

        var sourceFileList = new List<string>(Directory.GetFiles(sourceDir, "*.jpg"));

        int fileCount = 0;

        folderName = folderName.Trim('\\');

        foreach (var sourcePicturePath in sourceFileList)
        {
            fileCount++;
            var fileCountText = string.Format("{0} von {1}", fileCount, sourceFileList.Count);
            var pictureText = folderName;

            string fileName = Path.GetFileName(sourcePicturePath);

            var destinationPicturePath = Path.Combine(Program.DestinationImageDirectory, destinationFolderName, fileName);
            if (string.IsNullOrEmpty(pictureText))
                pictureText = fileName;

            this.ReportProgress(string.Format("{0}\\ - Bild {1}", folderName, fileCountText));

            this.count++;

            PictureMaker.MakePicture(
                sourcePicturePath,
                destinationPicturePath,
                pictureText);

            if (Program.Abort)
            {
                return;
            }
        }

        var subfolderList = Directory.GetDirectories(sourceDir);

        foreach (var subfolder in subfolderList )
        {
            
            this.ProcessFolder(subfolder);

            if (Program.Abort)
            {
                return;
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

    internal static void ReducePictureSize(string picturePath, int maxWidth, int maxHeight)
    {
        bool resize = false;
        int newWidth;
        int newHeight;
        Bitmap originalImage;
        PixelFormat pixelFormat;

        originalImage = new Bitmap(picturePath);
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

                newImage.Save(picturePath, ImageFormat.Jpeg);
            }
        }
    }
}
