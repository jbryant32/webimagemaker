using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebImageSizing
{
    public class AppRun
    {
        public static void RunWithoutWrapper()
        {
            FileManager fileManager = new FileManager();

            var path = string.Empty;
            var imageName = string.Empty;

            Console.WriteLine("Input File Image Path And Press Enter");
            //Check if directory exist and file type is ok
            do
            {
                path = Console.ReadLine();//wait for users to input file path 
                if (!fileManager.CheckFileTypeOk(path) || !fileManager.CheckDirectoryExist(path))
                {
                    if (!fileManager.CheckFileTypeOk(path))
                        Console.WriteLine("File Type  Invalid Please Try Another Type And Press Enter");
                    if (!fileManager.CheckDirectoryExist(path))
                        Console.WriteLine("File Path  Invalid Please Try Another Type And Press Enter");
                }
                else
                {
                    break;
                }
                Thread.Sleep(2000);

            } while (true);


            Console.WriteLine("Input Image New Name And Press Enter");
            //get image name and check if image name is ok
            do
            {
                imageName = Console.ReadLine();
                if (fileManager.CheckNewFileName(imageName))
                    break;
                else
                {
                    Console.WriteLine("Name Invalid Cannot Contain Special Characters ");
                    Thread.Sleep(500);
                    Console.WriteLine("Input Image New Name And Press Enter");
                    imageName = string.Empty;
                }


                Thread.Sleep(2000);

            } while (true);

            ImageResizer imageResizer = new ImageResizer(path, imageName);
            imageResizer.CreateImagesForWeb();

            Console.WriteLine("Images Created OK");
            Console.ReadLine();
        }
        public static void RunWithWrapper()
        {
            throw new NotImplementedException();
        }
    }
}
