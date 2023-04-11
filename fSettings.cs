using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace GuessMusic
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void SetOptions()
        {
            Subfolders.Checked = Quiz.AllDirectories;
            InfoResponseTime.Text = Quiz.MusicDuration.ToString();
            InfoGameDuration.Text = Quiz.GameDuration.ToString();
            RandomStart.Checked = Quiz.RandomStart;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Quiz.AllDirectories = Subfolders.Checked;
            Quiz.MusicDuration = Convert.ToInt32(InfoResponseTime.Text);
            Quiz.GameDuration = Convert.ToInt32(InfoGameDuration.Text);
            Quiz.RandomStart = RandomStart.Checked;
            Quiz.WriteOptions();
            this.Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetOptions();
            this.Hide();
        }

        private void Select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string[] music_list = Directory.GetFiles(fbd.SelectedPath, "*.mp3", Subfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                Quiz.LastFolder = fbd.SelectedPath;
                listBox.Items.Clear();
                listBox.Items.AddRange(music_list);
                Quiz.QuizList.Clear();
                Quiz.QuizList.AddRange(music_list);

            }
        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            SetOptions();
            listBox.Items.Clear();
            listBox.Items.AddRange(Quiz.QuizList.ToArray());
        }
    }
}
