using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientApp.Connection
{
    public class TcpClientHelper
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private string server;
        private int port;

        public TcpClientHelper(string server, int port)
        {
            this.server = server;
            this.port = port;
            tcpClient = new TcpClient();
        }

        public bool IsConnected => tcpClient?.Client != null && tcpClient.Client.Connected;

        public void Connect()
        {
            if (!IsConnected)
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(server, port);
                stream = tcpClient.GetStream();
            }
        }

        public void StartReceiving()
        {
            if (!IsConnected)
                throw new InvalidOperationException("Not connected to server.");

            ThreadPool.QueueUserWorkItem(callback =>
            {
                while (IsConnected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;  // Server has disconnected

                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    // Raise an event or callback here to process received message
                    OnMessageReceived?.Invoke(this, new MessageEventArgs { Message = message });
                }
            });
        }

        public event EventHandler<MessageEventArgs> OnMessageReceived;

        public class MessageEventArgs : EventArgs
        {
            public string Message { get; set; }
        }

        public void Send(string message)
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Not Connected to Server.");
            }
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public void Close()
        {
            stream?.Close();
            tcpClient?.Close();
        }
    }
}
