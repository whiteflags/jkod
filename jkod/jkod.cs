using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace jkod
{
    public partial class jkodForm : Form
    {
        public jkodForm()
        {
            InitializeComponent();
        }

        public void jkod_Load(object sender, EventArgs e)
        {
            cbxBaseList.SelectedIndex = 0;
            cbxColumnWidth.SelectedIndex = 1;
            cbxBytesPerLine.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string suggestedSaveFileName = openFileDialog1.FileName + "." + saveFileDialog1.DefaultExt;
                saveFileDialog1.FileName = suggestedSaveFileName;
                OpenFileOrDie();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OpenFileOrDie();
        }

        private void OpenFileOrDie()
        {
            try
            {
                string fileToDump = openFileDialog1.FileName;
                uint colWidth = Convert.ToUInt32(cbxColumnWidth.SelectedItem);
                uint bytesPerLine = Convert.ToUInt32(cbxBytesPerLine.SelectedItem);
                txtOutput.Text = Dumper.dump(fileToDump, cbxBaseList.SelectedIndex,
                    colWidth, bytesPerLine);
            }
            catch (IOException)
            {
                MessageBox.Show("The file may be too big, was corrupted, or could not be found!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have the necessary permissions to open this!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, txtOutput.Text);
                }

            }
            catch (IOException)
            {
                MessageBox.Show("The file could not be saved as directed!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have the necessary permissions to save here!");
            }
        }
    }
}
