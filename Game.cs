using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game : Form1
    {
        public Game(CustomButton[] buttonsGiven)
        {
            this.buttons = buttonsGiven;
            CustomButton[] newButtons = new CustomButton[buttonsGiven.Length];
            for (int i = 0; i < buttons.Length; i++)
            {
                newButtons[i] = buttonsGiven[i];
            }

            foreach (CustomButton currentButton in buttonsGiven)
            {
                int aliveN = countAlive(currentButton);
                bool isAlive = currentButton.isClicked();

                if (isAlive)
                {
                    if (aliveN < 2 || aliveN > 3)
                    {
                        newButtons[currentButton.getBNum()].kill(newButtons[currentButton.getBNum()]);
                    }
                }
                else
                {
                    if (aliveN == 3)
                    {
                        newButtons[currentButton.getBNum()].alive(newButtons[currentButton.getBNum()]);
                    }
                }

            }
            this.buttons = newButtons;

        }
        private int countAlive(CustomButton currentButton)
        {
            int count = 0;
            int row = currentButton.getRow();
            int col = currentButton.getCol();
            int currentB = currentButton.getBNum();
            int[] neighbors = { -33, -32, -31, -1, 1, 31, 32, 33 };
            foreach (int i in neighbors)
            {
                int neighbor = i + currentB;
                if (isValid(neighbor, row, col))
                {
                    if (buttons[neighbor].isClicked())
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private bool isValid(int neighbor, int row, int col)
        {
            int neighborRow = neighbor/32;
            int neighborCol = neighbor%32;
            if (neighborRow < 0 || neighborRow >= 32 || neighborCol < 0 || neighborCol >= 32)
            {
                return false;
            }
            return true;
        }
    }
}













/* 
 * More broken code :(
 *         CustomButton[] buttons;
        public Game(CustomButton[] buttonsGiven)
        {
            this.buttons = buttonsGiven;
                if (Form1.numAlive < 2)
                {
                   run = false;
                    return;
                }

            foreach (CustomButton button in buttons)
                {
                    if (Form1.numAlive < 2)
                    {
                        run = false;
                    }
                    bool isAlive = button.isClicked();
                    int aliveCount = countAlive(button);

                    if (isAlive)
                    {
                        if (aliveCount == 2)
                        {
                            continue;
                        }
                        else
                        {
                            button.kill(button);
                        }
                    }
                    else
                    {
                        if (aliveCount == 3)
                        {
                            button.alive(button);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
        }
        private int countAlive(CustomButton currentButton)
        {
            int count = 0;
            int iV = isValid(currentButton);
            int bNum = currentButton.getBNum();
            //special cases
            //row = 0
            if (iV == 1)
            {
                //0,0
                if (currentButton.getCol() == 0)
                {
                    if (buttons[bNum + 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 33].isClicked())
                    {
                        count++;
                    }
                }
                //0,31
                else if (currentButton.getCol() == 31)
                {
                    if (buttons[bNum - 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 32].isClicked())
                    {
                        count++;
                    }
                }
                //base cases
                else
                {
                    if (buttons[bNum - 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 33].isClicked())
                    {
                        count++;
                    }
                }
                return count;
            }

            // 0 col
            else if (iV == 2)
            {
                // 31 row 
                if (currentButton.getRow() == 31)
                {
                    if (buttons[bNum - 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 1].isClicked())
                    {
                        count++;
                    }
                }
                else
                {
                    if (buttons[bNum - 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 33].isClicked())
                    {
                        count++;
                    }
                }
                return count;
            }

            else if (iV == 3)
            {
                //31,31
                if (currentButton.getCol() == 31)
                {
                    if (buttons[bNum - 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 1].isClicked())
                    {
                        count++;
                    }
                }
                else
                {
                    if (buttons[bNum - 32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 33].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum - 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[bNum + 1].isClicked())
                    {
                        count++;
                    }
                }
                return count;

            }
            else if (iV == 4)
            {
                if (buttons[bNum - 32].isClicked())
                {
                    count++;
                }
                if (buttons[bNum - 33].isClicked())
                {
                    count++;
                }
                if (buttons[bNum - 1].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 32].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 31].isClicked())
                {
                    count++;
                }
                return count;
            }
            else
            {
                if (buttons[bNum - 32].isClicked())
                {
                    count++;
                }
                if (buttons[bNum - 33].isClicked())
                {
                    count++;
                }
                if (buttons[bNum - 31].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 32].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 31].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 33].isClicked())
                {
                    count++;
                }
                if (buttons[bNum - 1].isClicked())
                {
                    count++;
                }
                if (buttons[bNum + 1].isClicked())
                {
                    count++;
                }
                return count;
            }
        }

        private int isValid(CustomButton currentButton)
        {
            if (currentButton.getRow() == 0)
            {
                return 1;
            }
            else if (currentButton.getCol() == 0)
            {
                return 2;
            }
            else if (currentButton.getRow() == 31)
            {
                return 3;
            }
            else if (currentButton.getCol() == 31)
            {
                return 4;
            }
            else 
            {
                return 0;
            } 
        }
    }
}*/

//here lies my hope and my dreams : only about 8 hours of code thrown away. This is another reason why you should never hardcode.
/*
 * //SPECIAL CASES
            if (iV == 1)
            {
                //0,0 special case
                if (currentButton.getCol() == 0)
                {
                    if (buttons[1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[32].isClicked())
                    {
                        count++;
                    }
                    if (buttons[33].isClicked())
                    {
                        count++;
                    }
                    return count;
                }

                //0,31
                else if (currentButton.getCol() == 31)
                {
                    if (buttons[30].isClicked())
                    {
                        count++;
                    }
                    if (buttons[64].isClicked())
                    {
                        count++;
                    }
                    if (buttons[63].isClicked())
                    {
                        count++;
                    }
                    return count;
                }
                //in 0 row 
                else
                {
                    if (buttons[currentButton.getRow() * currentButton.getCol() + 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[currentButton.getRow() * currentButton.getCol() - 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[currentButton.getRow() + 1 * currentButton.getCol()].isClicked())
                    {
                        count++;
                    }
                    if (buttons[currentButton.getRow() + 1 * currentButton.getCol() + 1].isClicked())
                    {
                        count++;
                    }
                    if (buttons[currentButton.getRow() + 1 * currentButton.getCol() - 1].isClicked())
                    {
                        count++;
                    }
                    return count;
                }
            }
            // in 0 col
            else if (iV == 2)
            {
                if (buttons[currentButton.getRow() - 1 * currentButton.getCol()].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() - 1 * currentButton.getCol() + 1].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() * currentButton.getCol() + 1].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() + 1 * currentButton.getCol()].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() + 1 * currentButton.getCol() + 1].isClicked())
                {
                    count++;
                }
                return count;
            }

            //last row case
            else if (iV == 3)
            {
                //special special
                if (currentButton.getCol() == 31)
                {
                    if (buttons[30 * 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[30 * 30].isClicked())
                    {
                        count++;
                    }
                    if (buttons[31 * 30].isClicked())
                    {
                        count++;
                    }
                    return count;
                }
                //0,31 case
                else if (currentButton.getCol() == 0)
                {
                    if (buttons[31 * 31].isClicked())
                    {
                        count++;
                    }
                    if (buttons[30 * 30].isClicked())
                    {
                        count++;
                    }
                    if (buttons[31 * 30].isClicked())
                    {
                        count++;
                    }
                    return count;
                }
            }


            //LAST COL CASE
            else if (iV == 4)
            {
                if (buttons[currentButton.getRow() - 1 * currentButton.getCol()].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() - 1 * currentButton.getCol() - 1].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() * currentButton.getCol() - 1].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() + 1 * currentButton.getCol()].isClicked())
                {
                    count++;
                }
                if (buttons[currentButton.getRow() + 1 * currentButton.getCol() - 1].isClicked())
                {
                    count++;
                }
                return count;
            }
        }
int i = 0;
int lifeVariable = 0;
while (Form1.numAlive > 2)
{
    foreach (CustomButton button in buttons)
    {
        if(Form1.numAlive < 3)
            { break; }

        if (i < 33)
        {
            if (i == 32)
            {
                if (buttons[i - 32].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i - 31].isClicked() == true)
                {
                    lifeVariable++;
                }
            }
            if (i == 0)
            {
                if (buttons[i + 1].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i + 31].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i + 32].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i + 33].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (lifeVariable < 2 || lifeVariable >= 4)
                {
                    if (button.isClicked())
                    {
                        button.kill(button);
                    }
                }
                else if (lifeVariable == 3 && button.isClicked() == true)
                {
                    button.kill(button);
                }
                else if (button.isClicked() == false && lifeVariable == 3)
                {
                    button.alive(button);
                }
                i++;
                lifeVariable = 0;
                continue;
            }
            if (buttons[i - 1].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i + 1].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i + 31].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i + 32].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i + 33].isClicked() == true)
            {
                lifeVariable++;
            }
            if (lifeVariable < 2 || lifeVariable >= 4)
            {
                if (button.isClicked())
                {
                    button.kill(button);
                }
            }
            else if (lifeVariable == 3 && button.isClicked() == true)
            {
                button.kill(button);
            }
            else if (button.isClicked() == false && lifeVariable == 3)
            {
                button.alive(button);
            }
            i++;
            lifeVariable = 0;
            continue;
        }

        else if (i >= 991)
        {
            if (i == 1025)
            {
                if (buttons[i - 33].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i - 32].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (buttons[i - 31].isClicked() == true)
                {
                    lifeVariable++;
                }
                if (lifeVariable < 2 || lifeVariable >= 4)
                {
                    if (button.isClicked())
                    {
                        button.kill(button);
                    }
                }
                else if (lifeVariable == 3 && button.isClicked() == true)
                {
                    button.kill(button);
                }
                else if (button.isClicked() == false && lifeVariable == 3)
                {
                    button.alive(button);
                }
                lifeVariable = 0;
                i = 0;
                break;
            }
            if (buttons[i - 33].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i - 32].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i - 31].isClicked() == true)
            {
                lifeVariable++;
            }
            if (buttons[i - 1].isClicked() == true)
            {
                lifeVariable++;
            }
            if (lifeVariable < 2 || lifeVariable >= 4)
            {
                if (button.isClicked())
                {
                    button.kill(button);
                }
            }
            else if (lifeVariable == 3 && button.isClicked() == true)
            {
                button.kill(button);
            }
            else if (button.isClicked() == false && lifeVariable == 3)
            {
                button.alive(button);
            }
            i++;
            lifeVariable = 0;
            continue;
        }

        if (buttons[i - 33].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i - 32].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i - 31].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i - 1].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i + 1].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i + 31].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i + 32].isClicked() == true)
        {
            lifeVariable++;
        }
        if (buttons[i + 33].isClicked() == true)
        {
            lifeVariable++;
        }
        if (lifeVariable < 2 || lifeVariable >= 4)
        {
            if (button.isClicked())
            {
                button.kill(button);
            }
        }
        else if (lifeVariable == 3 && button.isClicked() == true)
        {
            button.kill(button);
        }
        else if (button.isClicked() == false && lifeVariable == 3)
        {
            button.alive(button);
        }
        i++;
        lifeVariable = 0;
    }
}
Form1.numAlive = 0;
*/
