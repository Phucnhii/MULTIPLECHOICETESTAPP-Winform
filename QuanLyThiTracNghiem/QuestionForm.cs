using iText.IO.Codec;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem
{
    public partial class QuestionForm : Form
    {
        private const string ApiKey = ""; // Replace with your actual API key

        private const string ChatGptApiUrl = "https://api.openai.com/v1/chat/completions"; // Updated endpoint for GPT-3.5-turbo

        public QuestionForm()
        {
            InitializeComponent();
        }

        private async void btnGenerateSummary_Click(object sender, EventArgs e)
        {
            string inputText = "Hãy tóm tắt đoạn văn sau" + richTextBoxInput.Text.Trim();
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Please enter some text to summarize.");
                return;
            }

            string summary = await GenerateSummary(inputText);
            if (!string.IsNullOrEmpty(summary))
            {
                richTextBoxSummary.Text = summary;

            }
            else
            {
                MessageBox.Show("Failed to generate summary.");
            }
        }

        private async Task<string> GenerateSummary(string inputText)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Set Authorization header
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKey);

                    // Prepare request data
                    var requestData = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                    new { role = "user", content = inputText }
                },
                        max_tokens = 200  // Adjust max_tokens as needed for longer passages
                    };

                    var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                    // Send HTTP POST request
                    var response = await client.PostAsync(ChatGptApiUrl, content);
                    response.EnsureSuccessStatusCode();

                    // Process response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);
                    string summary = responseObject.choices[0].message.content;

                    return summary;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tóm tắt văn bản: {ex.Message}");
            }

            return null;
        }





        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                // Define the file path where the PDF will be saved
                string filePath = @"D:\summary.pdf";

                // Load the Arial Unicode font from a TTF file
                string fontPath = @"C:\Windows\Fonts\Arial.ttf"; // Change to the correct path of your Arial.ttf
                BaseFont bfArial = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bfArial, 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font contentFont = new iTextSharp.text.Font(bfArial, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font closingFont = new iTextSharp.text.Font(bfArial, 12, iTextSharp.text.Font.ITALIC);


                // Create the PDF document
                using (Document doc = new Document())
                {
                    // Create a writer instance to write the document to the specified file path
                    PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Open the document for writing
                    doc.Open();

                    // Add the title to the document
                    Paragraph title = new Paragraph("TÓM TẮT CỦA BẠN", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20 // Space after the title
                    };
                    doc.Add(title);

                    // Add the content from the richTextBoxSummary to the PDF document
                    Paragraph content = new Paragraph(richTextBoxSummary.Text, contentFont)
                    {
                        SpacingAfter = 20 // Space after the content
                    };
                    doc.Add(content);

                    // Add the closing line to the document
                    Paragraph closing = new Paragraph("Cảm ơn bạn đã sử dụng ứng dụng thi trắc nghiệm của chúng tôi", closingFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(closing);
                }
                MessageBox.Show("PDF file đã được tạo thành công và lưu vào ổ D!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating PDF: {ex.Message}");
            }
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nguoidung nd = new Nguoidung();
            this.Hide();
            nd.ShowDialog();
            this.Close();
        }
    }
}
