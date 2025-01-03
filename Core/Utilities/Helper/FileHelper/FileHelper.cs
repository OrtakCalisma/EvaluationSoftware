﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Core.Utilities.Helper.GuidHelper;

namespace Core.Utilities.Helper.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string rootDirectory)
        {
            throw new NotImplementedException();
        }

        public string Upload(IFormFile file, string rootDirectory)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(rootDirectory))
                {
                    Directory.CreateDirectory(rootDirectory);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelperClass.CreateGuid();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(rootDirectory + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
