using GenerativeAI.Methods;
using GenerativeAI.Models;
using GenerativeAI.Types;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class ChatBot : Form
    {
        ChatSession chatSession;
        public string apiKey = "AIzaSyCm9xUKKvHnV3zdcQrwroELZIc6HF4ZizY"; //https://aistudio.google.com/ 
        public ChatBot()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            var message = txtMessage.Text.Trim();
            await SendMessageAsync(message);

        }

        private async Task SendMessageAsync(string message)
        {
            if (btnSend.Text != "Send") return;

            if (message.Length > 0)
            {
                txtMessage.Text = "";
                btnSend.Text = "Waiting...";

                txtBody.SelectionAlignment = HorizontalAlignment.Right;
                txtBody.SelectionColor = Color.Blue;
                txtBody.AppendText($"Me: {message}\n");

                txtBody.SelectionAlignment = HorizontalAlignment.Left;
                txtBody.SelectionColor = Color.Red;
                var result = await chatSession.SendMessageAsync(message);
                txtBody.AppendText($"Gemini AI: {result}\n");

                txtBody.SelectionAlignment = HorizontalAlignment.Right;
                txtBody.SelectionColor = txtBody.ForeColor;

                btnSend.Text = "Send";
                txtBody.ScrollToCaret();
            }
        }

        private void ChatBot_Load(object sender, EventArgs e)
        {
            var model = new GenerativeModel(apiKey);
            chatSession = model.StartChat(new StartChatParams());

        }

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var message = txtMessage.Text.Trim();
                await SendMessageAsync(message);
            }
        }
    }
}
