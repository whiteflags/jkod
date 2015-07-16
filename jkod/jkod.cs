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
            cbxSizeSuffix.SelectedIndex = 0;
        }

        /* Button should prompt the user for a file and display it with the current output options. */
        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                OpenFileOrDie();
            }
        }

        /* Button should reopen the file with the new output options. */
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OpenFileOrDie();
        }

        /* OpenFileOrDie:
         * Helper function that actually opens the file and dumps it, or handles an IO exception
         * before returning.
         */
        private void OpenFileOrDie()
        {
            try
            {
                Dumper d = new Dumper();
                string fileToDump = openFileDialog1.FileName;
                d.ColumnWidth = Convert.ToInt32(cbxColumnWidth.Text);
                d.IsVerbose = !chkVerbose.Checked;
                d.BytesPerLine = Convert.ToUInt32(cbxBytesPerLine.Text);
                int value = cbxBaseList.SelectedIndex;

                if (d.BytesPerLine % d.ColumnWidth != 0)
                    throw new AddressSizeException();

                if (value == 0)
                    d.BaseSelected = Dumper.BaseOption.OCTAL;
                else if (value == 1)
                    d.BaseSelected = Dumper.BaseOption.HEXA;
                else
                    d.BaseSelected = Dumper.BaseOption.DECIMAL;

                int offset = txtSkip.Text.Length > 0? Convert.ToInt32(txtSkip.Text) : 0;
                switch(cbxSizeSuffix.SelectedIndex)
                {
                    case 2:
                        offset *= 1024 * 1024;
                        break;
                    case 1:
                        offset *= 1024;
                        break;
                    case 0:
                    default:
                        break;
                }

                txtOutput.Text = d.dump(fileToDump, offset);
            }
            catch (IOException)
            {
                MessageBox.Show("The file may be too big, was corrupted, or could not be found!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have the necessary permissions to open this!");
            }
            catch (AddressSizeException ex)
            {
                MessageBox.Show(ex.Message);
                cbxColumnWidth.Focus();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a whole number only.");
                cbxColumnWidth.Focus();
            }
        }

        /* Button should write a dump file, or handle an exception before returning. 
         * The default file name is the name of the file opened, plus ".dump"
         */
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] path = openFileDialog1.FileName.Split('\\');
                string suggestedSaveFileName = path[path.Length - 1] + "." + saveFileDialog1.DefaultExt;
                saveFileDialog1.FileName = suggestedSaveFileName;

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
