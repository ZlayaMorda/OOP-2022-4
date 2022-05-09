
namespace Paint
{
    public partial class Form1 : Form, IPaint
    {
        Presenter presenter;

        public Form1()
        {
            InitializeComponent();
            presenter = new(this);
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
                return buttonLineColor.BackColor;
            }
        }
        Color IPaint.BrushColor
        {
            get
            {
                return buttonBrushColor.BackColor;
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
            if(presenter.Model.IsClicked)
            {
                presenter.Move(e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            presenter.Paint(e.Graphics);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (presenter.Model.IsClicked)
            {
                presenter.Click(e.X, e.Y);
                pictureBox1.Invalidate();
            }
            else
            {
                presenter.ReloadView(this);
                presenter.Click(e.X, e.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            presenter.DoubleClick();
        }

        private void Before_Click(object sender, EventArgs e)
        {
            presenter.Before();
            pictureBox1.Invalidate();
        }

        private void After_Click(object sender, EventArgs e)
        {
            presenter.After();
            pictureBox1.Invalidate();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            presenter.Save();
            pictureBox1.Invalidate();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            presenter.Load();
            pictureBox1.Invalidate();
        }
    }
}