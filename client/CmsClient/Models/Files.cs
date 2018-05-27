using System;
using System.Collections.Generic;
using System.IO;

namespace CmsClient.Models
{
    public class MediaFile
    {
        public MediaFile(string name, string fullPath)
        {
            Name = name;
            FullPath = fullPath;
        }

        public string Name { get; }
        public string FullPath { get; }

        public override bool Equals(object obj)
        {
            var file = obj as MediaFile;
            return file != null &&
                   Name == file.Name &&
                   FullPath == file.FullPath;
        }

        public override int GetHashCode()
        {
            var hashCode = 193482316;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullPath);
            return hashCode;
        }

        public static MediaFile Create(string fullPath)
        {
            var name = Path.GetFileName(fullPath);
            return new MediaFile(name, fullPath);
        }
    }
}
