namespace GameOfLife
{
    public partial class Form1 : Form
    {
        public int[] list;
        public int[] dead;
        public bool flag = false;
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
                    var button = new Button();
                    button.Click += bClick;
                    button.Tag = k;
                    button.Margin = new Padding(0);
                    button.Name = string.Format("button_{0}{1}", i, j);
                    this.tableLayoutPanel1.Controls.Add(button, j, i);
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

        void bClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int i = 0;
            if (clickedButton != null)
            {
                int buttonNumber = (int)clickedButton.Tag;
                textBox1.Text = buttonNumber.ToString();
                clickedButton.BackColor = Color.Yellow;
                list[i] = buttonNumber;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                Game game = new Game(list);
            }
            
        }

    }
}