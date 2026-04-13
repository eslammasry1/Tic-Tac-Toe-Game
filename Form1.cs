using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {

        stGameStatus GameStatus;
        enPlayer playerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }
        public Form1()
        {
            InitializeComponent();
        }

        public bool ChackValues(PictureBox PB1, PictureBox PB2, PictureBox PB3)
        {
            if (PB1.Tag.ToString()!="?" && PB1.Tag.ToString() == PB2.Tag.ToString() 
                && PB1.Tag.ToString() == PB3.Tag.ToString())
            {
                PB1.BackColor = Color.GreenYellow;
                PB2.BackColor = Color.GreenYellow;
                PB3.BackColor = Color.GreenYellow;
                if (PB1.Tag.ToString()=="X" )
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }
            GameStatus.GameOver = false;
            return false;
        }
        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner) 
            {
                case enWinner.Player1:
                    lblTurn.Text = "Player1";
                    break;
                case enWinner.Player2:
                    lblTurn.Text = "Player2";
                    break;
                default:
                    lblTurn.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        public void ChangeImage (PictureBox PB)
        {
            if (PB.Tag.ToString() == "?")
            {
                switch(playerTurn)
                {
                    case enPlayer.Player1:
                        PB.Image = Properties.Resources.X;
                        playerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        PB.Tag = "X";
                        Victory();
                        break;
                    case enPlayer.Player2:
                        PB.Image = Properties.Resources.O;
                        playerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        PB.Tag = "O";
                        Victory();
                        break;

                }
            }
            else

            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }

        }
        // فوز O
        void Victory()
        {
            // الصف الأول
            if(ChackValues(pB_OX1, pB_OX2, pB_OX3))
                { return; }

            // الصف الثاني
            if(ChackValues(pB_OX4, pB_OX5, pB_OX6))
                { return; }

            // الصف الثالث
            if(ChackValues(pB_OX7, pB_OX8, pB_OX9))
                { return; }

            // العمود الأول
            if(ChackValues(pB_OX1, pB_OX4, pB_OX7))
                { return; }

            // العمود الثاني
            if(ChackValues(pB_OX2, pB_OX5, pB_OX8))
                { return; }

            // العمود الثالث
            if (ChackValues(pB_OX3, pB_OX6, pB_OX9))
                { return; }

            // القطر الأول
            if(ChackValues(pB_OX1, pB_OX5, pB_OX9))
                { return; }

            // القطر الثاني
            if (ChackValues(pB_OX3, pB_OX5, pB_OX7))
                { return; }
        }
        bool X = true;

        bool Click1 = true;
        private void pB_OX1_Click(object sender, EventArgs e)
        {
            ChangeImage(pB_OX1);
        }


        private void pB_OX2_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX2);
        }

        private void pB_OX3_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX3);
        }


        private void pB_OX4_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX4);
        }


        private void pB_OX5_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX5);
        }


        private void pB_OX6_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX6);
        }

        bool Click7 = true;

        private void pB_OX7_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX7);
        }

        bool Click8 = true;

        private void pB_OX8_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX8);
        }
        bool Click9 = true;

        private void pB_OX9_Click_1(object sender, EventArgs e)
        {
            ChangeImage(pB_OX9);
        }
        private void RestButton(PictureBox PB)
        {
            PB.Image = Resources.question_mark_96;
            PB.Tag = "?";
            PB.BackColor = Color.Transparent;

        }

        void Restart()
        {
            RestButton(pB_OX9);
            RestButton(pB_OX1);
            RestButton(pB_OX2);
            RestButton(pB_OX3);
            RestButton(pB_OX4);
            RestButton(pB_OX5);
            RestButton(pB_OX6);
            RestButton(pB_OX7);
            RestButton(pB_OX8);

            playerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
