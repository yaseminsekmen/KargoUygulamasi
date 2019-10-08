using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KargoUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void araçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ar git = new Ar();
            git.Show();
            this.Hide();
        }

        private void sevkiyatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sevk git = new Sevk();
            git.Show();
            this.Hide();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mus git = new Mus();
            git.Show();
            this.Hide();
        }

        private void şubelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Su git = new Su();
            git.Show();
            this.Hide();
        }
    }
}
