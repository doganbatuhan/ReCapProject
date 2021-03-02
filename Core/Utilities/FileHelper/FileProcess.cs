using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileProcess
    {
        public static string Create(IFormFile file, string path)
        {
            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + Guid.NewGuid().ToString()
                        + Path.GetExtension(file.FileName)))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                        return fileStream.Name.ToString();
                    }
                }
                return "Failed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
