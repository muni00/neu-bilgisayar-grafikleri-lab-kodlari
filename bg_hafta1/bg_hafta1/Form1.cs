namespace bg_hafta1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics grafikNesne;
            grafikNesne = this.CreateGraphics();
            Pen kalem = new Pen(Color.Blue, 4);
            grafikNesne.DrawRectangle(kalem, 20, 20, 100, 50);
        }
        Point baslangicXY;
        Point bitisXY;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            bitisXY = e.Location;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen kalem = new Pen(Color.Green, 4);
            e.Graphics.DrawLine(kalem, baslangicXY.X, baslangicXY.Y, bitisXY.X, bitisXY.Y);
            //e.Graphics.DrawLine(kalem,Math.Min(baslangicXY.Y, bitisXY.Y), Math.Max(baslangicXY.X, bitisXY.X));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            baslangicXY = e.Location;
            Invalidate();
        }
    }
}