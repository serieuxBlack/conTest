using System;
using System.Windows.Forms;
using ClientApp.Connection;

namespace ClientApp
{
    public partial class ChatForm : Form
    {
        private TcpClientHelper clientHelper;

        public ChatForm(TcpClientHelper client)
        {
            InitializeComponent();
            clientHelper = client;
            clientHelper.OnMessageReceived += ClientHelper_OnMessageReceived;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string message = textBoxInput.Text;
            clientHelper.Send(message);
            richTextBox1.AppendText("Me: " + message + "\n");
            textBoxInput.Clear();
        }

        private void ClientHelper_OnMessageReceived(object sender, TcpClientHelper.MessageEventArgs e)
        {
            Invoke(new Action(() =>
            {
                richTextBox1.AppendText("Server: " + e.Message + "\n");
            }));
        }
    }
}
