using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessMusic
{
    public partial class fMain : Form
    {
        fSettings fs = new fSettings();
        fGame fg = new fGame();
        public fMain()
        {
            InitializeComponent();
        }

        

        private void Settings_Click(object sender, EventArgs e)
        {
            fs.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            fg.ShowDialog();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Quiz.ReadOptions();
            Quiz.ReadMusic();
        }
    }
}
