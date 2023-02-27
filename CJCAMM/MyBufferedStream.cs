using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CJC_Advanced_Midi_Merger
{
    public class MyBufferedStream
    {
        FileStream file;
        byte[] b1, b2;
        int ptr, buffsiz;
        Thread thread;

        public MyBufferedStream(FileStream file, int buffsiz)
        {
            this.file = file;
            this.buffsiz = buffsiz;
            b1 = new byte[buffsiz];
            b2 = new byte[buffsiz];
            ptr = 0;
        }

        void output()
        {
            file.Write(b2, 0, buffsiz);
        }

        public void WriteByte(byte b)
        {
            b1[ptr++] = b;
            if (ptr == buffsiz)
            {
                if (thread != null && thread.IsAlive) thread.Join();
                byte[] temp = b1; b1 = b2; b2 = temp;
                ptr = 0;
                thread = new Thread(output);
                thread.Start();
            }
        }

        public void Flush()
        {
            if (thread != null && thread.IsAlive) thread.Join();
            file.Write(b1, 0, ptr);
            ptr = 0;
        }
        
        void outputlarge(object param)
        {
            List<byte> par = (List<byte>)param;
            file.Write(par.ToArray(), 0, par.Count);
        }

        public void Write(List<byte> bytes)
        {
            if (bytes.Count > buffsiz)
            {
                Flush();
                thread = new Thread(outputlarge);
                thread.Start(bytes);
            }
            else
            {
                foreach (byte iter in bytes) WriteByte(iter);
            }
        }

        public void Seek(int pos, SeekOrigin org)
        {
            file.Seek(pos, org);
        }

        public void Close()
        {
            if (file != null)
            {
                Flush();
                file.Close();
                file = null;
            }
        }
    }

    public class MyBufferedReadStream
    {
        FileStream file;
        byte[] b1, b2;
        int ptr, buffsiz;
        Thread thread;

        void input()
        {
            file.Read(b2, 0, buffsiz);
        }

        public MyBufferedReadStream(FileStream file, int buffsiz)
        {
            this.file = file;
            this.buffsiz = buffsiz;
            b1 = new byte[buffsiz];
            b2 = new byte[buffsiz];
            ptr = 0;
            file.Read(b1, 0, buffsiz);
            thread = new Thread(input);
            thread.Start();
        }

        public byte ReadByte()
        {
            if (ptr < buffsiz - 1) return b1[ptr++];
            else
            {
                byte ret = b1[ptr];
                if (thread.IsAlive) thread.Join();
                byte[] temp = b1; b1 = b2; b2 = temp;
                ptr = 0;
                thread = new Thread(input);
                thread.Start();
                return ret;
            }
        }
        public void Close()
        {
            if (file != null)
            {
                file.Close();
                file = null;
            }
        }
    }
}
