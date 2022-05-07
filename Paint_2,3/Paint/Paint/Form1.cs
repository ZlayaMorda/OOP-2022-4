using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            buttonLineColor.BackColor = colorDialog1.Color;
            //model.pen = new Pen(button1.BackColor);
            //model.pen.Width = trackBar1.Value;
        }

        private void buttonBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            buttonBrushColor.BackColor = colorDialog1.Color;
        }

        private bool IsMouseUp = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseUp = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseUp = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}