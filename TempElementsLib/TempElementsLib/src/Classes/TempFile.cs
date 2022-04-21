using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempElementsLib.Interfaces;
using TempElementsLib.src.Interfaces;

namespace TempElementsLib.src.Classes
{
    public class TempFile : ITempFile, IMovableElement
    {
        public readonly FileStream fileStream;

        public readonly FileInfo fileInfo;

        public string FilePath => fileInfo.FullName;

        public bool IsDestroyed { get; protected set; }


        public TempFile(string fileName)
        {
            IsDestroyed = false;

            fileInfo = new FileInfo(fileName);
            fileStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Console.WriteLine($"Created tmp file at {FilePath}");


        }


        ~TempFile() { Dispose(); }

        public TempFile() : this(Path.GetTempFileName()) { }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);

            IsDestroyed = true;

        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileStream?.Close();
            }

            fileInfo?.Delete();

        }

        public void AddText(string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fileStream.Write(info, 0, info.Length);
            fileStream.Flush();
        }
        public void MoveTo(string newPath)
        {
            this.fileStream.Close();
            this.fileInfo.MoveTo(newPath);
        }
    }
}

