using System;
using System.IO;
using System.Windows.Forms;

namespace Task8
{
    public partial class Form1 : Form
    {
        private string[] imageFiles; // Array to hold image file paths
        private int currentIndex = 0; // To keep track of the current image

        public Form1()
        {
            InitializeComponent();
        }

        // Browse folder button click event
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            // Open Folder Browser dialog to select folder
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get all image files in the selected folder
                    string folderPath = folderDialog.SelectedPath;
                    imageFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                    // Filter to only image files
                    imageFiles = Array.FindAll(imageFiles, file => file.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                                                                  file.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase));

                    if (imageFiles.Length > 0)
                    {
                        currentIndex = 0; // Reset to the first image
                        ShowImage();
                    }
                    else
                    {
                        MessageBox.Show("No images found in the selected folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Show image in PictureBox
        private void ShowImage()
        {
            if (imageFiles.Length > 0 && currentIndex >= 0 && currentIndex < imageFiles.Length)
            {
                // Load the image into PictureBox
                pictureBoxPreview.ImageLocation = imageFiles[currentIndex];
                labelImageIndex.Text = $"{currentIndex + 1} / {imageFiles.Length}";
            }
        }

        // Previous button click event
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                ShowImage();
            }
        }

        // Next button click event
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < imageFiles.Length - 1)
            {
                currentIndex++;
                ShowImage();
            }
        }
    }
}
