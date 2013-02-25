using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Distancing_Algorithm;


namespace Distancing_Algorithm.Code
{
    

    public class ComPort 
    {
        SerialPort sp;

        public ComPort() :this("COM4")
        {
            
        }

        public ComPort(string Port)
        {
            sp = new SerialPort(Port, 115200, Parity.None, 8, StopBits.One);  // COM1 :LAB   COM5: LAPATOP
            sp.ReadTimeout = 1000;
        }
        public void SendCommand(byte ID ,byte[] payload)
        {
            int FrameLength = payload.Count() + 2;
            List<byte> Command = new List<byte>();
            Command.Add(ID);
            Command.Add((byte)FrameLength);
            Command.AddRange(payload);
            sp.Write(Command.ToArray(), 0, Command.Count());

        }

        public void SendCommand(byte ID, byte payload)
        {
            byte[] array = new byte[1];
            array[0] = payload;
            SendCommand(ID, array);

        }

        public void WaitInventoryPacket()
        {
            while (sp.BytesToRead < 22)
            { }
        }

        public byte[] ReadPacket()
        {
            byte[] start = new byte[2];
            byte[] payload;
            int Startread;
            int PayloadRead;
            try
            {
                
                while (sp.BytesToRead <  2)
                { }
                Startread = sp.Read(start, 0, 2);
                System.Threading.Thread.Sleep(Program.SleepTimer);
                payload = new byte[start[1]-2];
                if (sp.BytesToRead >= payload.Length)
                {
                    PayloadRead = sp.Read(payload, 0, payload.Length);
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("{0}",e); 
                throw e;
            }
            IEnumerable<byte> rv = start.Concat(payload);
            if (!Helpers.CheckPacket(rv.ToArray()))
                throw new Exception("Recieved Packet is Malformed!");
            return rv.ToArray();
        }
        public void Open()
        {
            sp.Open();
        }
        public void Close()
        {
            sp.Close();
        }
    }
}
