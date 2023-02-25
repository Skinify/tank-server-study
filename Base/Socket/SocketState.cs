using System.Net.Sockets;
using System.Text;

namespace Base.GameSocket
{
    public class SocketState : IDisposable
    {
        public Socket? Socket = null;
        public byte[] Buffer = new byte[8192];
        public StringBuilder ReceivedData = new StringBuilder(8192);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    if (Socket != null)
                    {
                        try
                        {
                            Socket.Shutdown(SocketShutdown.Both);
                        }
                        catch (Exception)
                        {
                        }
                        Socket.Close();
                        Socket.Dispose();
                        Socket = null;
                    }
                }

                GC.Collect();
            }
            catch (Exception)
            {
            }
        }

        public string? ReadBufferDataAsString()
        {
            var t = ReadBufferDataAsByteArray();
            if (t is null)
                return null;

            return Encoding.UTF8.GetString(t);
        }
        public byte[]? ReadBufferDataAsByteArray()
        {
            bool fin = (Buffer[0] & 0b10000000) != 0,
                    mask = (Buffer[1] & 0b10000000) != 0; // must be true, "All messages from the client to the server have this bit set"
            int opcode = Buffer[0] & 0b00001111, // expecting 1 - text message

                offset = 2;
            ulong msglen = (ulong)(Buffer[1] & 0b01111111);

            if (msglen == 126)
            {
                // bytes are reversed because websocket will print them in Big-Endian, whereas
                // BitConverter will want them arranged in little-endian on windows
                msglen = BitConverter.ToUInt16(new byte[] { Buffer[3], Buffer[2] }, 0);
                offset = 4;
            }
            else if (msglen == 127)
            {
                // To test the below code, we need to manually buffer larger messages — since the NIC's autobuffering
                // may be too latency-friendly for this code to run (that is, we may have only some of the bytes in this
                // websocket frame available through client.Available).
                msglen = BitConverter.ToUInt64(new byte[] { Buffer[9], Buffer[8], Buffer[7], Buffer[6], Buffer[5], Buffer[4], Buffer[3], Buffer[2] }, 0);
                offset = 10;
            }

            if (msglen == 0)
            {
                Console.WriteLine("msglen == 0");
            }
            else if (mask)
            {
                byte[] decoded = new byte[msglen];
                byte[] masks = new byte[4] { Buffer[offset], Buffer[offset + 1], Buffer[offset + 2], Buffer[offset + 3] };
                offset += 4;

                for (ulong i = 0; i < msglen; ++i)
                    decoded[i] = (byte)(Buffer[(ulong)offset + i] ^ masks[i % 4]);

                return decoded;
            }
            else
                Console.Write("Mask byt not set");


            return null;
        }

        public void Clear()
        {
            Array.Clear(Buffer, 0, Buffer.Length);
            ReceivedData.Clear();
        }

        ~SocketState()
        {
            Dispose(false);
        }
    }
}
