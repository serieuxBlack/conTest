using System;
using System.Drawing.Text;
using System.Windows.Forms;
using ClientApp.Connection; // Ensure this using directive is added to access TcpClientHelper

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        private TcpClientHelper clientHelper;

        public ClientForm()
        {
            InitializeComponent();
            clientHelper = new TcpClientHelper("54.147.41.5", 8848);
            clientHelper.OnMessageReceived += ClientHelper_OnMsgIn;
        }

        private void ackButton_Click(object sender, EventArgs e)
        {
            try
            {
                clientHelper.Connect();
                clientHelper.Send("ACK");
                clientHelper.StartReceiving();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection Failed: {ex.Message}");
            }
        }

        private void ClientHelper_OnMsgIn(object sender, TcpClientHelper.MessageEventArgs e)
        {
            if (e.Message == "ACK RECEIVED")
            {
                Invoke(new Action(() =>
                {
                    ackButton.Enabled = false;
                    OpenChatForm();
                }));
            }
            else
            {
                MessageBox.Show("Server: " + e.Message);
            }
        }

        private void OpenChatForm()
        {
            ChatForm chatForm = new ChatForm(clientHelper);
            chatForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            clientHelper?.Close();
        }
    }
}

