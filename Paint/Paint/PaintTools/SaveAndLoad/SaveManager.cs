using System.Windows.Forms;

namespace WindowsFormsApplication1.PaintTools.SaveAndLoad
{
    class SaveManager
    {
        public void SavePictureToBmpFile(PictureBox pictureBox)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image|*.bmp";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();
                pictureBox.Image.Save(fs,System.Drawing.Imaging.ImageFormat.Bmp);
                fs.Close();
            }
        }
    }
}
