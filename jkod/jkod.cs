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
                int colWidth = Convert.ToInt32(cbxColumnWidth.SelectedItem);
                string output = Dumper.dump(openFileDialog1.FileName, cbxBaseList.SelectedIndex, colWidth);
                txtOutput.Text = output;
            }
        }
    }
}
