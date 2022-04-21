using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempElementsLib.src.Classes
{
    public class TempTxtFile : TempFile
    {

        public StreamReader TextReader { get; }
        public StreamWriter TextWriter { get; }


        public TempTxtFile() : this(Path.GetTempPath() + Guid.NewGuid() + ".txt")
        {

        }


        public TempTxtFile(string path) : base(path)
        {
            TextReader = new StreamReader(fileStream);
            TextWriter = new StreamWriter(fileStream);
        }

        ~TempTxtFile() { Dispose(false); }

        public string ReadLine() => TextReader.ReadLine();

        public string ReadAllText() => TextReader.ReadToEnd();

        public void Write(string value)
        {
            TextWriter.Write(value);
            Flush();
        }
        public void Write(char value)
        {
            TextWriter.Write(value);
            Flush();
        }

        public void WriteLine(string value)
        {
            TextWriter.WriteLine(value);
            Flush();
        }
        public void WriteLine(char value)
        {
            TextWriter.WriteLine(value);
            Flush();
        }

        private void Flush()
        {
            TextWriter.Flush();
        }
    }
}

