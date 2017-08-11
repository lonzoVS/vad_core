using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using vad_core.Models;
namespace vad_core.WaveProcessor
{
    public class Signal
    {

        public WavModel WavModel { get; private set; } = new WavModel();
        public void ReadWAVE(string filename)
        {

            int i = 0;
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                char[] riff = br.ReadChars(4);
                if (riff[0] != 'R')
                {
                    throw new FormatException("not riff");
                }
                br.ReadInt32();
                riff = br.ReadChars(4);
                if (riff[0] != 'W')
                {
                    throw new FormatException("not wave");
                }
                riff = br.ReadChars(4);
                if (riff[0] != 'f')
                {
                    throw new FormatException("not fmt");
                }
                br.ReadInt32();
                WavModel.type = br.ReadInt16();
                WavModel.channels = br.ReadInt16();
                WavModel.freq = br.ReadInt32();
                WavModel.bytes = br.ReadInt32();
                WavModel.aling = br.ReadInt16();
                WavModel.bits = br.ReadInt16();
                riff = br.ReadChars(4);
                if (riff[0] != 'd')
                {
                    throw new FormatException("not data");
                }
                WavModel.len_data = br.ReadInt32();

                if (WavModel.channels == 2)
                {
                    WavModel.len_data /= 2;
                }
                if (WavModel.bits == 16)
                {
                    WavModel.len_data /= 2;
                }
                WavModel.samples = new double[WavModel.len_data];
                WavModel.samples2 = new double[WavModel.len_data];
                if (WavModel.bits == 8)
                {
                    byte d8 = 0;
                    for (i = 0; i < WavModel.len_data; i++)
                    {
                        d8 = br.ReadByte();
                        WavModel.samples[i] = (double)(d8 - 128);
                    }
                }
                else
                {
                    short d16 = 0;
                    for (i = 0; i < WavModel.len_data; i++)
                    {
                        d16 = br.ReadInt16();
                        WavModel.samples[i] = d16;
                    }
                    if (WavModel.channels == 2)
                    {
                        for (i = 0; i < WavModel.len_data; i++)
                        {
                            d16 = br.ReadInt16();
                            WavModel.samples2[i] = d16;
                        }
                    }
                }
                br.Dispose();
                fs.Dispose();
            }
            catch (FormatException)
            {
                //MessageBox.Show("Ошибка чтения заголовков файла", "",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {

            }

        }
    }
}
