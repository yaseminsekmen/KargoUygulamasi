using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using kKargo.ORM.Entity;
using kKargo.ORM.Facade;

namespace KargoUygulamasi
{
    public partial class Su : Form
    {
        public Su()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Subeler.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sube ekle = new Sube();
            ekle.SubeAdi = textBox1.Text;
            ekle.SubeIl = textBox2.Text;
            ekle.SubeIlce = textBox3.Text;
            ekle.TeslimDurumu = textBox4.Text;
            if (!Subeler.Ekle(ekle))
                MessageBox.Show("Veriler Eklenmedi....");
            dataGridView1.DataSource = Subeler.Listele();
        }

        private void Su_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sube sil = new Sube();
            sil.SubeID = (int)textBox1.Tag;
            if (!Subeler.Sil(sil))
                MessageBox.Show("Veri Silinemedi..");
            dataGridView1.DataSource = Subeler.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["SubeAdi"].Value.ToString();
            textBox1.Tag = satir.Cells["SubeID"].Value;
            textBox2.Text = satir.Cells["SubeIl"].Value.ToString();
            textBox3.Text = satir.Cells["SubeIlce"].Value.ToString();
            textBox4.Text = satir.Cells["TeslimDurumu"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sube yenile = new Sube();
            yenile.SubeID = (int)textBox1.Tag;
            yenile.SubeAdi = textBox1.Text;
            yenile.SubeIl = textBox2.Text;
            yenile.SubeIlce = textBox3.Text;
            yenile.TeslimDurumu = textBox4.Text;
            if (!Subeler.Yenile(yenile))
                MessageBox.Show("Veriler Güncellenemedi....");
            dataGridView1.DataSource = Subeler.Listele();
        }
    }
}
