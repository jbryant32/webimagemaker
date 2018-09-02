using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WebImageSizing
{
    //handles io opertaions
    public class FileManager
    {
        private readonly string[] ImageTypes = new string[] { ".jpg", ".jpeg", ".bmp", ".png", ".gif" };

        //check if file types from user is acceptable
        public bool CheckFileTypeOk(string _path)
        {
            var FileType = Path.GetExtension(_path).ToLower();
            foreach (var ext in ImageTypes)
            {
                if (FileType == ext)
                    return true;
                else
                    return false;
            }
            return false;
        }
        //gets the files path and checks if the directorys is correct
        public bool CheckDirectoryExist(string _path) {
            var dir = Path.GetDirectoryName(_path);
            return  Directory.Exists(dir);
        }
        //this is the name that will be used to name the new files created 
        //removes blank spaces and checks if special characters are used
        public bool CheckNewFileName(string name)
        {
            name = name.Replace(" ", "");
            var match = Regex.Match(name, @"\p{P}");
            if (match.Success)
            {
                return false;
            }
            else
                return true;
        }
    }
}
