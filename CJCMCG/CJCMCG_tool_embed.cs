using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CJCMCG
{

    partial class MainWindow
    {
        private void ToolProcess()
        {
            try
            {
                if (!fileselected)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        filename.IsEnabled = true;
                        prog.IsEnabled = true;
                        Piliang.IsEnabled = true;
                        canc.IsEnabled = false;
                        width.IsEnabled = true;
                        height.IsEnabled = true;
                        fps.IsEnabled = true;
                        pres.IsEnabled = true;
                        des.IsEnabled = true;
                        is_preprocess.IsEnabled = true;
                    }));
                    return;
                }
                string fileout = "";
                SaveFileDialog getFileout = new SaveFileDialog
                {
                    Filter = "CJCMCG Preprocessed files (*.cjcmcg)|*.cjcmcg"
                };
                if (getFileout.ShowDialog() == true)
                {
                    fileout = getFileout.FileName;
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        preview.Text = "";
                        filename.IsEnabled = true;
                        prog.IsEnabled = true;
                        Piliang.IsEnabled = true;
                        canc.IsEnabled = false;
                        width.IsEnabled = true;
                        height.IsEnabled = true;
                        fps.IsEnabled = true;
                        pres.IsEnabled = true;
                        des.IsEnabled = true;
                        is_preprocess.IsEnabled = true;
                    }));
                    return;
                }
                Stream inppp = File.Open(filein, FileMode.Open, FileAccess.Read, FileShare.Read);
                while (!filein.EndsWith(".mid"))
                {
                    if (filein.EndsWith(".xz"))
                    {
                        inppp = AddXZLayer(inppp);
                        filein = filein.Substring(0, filein.Length - 3);
                    }
                    else if (filein.EndsWith(".zip"))
                    {
                        inppp = AddZipLayer(inppp);
                    }
                    else if (filein.EndsWith(".rar"))
                    {
                        inppp = AddRarLayer(inppp);
                    }
                    else if (filein.EndsWith(".7z"))
                    {
                        inppp = Add7zLayer(inppp);
                    }
                    else if (filein.EndsWith(".tar"))
                    {
                        inppp = AddTarLayer(inppp);
                    }
                    else if (filein.EndsWith(".gz"))
                    {
                        inppp = AddGZLayer(inppp);
                    }
                    else if (filein.EndsWith(".bz2"))
                    {
                        inppp = AddBZ2Layer(inppp);
                    }
                }
                BufferedStream inpp = new BufferedStream(inppp, 16777216);
                int ReadByte()
                {
                    int b = inpp.ReadByte();
                    if (b == -1)
                    {
                        throw new Exception("Unexpected file end");
                    }

                    return b;
                }
                ArrayList nts = new ArrayList(), nto = new ArrayList();
                ArrayList lrcs = new ArrayList();
                ArrayList bpm = new ArrayList();
                long noteall = 0;
                int alltic = 0;
                for (int i = 0; i < 4; ++i)
                {
                    ReadByte();
                }
                for (int i = 0; i < 4; ++i)
                {
                    ReadByte();
                }
                ReadByte();
                ReadByte();
                int trkcnt;
                trkcnt = (toint(ReadByte()) * 256) + toint(ReadByte());
                resol = (toint(ReadByte()) * 256) + toint(ReadByte());
                bpm.Add(new pairli(0, 5000000000.0 / resol, -1, 0));
                int nowtrk = 1;
                int allticreal = 0;
                lrcs.Add(new pairls(0, "", -1, -1));
                for (int trk = 0; trk < trkcnt; trk++)
                {
                    int bpmcnt = 0;
                    int lrccnt = 0;
                    long notes = 0;
                    long leng = 0;
                    ReadByte();
                    ReadByte();
                    ReadByte();
                    ReadByte();
                    for (int i = 0; i < 4; i++)
                    {
                        leng = leng * 256 + toint(ReadByte());
                    }
                    int lstcmd = 256;
                    Dispatcher.Invoke(new Action(() =>
                    {
                        string str = prog.Uid;
                        str = str.Replace("{trackcount}", (trk + 1).ToString() + "/" + trkcnt.ToString()).Replace("{tracksize}", leng.ToString("N0"));
                        prog.Content = str;
                    }));
                    int getnum()
                    {
                        int ans = 0;
                        int ch = 256;
                        while (ch >= 128)
                        {
                            ch = toint(ReadByte());
                            leng--;
                            ans = ans * 128 + (ch & 0b01111111);
                        }
                        return ans;
                    }
                    int get()
                    {
                        if (lstcmd != 256)
                        {
                            int lstcmd2 = lstcmd;
                            lstcmd = 256;
                            return lstcmd2;
                        }
                        leng--;
                        return toint(ReadByte());
                    }
                    int TM = 0;
                    int prvcmd = 256;
                    while (true)
                    {
                        int added = getnum();
                        TM += added;
                        int cmd = ReadByte();
                        leng--;
                        if (cmd < 128)
                        {
                            lstcmd = cmd;
                            cmd = prvcmd;
                        }
                        prvcmd = cmd;
                        int cm = cmd & 0b11110000;
                        if (cm == 0b10010000)
                        {
                            get();
                            ReadByte();
                            leng--;
                            while (nts.Count <= TM)
                            {
                                nts.Add(0L);
                            }
                            while (nto.Count <= TM)
                            {
                                nto.Add(0L);
                            }
                            nts[TM] = (Convert.ToInt64(nts[TM]) + 1L);
                            notes++;
                        }
                        else if (cm == 0b10000000)
                        {
                            get();
                            ReadByte();
                            leng--;
                            while (nts.Count <= TM)
                            {
                                nts.Add(0L);
                            }
                            while (nto.Count <= TM)
                            {
                                nto.Add(0L);
                            }
                            nto[TM] = (Convert.ToInt64(nto[TM]) + 1L);
                        }
                        else if (cm == 0b11000000 || cm == 0b11010000 || cmd == 0b11110011)
                        {
                            get();
                        }
                        else if (cm == 0b11100000 || cm == 0b10110000 || cmd == 0b11110010 || cm == 0b10100000)
                        {
                            get();
                            ReadByte();
                            leng--;
                        }
                        else if (cmd == 0b11110000)
                        {
                            if (get() == 0b11110111)
                            {
                                continue;
                            }
                            do
                            {
                                leng--;
                            } while (ReadByte() != 0b11110111);
                        }
                        else if (cmd == 0b11110100 || cmd == 0b11110001 || cmd == 0b11110101 || cmd == 0b11111001 || cmd == 0b11111101 || cmd == 0b11110110 || cmd == 0b11110111 || cmd == 0b11111000 || cmd == 0b11111010 || cmd == 0b11111100 || cmd == 0b11111110)
                        {
                        }
                        else if (cmd == 0b11111111)
                        {
                            cmd = get();
                            if (cmd == 0)
                            {
                                ReadByte(); ReadByte(); ReadByte();
                                leng -= 3;
                            }
                            else if (cmd >= 1 && cmd <= 10 && cmd != 5 || cmd == 0x7f)
                            {
                                long ff = getnum();
                                while (ff-- > 0)
                                {
                                    ReadByte();
                                    leng--;
                                }
                            }
                            else if (cmd == 0x20 || cmd == 0x21)
                            {
                                ReadByte(); ReadByte(); leng -= 2;
                            }
                            else if (cmd == 0x2f)
                            {
                                ReadByte();
                                leng--;
                                if (TM > allticreal)
                                {
                                    allticreal = TM;
                                }
                                TM -= added;
                                break;
                            }
                            else if (cmd == 0x51)
                            {
                                bpmcnt++;
                                ReadByte();
                                leng--;
                                int BPM = get();
                                BPM = BPM * 256 + get();
                                BPM = BPM * 256 + get();
                                bpm.Add(new pairli(TM, BPM, trk, bpmcnt));
                            }
                            else if (cmd == 5)
                            {
                                Encoding gb2312 = Encoding.GetEncoding("GBK");
                                Encoding def = Encoding.GetEncoding("UTF-8");
                                lrccnt++;
                                int ff = getnum();
                                byte[] S = new byte[ff];
                                int cnt = 0;
                                while (ff-- > 0)
                                {
                                    S[cnt++] = Convert.ToByte(ReadByte());
                                    leng--;
                                }
                                S = Encoding.Convert(gb2312, def, S);
                                lrcs.Add(new pairls(TM, def.GetString(S), trk, lrccnt));
                            }
                            else if (cmd == 0x54 || cmd == 0x58)
                            {
                                ReadByte(); ReadByte(); ReadByte(); ReadByte(); ReadByte();
                                leng -= 5;
                            }
                            else if (cmd == 0x59)
                            {
                                ReadByte(); ReadByte(); ReadByte();
                                leng -= 3;
                            }
                            else if (cmd == 0x0a)
                            {
                                int ss = get();
                                while (ss-- > 0)
                                {
                                    ReadByte();
                                    leng--;
                                }
                            }
                        }
                    }
                    while (leng > 0)
                    {
                        ReadByte();
                        leng--;
                    }
                    noteall += notes;
                    nowtrk++;
                }
                Dispatcher.Invoke(new Action(() =>
                {
                    prog.SetResourceReference(ContentProperty, "m.ReadFinished");
                    string str = (string)prog.Content;
                    str = str.Replace("{notecnt}", noteall.ToString("N0"));
                    prog.Content = str;
                }));
                alltic = nto.Count;
                bpm.Sort(new AhhShitPairliCompare());
                lrcs.Sort(new AhhShitPairlsCompare());
                BufferedStream outs = new BufferedStream(File.Open(fileout, FileMode.Create, FileAccess.Write, FileShare.Write), 16777216);
                outs.WriteByte((byte)(resol / 256 / 256 / 256));
                outs.WriteByte((byte)(resol / 256 / 256 % 256));
                outs.WriteByte((byte)(resol / 256 % 256));
                outs.WriteByte((byte)(resol % 256));
                int bpms = bpm.Count;
                outs.WriteByte((byte)(bpms / 256 / 256 / 256));
                outs.WriteByte((byte)(bpms / 256 / 256 % 256));
                outs.WriteByte((byte)(bpms / 256 % 256));
                outs.WriteByte((byte)(bpms % 256));
                for (int i = 0; i < bpms; i++)
                {
                    pairli pr = (pairli)bpm[i];
                    outs.WriteByte((byte)(pr.x / 256 / 256 / 256));
                    outs.WriteByte((byte)(pr.x / 256 / 256 % 256));
                    outs.WriteByte((byte)(pr.x / 256 % 256));
                    outs.WriteByte((byte)(pr.x % 256));
                    outs.WriteByte((byte)(pr.y / 256 / 256 % 256));
                    outs.WriteByte((byte)(pr.y / 256 % 256));
                    outs.WriteByte((byte)(pr.y % 256));
                }
                int lrcc = lrcs.Count;
                outs.WriteByte((byte)(lrcc / 256 / 256 / 256));
                outs.WriteByte((byte)(lrcc / 256 / 256 % 256));
                outs.WriteByte((byte)(lrcc / 256 % 256));
                outs.WriteByte((byte)(lrcc % 256));
                for (int i = 0; i < lrcc; i++)
                {
                    pairls pr = (pairls)lrcs[i];
                    outs.WriteByte((byte)(pr.x / 256 / 256 / 256));
                    outs.WriteByte((byte)(pr.x / 256 / 256 % 256));
                    outs.WriteByte((byte)(pr.x / 256 % 256));
                    outs.WriteByte((byte)(pr.x % 256));
                    byte[] byteArray = Encoding.UTF8.GetBytes(pr.y);
                    int ys = byteArray.Length;
                    outs.WriteByte((byte)(ys / 256 / 256 / 256));
                    outs.WriteByte((byte)(ys / 256 / 256 % 256));
                    outs.WriteByte((byte)(ys / 256 % 256));
                    outs.WriteByte((byte)(ys % 256));
                    outs.Write(byteArray, 0, ys);
                }
                long xi = noteall;
                List<byte> list = new List<byte>();
                bool started = false;
                if (xi == 0)
                {
                    list.Add(0);
                }

                while (xi > 0)
                {
                    byte nx = (byte)(xi % 128);
                    xi /= 128;
                    if (started)
                    {
                        nx += 128;
                    }

                    started = true;
                    list.Add(nx);
                }
                list.Reverse();
                for (int j = 0; j < list.Count; j++)
                {
                    outs.WriteByte(list[j]);
                }
                int mids = nts.Count;
                outs.WriteByte((byte)(mids / 256 / 256 / 256));
                outs.WriteByte((byte)(mids / 256 / 256 % 256));
                outs.WriteByte((byte)(mids / 256 % 256));
                outs.WriteByte((byte)(mids % 256));
                for (int i = 0; i < mids; i++)
                {
                    long x = (long)nts[i], y = (long)nto[i];
                    list = new List<byte>();
                    started = false;
                    if (x == 0)
                    {
                        list.Add(0);
                    }

                    while (x > 0)
                    {
                        byte nx = (byte)(x % 128);
                        x /= 128;
                        if (started)
                        {
                            nx += 128;
                        }

                        started = true;
                        list.Add(nx);
                    }
                    list.Reverse();
                    for (int j = 0; j < list.Count; j++)
                    {
                        outs.WriteByte(list[j]);
                    }

                    started = false;
                    list.Clear();
                    if (y == 0)
                    {
                        list.Add(0);
                    }

                    while (y > 0)
                    {
                        byte ny = (byte)(y % 128);
                        y /= 128;
                        if (started)
                        {
                            ny += 128;
                        }

                        started = true;
                        list.Add(ny);
                    }
                    list.Reverse();
                    for (int j = 0; j < list.Count; j++)
                    {
                        outs.WriteByte(list[j]);
                    }
                }
                outs.Flush();
                outs.Close();
                Dispatcher.Invoke(new Action(() =>
                {
                    prog.SetResourceReference(ContentProperty, "m.Finished");
                    preview.Text = "";
                }));
                Dispatcher.Invoke(new Action(() =>
                {
                    filename.IsEnabled = true;
                    prog.IsEnabled = true;
                    Piliang.IsEnabled = true;
                    canc.IsEnabled = false;
                    width.IsEnabled = true;
                    height.IsEnabled = true;
                    fps.IsEnabled = true;
                    pres.IsEnabled = true;
                    des.IsEnabled = true;
                    is_preprocess.IsEnabled = true;
                }));
            }
            catch (ThreadAbortException)
            {
                Dispatcher.Invoke(new Action(() =>
                {
                    prog.SetResourceReference(ContentProperty, "m.Stopped");
                    preview.Text = "";
                    filename.IsEnabled = true;
                    prog.IsEnabled = true;
                    Piliang.IsEnabled = true;
                    canc.IsEnabled = false;
                    width.IsEnabled = true;
                    height.IsEnabled = true;
                    fps.IsEnabled = true;
                    pres.IsEnabled = true;
                    des.IsEnabled = true;
                    is_preprocess.IsEnabled = true;
                }));
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!");
                Dispatcher.Invoke(new Action(() =>
                {
                    prog.SetResourceReference(ContentProperty, "m.Failed");
                    preview.Text = "";
                    filename.IsEnabled = true;
                    prog.IsEnabled = true;
                    Piliang.IsEnabled = true;
                    canc.IsEnabled = false;
                    width.IsEnabled = true;
                    height.IsEnabled = true;
                    fps.IsEnabled = true;
                    pres.IsEnabled = true;
                    des.IsEnabled = true;
                    is_preprocess.IsEnabled = true;
                }));
            }
        }
    }
}
