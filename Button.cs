using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CustomButton : Button
    {
        int row;
        int col;
        bool clicked = false;
        int bNum;
        public CustomButton(int bNum) 
        { 
            this.bNum = bNum;
            clicked = false;
            this.Click += new EventHandler(bClick);
        }

        public void bClick(object sender, EventArgs e)
        {
            CustomButton clickedButton = sender as CustomButton;

            if (clicked == true)
            {
                clickedButton.clicked = false;
                clickedButton.BackColor = default(Color);
                Form1.numAlive--;
            }
            else if (clickedButton != null)
            {
                clickedButton.clicked = true;
                int buttonNumber = (int)clickedButton.Tag;
                clickedButton.BackColor = Color.Yellow;
                Form1.numAlive = Form1.numAlive + 1;
            }
        }
        public void kill(CustomButton button)
        {
            button.BackColor = Color.AliceBlue;
            button.clicked = false;
            Form1.numAlive -= 1;
        }
        public void alive(CustomButton button)
        {
            button.BackColor = Color.Yellow;
            button.clicked = true;
            Form1.numAlive += 1;
        }
        public bool isClicked()
        {
            return clicked;
        }

        public void setRowCol(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public int getRow() { return row; }
        public int getCol() { return col; }

        public int getBNum() { return bNum;}

    }
}
