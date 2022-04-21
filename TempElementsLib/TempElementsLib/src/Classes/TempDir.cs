using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempElementsLib.Interfaces;

namespace TempElementsLib.src.Classes
{
    public class TempDir : ITempDir
    {

        public readonly DirectoryInfo directoryInfo;
        public string DirPath => directoryInfo.FullName;

        public bool IsEmpty => directoryInfo.GetFiles().Length == 0;

        public bool IsDestroyed { get; protected set; }



        public TempDir() : this(Path.GetTempPath() + Guid.NewGuid().ToString())
        {

        }

        public TempDir(string dirName)
        {
            IsDestroyed = false;

            directoryInfo = new DirectoryInfo(dirName);
            directoryInfo.Create();

            Console.WriteLine($"Created tmp directory at {directoryInfo.FullName}");
        }

        public void Empty()
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
        }

        ~TempDir() { Dispose(); }


        public void Dispose()
        {


            directoryInfo?.Delete();

            GC.SuppressFinalize(this);

            IsDestroyed = true;

        }




    }
}

