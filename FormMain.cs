using EncryptDoc;
using EncryptingText;

namespace CybersecurityTest;

public partial class FormMain : Form
{
    private readonly Label labelTitle = new();
    private readonly TextBox textBoxFolder = new();
    private readonly Button buttonSearch = new();
    private readonly Button buttonEncrypt = new();
    private readonly Button buttonDecrypt = new();
    private readonly TextBox textBoxText = new();
    private readonly Label labelText = new();
    private readonly Button buttonEncrypt2 = new();
    private readonly Button buttonDecrypt2 = new();
    private readonly Label labelDeveloper = new();

    public FormMain()
    {
        SuspendLayout();
        Text = "Cybersecurity Test";
        ClientSize = new Size(400, 300);
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedToolWindow;

        labelTitle.Location = new Point(10, 5);
        labelTitle.Name = "labelTitle";
        labelTitle.Text = "Search Folder:";
        labelTitle.ForeColor = Color.Black;
        Controls.Add(labelTitle);

        textBoxFolder.Location = new Point(10, 30);
        textBoxFolder.Size = new Size(380, 40);
        textBoxFolder.Name = "textBoxFolder";
        textBoxFolder.Text = string.Empty;
        textBoxFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        Controls.Add(textBoxFolder);

        buttonSearch.Text = "Search";
        buttonSearch.Name = "buttonSearch";
        buttonSearch.Size = new Size(110, 40);
        buttonSearch.Location = new Point(10, 65);
        buttonSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonSearch.Click += ButtonSearch_Click;
        Controls.Add(buttonSearch);

        buttonEncrypt.Text = "Encrypt";
        buttonEncrypt.Name = "buttonEncrypt";
        buttonEncrypt.Size = new Size(110, 40);
        buttonEncrypt.Location = new Point(120, 65);
        buttonEncrypt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonEncrypt.Click += ButtonEncrypt_Click;
        Controls.Add(buttonEncrypt);

        buttonDecrypt.Text = "Decrypt";
        buttonDecrypt.Name = "buttonDecrypt";
        buttonDecrypt.Size = new Size(110, 40);
        buttonDecrypt.Location = new Point(230, 65);
        buttonDecrypt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonDecrypt.Click += ButtonDecrypt_Click;
        Controls.Add(buttonDecrypt);

        labelText.Name = "labelText";
        labelText.Text = "Text to encrypt:";
        labelText.Location = new Point(10, 120);
        Controls.Add(labelText);

        textBoxText.Location = new Point(10, 140);
        textBoxText.Size = new Size(380, 40);
        textBoxText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        textBoxText.Name = "textBoxText";
        Controls.Add(textBoxText);

        buttonEncrypt2.Text = "Encrypt";
        buttonEncrypt2.Name = "buttonEncrypt2";
        buttonEncrypt2.Location = new Point(10, 180);
        buttonEncrypt2.Size = new Size(110, 40);
        buttonEncrypt2.Click += ButtonEncrypt2_Click;
        Controls.Add(buttonEncrypt2);

        buttonDecrypt2.Text = "Decrypt";
        buttonDecrypt2.Name = "buttonDecrypt2";
        buttonDecrypt2.Location = new Point(120, 180);
        buttonDecrypt2.Size = new Size(110, 40);
        buttonDecrypt2.Click += ButtonDecrypt2_Click;
        Controls.Add(buttonDecrypt2);

        labelDeveloper.Name = "labelDeveloper";
        labelDeveloper.Text = "Created by Roberto David Morales Ramos";
        labelDeveloper.AutoSize = true;
        labelDeveloper.Location = new Point(10, 250);
        Controls.Add(labelDeveloper);

        ResumeLayout();
        PerformLayout();
    }

    private void ButtonSearch_Click(object? sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new();
        DialogResult result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            textBoxFolder.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void ButtonEncrypt_Click(object? sender, EventArgs e)
    {
        try
        {
            if (Directory.Exists(textBoxFolder.Text))
            {
                string[] files = Directory.GetFiles(textBoxFolder.Text);

                foreach (var file in files)
                {
                    Encrypt.EncryptFile(file, file + ".encrypted", "cybersecurity");
                    File.Delete(file);
                }
            }
        }
        catch (Exception Exception)
        {
            MessageBox.Show(Exception.Message);
        }
    }

    private void ButtonDecrypt_Click(object? sender, EventArgs e)
    {
        try
        {
            if (Directory.Exists(textBoxFolder.Text))
            {
                string[] files = Directory.GetFiles(textBoxFolder.Text);
                foreach (var file in files)
                {
                    string fileWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    Encrypt.DecryptFile(file, Path.Combine(textBoxFolder.Text, fileWithoutExtension), "cybersecurity");
                    File.Delete(file);
                }
            }
        }
        catch (Exception Exception)
        {
            MessageBox.Show(Exception.Message);
        }
    }
    private void ButtonEncrypt2_Click(object? sender, EventArgs e)
    {
        textBoxText.Text = Encripty.Encrypt(textBoxText.Text);
    }

    private void ButtonDecrypt2_Click(object? sender, EventArgs e)
    {
        textBoxText.Text = Encripty.Decrypt(textBoxText.Text);
    }
}