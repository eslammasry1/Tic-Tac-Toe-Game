using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            // لما الفورم التاني يتقفل، اقفل الأول (وبالتالي البرنامج كله)
            frm.FormClosed += (s, args) => this.Close();

            frm.Show();   // نفتح الفورم التاني
            this.Hide();  // نخفي الفورم الحال
        }
    }
}
