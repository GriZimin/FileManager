using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FileManager
{
    public class FilesGetter
    {
        public FilesGetter()
        {

        }
        public List<DirectoryInfo> GetDirs(string path)
        {
            List<DirectoryInfo> res = new List<DirectoryInfo>();
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(path);                
                DirectoryInfo[] dirs = fileList.GetDirectories(); //get all directories

                for (int i = 0; i < dirs.Length; i++)
                {
                    res.Add(dirs[i]);
                }                
            }
            catch
            {

            }
            return res;
        }
        public List<FileInfo> GetFiles(string path)
        {
            List<FileInfo> res = new List<FileInfo>();
            try
            {
                DirectoryInfo fileList = new DirectoryInfo(path);
                FileInfo[] files = fileList.GetFiles(); //get all files                
                
                for (int i = 0; i < files.Length; i++)
                {
                    res.Add(files[i]);
                }
            }
            catch
            {

            }
            return res;
        }
    }    
}
