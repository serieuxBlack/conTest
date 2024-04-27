using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ServerApp.Connection;
using ServerApp.Helper;
using ServerApp.Handle_Packet;
using ServerApp.Forms;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private FormDOS formDOS;
        private TcpServer server;
        private bool trans;
        public static List<AsyncTask> getTasks = new List<AsyncTask>();
        private ListViewColumnSorter lvwColumnSorter;
        private Button btnStartChat;

        public ServerForm()
        {
            InitializeComponent();

            // Start the TCP server
            server = new TcpServer(this, 8848); // The port number should match your setup
            server.ClientConnected += OnClientConnected;
            server.Start();
            //init Division of Signal form
            this.Opacity = 100;
            formDOS = new FormDOS
            {
                Name = "DOS",
                Text = "DOS",
            };
            InitializeChatButton();
        }

        private void InitializeChatButton()
        {
            btnStartChat = new Button();
            btnStartChat.Text = "Start Chat";
            btnStartChat.Enabled = false; // Start as disabled
            btnStartChat.Location = new System.Drawing.Point(10, 50); // Set appropriate location
            btnStartChat.Size = new System.Drawing.Size(100, 50);
            btnStartChat.Click += BtnStartChat_Click;
            this.Controls.Add(btnStartChat);
        }
        private void BtnStartChat_Click(object sender, EventArgs e)
        {
            // You can instantiate and show the chat form here
            FormChat chatForm = new FormChat();
            chatForm.Show();
        }

        private void OnClientConnected(object sender, EventArgs e)
        {
            UpdateStatusLabel("Server ready to connect");
        }
        public void EnableChatButton()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => btnStartChat.Enabled = true));
            }
            else
            {
                btnStartChat.Enabled = true;
            }
        }

        // Public method to update the status label
        public void UpdateStatusLabel(string text)
        {
            // Check if invoke is required for thread safety
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => statusLabel.Text = text));
            }
            else
            {
                statusLabel.Text = text;
            }
        }

        // Optionally, override the OnFormClosing method to stop the server when the form is closed
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (server != null)
            {
                server.Stop();
            }
        }
    }
}
