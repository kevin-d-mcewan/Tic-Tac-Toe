using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {

        bool turn = true;// true = X turn; false = Y turn;
        int turn_count = 0; // increment this each time someone goes
        //static string player1, player2;

        public Form1 ()
        {
            InitializeComponent();
        
        }

        /*
        public static void setPlayerNames (String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }
        */
        private void aboutToolStripMenuItem_Click (object sender, EventArgs e)
        {
            MessageBox.Show("By Kevin", "Tic Tac Toe About");
        }

        private void exitToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click (object sender, EventArgs e)
        {
            Button b = (Button) sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner ()
        {
            bool there_is_a_winner = false;

            //horizontal checks
            if ((A1.Text.ToString() == A2.Text.ToString()) && (A2.Text.ToString() == A3.Text.ToString()) && (!A1.Enabled))
                there_is_a_winner = true;
            if ((B1.Text.ToString() == B2.Text.ToString())&&(B2.Text.ToString() == B3.Text.ToString())&&(!B1.Enabled))
                there_is_a_winner = true;
            if ((C1.Text.ToString() == C2.Text.ToString())&&(C2.Text.ToString() == C3.Text.ToString())&&(!C1.Enabled))
                there_is_a_winner = true;

            //vertical checks
            if ((A1.Text.ToString() == B1.Text.ToString()) && (B1.Text.ToString() == C1.Text.ToString()) &&(!A1.Enabled))
                there_is_a_winner = true;
            if ((A2.Text.ToString() == B2.Text.ToString())&&(B2.Text.ToString() == C2.Text.ToString())&&(!A2.Enabled))
                there_is_a_winner = true;
            if ((A3.Text.ToString() == B3.Text.ToString())&&(B3.Text.ToString() == C3.Text.ToString())&&(!A3.Enabled))
                there_is_a_winner = true;

            //diagonal checks
            if ((A1.Text.ToString() == B2.Text.ToString())&&(B2.Text.ToString() == C3.Text.ToString())&&(!A1.Enabled))
                there_is_a_winner = true;
            if ((A3.Text.ToString() == B2.Text.ToString()) && (B2.Text.ToString() == C1.Text.ToString()) && (!C1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();

                }
                MessageBox.Show(winner + " Wins!", "Yay!");
            } //end if
            else
            {
                if (turn_count == 9)
                {
                    
                    draw_count.Text = (Int32.Parse(draw_count.Text)+1).ToString();
                    MessageBox.Show("Draw", "Bummer!");
                    newGameToolStripMenuItem.PerformClick();
                }
            }

        } //end checkForWinner

        private void disableButtons ()
        {
           foreach(Control c in Controls)
           {
               try
               {
                   Button b = (Button)c;
                   b.Enabled = false;
               }
               catch{}
           
           } //foreach
        }//disableButton

        private void newGameToolStripMenuItem_Click (object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button) c;
                        b.Enabled = true;
                        b.Text = "";
                    }//end try
                    catch
                    {
                    }
                    //end catch
                }//end foreach
            

        }

        private void button_enter (object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                   b.Text = "X";
                else
                    b.Text = "O";
            }//end if
        }

        private void button_leave (object sender, EventArgs e)
        {
            Button b  = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }//end if
        }

        private void resetWinCountToolStripMenuItem_Click (object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void Form1_Load (object sender, EventArgs e)
        {/*
            Form f2 = new Form2();
            f2.ShowDialog();
            p1.Text = player1;
            p2.Text = player2; */
        }
    }
}
