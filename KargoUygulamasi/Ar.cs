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
    public partial class Ar : Form
    {
        public Ar()
        {
            InitializeComponent();
        }

        private void Ar_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Araclar.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arac ekle = new Arac();
            ekle.AracTuru = comboBox1.SelectedItem.ToString();
            ekle.AracKapasitesi = Convert.ToInt32(textBox1.Text);
            ekle.AracSoforu = textBox2.Text;
            if (!Araclar.Ekle(ekle))
                MessageBox.Show("Veriler Eklenmedi....");
            dataGridView1.DataSource = Araclar.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["AracTuru"].Value.ToString();
            textBox2.Tag = satir.Cells["AracID"].Value;
            textBox1.Text = satir.Cells["AracKapasitesi"].Value.ToString();
            textBox2.Text = satir.Cells["AracSoforu"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Arac sil = new Arac();
            sil.AracID = (int)textBox2.Tag;
            if (!Araclar.Sil(sil))
                MessageBox.Show("Veri Silinemedi..");
            dataGridView1.DataSource = Araclar.Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arac yenile = new Arac();
            yenile.AracID = (int)textBox2.Tag;
            yenile.AracTuru = comboBox1.SelectedItem.ToString();
            yenile.AracKapasitesi = Convert.ToInt32(textBox1.Text);
            yenile.AracSoforu = textBox2.Text;
            if (!Araclar.Yenile(yenile))
                MessageBox.Show("Veriler Güncellenemedi....");
            dataGridView1.DataSource = Araclar.Listele();
        }
    }
}
