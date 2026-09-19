namespace es1_bubble
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int size = 10, i = 0;
        Color set_color = Color.Red;
        Graphics g;
        Color colorRandom()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MouseWheel += Form1_MouseWheel;
            label1.Text = "size = " + size.ToString();
        }



        private void Form1_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                size += 5;
            }
            else
            {
                size -= 5;
            }
            label1.Text = "size = " + size.ToString();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();

            if (e.Button == MouseButtons.Left)
            {
                g.FillEllipse(new SolidBrush(set_color), e.X, e.Y, size, size);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (checkBox1.Checked)
                    checkBox1.Checked = false;
                if (checkBox2.Checked == false && checkBox3.Checked == false && checkBox1.Checked == false)
                {
                    checkBox2.Checked = true;
                }
                g.FillEllipse(new SolidBrush(set_color), e.X, e.Y, size, size);
                if (checkBox2.Checked == true)
                {
                    set_color = Color.FromArgb
                (
                    Math.Clamp(set_color.R - 5, 0, 255),
                    Math.Clamp(set_color.G - 5, 0, 255),
                    Math.Clamp(set_color.B - 5, 0, 255)
                );
                }
                if (checkBox3.Checked == true)
                {
                    set_color = Color.FromArgb
                (
                    Math.Clamp(set_color.R + 5, 0, 255),
                    Math.Clamp(set_color.G + 5, 0, 255),
                    Math.Clamp(set_color.B + 5, 0, 255)
                );
                }

                pictureBox1.BackColor = set_color;
            }
            i++;
            label1.Text = i.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            set_color = colorDialog1.Color;
            pictureBox1.BackColor = set_color;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                set_color = colorRandom();
                pictureBox1.BackColor = set_color;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
            }
        }

    }
}