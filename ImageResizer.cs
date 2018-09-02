using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace WebImageSizing
{
    public class ImageResizer
    {
        private readonly double[] sizes = new double[] { 100, 300, 500, 750, 1000, 1500, 2500 };
        private string ImagePath { get; set; }
        private string ImageName { get; set; }
        public ImageResizer(string imagepath, string imagename)
        {
            this.ImagePath = imagepath;
            this.ImageName = imagename;
        }
        //maintains ratio creates images from 7 standard web sizes and saves
        public void CreateImagesForWeb()
        {
            foreach (var size in sizes)
            {
                using (Image<Rgba32> image = Image.Load(ImagePath))
                {

                    int Width = (int)(image.Width * (size / (float)image.Width));
                    int Height = (int)(image.Height * (size / (float)image.Width));

                    var filename = Path.GetFileName(ImagePath);
                    var extention = Path.GetExtension(filename);
                    var imagePath = ImagePath.Replace(filename, $"{ImageName}_W{Width}_H{Height}{extention}");

                    image.Mutate(x => x
                    .Resize(Width, Height)
                    );

                    image.Save(imagePath); // Automatic encoder selected based on extension.
                    Console.WriteLine($"File Saved As {Path.GetFileName(imagePath)}");


                }
                
            }
            using (var imageStream = new FileStream(ImagePath, FileMode.Open))
            {
                using (Image<Rgba32> image = Image.Load(imageStream))
                {

                }
            }
        }

    }
}
