using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace jkod
{
    public partial class jkod : Form
    {
        public jkod()
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
                OpenFileOrDie();
            }
        }

        private void OpenFileOrDie()
        {
            string fileToDump = openFileDialog1.FileName;
            uint colWidth = Convert.ToUInt32(cbxColumnWidth.SelectedItem);
            uint bytesPerLine = Convert.ToUInt32(cbxBytesPerLine.SelectedItem);
            txtOutput.Text = Dumper.dump(fileToDump, cbxBaseList.SelectedIndex,
                colWidth, bytesPerLine);
        }
    }
}
