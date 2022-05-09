using System.Drawing;
using System.Windows.Forms;
using Paint.mvp;

namespace Paint
{
    public partial class Form1 : Form, IPaint
    {
        Presenter presenter;

        public Form1()
        {
            presenter = new(this);
            // BrokenLine brokenLine = new();
            //FiguresDict.Add("Line", brokenLine);
            //FiguresDict.Add("Line", rectangle);
            //FiguresDict.Add("Line", ellipse);
            InitializeComponent();
        }

        string IPaint.Name
        { 
            get
            {
                if(comboBox1.SelectedItem != null)
                {
                    return comboBox1.SelectedItem.ToString();
                }
                else { return "Line"; }
                    
            }
        }
        Color IPaint.LineColor
        {
            get
            {
                return buttonLineColor.BackColor = colorDialog1.Color;
            }
        }
        Color IPaint.BrushColor
        {
            get
            {
                return buttonBrushColor.BackColor = colorDialog1.Color;
            }
        }
        float IPaint.Width
        {
            get
            {
                return trackBarWidth.Value;
            }
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            buttonLineColor.BackColor = colorDialog1.Color;
        }

        private void buttonBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            buttonBrushColor.BackColor = colorDialog1.Color;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            presenter.Click(e.X, e.Y);
        }
    }
}