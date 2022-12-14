using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinballGame
{
    public partial class FormPinball : Form
    {
        public FormPinball()
        {
            InitializeComponent();
        }


        //Our pinball machine has 6 pockets.
        //We would like to know how many balls end up in each pocket
        //after a large number of trials.
        //
        //              |
        //              V
        //------------------------- Level 1
        //              *
        //------------------------- Level 2
        //            *   *
        //------------------------- Level 3
        //          *   *   *
        //------------------------- Level 4
        //        *   *   *   *
        //------------------------- Level 5
        //      *   *   *   *   *
        //------------------------- Level 6
        //    *   *   *   *   *   *
        //| 1 | 2 | 3 | 4 | 5 | 6 | 7 |

        //At every level the ball has only 2 possibilities,
        //to fall on right on left.
        //We start at pos 4 since it's right in the middle and
        //at every level we add or deduct 0.5;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            int[] frequency = new int[8];
            Initialize(frequency, 7);
            Simulate(frequency);
            Display(frequency);
            
        }

        private void Initialize(int[] f, int u)
        {
            for (int i = 1; i <= u; i++)
            {
                f[i] = 0;
            }
        }

        private void Simulate(int[] f)
        {
            Random r = new Random();

            double move;

            for (int i = 1; i <= 1000; i++)
            {
                move = 4.0;
                for (int j = 1; j <= 6; j++)
                {
                    int temp = r.Next(1, 3);
                    if (temp == 1)
                    {
                        move += 0.5;
                    }
                    else
                    {
                        move -= 0.5;
                    }
                }

                int c = (int)move;
                f[c] += 1;
            }
        }

        private void Display(int[] f)
        {
            for (int i = 1; i <= 7; i++)
            {
                TxtResult.Text += "Pocket " + i + " frequency " + f[i] + Environment.NewLine;
            }
        }
    }
}
