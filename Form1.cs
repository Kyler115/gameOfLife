namespace GameOfLife
{
    public partial class Form1 : Form
    {
        public CustomButton[] buttons = new CustomButton[1024];
        public bool flag = false;
        public static int numAlive = 0;
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < 32)
            {
                while (j < 32)
                {
                    var button = new CustomButton(k);
                    button.setRowCol(j, i);
                    button.Tag = k;
                    button.Margin = new Padding(0);
                    button.Name = string.Format("button_{0}{1}", i, j);
                    this.tableLayoutPanel1.Controls.Add(button, j, i);
                    buttons[k] = button;
                    button.Text = k.ToString();
                    j++;
                    k++;
                }
                j = 0;
                i++;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(buttons);
        }

    }
}